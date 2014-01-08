using H.Crawly.Content;
using System.Linq;
using System.Web;

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

        public void ProcessRequest(HttpContext context)
        {
            if (IsCrawlRequest(context))
            {
                context.Response.ClearContent();
                context.Response.Write(new CrawlyContentProcessor(context.Request.Url).Populate("test", "ASAD").GetContent());
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
