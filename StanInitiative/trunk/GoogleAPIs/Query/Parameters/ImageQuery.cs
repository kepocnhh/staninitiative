using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleSearchAPI.Query
{
    /// <summary>
    /// Provides a google images query. AJAX API URL: http://ajax.googleapis.com/ajax/services/search/images.
    /// </summary>    
    public class ImageQuery : BaseQuery
    {
        public ImageQuery(string queryText) : base(queryText) 
        { 
            ServiceName = QueryServicesConsts.ImageQuery;

            //Initializing the image query parameters..
            this.InitQueryParameter<QueryImageSizeParameter>(ref m_ImageSize);
            this.InitQueryParameter<QueryImageColorizationParameter>(ref m_ImageColorization);
            this.InitQueryParameter<QueryImageColorParameter>(ref m_ImageColor);
            this.InitQueryParameter<QuerySafeParameter>(ref m_Safe);
            this.InitQueryParameter<QueryImageRightsParameter>(ref m_ImageRights);
            this.InitQueryParameter<QuerySiteSearchParameter>(ref m_SiteSearch);
            this.InitQueryParameter<QueryImageTypeParameter>(ref m_ImageType);
            this.InitQueryParameter<QueryImageFileTypeParameter>(ref m_ImageFileType);
        }

        private QueryImageSizeParameter m_ImageSize;
        public QueryImageSizeParameter ImageSize
        {
            get { return m_ImageSize; }
            set { m_ImageSize = value; }
        }

        private QueryImageColorizationParameter m_ImageColorization;
        public QueryImageColorizationParameter ImageColorization
        {
            get { return m_ImageColorization; }
            set { m_ImageColorization = value; }
        }

        private QueryImageColorParameter m_ImageColor;
        public QueryImageColorParameter ImageColor
        {
            get { return m_ImageColor; }
            set { m_ImageColor = value; }
        }

        private QuerySafeParameter m_Safe;
        public QuerySafeParameter Safe
        {
            get { return m_Safe; }
            set { m_Safe = value; }
        }

        private QueryImageRightsParameter m_ImageRights;
        public QueryImageRightsParameter ImageRights
        {
            get { return m_ImageRights; }
            set { m_ImageRights = value; }
        }

        private QuerySiteSearchParameter m_SiteSearch;
        public QuerySiteSearchParameter SiteSearch
        {
            get { return m_SiteSearch; }
            set { m_SiteSearch = value; }
        }

        private QueryImageTypeParameter m_ImageType;
        public QueryImageTypeParameter ImageType
        {
            get { return m_ImageType; }
            set { m_ImageType = value; }
        }

        private QueryImageFileTypeParameter m_ImageFileType;
        public QueryImageFileTypeParameter ImageFileType
        {
            get { return m_ImageFileType; }
            set { m_ImageFileType = value; }
        }
    }
}
