using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using RewardsService.DTO.Read;
using RewardsService.Enums;

namespace RewardsService.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new OkObjectResult(new Error(context.ModelState.Values
                      .SelectMany(v => v.Errors)
                      .Select(e => new ErrorInfo() { Code = ErrorCode.ValidationError, Message = e.ErrorMessage })));
            }
        }
    }
}
