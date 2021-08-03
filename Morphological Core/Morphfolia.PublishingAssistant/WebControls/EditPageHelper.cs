// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Web.UI.WebControls;
using Morphfolia.Business;
using Morphfolia.Common.Info;

namespace Morphfolia.PublishingSystem.WebControls
{
    /// <summary>
    /// Provides some helper methods for the EditPage WebControl, which may also be useful elsewhere.
    /// </summary>
    public class EditPageHelper
    {
        private StaticCustomPropertyHelper controlPropertyHelper = new StaticCustomPropertyHelper();

        public static string GetSelectedValueFromDropDownList(DropDownList ddl)
        {
            string selectedValue = ddl.Items[ddl.SelectedIndex].Value;

            if (
                (selectedValue.Equals(String.Empty)) |
                (selectedValue.Equals(Morphfolia.Common.Constants.Framework.Various.PleaseSelect)) |
                (selectedValue.Equals(Morphfolia.Common.Constants.Framework.Various.NoneAvailable))
                )
            {
                return String.Empty;
            }
            else
            {
                return selectedValue;
            }
        }

        /// <summary>
        /// Populates a panel with a bunch of 'custom property controls', and with previously saved values.
        /// </summary>
        /// <remarks>Works for both PageLayouts and SkinProviders.</remarks>
        /// <param name="pnlCustomProperties"></param>
        /// <param name="selectedType"></param>
        /// <param name="instanceId"></param>
        /// <param name="clear"></param>
        public static void FillCustomPropertiesPanelForSelectedType(Panel targetPanel, string selectedType, int instanceId, bool clear)
        {
            Logging.Logger.LogInformation("EditPageHelper FillCustomPropertiesPanelForSelectedType()", string.Format("invoked, selectedType: {0}, instanceId: {1}, targetPanel: {2}", selectedType, instanceId.ToString(), targetPanel));

            if (clear)
            {
                Logging.Logger.LogInformation("EditPageHelper FillCustomPropertiesPanelForSelectedType()", "targetPanel.Controls.Clear()");
                targetPanel.Controls.Clear();
            }

            //Literal lbl = new Literal();
            //targetPanel.Controls.Add(lbl);
            //lbl.Text = "<p>Properties Available for this Page Template:</p>";

            CustomPropertyInfoCollection properties = Morphfolia.PageLayoutAndSkinAssistant.WebLayoutControlHelper.GetAvailableCustomPropertiesForType(selectedType);
            foreach (Morphfolia.Common.Info.CustomPropertyInfo customPropertyInfo in properties)
            {
                PublishingSystem.WebControls.CustomProperty customProperty = new PublishingSystem.WebControls.CustomProperty();
                targetPanel.Controls.Add(customProperty);
                //customProperty.Width = Unit.Percentage(100);
                customProperty.ID = string.Format("CustomProperty{0}", customPropertyInfo.PropertyKey);
                customProperty.InstanceId = instanceId; //_PageID;
                customProperty.PropertyKey = customPropertyInfo.PropertyKey;
                customProperty.PropertyValue = customPropertyInfo.PropertyDefaultValue;
                customProperty.PropertyName = customPropertyInfo.PropertyName;

                if (customPropertyInfo.SuggestedUsage.Equals(Morphfolia.Common.Constants.Framework.SpecialCustomPropertySuggestedUsages.HexCode))
                {
                    customProperty.SuggestedUsage = "Hex code (#RRGGBB) or named colour (<a href='ColourChart.aspx' target='_blank'>Hex Codes / Colour Chart</a>)";
                }
                else
                {
                    customProperty.SuggestedUsage = customPropertyInfo.SuggestedUsage;
                }

                customProperty.Description = customPropertyInfo.Description;
                customProperty.InputSize = customPropertyInfo.InputSize;
            }

            Logging.Logger.LogInformation("EditPageHelper FillCustomPropertiesPanelForSelectedType()", "Complete");
        }

        public static void PopulateCustomPropertiesWithPreviouslySavedData(Panel targetPanel, int instanceId)
        {
            Logging.Logger.LogInformation("EditPageHelper PopulateCustomPropertiesWithPreviouslySavedData(targetPanel, instanceId)", "Invoked");

            foreach (object webControl in targetPanel.Controls)
            {
                if (webControl is WebControl)
                {
                    PublishingSystem.WebControls.CustomProperty tempCustomProperty;
                    if (webControl is PublishingSystem.WebControls.CustomProperty)
                    {
                        tempCustomProperty = (PublishingSystem.WebControls.CustomProperty)webControl;

                        CustomPropertyInstanceInfoCollection controlPropertyInfoCollection = StaticCustomPropertyHelper.GetControlPropertiesByInstanceIDAndPropertyKey(instanceId, tempCustomProperty.PropertyKey);
                        if (controlPropertyInfoCollection.Count > 0)
                        {
                            tempCustomProperty.PropertyValue = controlPropertyInfoCollection[0].PropertyValue;
                        }
                    }
                }
            }

            Logging.Logger.LogInformation("EditPageHelper PopulateCustomPropertiesWithPreviouslySavedData(targetPanel, instanceId)", "Complete");
        }

        public static void SaveAllCustomProperties(Panel targetPanel)
        {
            Logging.Logger.LogInformation("EditPageHelper SaveAllCustomProperties(targetPanel)", "Invoked.");

            foreach (WebControl webControl in targetPanel.Controls)
            {
                PublishingSystem.WebControls.CustomProperty tempCustomProperty;
                if (webControl is PublishingSystem.WebControls.CustomProperty)
                {
                    tempCustomProperty = (PublishingSystem.WebControls.CustomProperty)webControl;
                    tempCustomProperty.Save();
                }
            }

            Logging.Logger.LogInformation("EditPageHelper SaveAllCustomProperties(targetPanel)", "Complete.");
        }

        public static void SaveAllCustomProperties(Panel targetPanel, int instanceId)
        {
            Logging.Logger.LogInformation("EditPageHelper SaveAllCustomProperties(targetPanel, instanceId)", string.Format("invoked, pnl: {0}, instanceId: {1}", targetPanel.ID, instanceId.ToString()));

            foreach (object webControl in targetPanel.Controls)
            {
                if (webControl is WebControl)
                {
                    PublishingSystem.WebControls.CustomProperty tempCustomProperty;
                    if (webControl is PublishingSystem.WebControls.CustomProperty)
                    {
                        tempCustomProperty = (PublishingSystem.WebControls.CustomProperty)webControl;
                        tempCustomProperty.InstanceId = instanceId;
                        tempCustomProperty.Save();
                    }
                }
            }

            Logging.Logger.LogInformation("EditPageHelper SaveAllCustomProperties(targetPanel, instanceId)", "Complete.");
        }
    }
}
