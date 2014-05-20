using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleSearchAPI.Query
{
    public interface IGoogleVideoResult : IGoogleResult
    {
        /// <summary>
        /// Supplies the title of the video result.
        /// </summary>
        new string Title { get; set; }
        /// <summary>
        /// Supplies the title, but unlike .title, this property is 
        /// stripped of html markup (e.g., b, i, etc.).
        /// </summary>
        string TitleNoFormatting { get; set; }
        /// <summary>
        /// Supplies the url of a playable version of the video result.
        /// </summary>
        new string Url { get; set; }
        /// <summary>
        /// Supplies a snippet style description of the video clip.
        /// </summary>
        new string Content { get; set; }
        /// <summary>
        /// Supplies the published date of the video (rfc-822 format).
        /// </summary>
        DateTime Published { get; set; }
        /// <summary>
        /// Supplies the name of the video's publisher, typically displayed 
        /// in green below the video thumbnail, similar to the treatment 
        /// used for visibleUrl in the other search result objects.
        /// </summary>
        string Publisher { get; set; }
        /// <summary>
        /// The approximate duration, in seconds, of the video.
        /// </summary>
        int Duration { get; set; }
        /// <summary>
        /// Supplies the width, in pixels, of the video thumbnail.
        /// </summary>
        int TbWidth { get; set; }
        /// <summary>
        /// Supplies the height, in pixels, of the video thumbnail.
        /// </summary>
        int TbHeight { get; set; }
        /// <summary>
        /// Supplies the url of a thumbnail image which visually represents the video.
        /// </summary>
        string TbUrl { get; set; }
        /// <summary>
        /// If present, supplies the url of the flash version of the video that can be
        /// played inline on your page. To play this video simply create an embed 
        /// element on your page using this value as the src attribute and using 
        /// application/x-shockwave-flash as the type attribute. If you want the 
        /// video to play right away, make sure to append and autoPlay=true to the url.
        /// </summary>
        string PlayUrl { get; set; }
        /// <summary>
        /// If present, this property supplies the YouTube user name of the author of the video.
        /// </summary>
        string Author { get; set; }
        /// <summary>
        /// If present, this property supplies a count of the number of plays for this video.
        /// </summary>
        int ViewCount { get; set; }
        /// <summary>
        /// If present, this property supplies the rating of the video on a scale of 1 to 5.
        /// </summary>
        int Rating { get; set; }
    }
}
