﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NZwalks.API.CustomActionFilters
{
    public class VaildateModelAttribute :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.ModelState.IsValid == false)
            {
               context.Result = new BadRequestResult();
            }
        }
    }
}
