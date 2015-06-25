using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;

namespace OverrideHeadersMiddleware
{
    public static class HeaderOverrideExtensions
    {
        public static IApplicationBuilder UseOverrideHeaders(this IApplicationBuilder builder, OverrideHeaderMiddlewareOptions options)
        {
            return builder.Use(next => new HeaderOverrideMiddleware(next, options).Invoke);
        }
    }
}
