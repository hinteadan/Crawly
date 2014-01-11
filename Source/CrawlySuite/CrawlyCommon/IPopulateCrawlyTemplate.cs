using System.Collections.Generic;
using System.Collections.Specialized;

namespace H.Crawly.Common
{
    public interface IPopulateCrawlyTemplate
    {
        IPopulateCrawlyTemplate For(NameValueCollection queryString);

        Dictionary<string, string> WithThese();
    }
}
