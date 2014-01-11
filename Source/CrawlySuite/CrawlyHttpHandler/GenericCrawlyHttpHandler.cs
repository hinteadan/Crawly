using System.Collections.Specialized;
using H.Crawly.Common;
using H.Crawly.Content;

namespace H.Crawly
{
    public class GenericCrawlyHttpHandler<T> : CrawlyHttpHandler where T : IPopulateCrawlyTemplate, new()
    {
        private readonly T populateTemplate = new T();

        public override CrawlyContentProcessor Populate(CrawlyContentProcessor processor, NameValueCollection queryString)
        {
            foreach (var p in populateTemplate.For(queryString).WithThese())
            {
                processor.Populate(p.Key, p.Value);
            }

            return base.Populate(processor, queryString);
        }
    }
}
