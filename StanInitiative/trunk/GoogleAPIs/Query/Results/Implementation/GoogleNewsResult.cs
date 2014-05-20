using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace GoogleSearchAPI.Query
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GoogleNewsResult : IGoogleNewsResult
    {
        #region IGoogleNewsResult Members

        /// <summary>
        /// Supplies the raw URL of the result.
        /// </summary>
        /// <value></value>
        [JsonProperty("unescapedUrl")]
        public string UnescapedUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies an escaped version of the news URL.
        /// </summary>
        /// <value></value>
        [JsonProperty("url")]
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies a snippet of content from the news story that includes the quotes.
        /// </summary>
        /// <value></value>
        [JsonProperty("content")]
        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the name of the person that the quote is attributed to.
        /// </summary>
        /// <value></value>
        [JsonProperty("author")]
        public string Author
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the name of the publisher of the news story.
        /// </summary>
        /// <value></value>
        [JsonProperty("publisher")]
        public string Publisher
        {
            get;
            set;
        }

        #endregion

        #region IGoogleResult Members

        /// <summary>
        /// Supplies the title value of the result.
        /// </summary>
        /// <value></value>
        [JsonProperty("title")]
        public string Title
        {
            get;
            set;
        }

        #endregion
    }
}
