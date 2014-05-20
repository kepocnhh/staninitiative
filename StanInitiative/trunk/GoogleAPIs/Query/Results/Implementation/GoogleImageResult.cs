using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace GoogleSearchAPI.Query
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GoogleImageResult : IGoogleImageResult
    {
        #region IGoogleImageResult Members

        /// <summary>
        /// Supplies the title of the image, which is usually the base filename.
        /// </summary>
        /// <value></value>
        [JsonProperty("title")]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the title, but unlike .title, this property
        /// is stripped of html markup (e.g., b, i, etc.).
        /// </summary>
        /// <value></value>
        [JsonProperty("titleNoFormatting")]
        public string TitleNoFormatting
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the raw URL of the image.
        /// </summary>
        /// <value></value>
        [JsonProperty("unescapedUrl")]
        public string UnescapedUrl
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
        /// Supplies the same information as .content, only stripped of HTML formatting.
        /// </summary>
        /// <value></value>
        [JsonProperty("contentNoFormatting")]
        public string ContentNoFormatting
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the URL of the page containing the image.
        /// </summary>
        /// <value></value>
        [JsonProperty("originalContextUrl")]
        public string OriginalContextUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the width of the image in pixels.
        /// </summary>
        /// <value></value>
        [JsonProperty("width")]
        public int Width
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the height of the image in pixels.
        /// </summary>
        /// <value></value>
        [JsonProperty("height")]
        public int Height
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the width, in pixels, of the image thumbnail.
        /// </summary>
        /// <value></value>
        [JsonProperty("tbWidth")]
        public int TbWidth
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the height, in pixels, of the image thumbnail.
        /// </summary>
        /// <value></value>
        [JsonProperty("tbHeight")]
        public int TbHeight
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the url of a thumbnail image.
        /// </summary>
        /// <value></value>
        [JsonProperty("tbUrl")]
        public string TbUrl
        {
            get;
            set;
        }

        #endregion
    }
}
