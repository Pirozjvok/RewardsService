using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RewardsService.DataBase;
using RewardsService.DTO.Read;
using RewardsService.DTO.Read.Forms;
using RewardsService.DTO.Write;
using RewardsService.DTO.Write.Forms;
using RewardsService.Models;
using RewardsService.Models.Forms;
using System.Reflection;
using System.Text.Json;

namespace RewardsService.Controllers
{
    [Route("api/[controller].[action]")]
    [ApiController]
    public class RewardsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        private readonly IMapper _mapper;
        public RewardsController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ReadForm), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateReward createReward)
        {
            if (createReward == null)
                return BadRequest(Error.CreateSingleError("Неправильный запрос", Enums.ErrorCode.BadRequest));

            RewardModel reward = _mapper.Map<RewardModel>(createReward);

            if (!await _context.Forms.AnyAsync(x => x.Id == reward.FormId))
                return Ok(Error.CreateSingleError("Данная форма не существует", Enums.ErrorCode.NotFound));

            await _context.Rewards.AddAsync(reward);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ReadRewards), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            List<RewardModel> rewards = await _context.Rewards.Include(x => x.Form).ToListAsync();
            List<ReadReward> result = rewards.Select(x => MapReward(x)!).Where(x => x != null).ToList();
            return Ok(new ReadRewards(result));
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadReward), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            RewardModel? model = await _context.Rewards.Include(x => x.Form).FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
                return Ok(Error.CreateSingleError("Данной награды не существует", Enums.ErrorCode.NotFound));

            ReadReward? reward = MapReward(model);
            if (reward == null)
                return Ok(Error.CreateSingleError("Ошибка на стороне сервера", Enums.ErrorCode.UnknownError));

            return Ok(reward);
        }

        private ReadReward? MapReward(RewardModel rewardModel)
        {
            FormEntity formEntity = rewardModel.Form!;
            Form? form = JsonSerializer.Deserialize<Form>(formEntity.Configuration);
            if (form == null)
                return null;
            ReadForm readDTO = _mapper.Map<ReadForm>(form);
            readDTO.Id = formEntity.Id;
            ReadReward rewardRead = _mapper.Map<ReadReward>(rewardModel);
            rewardRead.Form = readDTO;
            return rewardRead;
        }
    }
}
