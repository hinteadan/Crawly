using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H.Crawly.Common
{
    public interface IPopulateCrawlyTemplate
    {
        Dictionary<string, string> WithThese();
    }
}
