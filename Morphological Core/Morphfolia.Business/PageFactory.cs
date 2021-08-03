// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Specialized; 
using Morphfolia.Business.Logging;
using Morphfolia.Common.Constants;
using Morphfolia.Common.Info;
using Morphfolia.Business.Constants;
using Morphfolia.Business.Logs;

namespace Morphfolia.Business
{
	/// <summary>
	/// Summary description for PageFactory.
	/// </summary>
	public class PageFactory
	{
        private static Morphfolia.IDataProvider.IPageDataProvider iPageDataProvider = null;
        private static Morphfolia.IDataProvider.IPageDataProvider IPageDataProvider
        {
            get
            {
                if (iPageDataProvider == null)
                {
                    iPageDataProvider = Helpers.ProviderLoader.Load(DataProviderAppSettingKeys.IPageDataProvider) as Morphfolia.IDataProvider.IPageDataProvider;
                }

                return iPageDataProvider;
            }
        }


        private static Morphfolia.IDataProvider.IContentDataProvider iContentDataProvider = null;
        private static Morphfolia.IDataProvider.IContentDataProvider IContentDataProvider
        {
            get
            {
                if (iContentDataProvider == null)
                {
                    iContentDataProvider = Helpers.ProviderLoader.Load(DataProviderAppSettingKeys.IContentDataProvider) as Morphfolia.IDataProvider.IContentDataProvider;
                }

                return iContentDataProvider;
            }
        }

		private static Page _Page;
		private static PageInfo _PageInfo;



        public static PageInfo NullPageInfo()
        {
            return new PageInfo(
                SystemTypeValues.NullInt,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                DateTime.Now,
                "System Administrator",
                false, false);
        }


		public static Page Page404()
		{
			_Page = new Page();
			_Page.PageID = SystemTypeValues.NullInt;
			_Page.Title = "Page not found";
            _Page.Keywords = string.Empty;
            _Page.Description = string.Empty;
            _Page.Url = "PageNotFound.aspx";
			_Page.LastModified = DateTime.Now;
			_Page.LastModifiedBy = "System Administrator";
			_Page.IsLive = true;
			_Page.IsSearchable = false;
			_Page.ContentItems = new ContentInfoCollection();
            _Page.ContentItems.Add(new ContentInfo(SystemTypeValues.NullInt, "Page not found.", string.Empty, string.Empty, Common.ContentTypes.All, true, false, string.Empty, DateTime.Now, "System Administrator"));
			return _Page;
		}

		public static Page SearchResultsPage()
		{
			_Page = new Page();
			_Page.PageID = SystemTypeValues.NullInt;
			_Page.Title = "Search Results";
			_Page.Keywords = "";
			_Page.Description = "";
			_Page.Url = "SearchResults.aspx";
			_Page.LastModified = DateTime.Now;
			_Page.LastModifiedBy = "System Administrator";
			_Page.IsLive = true;
			_Page.IsSearchable = false;
			_Page.ContentItems = new Morphfolia.Common.Info.ContentInfoCollection();
			return _Page;
		}

		/// <summary>
		/// Returns a blank page - used for pages like the login page where we want 
		/// to add some controls to the "page" instead of some content in a Page object.
		/// </summary>
		/// <returns></returns>
		public static Page GenericPage( string title )
		{
			return GenericPageAssembler( title, "blank.aspx" );
		}

		public static Page GenericPage( string title, string url )
		{
			return GenericPageAssembler( title, url );
		}

		private static Page GenericPageAssembler( string title, string url )
		{
			_Page = new Page();
			_Page.PageID = -1;
			_Page.Title = title;
			_Page.Keywords = "";
			_Page.Description = "";
			_Page.Url = url;
			_Page.LastModified = DateTime.Now;
			_Page.LastModifiedBy = "System Administrator";
			_Page.IsLive = true;
			_Page.IsSearchable = false;
			_Page.ContentItems = new Morphfolia.Common.Info.ContentInfoCollection();
			//_Page.ContentItems.Add( new Morphfolia.Common.Info.ContentInfo(-1, "Page not found.", "", "", true, false, DateTime.Now, "System Administrator") );
			return _Page;
		}


		/// <summary>
		/// This is a specific constructor used only when we want to build new page to 
		/// store a new content item as we create the content item.  Should probably move this into a PageHelper class.
		/// </summary>
		public static Page Page( 
			string userWhoIsAddingPage, 
			string title, 
            string url,
            string keywords,
            string description,
            bool isLive, 
			bool isSearchable )//,
			//int contentId )
		{
			// First save a placeholder copy for the new page in order to get the PageID. 
			// As we do this we will also set some of the properties of the page to the desired values.
			// Won't set URL until we have the PageID.
			// Set isLive and isSearchable to false as we haven't finished yet:
			int newPageID = IPageDataProvider.Page_INSERT( new Morphfolia.Common.Info.PageSaveNewInfo(
                title,
                url,
                keywords,
				description,
				userWhoIsAddingPage,
                isSearchable,
                isLive));

            Auditor.LogAuditEntry(newPageID, AuditableObjects.Page, "Created");


			_PageInfo = IPageDataProvider.Page_SELECT_PageByID( newPageID );

			// Now update it to more accurately reflect the desired values: 
			_Page = new Page();
			_Page.PageID = newPageID;
            _Page.Title = _PageInfo.Title;
            _Page.Keywords = _PageInfo.Keywords;
            _Page.Description = _PageInfo.Description;
            _Page.Url = _PageInfo.Url;
            _Page.LastModified = _PageInfo.LastModified;
            _Page.LastModifiedBy = _PageInfo.LastModifiedBy;
            _Page.IsLive = _PageInfo.IsLive;
            _Page.IsSearchable = _PageInfo.IsSearchable;

			// Finally add the content item to the page ????:
            //Morphfolia.Common.Info.PageContentUpdateInfoCollection pageContentUpdateInfoCollection = new Morphfolia.Common.Info.PageContentUpdateInfoCollection();
            //pageContentUpdateInfoCollection.Add( new Morphfolia.Common.Info.PageContentUpdateInfo( newPageID, contentId ) );
            //_Page.Save( pageContentUpdateInfoCollection );

			return _Page;
		}



		/// <summary>
		/// The constructor used to instansiate an existing page.
		/// Should only be used in the admin section.
		/// </summary>
		/// <param name="pageId">The ID of the Page to get.</param>
		public static Page Page( int pageId )
		{
			// if the pageId is -1 we know that someone has not requested any specific page.
			if( pageId == -1 )
			{
				return Page404();
			}
			else
			{

				try
				{
					_PageInfo = IPageDataProvider.Page_SELECT_PageByID( pageId );

					_Page = new Page();
					_Page.PageID = pageId;
					_Page.Title = _PageInfo.Title;
					_Page.Keywords = _PageInfo.Keywords;
					_Page.Description = _PageInfo.Description;
					_Page.Url = _PageInfo.Url;
					_Page.LastModified = _PageInfo.LastModified;
					_Page.LastModifiedBy = _PageInfo.LastModifiedBy;
					_Page.IsSearchable = _PageInfo.IsSearchable;
					_Page.IsLive = _PageInfo.IsLive;
					_Page.ContentItems = IContentDataProvider.Content_SELECT_PageByIDForAdminMode( pageId );
					return _Page;
				}
				catch(Exception ex)
				{
                    Logger.LogException("Failed to construct Page object, returning 404 Page.", ex, EventIds._4100, string.Format("Requested PageID = {0}", pageId.ToString()));

					return Page404();
				}
			}
		}



		/// <summary>
		/// Publish a page to the site for public/anon users to view.
		/// </summary>
		/// <param name="url">The url of the page to publish</param>
		/// <returns>A Page object</returns>
		public static Page PublishThisPage( string url )
		{
            //Morphfolia.Common.Utilities.LicenseChecker.CheckDomain(System.Web.HttpContext.Current);



			if((url == null)|(url == ""))
			{
                Logger.LogWarning("The url not supplied, returning 404 Page.", "The url supplied was either empty or null.", EventIds._4104);

				return Page404();
			}


			try
			{
				_PageInfo = IPageDataProvider.Page_SELECT_ByURLForLivePublishing( url );
				_Page = new Page();
				_Page.PageID = _PageInfo.PageID;
				_Page.Title = _PageInfo.Title;
				_Page.Keywords = _PageInfo.Keywords;
				_Page.Description = _PageInfo.Description;
				_Page.Url = _PageInfo.Url;
				_Page.LastModified = _PageInfo.LastModified;
				_Page.LastModifiedBy = _PageInfo.LastModifiedBy;
				_Page.IsSearchable = _PageInfo.IsSearchable;
				_Page.IsLive = _PageInfo.IsLive;
                _Page.ContentItems = IContentDataProvider.Content_SELECT_PageByIDForLivePublishing(_Page.PageID);

				return _Page;
			}
			catch( System.Exception ex )
			{
                Logger.LogException("Failed to construct Page object, returning 404 Page.", ex, EventIds._4101, string.Format("Requested URL = {0}", url));

				return Page404();
			}			
		}



		/// <summary>
		/// This  constructor creates a new instance of a Page based on the arguments supplied 
		/// and saves the page straight away.
		/// </summary>
		public static Page SaveNewPage( 
			string userWhoIsAddingPage, 
			string title, 
			string url,
			string keywords,
			string description,
			bool isLive, 
			bool isSearchable )
		{

            // The url must end with .aspx in order for the Default HttpHandler to work. 
            if (!url.EndsWith(".aspx"))
            {
                url = string.Format("{0}.aspx", url);
            }


			// Save a placeholder copy for the new page in order to get the PageID. 
			// As we do this we will also set some of the properties of the page to the desired values.
			// Won't set URL until we have the PageID.
			// Set isLive and isSearchable to false as we haven't finished yet:
			int pageId = IPageDataProvider.Page_INSERT( new Morphfolia.Common.Info.PageSaveNewInfo(
				title,
				url,
				keywords,
				description,
				userWhoIsAddingPage,
				isSearchable,
				isLive) );



            Auditor.LogAuditEntry(pageId, AuditableObjects.Page, "Created");



			// Check that Page_INSERT was successful:
			if( pageId < 1 )
			{
				throw new ApplicationException("Page_INSERT must have failed: pageId < 1");
			}

			_Page = new Page();

			_Page.PageID = pageId;
			_Page.Title = title;
			_Page.Url = url;
			_Page.Keywords = keywords;
			_Page.Description = description;
			_Page.IsSearchable = isSearchable;
			_Page.IsLive = isLive;

			//			// Finally add the content item to the page ????:
			//			Morphfolia.Common.Info.PageContentUpdateInfoCollection pageContentUpdateInfoCollection = new Morphfolia.Common.Info.PageContentUpdateInfoCollection();
			//			pageContentUpdateInfoCollection.Add( new Morphfolia.Common.Info.PageContentUpdateInfo( newPageID, contentId ) );
			//			Save( userWhoIsAddingPage, pageContentUpdateInfoCollection );

			return _Page;
		}


        public static void DeletePageById(int pageId)
        {
            IPageDataProvider.Page_DELETE_ByPageID(pageId);
        }
	}
}
