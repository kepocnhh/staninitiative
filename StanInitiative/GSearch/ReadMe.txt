/******************************************************************************
 * GSearch.NET
 *
 * Version: 1.1.0.0 (February 27, 2009)
 * 
 * Copyright (c) 2009, Mark Betz. All rights reserved. 
 * 
 * Redistribution and use in source and binary forms, with or without modification, are permitted provided
 * that the following conditions are met: 
 * 
 *   * Redistributions of source code must retain the above copyright notice, this list of conditions
 *      and the following disclaimer. 
 *   * Redistributions in binary form must reproduce the above copyright notice, this list of conditions
 *      and the following disclaimer in the documentation and/or other materials provided with the
 *      distribution. 
 *   * Neither the name of the Author nor the names of contributors may be used to endorse or promote
 *      products derived from this software without specific prior written permission. 
 *     
 * THIS SOFTWARE IS PROVIDED BY MARK BETZ ''AS IS'' AND ANY  EXPRESS OR IMPLIED WARRANTIES,
 * INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
 * FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL MARK BETZ BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
 * BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA,
 * OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY
 * OF SUCH DAMAGE. 

GSearch.NET Google Search Class Library for .NET 3.5

OVERVIEW

GSearch.NET is a class library for conducting Google Searches from .NET 3.5 managed code. It uses Google's RESTful webservice API and the JSON deserialization facilities in .NET 3.5. A seperate version of the libraries is available for use in Silverlight 2.0 applications.

GSearch encapsulates all of the search types and options currently supported by the Google API. The list of supported search types is: web, image, video, books, blogs, patents, news, and locations. Each type of search is implemented in a separate assembly. For example: the image search facility is implemented in GSearch.Image.dll. An application only needs to reference and distribute the assemblies for search types it uses, along with the core search engine in GSearch.Core.dll.

For more information on the Google webservice API for search, see the documentation at:

http://code.google.com/apis/ajaxsearch/documentation/reference.html

For a detailed reference to the GSearch class libraries see the class reference packaged with the library archive.

CONTENTS OF THE ARCHIVE

The archive contains the following files:

GSearch.Core.dll					- implements the core search engine, required for all applications
GSearch.Blog.dll					- implements the classes for searching blogs
GSearch.Book.dll					- implements the classes for searching books
GSearch.Image.dll				- implements the classes for searching images
GSearch.Local.dll					- implements the classes for searching locations
GSearch.News.dll					- implements the classes for searching news stories
GSearch.Patent.dll				- implements the classes for searching patents
GSearch.Video.dll					- implements the classes for searching videos
GSearch.Web.dll					- implements the classes for searching the web
GSearchPad.exe					- a .NET 3.5 test/example program for GSearch
GConvert.dll						- used by GSearchPad.exe
GSearch.NET.ClassRef.chm	- the class reference document
ReadMe.txt							- this text file

USING GSEARCH

The following example illustrates how to use the GSearch engine to search Google for images. The mechanism is identical for all the search classes, but of course the results change. See the class reference for more information.

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GSearch;

public void DoSearch( string query )
{
	// create an instance of the search class
	GImageSearch gis = new GImageSearch();

	// create some search arguments
	ImageSearchArgs isa = new ImageSearchArgs();
	
	// set up the search
	isa.Terms = query;
	
	// eight results per page
	isa.ResultSize = SearchResultSize.Large;
	
	// large images
	isa.ImageSize = SearchImageSize.Large;
	
	// no pr0n
	isa.Filter = SearchSafety.Full;
	
	// get the results, blocks until something happens
	try
	{
		GImageResponse gir = gis.Search(isa);
	}
	catch( Exception ex )
	{
		// something went wrong, ex.InnerException will have
		// the details, ex.Message has the high level overview
	}

	// process the results - don't blame me for the nesting of these
	// types... that's the way the Google response is structured :)
	foreach( GImageResults g in gir.Result.Response.Results )
	{
		// display a thumbnail
		Uri imgUri = new Uri(g.TbUrl, UriKind.RelativeOrAbsolute);
	    BitmapImage bi = new BitmapImage(imgUri);
		ThumbControl.Source = bi;
	}
}

The example above shows the blocking form of the Search method being called on a GImageSearch instance to search for images. The blocking (or synchronous) form will block the calling thread until results are available or an exception is thrown. The following example shows how to use the non-blocking (asynchronous) version:

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GSearch;

public void DoSearch( string query )
{
	// create an instance of the search class
	GImageSearch gis = new GImageSearch();

	// wire up the event we need to get the results
	gis.SearchProgressChanged += 
		new EventHandler<ImageSearchEventArgs>(gis_SearchProgressChanged);
	
	// create some search arguments
	ImageSearchArgs isa = new ImageSearchArgs();
	
	// set up the search
	isa.Terms = query;
	
	// eight results per page
	isa.ResultSize = SearchResultSize.Large;
	
	// large images
	isa.ImageSize = SearchImageSize.Large;
	
	// no pr0n
	isa.Filter = SearchSafety.Full;
	
	// get the results
	try
	{
		GImageResponse gir = gis.SearchAsync(isa);
	}
	catch( Exception ex )
	{
		// something went wrong, ex.InnerException will have
		// the details, ex.Message has the high level overview
	}
}

// process the results - don't blame me for the nesting of these
// types... that's the way the Google response is structured :)
private void DisplayThumbs( GImageResponse gir )
{
	foreach( GImageResults g in gir.Result.Response.Results )
	{
		// display a thumbnail
		Uri imgUri = new Uri(g.TbUrl, UriKind.RelativeOrAbsolute);
	    BitmapImage bi = new BitmapImage(imgUri);
		ThumbControl.Source = bi;
	}
}

// the event handler is called at certain milestones. when e.Status is equal to
// SearchStatus.Complete then e.Result contains the response
private void gis_SearchProgressChanged( object sender, ImageSearchEventArgs e )
{
	switch( e.Status )
	{
		case SearchStatus.Complete:
			DisplayThumbs( e.Result );
			break;
	}
}

The asynchronous version of the search method is not available in the Silverlight version of the library, since Silverlight does not support blocking http reads.

VERSION HISTORY

Version: 1.0.0.0
Date: January 10, 2009

Initial release