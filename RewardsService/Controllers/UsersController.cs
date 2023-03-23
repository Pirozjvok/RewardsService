using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RewardsService.Auth;
using RewardsService.DataBase;
using RewardsService.DTO.Read;
using RewardsService.DTO.Write;
using RewardsService.DTO.Write.Forms;
using RewardsService.Enums;
using RewardsService.Models;

namespace RewardsService.Controllers
{
    [Route("api/[controller].[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseContext _context;

        private readonly IMapper _mapper;

        private readonly JwtTokenHelper _tokenHelper;
        public UsersController(DatabaseContext context, IMapper mapper, JwtTokenHelper tokenHelper)
        {
            _context = context;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ReadUserProfile),StatusCodes.Status200OK)]
        public async Task<IActionResult> Profile(int id)
        {
            UserProfile? profile = await _context.Profiles.FirstOrDefaultAsync(x => x.Id ==  id);
            if (profile == null)
                return NotFound();

            ReadUserProfile read = new ReadUserProfile(profile.Id, profile.Name, profile.AvatarUrl);
            return Ok(read);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserRegister userRegister)
        {
            UserProfile userProfile = new UserProfile()
            {
                Email = userRegister.Email,
                Name = userRegister.Name,
                Password = BCrypt.Net.BCrypt.HashPassword(userRegister.Password)
        };

            await _context.Profiles.AddAsync(userProfile);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Produces(typeof(AuthModel))]
        public async Task<IActionResult> Auth([FromBody] AuthData data)
        {
            string login = data.Login;
            string password = data.Password;
            var user = await _context.Profiles.FirstOrDefaultAsync(user => user.Email == login);
            if (user is null)
            {
                return Unauthorized(Error.CreateSingleError("Incorrect password.", ErrorCode.IncorrectPassword));
            }
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return Unauthorized(Error.CreateSingleError("Incorrect password.", ErrorCode.IncorrectPassword));
            }

            ReadUserProfile readUser = new ReadUserProfile(user.Id, user.Name, user.AvatarUrl);
            AuthModel am = new AuthModel()
            {
                Token = _tokenHelper.CreateTokenInfo(user.Id).Token,
                User = readUser
            };

            return Ok(am);
        }
    }
}
