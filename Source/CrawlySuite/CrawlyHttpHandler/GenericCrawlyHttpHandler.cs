using H.Crawly.Common;
using H.Crawly.Content;

namespace H.Crawly
{
    public class GenericCrawlyHttpHandler<T> : CrawlyHttpHandler where T : IPopulateCrawlyTemplate, new()
    {
        private readonly T populateTemplate = new T();

        public override CrawlyContentProcessor Populate(CrawlyContentProcessor processor)
        {
            foreach (var p in populateTemplate.WithThese())
            {
                processor.Populate(p.Key, p.Value);
            }

            return base.Populate(processor);
        }
    }
}
