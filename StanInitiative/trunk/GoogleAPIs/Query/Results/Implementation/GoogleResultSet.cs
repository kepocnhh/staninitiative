using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace GoogleSearchAPI.Query
{
    /// <summary>
    /// A Google Result Set supplied by the Google AJAX API.
    /// </summary>
    public class GoogleResultSet<ResultType> : IGoogleResultSet<ResultType> where ResultType : IGoogleResult
    {
        #region Ctor
        public GoogleResultSet()
        {

        }        
        #endregion

        #region IGoogleResultSet Members

        /// <summary>
        /// The list of the Google Search results.
        /// </summary>
        /// <value></value>
        public IList<ResultType> Results
        {
            get;
            set;
        }

        /// <summary>
        /// Provides details about the amount of results, pages and which start indexes are valid to query.
        /// </summary>
        /// <value></value>
        public ICursor Cursor
        {
            get;
            set;
        }

        /// <summary>
        /// Additional details about the search. TODO: Find out what is this exactly.
        /// </summary>
        /// <value></value>
        public string ResponseDetails
        {
            get;
            set;
        }

        /// <summary>
        /// Response status. In here we will know if the search succeeded or failed.
        /// 200 on success. non-200 on failure.
        /// </summary>
        /// <value></value>
        public int Status
        {
            get;
            set;
        }

        #endregion
    }
}
