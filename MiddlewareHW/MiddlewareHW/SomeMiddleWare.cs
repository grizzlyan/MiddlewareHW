using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareHW
{
    public class SomeMiddleWare
    {
        private readonly RequestDelegate _next;


        public SomeMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
            var extraHeaderAttribute = endpoint?.Metadata.GetMetadata<ExtraHeaderAttribute>();

            if (extraHeaderAttribute != null)
            {
                context.Response.Headers.Add(extraHeaderAttribute.Key, extraHeaderAttribute.Value);
            } 
        }
    }

    public static class SomeMiddleWareExtensions
    {
        public static IApplicationBuilder UseSomeMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SomeMiddleWare>();
        }
    }
}
