using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleSearchAPI.Query
{
    /// <summary>
    /// Describes a Google search, search results.
    /// </summary>
    public interface IGoogleResultSet<ResultType> where ResultType : IGoogleResult
    {
        /// <summary>
        /// The list of the Google Search results.
        /// </summary>
        IList<ResultType> Results { get; set; }

        /// <summary>
        /// Provides details about the amount of results, pages and which start indexes are valid to query.
        /// </summary>
        ICursor Cursor { get; set; }

        /// <summary>
        /// Additional details about the search. TODO: Find out what is this exactly.
        /// </summary>
        string ResponseDetails { get; set; }
        /// <summary>
        /// Response status. In here we will know if the search succeeded or failed.
        /// 200 on success. non-200 on failure.
        /// </summary>
        int Status { get; set; }
    }
}
