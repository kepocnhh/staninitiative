using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace GoogleSearchAPI.Query
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GoogleBookResult : IGoogleBookResult
    {
        #region IGoogleBookResult Members

        /// <summary>
        /// Supplies the title of the book.
        /// </summary>
        /// <value></value>
        [JsonProperty("title")]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the title, but unlike .title, this property is
        /// stripped of html markup (e.g., b, i, etc.).
        /// </summary>
        /// <value></value>
        [JsonProperty("titleNoFormatting")]
        public string TitleNoFormatting
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
        /// Supplies an escaped version of the book's URL.
        /// </summary>
        /// <value></value>
        [JsonProperty("url")]
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the list of authors of the book.
        /// </summary>
        /// <value></value>
        [JsonProperty("authors")]
        public string Authors
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the identifier associated with the book. This is typically an ISBN.
        /// </summary>
        /// <value></value>
        [JsonProperty("bookId")]
        public string BookId
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the year that the book was published.
        /// </summary>
        /// <value></value>
        [JsonProperty("publishedYear")]
        public int PublishedYear
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the number of pages contained within the book.
        /// </summary>
        /// <value></value>
        [JsonProperty("pageCount")]
        public int PageCount
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies an html dom node that represents a thumbnail image of the book's cover.
        /// </summary>
        /// <value></value>
        [JsonProperty("thumbnailHtml")]
        public string ThumbnailHtml
        {
            get;
            set;
        }

        #endregion

        #region IGoogleResult Members


        [JsonIgnore]
        public string Content
        {
            get;
            set;
        }

        #endregion
    }
}
