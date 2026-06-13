using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BackOffice.Controllers.Attribute
{
    public class HeaderSwagger : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var hasClientIdAttribute = context
                .MethodInfo.DeclaringType!.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .Any(a => a is RequireClientIdAttribute);

            var hasStoreIdAttribute = context
                .MethodInfo.DeclaringType!.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .Any(a => a is RequireStoreIdAttribute);

            if (hasClientIdAttribute)
            {
                operation.Parameters ??= [];

                operation.Parameters.Add(
                    new OpenApiParameter
                    {
                        Name = "ClientId",
                        In = ParameterLocation.Header,
                        Required = true,

                        Schema = new OpenApiSchema
                        {
                            Type = "string",
                            Default = new OpenApiString("11111111-1111-1111-1111-111111111111"),
                        },
                    }
                );
            }

            if (hasStoreIdAttribute)
            {
                operation.Parameters ??= [];

                operation.Parameters.Add(
                    new OpenApiParameter
                    {
                        Name = "StoreId",
                        In = ParameterLocation.Header,
                        Required = true,

                        Schema = new OpenApiSchema
                        {
                            Type = "string",
                            Default = new OpenApiString("22222222-2222-2222-2222-222222222222"),
                        },
                    }
                );
            }
        }
    }
}
