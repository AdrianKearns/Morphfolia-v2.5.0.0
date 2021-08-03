// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using Morphfolia.Business;

namespace Morphfolia.Web._publishing
{
	/// <summary>
	/// Summary description for content_management.
	/// </summary>
    public partial class content_management : System.Web.UI.Page
	{
        protected Morphfolia.PublishingSystem.WebControls.ContentList contentList = new Morphfolia.PublishingSystem.WebControls.ContentList();

        private Common.ContentTypes.ContentTypeDefinition ctd = Common.ContentTypes.All;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (Request.Params["ct"] != null)
            {               
                if (!Request.Params["ct"].ToString().Equals(string.Empty))
                {
                    string contentType = Request.Params["ct"].ToString().ToUpper();
                    switch (contentType)
                    {
                        case "BLOGPOST":
                            ctd = Common.ContentTypes.BlogPost;
                            break;

                        case "OPENMARKUP":
                            ctd = Common.ContentTypes.OpenMarkup;
                            break;

                        default:
                            ctd = Common.ContentTypes.All;
                            break;
                    }
                }
            }

            ContentListContainer.Controls.Add(contentList);
            contentList.ContentListInfoCollection = ContentItemHelper.List(ctd);
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion
	}
}