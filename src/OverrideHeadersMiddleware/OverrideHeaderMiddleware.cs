using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

namespace OverrideHeadersMiddleware
{
    public class HeaderOverrideMiddleware
    {
        OverrideHeaderMiddlewareOptions options;
        public HeaderOverrideMiddleware(RequestDelegate next, OverrideHeaderMiddlewareOptions overrideMiddlewareOptions)
        {
            options = overrideMiddlewareOptions;
        }

        /*
         Write rules for the different headers
         Read the value for the different header keys we are looking for, 
         then override those values in the request with the values in header   
            X-Forwarded-For
            X-Forwarded-Host
            X-Forwarded-Proto
            X-Http-Method-Override    
        */
        public Task Invoke(HttpContext context)
        {

            var xForward = context.Request.Headers.Get("X-Forward-For");
            if (options.XForwardForEnabled && xForward != null)
            {
                context.Response.WriteAsync("Found X-Forward-For\n");
                var originalIPAddress = xForward[0];
            }

            var xForwardHost = context.Request.Headers.Get("X-Forwarded-Host");
            if (options.XForwardHostEnabled && xForwardHost != null)
            {
                context.Response.WriteAsync("Found X-Forwarded-Host\n");
                context.Request.Host = new HostString(xForwardHost.ToString());
            }

            var xForwardProto = context.Request.Headers.Get("X-Forwarded-Proto");
            if (options.XForwardProtoEnabled && xForwardProto != null)
            {
                context.Response.WriteAsync("Found X-Forwarded-Proto\n");
                context.Request.Protocol = xForwardProto;
            }

            var xMethodOverride = context.Request.Headers.Get("X-Http-Method-Override");
            if (options.XHttpMethodOverrideEnabled && xMethodOverride != null)
            {
                context.Response.WriteAsync("Found X-Http-Method-Override\n");
                context.Request.Method = context.Request.Headers.Get("X-Http-Method-Override");
            }

            return context.Response.WriteAsync(context.Request.Headers.ToString());
        }
    }
}
