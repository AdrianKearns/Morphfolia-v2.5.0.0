// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Business;
using Morphfolia.Common.Info;


namespace Morphfolia.WebControls
{
	/// <summary>
	/// Summary description for SiteMap.
	/// </summary>
	public class SiteMap : WebControl, INamingContainer
	{
		//private PageLister _PageLister = new Morphfolia.Business.PageLister();
		private PageInfoCollection _PageInfoCollection;
		private Morphfolia.WebControls.SiteMapNode RootNode;
		private Panel pnlSiteMap;



		private string rootNodeText = "Site Map";
		public string RootNodeText
		{
			get{ return rootNodeText; }
			set{ rootNodeText = value; }
		}



        public SiteMap()
        {
        }

        public SiteMap(Morphfolia.WebControls.SiteMapNode rootNode)
        {
            RootNode = rootNode;
        }


		protected override void CreateChildControls()
		{
            //this.EnableViewState = false;

			if( this._PageInfoCollection == null )
			{
				// Only show pages that are both Live and Searchable: 
                this._PageInfoCollection = Morphfolia.Business.PageLister.List(new PageListerSearchCriteria(true, true));
			}


			pnlSiteMap = new Panel();
			Controls.Add( pnlSiteMap );
            pnlSiteMap.ID = "pnlSiteMap";


            if (RootNode == null)
            {
                RootNode = new Morphfolia.WebControls.SiteMapNode(this);
                this.Controls.Add(RootNode);
                pnlSiteMap.Controls.Add(RootNode);
                RootNode.Url = string.Empty;
                RootNode.ID = "RootNode";
            }


            if (this._PageInfoCollection != null)
            {
                foreach (PageInfo p in this._PageInfoCollection)
                {
                    RootNode.AddNode(new Morphfolia.WebControls.SiteMapNode.WorkingInfo(p.Title, p.Url));
                }
            }
		}


        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            if (Visible)
            {
                //if (RootNode == null)
                //{
                //    throw new AccessViolationException();
                //}

                //if (RootNodeText == null)
                //{
                //    throw new AccessViolationException();
                //}

                if (RootNode != null)
                {
                    RootNode.Text = RootNodeText;
                }

                base.RenderContents(writer);
            }
        }


        //protected override void Render(HtmlTextWriter output)
        //{
        //    EnsureChildControls();

        //    if( Visible )
        //    {
        //        RootNode.Text = RootNodeText;

        //        pnlSiteMap.RenderControl( output );
        //    }
        //}
	}
}
