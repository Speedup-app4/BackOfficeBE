using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BackOffice.Controllers.Attribute
{
    public class RequireStoreIdAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;

            if (
                !request.Headers.TryGetValue("StoreId", out var storeIdRaw)
                || !Guid.TryParse(storeIdRaw, out var storeId)
            )
            {
                context.Result = new BadRequestObjectResult(
                    new { message = "Header 'StoreId' is required and must be a Guid." }
                );
                return;
            }

            context.HttpContext.Items["StoreId"] = storeId;
            base.OnActionExecuting(context);
        }
    }
}
