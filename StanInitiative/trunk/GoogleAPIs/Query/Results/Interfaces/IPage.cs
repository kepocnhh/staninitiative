using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleSearchAPI.Query
{
    public interface IPage
    {
        int Start { get; set; }
        string Label { get; set; }
    }
}
