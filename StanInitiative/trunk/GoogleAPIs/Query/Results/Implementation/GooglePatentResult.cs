using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace GoogleSearchAPI.Query
{
    [JsonObject(MemberSerialization.OptIn)]
    public class GooglePatentResult : IGooglePatentResult
    {
        #region IGooglePatentResult Members

        /// <summary>
        /// Supplies the title of the patent result.
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
        /// Supplies an escaped version of the patent URL.
        /// </summary>
        /// <value></value>
        [JsonProperty("url")]
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies a snippet style description of the patent.
        /// </summary>
        /// <value></value>
        [JsonProperty("content")]
        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the application filing date of the patent (rfc-822 format).
        /// </summary>
        /// <value></value>
        [JsonProperty("applicationDate")]
        public DateTime ApplicationDate
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the patent number for issued patents, and the application number for filed,
        /// but not yet issued patents.
        /// </summary>
        /// <value></value>
        [JsonProperty("patentNumber")]
        public double PatentNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the status of the patent which can either be "filed" for filed, but not
        /// yet issued patents, or "issued" for issued patents.
        /// </summary>
        /// <value></value>
        [JsonProperty("patentStatus")]
        public string PatentStatus
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the assignee of the patent.
        /// </summary>
        /// <value></value>
        [JsonProperty("assignee")]
        public string Assignee
        {
            get;
            set;
        }

        /// <summary>
        /// Supplies the url of a thumbnail image which visually represents the patent.
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
