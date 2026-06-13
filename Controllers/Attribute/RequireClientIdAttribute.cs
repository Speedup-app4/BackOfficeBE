using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BackOffice.Controllers.Attribute
{
    public class RequireClientIdAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;

            if (
                !request.Headers.TryGetValue("ClientId", out var storeIdRaw)
                || !Guid.TryParse(storeIdRaw, out var storeId)
            )
            {
                context.Result = new BadRequestObjectResult(
                    new { message = "Header 'ClientId' is required and must be a Guid." }
                );
                return;
            }

            context.HttpContext.Items["ClientId"] = storeId;
            base.OnActionExecuting(context);
        }
    }
}
