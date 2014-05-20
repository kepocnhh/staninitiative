using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace GoogleSearchAPI.Query
{
    [JsonObject]
    public class Cursor : ICursor
    {
        #region ICursor Members

        [JsonIgnore]
        public IList<IPage> Pages
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the estimated result count.
        /// </summary>
        /// <value>The estimated result count.</value>
        [JsonProperty("estimatedResultCount")]
        public int EstimatedResultCount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the index of the current page.
        /// </summary>
        /// <value>The index of the current page.</value>
        [JsonProperty("currentPageIndex")]
        public int CurrentPageIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the more results URL.
        /// </summary>
        /// <value>The more results URL.</value>
        [JsonProperty("moreResultsUrl")]
        public string MoreResultsURL
        {
            get;
            set;
        }

        #endregion
    }
}
