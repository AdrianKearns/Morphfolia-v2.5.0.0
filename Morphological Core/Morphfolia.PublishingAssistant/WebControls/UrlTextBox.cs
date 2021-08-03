// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Common.Info;
using Morphfolia.Common.Constants.Framework;

namespace Morphfolia.PublishingSystem.WebControls
{


    /// <summary>
    /// Summary description for ContentList
    /// </summary>
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class UrlTextBox : WebControl, INamingContainer
    {       
        public TextBox txtUrl;
        public Panel divExistingURLs;


        protected override void CreateChildControls()
        {
            txtUrl = new TextBox();
            Controls.Add(txtUrl);

            divExistingURLs = new Panel();
            Controls.Add(divExistingURLs);

            ClientScriptManager csm = this.Page.ClientScript;
            if (!csm.IsClientScriptIncludeRegistered(ClientScriptRegistrationKeys.UrlTypeAheadHelper))
            {
                csm.RegisterClientScriptInclude(ClientScriptRegistrationKeys.UrlTypeAheadHelper, string.Format("{0}/Morphfolia/JavaScript/UrlTypeAheadHelper.js", WebUtilities.FullyQualifiedApplicationRoot()));
            }
        }


        public string Text
        {
            get
            {
                EnsureChildControls();
                return txtUrl.Text;
            }
            set
            {
                EnsureChildControls();
                txtUrl.Text = value;
            }
        }


        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            if (Visible)
            {
                divExistingURLs.ID = "divExistingURLs";
                divExistingURLs.Style.Add("border", "solid 1px #cccccc;");
                divExistingURLs.Style.Add("visibility", "hidden");
                divExistingURLs.Style.Add("overflow-y", "scroll");
                divExistingURLs.Style.Add("position", "absolute");

                if (Width == null)
                {
                    divExistingURLs.Style.Add("width", "500px");
                }
                else
                {
                    txtUrl.Width = Width;
                    divExistingURLs.Style.Add("width", Width.ToString());
                }

                divExistingURLs.Style.Add("height", "200px");
                divExistingURLs.Style.Add("background-color", "#fefefe");

                txtUrl.Attributes.Add("onkeyup", string.Format("CheckURLCriteria(this, '{0}')", divExistingURLs.ClientID));
                //txtUrl.Attributes.Add("onkeyup", "alert('divExistingURLs');");


                //this.Render(writer);
                txtUrl.RenderControl(writer);
                divExistingURLs.RenderControl(writer);
            }
        }



    }
}