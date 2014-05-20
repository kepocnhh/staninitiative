using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleSearchAPI.Query
{
    interface IGoogleNewsResult : IGoogleResult
    {
        /// <summary>
        /// Supplies the raw URL of the result.
        /// </summary>
        string UnescapedUrl { get; set; }
        /// <summary>
        /// Supplies an escaped version of the news URL.
        /// </summary>
        new string Url { get; set; }
        /// <summary>
        /// Supplies a snippet of content from the news story that includes the quotes.
        /// </summary>
        new string Content { get; set; }
        /// <summary>
        /// Supplies the name of the person that the quote is attributed to.
        /// </summary>
        string Author { get; set; }
        /// <summary>
        /// Supplies the name of the publisher of the news story.
        /// </summary>
        string Publisher { get; set; }
    }
}
