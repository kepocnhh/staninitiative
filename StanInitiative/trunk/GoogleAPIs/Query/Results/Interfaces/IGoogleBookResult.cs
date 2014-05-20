using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleSearchAPI.Query
{
    interface IGoogleBookResult : IGoogleResult
    {
        /// <summary>
        /// Supplies the title of the book.
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
        /// Supplies an escaped version of the book's URL.
        /// </summary>
        new string Url { get; set; }
        /// <summary>
        /// Supplies the list of authors of the book.
        /// </summary>
        string Authors { get; set; }
        /// <summary>
        /// Supplies the identifier associated with the book. This is typically an ISBN.
        /// </summary>
        string BookId { get; set; }
        /// <summary>
        /// Supplies the year that the book was published.
        /// </summary>
        int PublishedYear { get; set; }
        /// <summary>
        /// Supplies the number of pages contained within the book.
        /// </summary>
        int PageCount { get; set; }
        /// <summary>
        /// Supplies an html dom node that represents a thumbnail image of the book's cover.
        /// </summary>
        string ThumbnailHtml { get; set; }
    }
}
