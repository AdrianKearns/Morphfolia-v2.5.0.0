// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using Morphfolia.Business;
using System.ComponentModel;
using Morphfolia.Common.Info;
using Morphfolia.Common.Constants.Framework;

namespace Morphfolia.PublishingSystem.WebControls
{
    /// <summary>
    /// Summary description for CustomProperty.
    /// </summary>
    [DesignerAttribute(typeof(Designers.DefaultDesigner))]
    public class CustomProperty : WebControl, INamingContainer, IPostBackDataHandler
    {
        private Table tblCustomProperty;
        private TableRow tr;
        private TableCell tdPropertyName;
        private TableCell tdSuggestedUsage;
        private TableCell tdPropertyValue;
        private TableCell tdDescription;
        private TextBox txtPropertyKey;
        private TextBox txtPropertyValue;


        private Various.InputSizes inputSize = Various.InputSizes.SingleLine30x1;
        public Various.InputSizes InputSize
        {
            get { return inputSize; }
            set { inputSize = value; }
        }


        private int instanceId = Morphfolia.Common.Constants.SystemTypeValues.NullInt;
        public int InstanceId
        {
            get { return instanceId; }
            set { instanceId = value; }
        }


        public string PropertyKey
        {
            get
            {
                EnsureChildControls();
                return txtPropertyKey.Text;
            }
            set
            {
                EnsureChildControls();
                txtPropertyKey.Text = value;
            }
        }

        public string PropertyName
        {
            get
            {
                EnsureChildControls();
                return tdPropertyName.Text;
            }
            set
            {
                EnsureChildControls();
                tdPropertyName.Text = value;
            }
        }

        public String PropertyValue
        {
            get
            {
                return (String)ViewState["PropertyValue"];
            }
            set
            {
                string v = value;
                ViewState["PropertyValue"] = v;
                EnsureChildControls();
                txtPropertyValue.Text = v;
            }
        }




        public string SuggestedUsage
        {
            get
            {
                EnsureChildControls();
                return tdSuggestedUsage.Text;
            }
            set
            {
                EnsureChildControls();
                tdSuggestedUsage.Text = string.Format("Suggested Usage: {0}", value);
            }
        }

        public string Description
        {
            get
            {
                EnsureChildControls();
                return tdDescription.Text;
            }
            set
            {
                EnsureChildControls();
                tdDescription.Text = string.Format("Description: {0}", value);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            EnsureChildControls();
        }


        protected override void CreateChildControls()
        {
            //base.CreateChildControls ();

            tblCustomProperty = new Table();
            Controls.Add(tblCustomProperty);
            tblCustomProperty.CssClass = "CustomPublishingProperty";
            tblCustomProperty.CellPadding = 3;
            tblCustomProperty.CellSpacing = 0;
            //tblCustomProperty.Attributes.Add("border", "1");
            tblCustomProperty.Width = Unit.Percentage(100);


            tr = new TableRow();
            Controls.Add(tr);
            tblCustomProperty.Rows.Add(tr);

            tdPropertyName = new TableCell();
            Controls.Add(tdPropertyName);
            tr.Cells.Add(tdPropertyName);
            tdPropertyName.Style.Add("font-weight", "bold");
            tdPropertyName.VerticalAlign = VerticalAlign.Top;
            tdPropertyName.Width = Unit.Percentage(30);

            tdPropertyValue = new TableCell();
            Controls.Add(tdPropertyValue);
            tr.Cells.Add(tdPropertyValue);
            tdPropertyValue.VerticalAlign = VerticalAlign.Top;
            //tdPropertyValue.HorizontalAlign = HorizontalAlign.Right;
            tdPropertyValue.Width = Unit.Percentage(70);

            txtPropertyValue = new TextBox();
            Controls.Add(txtPropertyValue);
            tdPropertyValue.Controls.Add(txtPropertyValue);
            txtPropertyValue.ID = "txtPropertyValue";

            txtPropertyKey = new TextBox();
            Controls.Add(txtPropertyKey);
            tdPropertyValue.Controls.Add(txtPropertyKey);
            txtPropertyKey.Style.Add("visibility", "Hidden");
            txtPropertyKey.Style.Add("position", "absolute");


            tr = new TableRow();
            Controls.Add(tr);
            tblCustomProperty.Rows.Add(tr);

            tdDescription = new TableCell();
            Controls.Add(tdDescription);
            tr.Cells.Add(tdDescription);
            tdDescription.ColumnSpan = 2;


            tr = new TableRow();
            Controls.Add(tr);
            tblCustomProperty.Rows.Add(tr);

            tdSuggestedUsage = new TableCell();
            Controls.Add(tdSuggestedUsage);
            tr.Cells.Add(tdSuggestedUsage);
            tdSuggestedUsage.ColumnSpan = 2;
        }



        protected override void RenderContents(HtmlTextWriter writer)
        {
            switch (InputSize)
            {
                case Various.InputSizes.MultipleLine40x7:
                    txtPropertyValue.MaxLength = 2000;
                    txtPropertyValue.Columns = 40;
                    txtPropertyValue.Rows = 7;
                    txtPropertyValue.TextMode = TextBoxMode.MultiLine;
                    break;

                case Various.InputSizes.MultipleLine30x3:
                    txtPropertyValue.MaxLength = 2000;
                    txtPropertyValue.Columns = 30;
                    txtPropertyValue.Rows = 3;
                    txtPropertyValue.TextMode = TextBoxMode.MultiLine;
                    break;

                case Various.InputSizes.SingleLine30x1:
                    txtPropertyValue.MaxLength = 2000;
                    txtPropertyValue.Columns = 30;
                    txtPropertyValue.Rows = 1;
                    txtPropertyValue.TextMode = TextBoxMode.SingleLine;
                    break;
            }

            tblCustomProperty.RenderControl(writer);
        }



        public void Save()
        {
            StaticCustomPropertyHelper.DeleteControlPropertiesByInstanceAndPropertyKey(InstanceId, PropertyKey);
            StaticCustomPropertyHelper.SaveControlPropertyByInstance(
                new SaveNewCustomPropertyInstanceInfo(
                    InstanceId,
                    Morphfolia.Common.ControlPropertyTypeFactory.CustomPropertyType(),
                    PropertyKey,
                    txtPropertyValue.Text)
                );
        }




        #region ...   IPostBackDataHandler Members   ...

        public void RaisePostDataChangedEvent()
        {
            // TODO:  Add CustomProperty.RaisePostDataChangedEvent implementation
        }

        public virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {

            String presentValue = PropertyValue;
            String postedValue = postCollection[postDataKey];

            if (presentValue == null || !presentValue.Equals(postedValue))
            {
                PropertyValue = postedValue;
                return true;
            }

            return false;
        }

        #endregion
    }
}