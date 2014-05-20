using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace GoogleSearchAPI.Query
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GoogleBlogResult : IGoogleBlogResult
    {
        #region IGoogleBlogResult Members

        /// <summary>
        /// Supplies the title of the blog post returned as a search result.
        /// </summary>
        /// <value></value>
        [JsonProperty("title")]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the title, but unlike .title, this property is stripped of html markup (e.g., b, i, etc.).
        /// </summary>
        /// <value></value>
        [JsonProperty("titleNoFormatting")]
        public string TitleNoFormatting
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies a snippet of content from the blog post associated with this search result.
        /// </summary>
        /// <value></value>
        [JsonProperty("content")]
        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the URL to the blog post referenced in this search result.
        /// </summary>
        /// <value></value>
        [JsonProperty("postUrl")]
        public string PostUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the name of the author that wrote the blog post.
        /// </summary>
        /// <value></value>
        [JsonProperty("author")]
        public string Author
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the URL of the blog which contains the post.
        /// Typically, this URL is displayed in green, beneath the blog search
        /// result and is linked to the blog.
        /// </summary>
        /// <value></value>
        [JsonProperty("blogUrl")]
        public string BlogUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the published date (rfc-822 format) of the blog post referenced
        /// by this search result.
        /// </summary>
        /// <value></value>
        [JsonProperty("publishedDate")]
        public DateTime PublishedDate
        {
            get;
            set;
        }

        #endregion

        #region IGoogleResult Members


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

        #endregion
    }
}
