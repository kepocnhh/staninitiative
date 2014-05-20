using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleSearchAPI.Query;

namespace GoogleSearchAPI
{
    /// <summary>
    /// Provides a Search interface using Google AJAX API.
    /// </summary>
    public interface IGoogleService
    {
        /// <summary>
        /// This method makes a synchronous call to the Google AJAX API to query it. It uses the query parameters
        /// that are supplied in the IGoogleQuery.
        /// </summary>
        /// <typeparam name="ResultType">The IGoogleResult implementation that matches the IGoogleQuery service. e.g WebQuery -> GoogleWebResult
        /// Supported result types: GoogleWebResult, GoogleImageResult, GoogleVideoResult, GoogleBlogResult, GoogleLocalResult, 
        /// GoogleBooksResult, GoogleNewsResult, GooglePatentResult</typeparam>
        /// <param name="query">The IGoogleQuery implementation that will be used to build the query to the Google AJAX API.
        /// Supported IGoogleQuery implementations: WebQuery, ImageQuery, VideoQuery, BookQuery, BlogQuery, LocalQuery, NewsQuery, PatentQuery</param>
        /// <returns></returns>
        IGoogleResultSet<ResultType> Search<ResultType>(IGoogleQuery query) where ResultType : IGoogleResult;
    }
}
