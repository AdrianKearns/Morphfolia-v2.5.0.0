// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

namespace Morphfolia.Web.UserControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for PageContentViewer.
	/// </summary>
	public partial class PageContentViewer : System.Web.UI.UserControl
	{
		//protected System.Web.UI.WebControls.Literal PageContent;


		//private Morphfolia.Business.PagePublisher _PagePublisher;
		//private Morphfolia.Business.Page _CurrentPage;


		private int _PageId;
		public int PageID
		{
			get{ return this._PageId; }
			set{ this._PageId = value; }
		}



		public PageContentViewer(  )
		{
			SetPageIDFromHttpContext();
		}


		public PageContentViewer( int pageId )
		{
			this._PageId = pageId;
		}


		protected void Page_Load(object sender, System.EventArgs e)
		{
			//PageContent.Text = CMS.Business.PagePublisher.GetPage( this._PageId ).PublishAllContent();
			//this.

			litPageContent = new Literal();
			litPageContent.ID = "litPageContent";
			this.Controls.Add( litPageContent );
			litPageContent.Visible = true;
		}



		/// <summary>
		/// Looks in the Current HttpContext for the value of "pid" if it is there.
		/// </summary>
		public void SetPageIDFromHttpContext()
		{
			this._PageId = -1;


			// Attempt to locate page id from the forms collection:
			if( HttpContext.Current.Request.Form["pid"] != null )
			{
				if( HttpContext.Current.Request.Form["pid"].ToString() != "" )
				{
					try
					{
						this._PageId = int.Parse( HttpContext.Current.Request.Form["pid"].ToString() );
					}
					catch
					{
						this._PageId = -1;
					}
				}
			}

			// Attempt to locate page id from the QueryString:
			if( HttpContext.Current.Request.QueryString["pid"] != null )
			{
				if( HttpContext.Current.Request.QueryString["pid"].ToString() != "" )
				{
					try
					{
						this._PageId = int.Parse( HttpContext.Current.Request.QueryString["pid"].ToString() );
					}
					catch
					{
						this._PageId = -1;
					}				
				}
			}
		}



		public void Render( bool setPageIDFromHttpContext )
		{
			if( setPageIDFromHttpContext )
			{
				SetPageIDFromHttpContext();
			}
//			Morphfolia.Business.PagePublisher pagePublisher = new Morphfolia.Business.PagePublisher();
//			Morphfolia.Business.Page page = new Morphfolia.Business.Page( this._PageId );
//			//PageContent.Text = p.GetPageNotStatic( this._PageId ).PublishAllContent();
//			//PageContent.Text = page.PublishAllContent();
//
//
//			litPageContent.Text = "Yo";
//


			litPageContent.Text = Morphfolia.Business.PageFactory.Page( this._PageId ).PublishAllContent();
		}

		public void Render( int pageId )
		{
			this._PageId = pageId;
			litPageContent.Text = Morphfolia.Business.PageFactory.Page( pageId ).PublishAllContent();
		}


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}
		#endregion
	}
}
