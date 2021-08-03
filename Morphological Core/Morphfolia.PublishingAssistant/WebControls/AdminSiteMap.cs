// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Common.Info;

namespace Morphfolia.PublishingSystem.WebControls
{
	/// <summary>
	/// Summary description for SiteMap.
	/// </summary>
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class AdminSiteMap : Morphfolia.WebControls.SiteMap, INamingContainer
	{
		//private PageLister _PageLister = new Morphfolia.Business.PageLister();
		private PageInfoCollection _PageInfoCollection;
		private AdminSiteMapNode RootNode;
		private Panel pnlSiteMap;


        public AdminSiteMap()
        {
        }

        public AdminSiteMap(PageInfoCollection pageInfoCollection )
        {
            this._PageInfoCollection = pageInfoCollection;
        }



        private string rootNodeText = "All Pages";
        public new string RootNodeText
        {
            get { return rootNodeText; }
            set { rootNodeText = value; }
        }



		protected override void CreateChildControls()
		{
			if( this._PageInfoCollection == null )
			{
                this._PageInfoCollection = Morphfolia.Business.PageLister.List();
			}

            this.EnableViewState = false;

			pnlSiteMap = new Panel();
			Controls.Add( pnlSiteMap );
            pnlSiteMap.ID = "pnlSiteMap";

			RootNode = new AdminSiteMapNode();
			this.Controls.Add( RootNode );
			pnlSiteMap.Controls.Add( RootNode );
			RootNode.Url = string.Empty;
            RootNode.ID = "RootNode";


			foreach( PageInfo p in this._PageInfoCollection )
			{
				RootNode.AddNode( new Morphfolia.WebControls.SiteMapNode.WorkingInfo( p.Title, p.Url ), p );
			}
		}




		protected override void Render(HtmlTextWriter output)
		{
			EnsureChildControls();

			if( Visible )
			{
                RootNode.Text = RootNodeText;

				pnlSiteMap.RenderControl( output );
			}
		}
	}
}

