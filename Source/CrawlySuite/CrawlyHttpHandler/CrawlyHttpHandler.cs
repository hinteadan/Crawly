using System.Collections.Specialized;
using System.Linq;
using System.Web;
using H.Crawly.Content;

namespace H.Crawly
{
    public class CrawlyHttpHandler : IHttpHandler
    {
        private const string crawlIndicatorKey = "_escaped_fragment_";

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        public virtual CrawlyContentProcessor Populate(CrawlyContentProcessor processor, NameValueCollection queryString)
        {
            return processor;
        }

        public virtual CrawlyContentProcessor Populate(CrawlyContentProcessor processor)
        {
            return Populate(processor);
        }

        public void ProcessRequest(HttpContext context)
        {
            if (IsCrawlRequest(context))
            {
                context.Response.ClearContent();
                context.Response.Write(this.Populate(new CrawlyContentProcessor(context.Request.Url, context.Server.MapPath("")), context.Request.QueryString).GetContent());
                context.Response.Flush();
                return;
            }

            context.Response.ClearContent();
            context.Response.TransmitFile(context.Server.MapPath(context.Request.Url.LocalPath));
        }

        private static bool IsCrawlRequest(HttpContext context)
        {
            return context.Request.QueryString.AllKeys.Contains(crawlIndicatorKey);
        }
    }
}
