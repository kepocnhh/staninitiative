using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleSearchAPI.Query
{
    public interface IQueryParameter
    {
        string Key { get; }
        string GetValueAsString();
        string GetQueryParameter();
    }
}