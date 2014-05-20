using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace GoogleSearchAPI.Query
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GoogleVideoResult : IGoogleVideoResult
    {
        #region IGoogleVideoResult Members

        /// <summary>
        /// Supplies the title of the video result.
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
        /// Supplies the url of a playable version of the video result.
        /// </summary>
        /// <value></value>
        [JsonProperty("url")]
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies a snippet style description of the video clip.
        /// </summary>
        /// <value></value>
        [JsonProperty("content")]
        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the published date of the video (rfc-822 format).
        /// </summary>
        /// <value></value>
        [JsonProperty("published")]
        public DateTime Published
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the name of the video's publisher, typically displayed
        /// in green below the video thumbnail, similar to the treatment
        /// used for visibleUrl in the other search result objects.
        /// </summary>
        /// <value></value>
        [JsonProperty("publisher")]
        public string Publisher
        {
            get;
            set;
        }

        /// <summary>
        /// The approximate duration, in seconds, of the video.
        /// </summary>
        /// <value></value>
        [JsonProperty("duration")]
        public int Duration
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the width, in pixels, of the video thumbnail.
        /// </summary>
        /// <value></value>
        [JsonProperty("tbWidth")]
        public int TbWidth
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the height, in pixels, of the video thumbnail.
        /// </summary>
        /// <value></value>
        [JsonProperty("tbHeight")]
        public int TbHeight
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the url of a thumbnail image which visually represents the video.
        /// </summary>
        /// <value></value>
        [JsonProperty("tbUrl")]
        public string TbUrl
        {
            get;
            set;
        }

        /// <summary>
        /// If present, supplies the url of the flash version of the video that can be
        /// played inline on your page. To play this video simply create an embed
        /// element on your page using this value as the src attribute and using
        /// application/x-shockwave-flash as the type attribute. If you want the
        /// video to play right away, make sure to append and autoPlay=true to the url.
        /// </summary>
        /// <value></value>
        [JsonProperty("playUrl")]
        public string PlayUrl
        {
            get;
            set;
        }

        /// <summary>
        /// If present, this property supplies the YouTube user name of the author of the video.
        /// </summary>
        /// <value></value>
        [JsonProperty("author")]
        public string Author
        {
            get;
            set;
        }

        /// <summary>
        /// If present, this property supplies a count of the number of plays for this video.
        /// </summary>
        /// <value></value>
        [JsonProperty("viewCount")]
        public int ViewCount
        {
            get;
            set;
        }

        /// <summary>
        /// If present, this property supplies the rating of the video on a scale of 1 to 5.
        /// </summary>
        /// <value></value>
        [JsonProperty("rating")]
        public int Rating
        {
            get;
            set;
        }

        #endregion
    }
}
