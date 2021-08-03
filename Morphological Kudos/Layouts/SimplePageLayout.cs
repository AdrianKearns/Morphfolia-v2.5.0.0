// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Common.Info;
using Morphfolia.Common.BaseClasses;
using Morphfolia.Common.Interfaces;
using Morphfolia.PageLayoutAndSkinAssistant;
using Morphfolia.PageLayoutAndSkinAssistant.Attributes;

namespace Morphological.Kudos.Layouts
{
	/// <summary>
	/// Summary description for SimpleBanner.
	/// </summary>
	[IsLayoutWebControl]
    public class SimplePageLayout : BasePageLayout, INamingContainer
    {
        private ISkinProvider skinProvider;

		private PlaceHolder headerPlaceHolder;
		private PlaceHolder contentPlaceHolder;
		private PlaceHolder footerPlaceHolder;

		private WebControl tblHeader;
		private Table tblContent;
		private WebControl tblFooter;
		private Literal BeginFormTag;
		private Literal EndFormTag;

		protected TableRow tr;
		protected TableCell tdContentContainer;


        private Morphfolia.Common.WebControlCollection childControls;
        public override Morphfolia.Common.WebControlCollection ChildControls
		{
			get{ 
				EnsureChildControls();
				if( childControls == null )
				{
					childControls = new Morphfolia.Common.WebControlCollection();
				}
				return childControls;
			}
			set{ 
				childControls = value;
			}
		}


		public SimplePageLayout()
		{
		}


		public SimplePageLayout( WebControl childWebControl )
		{
			ChildControls.Add( childWebControl );
		}


		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// the values of these strings should be the same as 
		/// the att...?
		/// </remarks>
		public new class ContentPlugKeys
		{
			public static readonly string C1 = "C1";
		}


        private CustomPropertyInstanceInfoCollection CustomProperties = null;


        public override void SetCustomProperties(CustomPropertyInstanceInfoCollection customProperties)
        {
            EnsureChildControls();

            Morphfolia.Common.Logging.Logger.LogVerboseInformation("SimplePageLayout.SetCustomProperties()", "Invoked.", 666);

            CustomProperties = customProperties;

			System.Text.StringBuilder sbC1 = new System.Text.StringBuilder();
            //string propertyType;
            string propertyKey;
            string propertyValue;
			//int temp;


            if (CustomProperties != null)
			{
                skinProvider = base.LoadSkinProvider(CustomProperties, new Skins.SpecialCircumstances.Anaplian());
                
                for (int i = 0; i < CustomProperties.Count; i++)
				{
                    //propertyType = CustomProperties[i].PropertyType.PropertyTypeIdentifier;
                    propertyKey = CustomProperties[i].PropertyKey;
                    propertyValue = CustomProperties[i].PropertyValue;

                    switch (propertyKey)
                    {
                        case Constants.CommonPropertyKeys.FormTemplatePresenterType:
                            FormTemplatePresenterType = propertyValue;
                            break;

                        case Constants.CommonPropertyKeys.OveralWidth:
                            try
                            {
                                OveralWidth = Unit.Parse(propertyValue);
                            }
                            catch
                            {
                            }
                            break;

                        case Constants.CommonPropertyKeys.OveralHorizontalAlign:
                            OveralHorizontalAlign = HorizontalAlignFromstring(propertyValue);
                            break;
                    }                               
				}
			}

            Morphfolia.Common.Logging.Logger.LogVerboseInformation("SimplePageLayout.SetCustomProperties()", "Complete.", 666);
		}


		#region ...   Properties   ...


        private string formTemplatePresenterType = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("Form-Template Presenter"),
        PropertyDescription("Allows you to specify the Form-Template Presenter that will be used to render content that has been entered based on an XML template.  If empty (or there is an error) the default Form-Template Presenter will be used."),
        PropertySuggestedUsage("[Type,Assembly] for example: Morphological.Kudos.FormTemplatePresenters.UserStoryTemplatePresenterProvider,Morphological.Kudos")]
        public override string FormTemplatePresenterType
        {
            get { return formTemplatePresenterType; }
            set { formTemplatePresenterType = value; }
        }


		private HorizontalAlign overalHorizontalAlign = HorizontalAlign.Center;
		[IsCustomProperty,
		PropertyFriendlyName(FriendlyNames.HorizontalAlignment),
		PropertyDefaultValue(DefaultValues.HorizontalAlignment),
		PropertyDescription(Descriptions.HorizontalAlignment),
		PropertySuggestedUsage(SuggestedUsageNotes.HorizontalAlignment)]
		public HorizontalAlign OveralHorizontalAlign
		{
			get{ return overalHorizontalAlign; }
			set{ overalHorizontalAlign = value; }
		}


		private Unit overalWidth = Unit.Pixel(650);
		[IsCustomProperty,
		PropertyFriendlyName("Width"),
		PropertyDescription(Descriptions.Width),
		PropertySuggestedUsage(SuggestedUsageNotes.Width)]
		public Unit OveralWidth
		{
			get{ return overalWidth; }
			set{ overalWidth = value; }
		}


		private string textC1 = "&nbsp;";
		[IsContentContainer]
		public string TextC1
		{
			get{ return textC1; }
			set{ textC1 = value; }
		}

        //private string skinIdentifier = string.Empty;
        //[IsCustomProperty,
        //PropertyFriendlyName(FriendlyNames.SkinIdentifier),
        //PropertyDescription(Descriptions.SkinIdentifier),
        //PropertySuggestedUsage(SuggestedUsageNotes.SkinIdentifier)]
        //public string SkinIdentifier
        //{
        //    get { return skinIdentifier; }
        //    set { skinIdentifier = value; }
        //}


		#endregion


		protected override void CreateChildControls()
		{
            Morphfolia.Common.Logging.Logger.LogVerboseInformation("SimplePageLayout.CreateChildControls()", "Invoked.", 666);

			headerPlaceHolder = new PlaceHolder();
			Controls.Add( headerPlaceHolder );
			headerPlaceHolder.ID = "headerPlaceHolder";

			BeginFormTag = new Literal();
			Controls.Add( BeginFormTag );
			//td.Controls.Add( BeginFormTag );
			BeginFormTag.Text = "<form id=\"Form1\" method=\"post\" runat=\"server\">";

			tblContent = new Table();
			Controls.Add( tblContent );
            //tblContent.Attributes.Add("border", "1");
			tblContent.HorizontalAlign = HorizontalAlign.Center;

			tr = new TableRow();
            Controls.Add(tr);
			tblContent.Rows.Add( tr );

            tdContentContainer = new TableCell();
            Controls.Add(tdContentContainer);
            tr.Cells.Add(tdContentContainer);
            tdContentContainer.VerticalAlign = VerticalAlign.Top;
            tdContentContainer.ID = "tdContentContainer";

			EndFormTag = new Literal();
			Controls.Add( EndFormTag );
			EndFormTag.Text = "</form>";

            contentPlaceHolder = new PlaceHolder();
            Controls.Add(contentPlaceHolder);
            contentPlaceHolder.ID = "contentPlaceHolder";

			footerPlaceHolder = new PlaceHolder();
			Controls.Add( footerPlaceHolder );
			footerPlaceHolder.ID = "footerPlaceHolder";

            Morphfolia.Common.Logging.Logger.LogVerboseInformation("SimplePageLayout.CreateChildControls()", "Complete.", 666);
		}


		protected override void RenderContents(HtmlTextWriter writer)
		{
			EnsureChildControls();

            Morphfolia.Common.Logging.Logger.LogVerboseInformation("SimplePageLayout.RenderContents()", "Invoked.", 666);

			if( Visible )
			{
                if (skinProvider == null)
                {
                    skinProvider = base.LoadSkinProvider(null, new Skins.SpecialCircumstances.Anaplian());
                }

                tblHeader = skinProvider.MakePageHeader(this.Page);
				Controls.Add( tblHeader );
				headerPlaceHolder.Controls.Add( tblHeader );

				tblContent.Width = OveralWidth;
				tblContent.HorizontalAlign = OveralHorizontalAlign;

				if( ChildControls.Count > 0 )
				{
					for(int c = 0; c < ChildControls.Count; c++)
					{
                        tdContentContainer.Controls.AddAt(c, ChildControls[c]);
					}
				}

                tblFooter = skinProvider.MakePageFooter(this.Page);
				Controls.Add( tblFooter );
				footerPlaceHolder.Controls.Add( tblFooter );

				base.RenderContents (writer);
			}

            Morphfolia.Common.Logging.Logger.LogVerboseInformation("SimplePageLayout.RenderContents()", "Complete.", 666);
		}


        public override void InitializeContent()
        {
            EnsureChildControls();

            Morphfolia.Common.Logging.Logger.LogVerboseInformation("SimplePageLayout.InitializeContent()", "Invoked.", 666);

            string propertyType;
            //string propertyKey;
            //string propertyValue;
            int temp;

            if (CustomProperties != null)
            {
                for (int i = 0; i < CustomProperties.Count; i++)
                {
                    propertyType = CustomProperties[i].PropertyType.PropertyTypeIdentifier;
                    //propertyKey = CustomProperties[i].PropertyKey;
                    //propertyValue = CustomProperties[i].PropertyValue;

                    if (propertyType.Equals(Morphfolia.Common.ControlPropertyTypeConstants.PropertyTypeIdentifiers.CONT))
                    {
                        temp = GetContentInfoIndexById(int.Parse(CustomProperties[i].PropertyValue));
                        if (temp != Morphfolia.Common.Constants.SystemTypeValues.NullInt)
                        {
                            AddContentToContentContainer(tdContentContainer, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                        }
                    }
                }
            }

            Morphfolia.Common.Logging.Logger.LogVerboseInformation("SimplePageLayout.InitializeContent()", "Complete.", 666);
        }

	}
}