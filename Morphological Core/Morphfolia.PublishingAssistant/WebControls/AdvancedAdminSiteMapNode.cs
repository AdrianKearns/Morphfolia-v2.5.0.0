// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Common.Info;
using Morphfolia.WebControls;

namespace Morphfolia.PublishingSystem.WebControls
{
	/// <summary>
	/// Summary description for SiteMapNode.
	/// </summary>
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class AdvancedAdminSiteMapNode : Morphfolia.WebControls.SiteMapNode, INamingContainer
	{

		private Table tblSiteMapNode;
		private TableRow trText;
		private TableHeaderCell tdText;
		private TableCell tdIcon;
		private Image imgIcon;
		private TableRow trLeafs;
		private TableCell tdLeafs;
		private TableRow trNodes;
		private TableCell tdNodes;
		private TableCell tdIndent;



        public AdvancedAdminSiteMapNode(AdvancedAdminSiteMap parentSiteMap)
        {
            ParentSiteMap = parentSiteMap;
        }


        public AdvancedAdminSiteMapNode(AdvancedAdminSiteMapNode parentSiteMapNode)
        {
            ParentSiteMapNode = parentSiteMapNode;
            ParentSiteMap = parentSiteMapNode.ParentSiteMap;
        }


		private string iconImageUrl;
		/// <summary>
		/// The text which is visble to users (the visible value of the node).
		/// </summary>
		public new string IconImageUrl
		{
			get
			{ 
				if( this.iconImageUrl == null )
				{
					this.iconImageUrl = "../g/folder.gif";
				}
				
				return this.iconImageUrl; }
			set{ this.iconImageUrl = value; }
		}


        private AdvancedAdminSiteMapNodeCollection nodes;
		/// <summary>
		/// Child nodes held by the Node.
		/// </summary>
        public new AdvancedAdminSiteMapNodeCollection Nodes
		{
			get
			{ 
				if( this.nodes == null )
				{
					this.nodes = new AdvancedAdminSiteMapNodeCollection();
				}
				return this.nodes; 
			}
			set{ this.nodes = value; }
		}

        private AdvancedAdminSiteMap parentSiteMap;
        public new AdvancedAdminSiteMap ParentSiteMap
        {
            get { return parentSiteMap; }
            set { 
                parentSiteMap = value; 
            }
        }

        private AdvancedAdminSiteMapNode parentSiteMapNode;
        public AdvancedAdminSiteMapNode ParentSiteMapNode
        {
            get { return parentSiteMapNode; }
            set { 
                parentSiteMapNode = value;
                if (parentSiteMapNode != null)
                {
                    ParentSiteMap = parentSiteMapNode.ParentSiteMap;
                }
            }
        }


		/// <summary>
		/// Allows you to add a child node - the full node branch structure 
		/// is automatically put in place as required (by iterative calls).
		/// </summary>
		/// <param name="info"></param>
		/// <param name="pageInfo"></param>
		/// <returns></returns>
		public void AddNode( WorkingInfo info, PageInfo pageInfo, AdvancedAdminSiteMapNode parentNode )
		{
            AdvancedAdminSiteMapNode newSiteMapNode = null;
            AdvancedAdminSiteMapNode node = null;
            AdvancedAdminSiteMapNode tempNode;
            ParentSiteMapNode = parentNode;
            ParentSiteMap = parentNode.ParentSiteMap;
			
			// First - see if the node already exists as  child node: 
			if( this.Nodes.Count > 0 )
			{
				for( int n = 0; n < this.Nodes.Count; n++ )
				{
					tempNode = this.Nodes[n];
					if( tempNode.Text.Equals( info.GetWorkingUrlSegmentAtIndex(this.UrlSegmentLength-1) ) )
					{
						// No, we don't: 
						node = this.Nodes[n];
						break;
					}
				}
			}

	
			if( node == null )
			{
				// If it doesn't - add it as a leaf if the UrlSegmentLength 
				// matches the poisition of this node:
				if( info.WorkingUrlSegmentLength == this.UrlSegmentLength )
				{
                    AdvancedAdminSiteMapLeaf leaf = new AdvancedAdminSiteMapLeaf(ParentSiteMap);
					leaf.Text = info.Text;
					leaf.Url = info.FullUrl;
					this.Leafs.Add( leaf );
					leaf.PageInfo = pageInfo;
                    //leaf.ParentSiteMap = ParentSiteMap;
                    leaf.CreateChildControlsComplete += new Morphfolia.PublishingSystem.WebControls.AdvancedAdminSiteMapLeaf.onCreateChildControlsComplete(leaf_CreateChildControlsComplete);
				}
				
				// If the incoming info is longer then we need to add the current urlSegment as a child node...
				if( info.WorkingUrlSegmentLength > this.UrlSegmentLength )
				{
                    newSiteMapNode = new AdvancedAdminSiteMapNode(ParentSiteMapNode);
					newSiteMapNode.Text = info.GetWorkingUrlSegmentAtIndex( this.UrlSegmentLength-1 );
					newSiteMapNode.Url = info.GetWorkingUrlToIndex( this.UrlSegmentLength-1 );
                    //newSiteMapNode.ParentSiteMapNode = ParentSiteMapNode;
					this.Nodes.Add( newSiteMapNode );
					node = newSiteMapNode;
				}
			}


			if( node != null )
			{			
				// If it doesn't - add it as a leaf if the UrlSegmentLength 
				// matches the poisition of this node:
				if( info.WorkingUrlSegmentLength == this.UrlSegmentLength )
				{
                    AdvancedAdminSiteMapLeaf leaf = new AdvancedAdminSiteMapLeaf(ParentSiteMap);
					leaf.Text = info.Text;
					leaf.Url = info.FullUrl;
					this.Leafs.Add( leaf );
					leaf.PageInfo = pageInfo;
                    //leaf.ParentSiteMap = ParentSiteMap;
                    leaf.CreateChildControlsComplete += new Morphfolia.PublishingSystem.WebControls.AdvancedAdminSiteMapLeaf.onCreateChildControlsComplete(leaf_CreateChildControlsComplete);
				}


				// ...and call the AddNode method again - passing in the same info object, after removing the 
				// urlSegment which was just added as a child node): 
				info.WorkingUrl = info.GetTailOfWorkingUrlToIndex( info.WorkingUrlSegmentLength-1 );
                node.AddNode(info, pageInfo, node);
			}

		}



		protected override void CreateChildControls()
		{
            this.EnableViewState = false;

			tblSiteMapNode = new Table();
			this.Controls.Add( tblSiteMapNode );
			tblSiteMapNode.CellPadding = 5;
			tblSiteMapNode.CellSpacing = 0;
			//tblSiteMapNode.Attributes.Add("border", "1");

			trText = new TableRow();
			this.Controls.Add( trText );
			tblSiteMapNode.Rows.Add( trText );

			tdIcon = new TableCell();
			this.Controls.Add( tdIcon );
			trText.Cells.Add( tdIcon );
			tdIcon.VerticalAlign = VerticalAlign.Top;

			imgIcon = new Image();
			this.Controls.Add( imgIcon );
			tdIcon.Controls.Add( imgIcon );
			imgIcon.ImageUrl = this.IconImageUrl;

			tdText = new TableHeaderCell();
			this.Controls.Add( tdText );
			trText.Cells.Add( tdText );
			tdText.Style.Add("font-weight", "700");
			tdText.VerticalAlign = VerticalAlign.Top;

			//----------------------------------------------
			// Leafs:
			//----------------------------------------------
			trLeafs = new TableRow();
			this.Controls.Add( trLeafs );
			tblSiteMapNode.Rows.Add( trLeafs );

			tdIndent = new TableCell();
			this.Controls.Add( tdIndent );
			trLeafs.Cells.Add( tdIndent );
			tdIndent.Text = "&nbsp;";

			tdLeafs = new TableCell();
			this.Controls.Add( tdLeafs );
			trLeafs.Cells.Add( tdLeafs );

			//----------------------------------------------
			// Nodes:
			//----------------------------------------------
			trNodes = new TableRow();
			this.Controls.Add( trNodes );
			tblSiteMapNode.Rows.Add( trNodes );

			tdIndent = new TableCell();
			this.Controls.Add( tdIndent );
			trNodes.Cells.Add( tdIndent );
			tdIndent.Text = "&nbsp;";

			tdNodes = new TableCell();
			this.Controls.Add( tdNodes );
			trNodes.Cells.Add( tdNodes );
		}



		protected override void Render(HtmlTextWriter writer)
		{
			EnsureChildControls();



			tdText.Text = this.Text;


			if( this.Leafs.Count == 0 )
			{
				trLeafs.Visible = false;
			}
			else
			{
				trLeafs.Visible = true;

				foreach( SiteMapLeaf leaf in this.Leafs )
				{
					this.Controls.Add( leaf );
					tdLeafs.Controls.Add( leaf );
				}
			}


			if( this.Nodes.Count == 0 )
			{
				trNodes.Visible = false;
			}
			else
			{
				trNodes.Visible = true;

				foreach( Morphfolia.WebControls.SiteMapNode node in this.Nodes )
				{
					this.Controls.Add( node );
					tdNodes.Controls.Add( node );
				}
			}


			if( Visible )
			{
				tblSiteMapNode.RenderControl( writer );
			}
		}



        private void leaf_CreateChildControlsComplete(AdvancedAdminSiteMapLeaf adminSiteMapLeaf)
		{
			adminSiteMapLeaf.SetPageInfo();
		}
	}



    public class AdvancedAdminSiteMapNodeCollection : CollectionBase
	{
        public AdvancedAdminSiteMapNode this[int index]
		{
            get { return ((AdvancedAdminSiteMapNode)List[index]); }
			set { List[index] = value; }
		}


        public int Add(AdvancedAdminSiteMapNode value)
		{
			return( List.Add( value ) );
		}

		public static string GetPathToDepth( int depth, string url )
		{
			if( url.Equals(String.Empty) )
			{
				return String.Empty;
			}
			else
			{
				//string[] urlSegment = this.url.Split( char.Parse("/") );				
				if( depth > url.Split( char.Parse("/") ).Length )
				{
					// ?
					return String.Empty;
				}
				else
				{
					System.Text.StringBuilder sb = new System.Text.StringBuilder();
					string[] urlSegment = url.Split( char.Parse("/") );
					for( int i = 0; i < depth; i++ )
					{
						string hoo = urlSegment[i];
						sb.AppendFormat("/{0}", urlSegment[i]);
					}
					sb.Remove(0, 1);
					return sb.ToString();
				}
			}
		}
	}
}