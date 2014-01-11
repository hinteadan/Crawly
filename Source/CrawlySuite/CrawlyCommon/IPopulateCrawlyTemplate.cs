using System.Collections.Generic;

namespace H.Crawly.Common
{
    public interface IPopulateCrawlyTemplate
    {
        Dictionary<string, string> WithThese();
    }
}
