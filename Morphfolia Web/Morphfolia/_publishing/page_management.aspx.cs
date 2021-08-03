// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Morphfolia.Web._publishing
{
	/// <summary>
	/// Summary description for page_management.
	/// </summary>
	public partial class page_management : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

//			System.Text.StringBuilder sb = new System.Text.StringBuilder();
//			sb.AppendFormat("ApplicationPath = [{0}]<br>", HttpContext.Current.Request.ApplicationPath );
//			sb.AppendFormat("Url = [{0}]<br>", HttpContext.Current.Request.Url );
//			sb.AppendFormat("ToString = [{0}]<br>", HttpContext.Current.Request.ToString() );
//			sb.AppendFormat("Path = [{0}]<br>", HttpContext.Current.Request.Path );
//			sb.AppendFormat("server_name = [{0}]<br>", HttpContext.Current.Request.ServerVariables["server_name"].ToString() );
//			this.Literal1.Text = sb.ToString();

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
