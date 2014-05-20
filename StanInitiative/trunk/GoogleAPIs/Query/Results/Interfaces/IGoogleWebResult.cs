using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleSearchAPI.Query
{
    public interface IGoogleWebResult : IGoogleResult
    {
        /// <summary>
        /// Supplies the title value of the result.
        /// </summary>
        new string Title { get; set; }
        /// <summary>
        /// Supplies the title, but unlike Title, this property is stripped of html markup (e.g., b, i, etc.).
        /// </summary>
        string TitleNoFormatting { get; set; }
        /// <summary>
        /// Supplies a brief snippet of information from the page associated with the search result.
        /// </summary>
        new string Content { get; set; }
        /// <summary>
        /// Supplies a shortened version of the URL associated with the result. Typically displayed in green, stripped of a protocol and path.
        /// </summary>
        string VisibleUrl { get; set; }
        /// <summary>
        /// Supplies an escaped version of the above URL.
        /// </summary>
        new string Url { get; set; }
        /// <summary>
        /// Supplies the raw URL of the result.
        /// </summary>
        string UnescapedUrl { get; set; }
        /// <summary>
        /// Supplies a url to Google's cached version of the page responsible for producing this result. 
        /// This property may be null indicating that there is no cache, and it might be out of date in 
        /// cases where the search result has been saved and in the mean time, the cache has gone stale. 
        /// For best results, this property should not be persisted.
        /// </summary>
        string CacheUrl { get; set; }
    }
}
