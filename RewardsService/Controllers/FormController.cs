using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RewardsService.DataBase;
using RewardsService.DTO.Forms;
using RewardsService.DTO.Read;
using RewardsService.DTO.Read.Forms;
using RewardsService.DTO.Write.Forms;
using RewardsService.Enums;
using RewardsService.Filters;
using RewardsService.Models;
using RewardsService.Models.Forms;
using System.Text.Json;

namespace RewardsService.Controllers
{
    [Route("api/[controller].[action]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly DatabaseContext _context;

        private readonly IMapper _mapper;
        public FormController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ReadForm), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody]CreateForm createForm)
        {
            if (createForm == null)
                return BadRequest(Error.CreateSingleError("Неправильный запрос", Enums.ErrorCode.BadRequest));
            Form form = _mapper.Map<Form>(createForm);
            string config = JsonSerializer.Serialize(form);
            FormEntity formEntity = new FormEntity(1, config);
            await _context.Forms.AddAsync(formEntity);
            await _context.SaveChangesAsync();
            ReadForm readForm = _mapper.Map<ReadForm>(form);
            readForm.Id = formEntity.Id;
            return Ok(readForm);
        }

        [HttpPost]
        public async Task<IActionResult> Check([FromBody] SendForm sendedForm)
        {
            FormEntity? formEntity = await _context.Forms.FirstOrDefaultAsync(x => x.Id == sendedForm.FormId);
            if (formEntity == null)
                return Ok(Error.CreateSingleError("Данной формы не существует", Enums.ErrorCode.NotFound));

            Form? form = JsonSerializer.Deserialize<Form>(formEntity.Configuration);

            if (form == null)
                return Ok(Error.CreateSingleError("Неизвестная ошибка", Enums.ErrorCode.UnknownError));

            if (form.Criterias == null)
                return Ok(new CheckResult() { Result = true });

            Dictionary<int, FormField> fields = form.Fields.ToDictionary(x => x.FieldId);
            Dictionary<int, FieldValue> values = sendedForm.Fields.ToDictionary(x => x.FieldId);

            bool result = false;
            string? message = null;
            foreach (CriteriasCollection item in form.Criterias)
            {
                bool group_result = true;
                foreach (CriteriaDTO criteria in item.Criterias)
                {
                    FormField field = fields[criteria.FieldId];
                    FieldValue value = values[criteria.FieldId];
                    bool check_result = CheckField(criteria, field, value);
                    if (!check_result)
                    {
                        group_result = false;
                        break;
                    }
                }
                if (group_result)
                {
                    message = item.MessageOnSuccess;
                    result = true;
                    break;
                } 
                else
                {
                    message = item.MessageOnError;
                }
            }

            return Ok(new CheckResult() { Result = result, Message = message });
        }

        private bool CheckField(CriteriaDTO criteria, FormField field, FieldValue value)
        {
            try
            {
                switch (field.FieldType)
                {
                    case FieldType.None:
                        break;
                    case FieldType.Text:
                        break;
                    case FieldType.Radio:
                        if (criteria.RequiredValue == value.Value)
                            return true;
                        else 
                            return false;
                    case FieldType.Switch:
                        if (criteria.RequiredValue == value.Value)
                            return true;
                        else
                            return false;
                    case FieldType.Number:
                        break;
                    default:
                        return false;
                }
            }
            catch
            {
                return false;
            }
            return false;

        }
    }
}
