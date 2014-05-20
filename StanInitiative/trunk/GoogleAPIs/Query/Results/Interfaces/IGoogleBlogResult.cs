using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleSearchAPI.Query
{
    public interface IGoogleBlogResult : IGoogleResult
    {
        /// <summary>
        /// Supplies the title of the blog post returned as a search result.
        /// </summary>
        new string Title { get; set; }
        /// <summary>
        /// Supplies the title, but unlike .title, this property is stripped of html markup (e.g., b, i, etc.).
        /// </summary>
        string TitleNoFormatting { get; set; }
        /// <summary>
        /// Supplies a snippet of content from the blog post associated with this search result.
        /// </summary>
        new string Content { get; set; }
        /// <summary>
        /// Supplies the URL to the blog post referenced in this search result.
        /// </summary>
        string PostUrl { get; set; }
        /// <summary>
        /// Supplies the name of the author that wrote the blog post.
        /// </summary>
        string Author { get; set; }
        /// <summary>
        /// Supplies the URL of the blog which contains the post. 
        /// Typically, this URL is displayed in green, beneath the blog search 
        /// result and is linked to the blog.
        /// </summary>
        string BlogUrl { get; set; }
        /// <summary>
        /// Supplies the published date (rfc-822 format) of the blog post referenced 
        /// by this search result.
        /// </summary>
        DateTime PublishedDate { get; set; }
    }
}
