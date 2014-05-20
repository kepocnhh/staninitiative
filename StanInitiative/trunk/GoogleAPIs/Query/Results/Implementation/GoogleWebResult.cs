using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace GoogleSearchAPI.Query
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GoogleWebResult : IGoogleWebResult
    {
        #region IGoogleWebResult Members

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

        /// <summary>
        /// Supplies the title, but unlike Title, this property is stripped of html markup (e.g., b, i, etc.).
        /// </summary>
        /// <value></value>
        [JsonProperty("titleNoFormatting")]
        public string TitleNoFormatting
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies a brief snippet of information from the page associated with the search result.
        /// </summary>
        /// <value></value>
        [JsonProperty("content")]
        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies a shortened version of the URL associated with the result. Typically displayed in green, stripped of a protocol and path.
        /// </summary>
        /// <value></value>
        [JsonProperty("visibleUrl")]
        public string VisibleUrl
        {
            get;
            set;
        }


        /// <summary>
        /// Supplies an escaped version of the above URL.
        /// </summary>
        /// <value></value>
        [JsonProperty("url")]
        public string Url
        {
            get;
            set;
        }

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
        /// Supplies a url to Google's cached version of the page responsible for producing this result.
        /// This property may be null indicating that there is no cache, and it might be out of date in
        /// cases where the search result has been saved and in the mean time, the cache has gone stale.
        /// For best results, this property should not be persisted.
        /// </summary>
        /// <value></value>
        [JsonProperty("cacheUrl")]
        public string CacheUrl
        {
            get;
            set;
        }

        #endregion
    }
}
