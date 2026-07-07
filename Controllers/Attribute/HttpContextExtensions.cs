using System;
using Microsoft.AspNetCore.Http;

namespace BackOffice.Controllers.Attribute
{
    public static class HttpContextExtensions
    {
        public static Guid GetClientId(this HttpContext context)
        {
            return context.Items.TryGetValue("ClientId", out var id) ? (Guid)id! : Guid.Empty;
        }
    }
}
