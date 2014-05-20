using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoogleSearchAPI.Query;
using System.Net;
using Newtonsoft.Json;
using System.Web;
using Newtonsoft.Json.Linq;
using System.IO;

namespace GoogleSearchAPI
{
    public class GoogleService : IGoogleService
    {
        private WebClient m_WebClient;
        private GoogleService()
        {
            m_WebClient = new WebClient();
            m_WebClient.Encoding = Encoding.UTF8;
        }

        private static GoogleService m_Instance;

        public static GoogleService Instance
        {
            get 
            {
                if (m_Instance == null)
                    m_Instance = new GoogleService();
                return m_Instance; 
            }
        }


        #region IGoogleService Members

        /// <summary>
        /// This method makes a synchronous call to the Google AJAX API to query it. It uses the query parameters
        /// that are supplied in the IGoogleQuery.
        /// </summary>
        /// <typeparam name="ResultType">The IGoogleResult implementation that matches the IGoogleQuery service. e.g WebQuery -&gt; GoogleWebResult
        /// Supported result types: GoogleWebResult, GoogleImageResult, GoogleVideoResult, GoogleBlogResult, GoogleLocalResult,
        /// GoogleBooksResult, GoogleNewsResult, GooglePatentResult</typeparam>
        /// <param name="query">The IGoogleQuery implementation that will be used to build the query to the Google AJAX API.
        /// Supported IGoogleQuery implementations: WebQuery, ImageQuery, VideoQuery, BookQuery, BlogQuery, LocalQuery, NewsQuery, PatentQuery</param>
        /// <returns></returns>
        public IGoogleResultSet<ResultType> Search<ResultType>(IGoogleQuery query) where ResultType : IGoogleResult
        {
            IGoogleResultSet<ResultType> result = null;
            try
            {
                //Sending query to Google AJAX API..
                string jsonData = m_WebClient.DownloadString(new Uri(HttpUtility.UrlPathEncode(query.ToUrl())));
                //Converting jsonData into an IGoogleResultSet object.
                result = ConvertJsonToResultSet<ResultType>(jsonData);
            }
            catch (WebException ex)
            {
                throw new Exception("Failed to connect to google ajax api, check that your internet connection is alive.", ex);
            }
            catch (NotSupportedException ex)
            {
                throw new Exception("Failed to connect to google ajax api, check that your internet connection is alive.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Converting the Json result to a GoogleResultSet failed", ex);
            }
            
            return result;
        }

        /// <summary>
        /// This method makes a synchronous call to the Google AJAX API Translate service. It uses
        /// the data in the TranslateQuery to build the query, and returns the translatedText response that the service yields.
        /// </summary>
        /// <param name="query">The IGoogleQuery implementation that will be used to build the query to the Google AJAX API.</param>
        /// <returns>The translatedText for the requested TranslateQuery LanguagePair.</returns>
        public string Translate(TranslateQuery query)
        {
            try
            {
                //Sending query to Google AJAX API..
                string jsonData = m_WebClient.DownloadString(new Uri(HttpUtility.UrlPathEncode(query.ToUrl())));
                //Converting jsonData into an IGoogleResultSet object.
                return ConvertJsonToTranslatedText(jsonData);
            }
            catch (WebException ex)
            {
                throw new Exception("Failed to connect to google ajax api, check that your internet connection is alive.", ex);
            }
            catch (NotSupportedException ex)
            {
                throw new Exception("Failed to connect to google ajax api, check that your internet connection is alive.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Converting the Json result to a translatedText failed", ex);
            }
        }

        #endregion

        #region Private Helper Methods
        private string ConvertJsonToTranslatedText(string jsonData)
        {
            //Converting the Json string to a JObject.            
            JObject jsonObj = JObject.Parse(jsonData);

            int status = (int)jsonObj.SelectToken("responseStatus");
            if (status != 200)
                throw new Exception("Translation failed, Google AJAX API returned status code " + status);

            string translatedText = (string)jsonObj.SelectToken("responseData.translatedText");
            return translatedText;
        }

        private IGoogleResultSet<ResultType> ConvertJsonToResultSet<ResultType>(string jsonData) where ResultType : IGoogleResult
        {            
            //Converting the Json string to a JObject.            
            JObject jsonObj = JObject.Parse(jsonData);
            //Converting the JObject to a IGoogleResultSet
            IGoogleResultSet<ResultType> resultSet = new GoogleResultSet<ResultType>();
            
            int status = (int)jsonObj.SelectToken("responseStatus");
            if (status != 200)
                throw new Exception("Query failed, Google AJAX API returned status code " + status);

            string responseDetails = (string)jsonObj.SelectToken("responseDetails");
            JObject cursorJson = (JObject)jsonObj.SelectToken("responseData.cursor");
            JArray cursorPages = (JArray)jsonObj.SelectToken("responseData.cursor.pages");
            JArray resultsJson = (JArray)jsonObj.SelectToken("responseData.results");

            //Creating the search results..            
            IList<ResultType> results = new List<ResultType>();
            if (resultsJson.Count > 0)
            {
                foreach (var result in resultsJson)
                {
                    ResultType item = JsonConvert.DeserializeObject<ResultType>(result.ToString());
                    results.Add(item);
                }
            }

            //Creating the search results cursor..            
            ICursor cursor = JsonConvert.DeserializeObject<Cursor>(cursorJson.ToString());            

            IList<IPage> pages = new List<IPage>();
            if (cursorPages.Count > 0)
            {
                foreach (var result in cursorPages)
                {
                    IPage item = JsonConvert.DeserializeObject<Page>(result.ToString());
                    pages.Add(item);
                }
            }
            cursor.Pages = pages;

            resultSet.ResponseDetails = responseDetails;
            resultSet.Status = status;
            resultSet.Results = results;
            resultSet.Cursor = cursor;

            return resultSet;
        }        
        #endregion
    }
}
