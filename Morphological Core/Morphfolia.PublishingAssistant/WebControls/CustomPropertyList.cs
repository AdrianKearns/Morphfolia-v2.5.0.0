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
	public class CustomPropertyList : WebControl, INamingContainer
	{
		//private Table tblCustomPropertyList;
		//private TableRow tr;
		//private TableCell td;
        private CustomProperty customProperty;


		private int instanceId = Morphfolia.Common.Constants.SystemTypeValues.NullInt;
		public int InstanceId
		{
			get{ return instanceId; }
			set{ instanceId = value; }
		}


        private CustomPropertyInstanceInfoCollection props = new CustomPropertyInstanceInfoCollection();
        public CustomPropertyInstanceInfoCollection Properties
        {
            get { return props; }
            set { props = value;  }
        }


        //protected override void CreateChildControls()
        //{
        //    //tblCustomPropertyList = new Table();
        //    //Controls.Add( tblCustomPropertyList );
        //    ////tblCustomPropertyList.CssClass = "CustomPublishingProperty";
        //    //tblCustomPropertyList.Attributes.Add("border", "1");
        //    //tblCustomPropertyList.Width = Unit.Percentage(100);


        //    //tr = new TableRow();
        //    //Controls.Add( tr );
        //    //tblCustomPropertyList.Rows.Add( tr );

        //    //td = new TableCell();
        //    //Controls.Add(td);
        //    //tr.Cells.Add(td);
        //}



        private void Populate()
        {
            if (Properties.Count == 0)
            {
                Label lblMsg = new Label();
                Controls.Add(customProperty);
                lblMsg.Text = "No properties are available.";
            }
            else
            {
                CustomPropertyInstanceInfo property;
                for (int i = 0; i < Properties.Count; i++)
                {
                    property = (CustomPropertyInstanceInfo)Properties[i];
                    customProperty = new CustomProperty();
                    Controls.Add(customProperty);
                    customProperty.InstanceId = property.InstanceID;
                    customProperty.PropertyKey = property.PropertyKey;
                    customProperty.PropertyValue = property.PropertyValue;
                }
            }
        }



        protected override void RenderContents(HtmlTextWriter writer)
        {
            EnsureChildControls();

            if (Visible)
            {
                Populate();
                base.RenderContents(writer);
            }
        }



		public void Save()
		{
            throw new NotImplementedException();

            //CustomPropertyHelper.DeleteControlPropertiesByInstanceAndPropertyKey(InstanceId, PropertyKey);
            //CustomPropertyHelper.SaveControlPropertyByInstance( 
            //    new SaveNewCustomPropertyInstanceInfo( 
            //        InstanceId, 
            //        Morphfolia.Common.ControlPropertyTypeFactory.CustomPropertyType(), 
            //        PropertyKey, 
            //        txtPropertyValue.Text )
            //    );
		}
		
		
		
	}
}