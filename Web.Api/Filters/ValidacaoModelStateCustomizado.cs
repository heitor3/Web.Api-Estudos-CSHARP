using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using Web.Api.Models;

namespace Web.Api.Filters
{
    public class ValidacaoModelStateCustomizado : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var validaCampoViewModel = new ValidaCampoViewOutPut(context.ModelState
                    .SelectMany(sm => sm.Value.Errors)
                    .Select(s => s.ErrorMessage));

                context.Result = new BadRequestObjectResult(validaCampoViewModel);
            }
            
        }
    }
}
