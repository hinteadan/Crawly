using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using H.Crawly.Common;

namespace H.Crawly.Web.Playground
{
    public class CustomTemplateDataSource : IPopulateCrawlyTemplate
    {
        public Dictionary<string, string> WithThese()
        {
            return new Dictionary<string, string> { 
                { "title", "Custom title from CustomTemplateDataSource" },
                { "content", "Custom content from CustomTemplateDataSource" }
            };
        }
    }
}