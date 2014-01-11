using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H.Crawly.Common;
using H.Crawly.Content;

namespace H.Crawly
{
    public class GenericCrawlyHttpHandler<T> : CrawlyHttpHandler where T : IPopulateCrawlyTemplate
    {

    }
}
