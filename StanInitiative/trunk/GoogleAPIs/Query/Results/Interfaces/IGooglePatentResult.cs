using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleSearchAPI.Query
{
    interface IGooglePatentResult : IGoogleResult
    {
        /// <summary>
        /// Supplies the title of the patent result.
        /// </summary>
        new string Title { get; set; }
        /// <summary>
        /// Supplies the title, but unlike .title, this property is 
        /// stripped of html markup (e.g., b, i, etc.).
        /// </summary>
        string TitleNoFormatting { get; set; }
        /// <summary>
        /// Supplies the raw URL of the result.
        /// </summary>
        string UnescapedUrl { get; set; }
        /// <summary>
        /// Supplies an escaped version of the patent URL.
        /// </summary>
        new string Url { get; set; }
        /// <summary>
        /// Supplies a snippet style description of the patent.
        /// </summary>
        new string Content { get; set; }
        /// <summary>
        /// Supplies the application filing date of the patent (rfc-822 format).
        /// </summary>
        DateTime ApplicationDate { get; set; }
        /// <summary>
        /// Supplies the patent number for issued patents, and the application number for filed, 
        /// but not yet issued patents.
        /// </summary>
        double PatentNumber { get; set; }
        /// <summary>
        /// Supplies the status of the patent which can either be "filed" for filed, but not 
        /// yet issued patents, or "issued" for issued patents.
        /// </summary>
        string PatentStatus { get; set; }
        /// <summary>
        /// Supplies the assignee of the patent.
        /// </summary>
        string Assignee { get; set; }
        /// <summary>
        /// Supplies the url of a thumbnail image which visually represents the patent.
        /// </summary>
        string TbUrl { get; set; }
    }
}
