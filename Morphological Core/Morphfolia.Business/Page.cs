// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using Morphfolia.Common.Info;
using System;
using System.Collections.Specialized; 
using Morphfolia.Common.Logging;
using Morphfolia.Common.Constants;
using Morphfolia.Business.Constants;
using Morphfolia.Business.Logs;

namespace Morphfolia.Business
{
	/// <summary>
	/// Summary description for Page.
	/// </summary>
	public class Page : Morphfolia.Common.Interfaces.IPage
	{
        private static Morphfolia.IDataProvider.IPageDataProvider pageDataProvider = null;
        internal static Morphfolia.IDataProvider.IPageDataProvider PageDataProvider
        {
            get
            {
                if (pageDataProvider == null)
                {
                    pageDataProvider = Helpers.ProviderLoader.Load(DataProviderAppSettingKeys.IPageDataProvider) as Morphfolia.IDataProvider.IPageDataProvider;
                }
                return pageDataProvider;
            }
        }



		private int _PageId = SystemTypeValues.NullInt;
		public int PageID
		{
			set { _PageId = value; }
			get { return _PageId; }
		}

		private string _Title = string.Empty;
		public string Title
		{
			get { return _Title; }
			set { _Title = value; }
		}

		private string _Keywords = string.Empty;
		public string Keywords
		{
			get { return _Keywords; }
			set { _Keywords = value; }
		}

		private string _Description = string.Empty;
		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}

		private string _Url = string.Empty;
        /// <summary>
        /// The Url as stored in the systems under-lying data store.
        /// </summary>
		public string Url
		{
			get { return SafeUrl( _Url ); }
			set { _Url = value; }
		}

		private string _LastModifiedBy = string.Empty;
		public string LastModifiedBy
		{
			get { return _LastModifiedBy; }
			set { _LastModifiedBy = value; }
		}

        private string pageLastModifiedBy = string.Empty;
        /// <summary>
        /// The user that last modified the underlying page record.
        /// </summary>
        public string PageLastModifiedBy
        {
            get { return pageLastModifiedBy; }
            set { pageLastModifiedBy = value; }
        }



		private DateTime _LastModified = SystemTypeValues.NullDate;
		public DateTime LastModified
		{
			get{ return this._LastModified; }
			set{ this._LastModified = value; }
		}

        private DateTime pageLastModified = SystemTypeValues.NullDate;
        /// <summary>
        /// The date and time of the last modification to the underlying page record.
        /// </summary>
        public DateTime PageLastModified
        {
            get { return pageLastModified; }
            set { pageLastModified = value; }
        }

		private bool _IsSearchable = false;
		public bool IsSearchable
		{
			get { return _IsSearchable; }
			set { _IsSearchable = value; }
		}

		private bool _IsLive = false;
		public bool IsLive
		{
			get { return _IsLive; }
			set { _IsLive = value; }
		}


		private ContentInfoCollection _ContentInfoCollection;
		public ContentInfoCollection ContentItems
		{
			get{ return this._ContentInfoCollection; }
			set{ this._ContentInfoCollection = value; }
		}


		public string Content()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			for(int i = 0; i < ContentItems.Count; i++)
			{
				sb.Append( ContentItems[i].Content );
			}
			return sb.ToString();
		}

        


        internal static PageInfo GetPageInfo(int pageId)
        {
            return PageDataProvider.Page_SELECT_PageByID(pageId);
        }


		private string contentLastModifiedBy;
		/// <summary>
		/// Returns the name of the user whom modified either the page or one of it's content items - going by the most recently modified.
		/// </summary>
		public string ContentLastModifiedBy
		{
			get
			{
				if( DateTime.Compare( contentLastModified, SystemTypeValues.NullDate ) == 0 )
				{
					SetContentLastModifiedNContentLastModifiedBy();
				}
				return contentLastModifiedBy;
			}
		}

		private DateTime contentLastModified = SystemTypeValues.NullDate;
		/// <summary>
		/// Returns the DateTime when the page or one of it's content items was most recently modified.
		/// </summary>
		public DateTime ContentLastModified
		{
			get
			{
				if( DateTime.Compare( contentLastModified, SystemTypeValues.NullDate ) == 0 )
				{
					SetContentLastModifiedNContentLastModifiedBy();
				}
				return contentLastModified;
			}
		}



		/// <summary>
		/// Used to populate the ContentLastModified and ContentLastModifiedBy properties.
		/// </summary>
		private void SetContentLastModifiedNContentLastModifiedBy()
		{
			//string ss;
			contentLastModified = this.LastModified;
			contentLastModifiedBy = this.LastModifiedBy;

			if(_ContentInfoCollection.Count > 0)
			{
				for(int i = 0; i < _ContentInfoCollection.Count; i++)
				{

					//ss = string.Format("{0} --- {1}", contentLastModified.ToString(), _ContentInfoCollection[i].LastModified.ToString() );

					if( DateTime.Compare( contentLastModified, _ContentInfoCollection[i].LastModified ) < 0 )
					{
						contentLastModified = _ContentInfoCollection[i].LastModified;
						contentLastModifiedBy = _ContentInfoCollection[i].LastModifiedBy;
					}
				}
			}
		}



		public string PublishAllContent()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			if(_ContentInfoCollection.Count > 0)
			{
				for(int i = 0; i < _ContentInfoCollection.Count; i++)
				{
					sb.Append( _ContentInfoCollection[i].Content );
				}
			}

			return sb.ToString();
		}


		/// <summary>
		/// At the moment this is only called after using the 
		/// public Page( string userWhoIsAddingPage, string newPageName, bool isLive, bool isSearchable, int contentId ) constructor.
		/// </summary>
		/// <param name="nameOfUserInvokingSave"></param>
		/// <param name="pageContentUpdateInfoCollection"></param>
		/// <returns></returns>
		public int SaveAsNew( string nameOfUserInvokingSave )
		{
			return this._PageId;
		}


        /// <summary>
        /// Saves the current page.
        /// </summary>
        /// <param name="nameOfUserInvokingSave"></param>
        /// <param name="pageContentUpdateInfoCollection"></param>
		public void Save()
		{
            SavePage(null);
		}


        public void Save(PageContentUpdateInfoCollection pageContentUpdateInfoCollection)
        {
            SavePage(pageContentUpdateInfoCollection);
        }


        private void SavePage(PageContentUpdateInfoCollection pageContentUpdateInfoCollection)
        {
            if(this.Url.Equals(string.Empty))
            {
                throw new Exceptions.BusinessException("Page.Url must not be empty.");
            }

            // The url must end with .aspx in order for the Default HttpHandler to work. 
            if (!this.Url.EndsWith(".aspx"))
            {
                this.Url = string.Format("{0}.aspx", this.Url);
            }

            Console.WriteLine("SavePage() PageID = " + this.PageID.ToString());
            if (this.PageID == SystemTypeValues.NullInt)
            {
                // Insert new page.
                PageSaveNewInfo pageSaveNewInfo = new PageSaveNewInfo(
                    this.Title, 
                    this.Url, 
                    this.Keywords, 
                    this.Description, 
                    this.LastModifiedBy, 
                    this.IsSearchable, 
                    this.IsLive);

                int pageId = PageDataProvider.Page_INSERT(pageSaveNewInfo);

                Auditor.LogAuditEntry(pageId, AuditableObjects.Page, "Created", this.LastModifiedBy);
            }
            else
            {
                // Update existing page.

                PageUpdateInfo pageUpdateInfo = new PageUpdateInfo(
                    this.PageID,
                    this.Title,
                    this.Url,
                    this.Keywords,
                    this.Description,
                    this.LastModifiedBy,
                    this.IsSearchable,
                    this.IsLive
                 );

                PageDataProvider.Page_UPDATE(pageUpdateInfo);

                Auditor.LogAuditEntry(this.PageID, AuditableObjects.Page, "Updated", this.LastModifiedBy);
            }


            if (pageContentUpdateInfoCollection != null)
            {
                if (pageContentUpdateInfoCollection.Count > 0)
                {
                    PageDataProvider.Page_UPDATE_Content(this._PageId, pageContentUpdateInfoCollection);
                }
            }
        }


		public void Delete()
		{
            PageDataProvider.Page_DELETE_ByPageID(this._PageId);

            Auditor.LogAuditEntry(this._PageId, AuditableObjects.Page, "Deleted", System.Security.Principal.WindowsIdentity.GetCurrent().Name);
		}


		public static string SafeUrl( string urlToParse )
		{

			if( urlToParse.IndexOf(@"\") > -1 )
			{
				urlToParse.Replace(@"\", "/");
			}

			if( urlToParse.IndexOf("?") > -1 )
			{
				urlToParse = urlToParse.Substring(0, urlToParse.IndexOf("?"));
			}

			if( urlToParse.EndsWith("/") )
			{
				urlToParse = string.Format("{0}NewPage.aspx", urlToParse);
			}

			if( !urlToParse.EndsWith(".aspx") )
			{
				urlToParse = string.Format("{0}.aspx", urlToParse);
			}

			return urlToParse;
		}

	}
}