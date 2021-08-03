// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using Morphfolia.Business;
using Morphfolia.Common.Info;
using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Collections;

namespace Morphfolia.WebControls
{
	/// <summary>
	/// Summary description for SiteMapNode.
	/// </summary>
	public class SiteMapNode : WebControl, INamingContainer
	{

		/// <summary>
		/// Holds a working copy of the data required by Nodes during construction.
		/// </summary>
		public class WorkingInfo
		{
			private string text;
			public string Text
			{
				get{ return this.text; }
				set{ this.text = value; }
			}


			private string workingUrl = String.Empty;
			public string WorkingUrl
			{
				get{ return this.workingUrl; }
				set{ this.workingUrl = value; }
			}


			private string fullUrl = String.Empty;
			public string FullUrl
			{
				get{ return this.fullUrl; }
				set{ this.fullUrl = value; }
			}




			public WorkingInfo( string text, string url )
			{
				this.Text = text;
				this.FullUrl = url;
				this.WorkingUrl = url;
			}



			public int WorkingUrlSegmentLength
			{
				get
				{ 			
					return this.WorkingUrl.Split( char.Parse("/") ).Length;
				}
			}



			public string GetWorkingUrlToIndex( int index )
			{
				// the index may be 0.
				string temp;
				if( this.WorkingUrl.Equals(String.Empty) )
				{
					return String.Empty;
				}
				else
				{
					if( index >= this.WorkingUrl.Split( char.Parse("/") ).Length )
					{
						// ?
						return String.Empty;
					}
					else
					{
						System.Text.StringBuilder sb = new System.Text.StringBuilder();
						string[] urlSegment = this.WorkingUrl.Split( char.Parse("/") );
						for( int i = 0; i <= index; i++ )
						{
							try
							{
								temp = urlSegment[i];
								sb.AppendFormat("/{0}", temp);
							}
							catch
							{
								string fooo = index.ToString() + "." + this.WorkingUrl.Split( char.Parse("/") ).Length.ToString();
								Console.WriteLine("");
							}
						}
						sb.Remove(0, 1);
						return sb.ToString();
					}
				}
			}


		
			public string GetTailOfWorkingUrlToIndex( int index )
			{
				// the index may be 0.
				string temp;
				if( this.WorkingUrl.Equals(String.Empty) )
				{
					return String.Empty;
				}
				else
				{
					if( index >= this.WorkingUrl.Split( char.Parse("/") ).Length )
					{
						// ?
						return String.Empty;
					}
					else
					{
						System.Text.StringBuilder sb = new System.Text.StringBuilder();
						string[] urlSegment = this.WorkingUrl.Split( char.Parse("/") );
						for( int i = 1; i <= index; i++ )
						{
							try
							{
								temp = urlSegment[i];
								sb.AppendFormat("/{0}", temp);
							}
							catch
							{
								string fooo = index.ToString() + "." + this.WorkingUrl.Split( char.Parse("/") ).Length.ToString();
							}
						}
						if(sb.Length > 0)
						{
							sb.Remove(0, 1);
						}
						return sb.ToString();
					}
				}
			}



			public string GetWorkingUrlSegmentAtIndex( int index )
			{
				if( this.WorkingUrl.Equals(String.Empty) )
				{
					return String.Empty;
				}
				else
				{
					if( index >= this.WorkingUrl.Split( char.Parse("/") ).Length )
					{
						// ?
						return String.Empty;
					}
					else
					{
						return this.WorkingUrl.Split( char.Parse("/") )[index];
					}
				}
			}
		}



		private Table tblSiteMapNode;
		private TableRow trText;
		private TableCell tdText;
		private TableCell tdIcon;
		private Image imgIcon;
		private TableRow trLeafs;
		private TableCell tdLeafs;
		private TableRow trNodes;
		private TableCell tdNodes;
		private TableCell tdIndent;



        public SiteMapNode()
        {
        }


        public SiteMapNode(SiteMap parentSiteMap)
        {
            ParentSiteMap = parentSiteMap;            
        }


        public SiteMapNode(SiteMapNode parentSiteMapNode)
        {
            ParentNode = parentSiteMapNode;
            if (parentSiteMapNode != null)
            {
                if (parentSiteMapNode.ParentSiteMap != null)
                {
                    ParentSiteMap = parentSiteMapNode.ParentSiteMap;
                }
            }
        }


		private string text = string.Empty;
		/// <summary>
		/// The text which is visble to users (the visible value of the node).
		/// </summary>
		public string Text
		{
			get{ return this.text; }
			set{ this.text = value; }
		}


		public override string ToString()
		{
			return this.Url;
		}


		private string url = String.Empty;
		/// <summary>
		/// The url which defines the full "location" of the node.
		/// </summary>
		public string Url
		{
			get{ return this.url; }
			set{ this.url = value; }
		}


		/// <summary>
		/// The number of segments in the Url.
		/// e.g: the UrlSegmentLength for the url "a/b/c/page.aspx" = 4.
		/// </summary>
		public int UrlSegmentLength
		{
			get{ 			
				return this.Url.Split( char.Parse("/") ).Length;
			}
		}

		
		private string iconImageUrl;
		/// <summary>
		/// The text which is visble to users (the visible value of the node).
		/// </summary>
		public string IconImageUrl
		{
			get{ 
				if( this.iconImageUrl == null )
				{
					 this.iconImageUrl = "Morphfolia/g/folder.gif";
				}
				
				return this.iconImageUrl; }
			set{ this.iconImageUrl = value; }
		}


        private SiteMap parentSiteMap;
        public SiteMap ParentSiteMap
        {
            get { return this.parentSiteMap; }
            set { this.parentSiteMap = value; }
        }


        private SiteMapNode parentNode;
        public SiteMapNode ParentNode
        {
            get { return this.parentNode; }
            set { this.parentNode = value; }
        }


        private SiteMapNodeCollection nodes;
        /// <summary>
        /// Child nodes held by the Node.
        /// </summary>
        public SiteMapNodeCollection Nodes
        {
            get
            {
                if (this.nodes == null)
                {
                    this.nodes = new SiteMapNodeCollection();
                }
                return this.nodes;
            }
            set { this.nodes = value; }
        }


        private SiteMapLeafCollection leafs = new SiteMapLeafCollection();
        /// <summary>
        /// Child leafs (node branch end points) of the node.
        /// </summary>
        public SiteMapLeafCollection Leafs
        {
            get { return this.leafs; }
            set { this.leafs = value; }
        }





		public string GetUrlToIndex( int index )
		{
			// the index may be 0.
			string temp;
			if( this.Url.Equals(String.Empty) )
			{
				return String.Empty;
			}
			else
			{
				if( index >= this.Url.Split( char.Parse("/") ).Length )
				{
					// ?
					return String.Empty;
				}
				else
				{
					System.Text.StringBuilder sb = new System.Text.StringBuilder();
					string[] urlSegment = this.Url.Split( char.Parse("/") );
					for( int i = 0; i <= index; i++ )
					{
						try
						{
							temp = urlSegment[i];
							sb.AppendFormat("/{0}", temp);
						}
						catch
						{
							string fooo = index.ToString() + "." + this.Url.Split( char.Parse("/") ).Length.ToString();
							Console.WriteLine("");
						}
					}
					sb.Remove(0, 1);
					return sb.ToString();
				}
			}
		}



		public string GetUrlToIndex( int index, string url )
		{
			// the index may be 0.
			string temp;
			if( url.Equals(String.Empty) )
			{
				return String.Empty;
			}
			else
			{
				if( index >= url.Split( char.Parse("/") ).Length )
				{
					// ?
					return String.Empty;
				}
				else
				{
					System.Text.StringBuilder sb = new System.Text.StringBuilder();
					string[] urlSegment = url.Split( char.Parse("/") );
					for( int i = 0; i <= index; i++ )
					{
						try
						{
							temp = urlSegment[i];
							sb.AppendFormat("/{0}", temp);
						}
						catch
						{
							string fooo = index.ToString() + "." + url.Split( char.Parse("/") ).Length.ToString();
							Console.WriteLine("");
						}
					}
					sb.Remove(0, 1);
					return sb.ToString();
				}
			}
		}



		public string GetUrlSegmentAtIndex( int index )
		{
			if( this.Url.Equals(String.Empty) )
			{
				return String.Empty;
			}
			else
			{
				if( index >= this.Url.Split( char.Parse("/") ).Length )
				{
					// ?
					return String.Empty;
				}
				else
				{
					return this.Url.Split( char.Parse("/") )[index];
				}
			}
		}



		public string GetUrlSegmentAtIndex( int index, string url )
		{
			if( url.Equals(String.Empty) )
			{
				return String.Empty;
			}
			else
			{
				if( index >= url.Split( char.Parse("/") ).Length )
				{
					// ?
					return String.Empty;
				}
				else
				{
					return url.Split( char.Parse("/") )[index];
				}
			}
		}



		/// <summary>
		/// Allows you to add a child node - the full node branch structure 
		/// is automatically put in place as required (by iterative calls).
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public virtual void AddNode( WorkingInfo info )
		{
			SiteMapNode newSiteMapNode = null;
			SiteMapNode node = null;
			SiteMapNode tempNode;

			
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
					SiteMapLeaf leaf = new SiteMapLeaf();
					leaf.Text = info.Text;
					leaf.Url = info.FullUrl;
					this.Leafs.Add( leaf );
				}
				
				// If the incoming info is longer then we need to add the current urlSegment as a child node...
				if( info.WorkingUrlSegmentLength > this.UrlSegmentLength )
				{
					newSiteMapNode = new SiteMapNode(ParentNode);
					newSiteMapNode.Text = info.GetWorkingUrlSegmentAtIndex( this.UrlSegmentLength-1 );
					newSiteMapNode.Url = info.GetWorkingUrlToIndex( this.UrlSegmentLength-1 );
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
					SiteMapLeaf leaf = new SiteMapLeaf();
					leaf.Text = info.Text;
					leaf.Url = info.FullUrl;
					this.Leafs.Add( leaf );
				}


				// ...and call the AddNode method again - passing in the same info object, after removing the 
				// urlSegment which was just added as a child node): 
				info.WorkingUrl = info.GetTailOfWorkingUrlToIndex( info.WorkingUrlSegmentLength-1 );
				node.AddNode( info );
			}

			//return newSiteMapNode;
		}



		/// <exclude />
		protected override void CreateChildControls()
		{
            this.EnableViewState = false;

			tblSiteMapNode = new Table();
			this.Controls.Add( tblSiteMapNode );
			tblSiteMapNode.CellPadding = 5;
			tblSiteMapNode.CellSpacing = 0;
			//tblSiteMapNode.Attributes.Add("border", "1");
            //tblSiteMapNode.EnableViewState = false;
            tblSiteMapNode.ID = "tblSiteMapNode";

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

			tdText = new TableCell();
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


		/// <exclude />
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

				foreach( SiteMapNode node in this.Nodes )
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

	}



	public class SiteMapNodeCollection : CollectionBase
	{
		public SiteMapNode this[ int index ]
		{
			get { return( (SiteMapNode) List[index] ); }
			set { List[index] = value; }
		}


		public int Add( SiteMapNode value )
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
