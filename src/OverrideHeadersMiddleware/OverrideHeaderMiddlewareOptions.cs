using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OverrideHeadersMiddleware
{
    public class OverrideHeaderMiddlewareOptions
    {
        public bool XForwardForEnabled { get; set; }
        public bool XForwardHostEnabled { get; set; }

        public bool XForwardProtoEnabled { get; set; }
        public bool XHttpMethodOverrideEnabled { get; set; }

        public OverrideHeaderMiddlewareOptions(bool AllOverridesEnabled = true)
        {
            XForwardForEnabled = AllOverridesEnabled;
            XForwardHostEnabled = AllOverridesEnabled;
            XForwardProtoEnabled = AllOverridesEnabled;
            XHttpMethodOverrideEnabled = AllOverridesEnabled;
        }
    }
}
