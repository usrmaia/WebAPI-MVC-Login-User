using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using API.Models.ErrorMessage;

namespace API.Filters
{
    public class ValidateModelStateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (!context.ModelState.IsValid) 
            {
                var error = new ValidField(context.ModelState.SelectMany(selector => selector.Value.Errors).Select(selector => selector.ErrorMessage));
                context.Result = new BadRequestObjectResult(error);
            }
        }
    }
}