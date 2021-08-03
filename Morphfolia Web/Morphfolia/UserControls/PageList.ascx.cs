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
	///		Summary description for PageList.
	/// </summary>
	public partial class PageList : System.Web.UI.UserControl
	{
		protected HttpContext CurrentContext = HttpContext.Current;

		private Morphfolia.Common.Info.PageInfoCollection _PageInfoCollection;
		//private Morphfolia.Business.PageLister _PageLister;
//		private Morphological.Utilities.DateAndTime _DateAndTime = new Morphological.Utilities.DateAndTime();
		private System.Web.UI.WebControls.Button _btnEdit;



		private void btnEdit_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
		{
			CurrentContext.Response.Redirect( string.Format("edit_page.aspx?p={0}", e.CommandArgument.ToString()) );		
		}


		protected void Page_Load(object sender, System.EventArgs e)
		{
			TableCell td;
			System.Web.UI.WebControls.TableRow tr;
            _PageInfoCollection = Morphfolia.Business.PageLister.List();

			//tblPageList.Rows.Clear();tblPageList.Attributes.Add("border", "1");

			if(_PageInfoCollection.Count == 0)
			{
				tr = new TableRow();
				tr.Cells.Add( this.TableCell("_PageInfoCollection.Count == 0") );
				tblPageList.Rows.Add( tr );
			}
			else
			{
				tr = new TableRow();
				tr.CssClass = "ListHeader";
				tr.Cells.Add( this.TableCell( "&nbsp;" ) );
				tr.Cells.Add( this.TableCell( "Title", 5 ) );
				tr.Cells.Add( this.TableCell( "&nbsp;" ) );
				tblPageList.Rows.Add( tr );

				tr = new TableRow();
				tr.CssClass = "ListHeader";
				tr.Cells.Add( this.TableCell( "ID" ) );
				tr.Cells.Add( this.TableCell( "Url", 6 ) );
				tblPageList.Rows.Add( tr );

				tr = new TableRow();
				tr.CssClass = "ListHeader";
				tr.Cells.Add( this.TableCell( "&nbsp;" ) );
				tr.Cells.Add( this.TableCell( "Last Modified" ) );
				tr.Cells.Add( this.TableCell( "Last Modified By" ) );
				tr.Cells.Add( this.TableCell( "Live" ) );
				tr.Cells.Add( this.TableCell( "Searchable", 2 ) );

				td = new TableCell();
				td.Text = "&nbsp;";
				td.Width = System.Web.UI.WebControls.Unit.Pixel(100);
				tr.Cells.Add( td );
				tblPageList.Rows.Add( tr );




				foreach(Morphfolia.Common.Info.PageInfo pageInfo in _PageInfoCollection)
				{
					tr = new TableRow();
					tr.Cells.Add( this.TableCellAsDivider(7) );
					tblPageList.Rows.Add( tr );


					_btnEdit = new Button();
					_btnEdit.Text = "Edit";
					_btnEdit.ID = string.Format("editPage_{0}", pageInfo.PageID.ToString() );
					_btnEdit.CommandName = "PageID";
					_btnEdit.CommandArgument = pageInfo.PageID.ToString();
					_btnEdit.Command += new System.Web.UI.WebControls.CommandEventHandler(this.btnEdit_Command);



					tr = new TableRow();
					tr.Cells.Add( this.TableCellAsButton( _btnEdit, System.Web.UI.WebControls.HorizontalAlign.Right ) );
					tr.Cells.Add( this.TableCell( string.Format("<b>{0}</b>", pageInfo.Title), 5 ) );
					tblPageList.Rows.Add( tr );



					tr = new TableRow();
					tr.Cells.Add( this.TableCell( pageInfo.PageID.ToString() ) );
					tr.Cells.Add( this.TableCell( string.Format("<a href='../{0}' target='_blank'>{0}</a>", pageInfo.Url, CurrentContext.Request.ApplicationPath), 5 ) );
					tblPageList.Rows.Add( tr );


					tr = new TableRow();
					tr.Cells.Add( this.TableCell( "&nbsp;" ) );
					//tr.Cells.Add( this.TableCell( _DateAndTime.DD_MMM_YYYY( pageInfo.LastModified ) ) );
                    tr.Cells.Add(this.TableCell( Morphfolia.Common.Utilities.DateTimeHelper.DDMMMYYYY(pageInfo.LastModified)));

					tr.Cells.Add( this.TableCell( pageInfo.LastModifiedBy ) );
					tr.Cells.Add( this.TableCellAsBool( pageInfo.IsLive, System.Web.UI.WebControls.HorizontalAlign.Left ) );
					tr.Cells.Add( this.TableCellAsBool( pageInfo.IsSearchable, System.Web.UI.WebControls.HorizontalAlign.Left ) );

					td = new TableCell();
					td.Width = System.Web.UI.WebControls.Unit.Percentage(100);
					td.Text = "&nbsp;";
					tr.Cells.Add( td );
					tblPageList.Rows.Add( tr );
				}

				tr = new TableRow();
				tr.Cells.Add( this.TableCell( "&nbsp;" ) );
				tr.Cells.Add( this.TableCell( "<img src='../g/spacer.gif' border='0' height='1' width='150'>" ) );
				tr.Cells.Add( this.TableCell( "<img src='../g/spacer.gif' border='0' height='1' width='150'>" ) );
				tr.Cells.Add( this.TableCell( "<img src='../g/spacer.gif' border='0' height='1' width='50'>" ) );
				tr.Cells.Add( this.TableCell( "<img src='../g/spacer.gif' border='0' height='1' width='50'>" ) );
				tr.Cells.Add( this.TableCell( "<img src='../g/spacer.gif' border='0' height='1' width='100'>" ) );
				tr.Cells.Add( this.TableCell( "<img src='../g/spacer.gif' border='0' height='1' width='150'>" ) );
				tblPageList.Rows.Add( tr );
			}
		}


		private System.Web.UI.WebControls.TableCell TableCellAsHeader( string text )
		{
			System.Web.UI.WebControls.TableCell td = new TableCell();
			td.Text = string.Format("<b>{0}</b>", text);
			td.VerticalAlign = VerticalAlign.Top;
			return td;
		}

		private System.Web.UI.WebControls.TableCell TableCellAsHeader( string text, int colspan )
		{
			System.Web.UI.WebControls.TableCell td = new TableCell();
			td.Text = string.Format("<b>{0}</b>", text);
			td.VerticalAlign = VerticalAlign.Top;
			td.ColumnSpan = colspan;
			return td;
		}


		private System.Web.UI.WebControls.TableCell TableCell( string text )
		{
			System.Web.UI.WebControls.TableCell td = new TableCell();
			td.Text = text;
			td.VerticalAlign = VerticalAlign.Top;
			return td;
		}

		private System.Web.UI.WebControls.TableCell TableCell( string text, string toolTip )
		{
			System.Web.UI.WebControls.TableCell td = new TableCell();
			td.Text = text;
			td.VerticalAlign = VerticalAlign.Top;
			td.ToolTip = toolTip;
			return td;
		}

		private System.Web.UI.WebControls.TableCell TableCell( string text, int colspan )
		{
			System.Web.UI.WebControls.TableCell td = new TableCell();
			td.Text = text;
			td.VerticalAlign = VerticalAlign.Top;
			td.ColumnSpan = colspan;
			return td;
		}

		private System.Web.UI.WebControls.TableCell TableCellAsBool( bool theValue, System.Web.UI.WebControls.HorizontalAlign horizontalAlign )
		{
			System.Web.UI.WebControls.TableCell td = new TableCell();
			td.HorizontalAlign = horizontalAlign;
			td.VerticalAlign = VerticalAlign.Top;

			if(theValue)
			{
				td.Text = "<img src='../g/tickbox_ticked.gif' width='16' height='16' title='Yes' border='0'>";
			}
			else
			{
				td.Text = "<img src='../g/tickbox_empty.gif' width='16' height='16' title='No' border='0'>";
			}

			return td;
		}

		private System.Web.UI.WebControls.TableCell TableCellAsButton( Button button, System.Web.UI.WebControls.HorizontalAlign horizontalAlign )
		{
			System.Web.UI.WebControls.TableCell td = new TableCell();
			td.HorizontalAlign = horizontalAlign;
			td.VerticalAlign = VerticalAlign.Top;
			td.Controls.Add( button );
			return td;
		}
		private System.Web.UI.WebControls.TableCell TableCellAsDivider( int colspan )
		{
			System.Web.UI.WebControls.TableCell td = new TableCell();
			//td.CssClass = "line";
			td.Text = "<img src='../g/spacer.gif' class='line' width='100%' height='1' border='0'>";
			td.ColumnSpan = colspan;
			return td;
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
