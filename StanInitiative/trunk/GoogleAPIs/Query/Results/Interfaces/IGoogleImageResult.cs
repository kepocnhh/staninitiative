using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleSearchAPI.Query
{
    public interface IGoogleImageResult : IGoogleResult
    {
        /// <summary>
        /// Supplies the title of the image, which is usually the base filename.
        /// </summary>
        new string Title { get; set; }
        /// <summary>
        /// Supplies the title, but unlike .title, this property 
        /// is stripped of html markup (e.g., b, i, etc.).
        /// </summary>
        string TitleNoFormatting { get; set; }
        /// <summary>
        /// Supplies the raw URL of the image.
        /// </summary>
        string UnescapedUrl { get; set; }
        /// <summary>
        /// Supplies an escaped version of the above URL.
        /// </summary>
        new string Url { get; set; }
        /// <summary>
        /// Supplies a brief snippet of information from the page associated with the search result.
        /// </summary>
        new string Content { get; set; }
        /// <summary>
        /// Supplies the same information as .content, only stripped of HTML formatting.
        /// </summary>
        string ContentNoFormatting { get; set; }
        /// <summary>
        /// Supplies the URL of the page containing the image.
        /// </summary>
        string OriginalContextUrl { get; set; }
        /// <summary>
        /// Supplies the width of the image in pixels.
        /// </summary>
        int Width { get; set; }
        /// <summary>
        /// Supplies the height of the image in pixels.
        /// </summary>
        int Height { get; set; }
        /// <summary>
        /// Supplies the width, in pixels, of the image thumbnail.
        /// </summary>
        int TbWidth { get; set; }
        /// <summary>
        /// Supplies the height, in pixels, of the image thumbnail.
        /// </summary>
        int TbHeight { get; set; }
        /// <summary>
        /// Supplies the url of a thumbnail image.
        /// </summary>
        string TbUrl { get; set; }
    }
}
