using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleSearchAPI.Query
{
    public interface ICursor
    {
        IList<IPage> Pages { get; set; }
        int EstimatedResultCount { get; set; }
        int CurrentPageIndex { get; set; }
        string MoreResultsURL { get; set; }
    }
}
