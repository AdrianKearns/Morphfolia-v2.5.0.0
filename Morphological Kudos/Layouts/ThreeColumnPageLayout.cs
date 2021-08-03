// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;
using Morphfolia.Common.BaseClasses;
using Morphfolia.Common.Constants.Framework;
using Morphfolia.Common.Info;
using Morphfolia.Common.Interfaces;
using Morphfolia.PageLayoutAndSkinAssistant;
using Morphfolia.PageLayoutAndSkinAssistant.Attributes;
using Morphfolia.PageLayoutAndSkinAssistant.Interfaces;

namespace Morphological.Kudos.Layouts
{
	/// <summary>
	/// Summary description for SimpleBanner.
	/// </summary>
	[IsLayoutWebControl]
    public class ThreeColumnPageLayout : BasePageLayout, INamingContainer, IDisplayTagCloud
    {
        private ISkinProvider skinProvider;

		private PlaceHolder headerPlaceHolder;
		private PlaceHolder contentPlaceHolder;
		private PlaceHolder footerPlaceHolder;

		private WebControl tblHeader;
		private Table tblContent;
		private WebControl tblFooter;

		private TableRow tr;
		private TableCell tdC1;
		private TableCell tdC2;
		private TableCell tdC3;


        public ThreeColumnPageLayout()
        {
        }


        private Morphfolia.Common.WebControlCollection childControls;
        public override Morphfolia.Common.WebControlCollection ChildControls
        {
            get
            {
                EnsureChildControls();
                if (childControls == null)
                {
                    childControls = new Morphfolia.Common.WebControlCollection();
                }
                return childControls;
            }
            set
            {
                childControls = value;
            }
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
			public const string TextC1 = "TextC1";
			public const string TextC2 = "TextC2";
			public const string TextC3 = "TextC3";
		}

		public class CustomPropertyKeys
		{
			public const string TextC1width = "TextC1width";
			public const string TextC2width = "TextC2width";
			public const string TextC3width = "TextC3width";
            //public const string OveralWidth = "OveralWidth";
            //public const string OveralHorizontalAlign = "OveralHorizontalAlign";
			public const string TextC1HorizontalAlignment = "TextC1HorizontalAlignment";
			public const string TextC2HorizontalAlignment = "TextC2HorizontalAlignment";
			public const string TextC3HorizontalAlignment = "TextC3HorizontalAlignment";
            //public const string CellPadding = "CellPadding";
            //public const string CellSpacing = "CellSpacing";
		}


        private CustomPropertyInstanceInfoCollection CustomProperties = null;


		/// <summary>
		/// Use the private Properties: Page and ControlProperties, to 
		/// populate the control with content.
		/// </summary>
        public override void SetCustomProperties(CustomPropertyInstanceInfoCollection customProperties)
        {
            EnsureChildControls();

            CustomProperties = customProperties;

            //System.Text.StringBuilder sbC1 = new System.Text.StringBuilder();
            //System.Text.StringBuilder sbC2 = new System.Text.StringBuilder();
            //System.Text.StringBuilder sbC3 = new System.Text.StringBuilder();
			string propertyKey;
			string propertyValue;
			//int temp;

            if (CustomProperties != null)
			{
                skinProvider = base.LoadSkinProvider(CustomProperties, new Skins.SpecialCircumstances.Anaplian());

                for (int i = 0; i < CustomProperties.Count; i++)
				{
                    propertyKey = CustomProperties[i].PropertyKey;
                    propertyValue = CustomProperties[i].PropertyValue;

					switch( propertyKey )
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

						case CustomPropertyKeys.TextC1width:
							try
							{
								TextC1width = Unit.Parse(propertyValue);
							}
							catch
							{
							}
							break;

						case CustomPropertyKeys.TextC2width:
							try
							{
								TextC2width = Unit.Parse(propertyValue);
							}
							catch
							{
							}
							break;

						case CustomPropertyKeys.TextC3width:
							try
							{
								TextC3width = Unit.Parse(propertyValue);
							}
							catch
							{
							}
							break;

                        case Constants.CommonPropertyKeys.OveralHorizontalAlign:
							OveralHorizontalAlign = HorizontalAlignFromstring( propertyValue );
							break;

						case CustomPropertyKeys.TextC1HorizontalAlignment:
							TextC1HorizontalAlignment = HorizontalAlignFromstring( propertyValue );
							break;

						case CustomPropertyKeys.TextC2HorizontalAlignment:
							TextC2HorizontalAlignment = HorizontalAlignFromstring( propertyValue );
							break;

						case CustomPropertyKeys.TextC3HorizontalAlignment:
							TextC3HorizontalAlignment = HorizontalAlignFromstring( propertyValue );
							break;

                        case Constants.CommonPropertyKeys.CellPadding:
                            CellPadding = Morphfolia.Common.VerySimpleMethodsThatShouldBeRefactored.SafeStringToInt(propertyValue);
							break;

                        case Constants.CommonPropertyKeys.CellSpacing:
                            CellSpacing = Morphfolia.Common.VerySimpleMethodsThatShouldBeRefactored.SafeStringToInt(propertyValue);
                            break;

                        case Constants.CommonPropertyKeys.DisplayTagCloud:
                            if (propertyValue.ToUpper().Equals("Y"))
                            {
                                Display_Tag_Cloud = true;
                            }
                            break;

                        case Constants.CommonPropertyKeys.TagCloudMinimumOccurranceThreshold:
                            TagCloudMinimumOccurranceThreshold = Morphfolia.Common.VerySimpleMethodsThatShouldBeRefactored.SafeStringToInt(propertyValue);
                            break;

                        case Constants.CommonPropertyKeys.TagCloudNumberOfTagDivisons:
                            TagCloudNumberOfTagDivisons = Morphfolia.Common.VerySimpleMethodsThatShouldBeRefactored.SafeStringToInt(propertyValue);
                            break;

                        case Constants.CommonPropertyKeys.TagCloudCssClass:
                            TagCloudCssClass = propertyValue;
                            break;
					}
				}
			}


            if (Display_Tag_Cloud)
            {
                Morphfolia.Business.ContentIndexer contentIndexer = new Morphfolia.Business.ContentIndexer();
                Morphfolia.WebControls.TagCloud tagCloud = new Morphfolia.WebControls.TagCloud();
                tagCloud.NumberOfTagDivisons = TagCloudNumberOfTagDivisons;
                tagCloud.MinimumOccurranceThreshold = TagCloudMinimumOccurranceThreshold;
                tagCloud.Words = contentIndexer.GetWordsForTagCloud(tagCloud.MinimumOccurranceThreshold);
                tagCloud.NavigateUrl = string.Format("{0}/{1}", 
                    Morphfolia.PublishingSystem.WebUtilities.VirtualApplicationRoot(),
                    PageURLs.SearchResults);
                tagCloud.NavigateUrlQueryStringKey = RequestKeys.SearchCriteriaIndentifier;

                if (!TagCloudCssClass.Equals(string.Empty))
                {
                    tagCloud.CssClass = TagCloudCssClass;
                }

                tdC3.Controls.Add(tagCloud);
            }
		}


        public override void InitializeContent()
        {
            EnsureChildControls();

            string propertyKey;
            string propertyValue;
            int temp;

            if (CustomProperties != null)
            {
                for (int i = 0; i < CustomProperties.Count; i++)
                {
                    propertyKey = CustomProperties[i].PropertyKey;
                    propertyValue = CustomProperties[i].PropertyValue;

                    switch (propertyKey)
                    {
                        case ContentPlugKeys.TextC1:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            if (temp != Morphfolia.Common.Constants.SystemTypeValues.NullInt)
                            {
                                AddContentToContentContainer(tdC1, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                            }
                            break;

                        case ContentPlugKeys.TextC2:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            if (temp != Morphfolia.Common.Constants.SystemTypeValues.NullInt)
                            {
                                AddContentToContentContainer(tdC2, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                            }
                            break;

                        case ContentPlugKeys.TextC3:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            if (temp != Morphfolia.Common.Constants.SystemTypeValues.NullInt)
                            {
                                AddContentToContentContainer(tdC3, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                            }
                            break;
                    }
                }
            }
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



		private int cellPadding = 5;
		[IsCustomProperty,
		PropertyFriendlyName(FriendlyNames.CellPadding),
		PropertyDescription(Descriptions.CellPadding),
		PropertySuggestedUsage(SuggestedUsageNotes.CellPadding)]
		public int CellPadding
		{
			get{ return cellPadding; }
			set{ cellPadding = value; }
		}


		private int cellSpacing = 0;
		[IsCustomProperty,
		PropertyFriendlyName(FriendlyNames.CellSpacing),
		PropertyDescription(Descriptions.CellSpacing),
		PropertySuggestedUsage(SuggestedUsageNotes.CellSpacing)]
		public int CellSpacing
		{
			get{ return cellSpacing; }
			set{ cellSpacing = value; }
		}


		private HorizontalAlign overalHorizontalAlign = HorizontalAlign.NotSet;
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

		private HorizontalAlign textC1HorizontalAlignment = HorizontalAlign.NotSet;
		[IsCustomProperty,
		PropertyFriendlyName("Column 1 Horizontal Alignment"),
		PropertyDescription(Descriptions.HorizontalAlignment),
		PropertySuggestedUsage(SuggestedUsageNotes.HorizontalAlignment)]
		public HorizontalAlign TextC1HorizontalAlignment
		{
			get{ return textC1HorizontalAlignment; }
			set{ textC1HorizontalAlignment = value; }
		}

		private HorizontalAlign textC2HorizontalAlignment = HorizontalAlign.NotSet;
		[IsCustomProperty,
		PropertyFriendlyName("Column 2 Horizontal Alignment"),
		PropertyDescription(Descriptions.HorizontalAlignment),
		PropertySuggestedUsage(SuggestedUsageNotes.HorizontalAlignment)]
		public HorizontalAlign TextC2HorizontalAlignment
		{
			get{ return textC2HorizontalAlignment; }
			set{ textC2HorizontalAlignment = value; }
		}

		private HorizontalAlign textC3HorizontalAlignment = HorizontalAlign.NotSet;
		[IsCustomProperty,
		PropertyFriendlyName("Column 3 Horizontal Alignment"),
		PropertyDescription(Descriptions.HorizontalAlignment),
		PropertySuggestedUsage(SuggestedUsageNotes.HorizontalAlignment)]
		public HorizontalAlign TextC3HorizontalAlignment
		{
			get{ return textC3HorizontalAlignment; }
			set{ textC3HorizontalAlignment = value; }
		}

		private Unit overalWidth;
		[IsCustomProperty,
		PropertyFriendlyName("Width"),
		PropertyDescription(Descriptions.Width),
		PropertySuggestedUsage(SuggestedUsageNotes.Width)]
		public Unit OveralWidth
		{
			get{ return overalWidth; }
			set{ overalWidth = value; }
		}

		private Unit textC1width;
		[IsCustomProperty,
		PropertyFriendlyName("Column 1 Width"),
		PropertyDescription(Descriptions.Width),
		PropertySuggestedUsage(SuggestedUsageNotes.Width)]
		public Unit TextC1width
		{
			get{ return textC1width; }
			set{ textC1width = value; }
		}

		private Unit textC2width;
		[IsCustomProperty,
		PropertyFriendlyName("Column 2 Width"),
		PropertyDescription(Descriptions.Width),
		PropertySuggestedUsage(SuggestedUsageNotes.Width)]
		public Unit TextC2width
		{
			get{ return textC2width; }
			set{ textC2width = value; }
		}

		private Unit textC3width;
		[IsCustomProperty,
		PropertyFriendlyName("Column 3 Width"),
		PropertyDescription(Descriptions.Width),
		PropertySuggestedUsage(SuggestedUsageNotes.Width)]
		public Unit TextC3width
		{
			get{ return textC3width; }
			set{ textC3width = value; }
		}



        private string textC1 = "&nbsp;";
        [IsContentContainer, ContentContainerColour("#ddeeff"), ContentContainerDescription("The left column.")]
        public string TextC1
        {
            get { return textC1; }
            set { textC1 = value; }
        }


        private string textC2 = "&nbsp;";
        [IsContentContainer, ContentContainerColour("#C1DFFD"), ContentContainerDescription("The center column.")]
        public string TextC2
        {
            get { return textC2; }
            set { textC2 = value; }
        }


        private string textC3 = "&nbsp;";
        [IsContentContainer, ContentContainerColour("#A7D2FD"), ContentContainerDescription("The right column.")]
        public string TextC3
        {
            get { return textC3; }
            set { textC3 = value; }
        }



        private bool Display_Tag_Cloud = false;
        private string displayTagCloud = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName(FriendlyNames.TagCloud),
        PropertyDescription(Descriptions.TagCloud),
        PropertySuggestedUsage(SuggestedUsageNotes.TagCloud)]
        public string DisplayTagCloud
        {
            get { return displayTagCloud; }
            set { displayTagCloud = value; }
        }


        private int tagCloudNumberOfTagDivisons = 3;
        [IsCustomProperty,
        PropertyFriendlyName(FriendlyNames.TagCloudNumberOfTagDivisons),
        PropertyDescription(Descriptions.TagCloudNumberOfTagDivisons),
        PropertySuggestedUsage(SuggestedUsageNotes.TagCloudNumberOfTagDivisons)]
        public int TagCloudNumberOfTagDivisons
        {
            get { return tagCloudNumberOfTagDivisons; }
            set { tagCloudNumberOfTagDivisons = value; }
        }


        private int tagCloudMinimumOccurranceThreshold = 1;
        [IsCustomProperty,
        PropertyFriendlyName(FriendlyNames.TagCloudMinimumOccurranceThreshold),
        PropertyDescription(Descriptions.TagCloudMinimumOccurranceThreshold),
        PropertySuggestedUsage(SuggestedUsageNotes.TagCloudMinimumOccurranceThreshold)]
        public int TagCloudMinimumOccurranceThreshold
        {
            get { return tagCloudMinimumOccurranceThreshold; }
            set { tagCloudMinimumOccurranceThreshold = value; }
        }


        private string tagCloudCssClass = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName(FriendlyNames.TagCloudCssClass),
        PropertyDescription(Descriptions.TagCloudCssClass),
        PropertySuggestedUsage(SuggestedUsageNotes.TagCloudCssClass)]
        public string TagCloudCssClass
        {
            get { return tagCloudCssClass; }
            set { tagCloudCssClass = value; }
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


        //public Morphfolia.Common.Types.AppearanceTemplateSkinOptionCollection SkinOptions
        //{
        //    get
        //    {
        //        return LayoutTemplateProviderFactory.Construct().SkinOptions;
        //    }
        //}


		protected override void CreateChildControls()
		{
			//base.CreateChildControls ();


			headerPlaceHolder = new PlaceHolder();
			Controls.Add( headerPlaceHolder );
			headerPlaceHolder.ID = "headerPlaceHolder";


			contentPlaceHolder = new PlaceHolder();
			Controls.Add( contentPlaceHolder );
			contentPlaceHolder.ID = "contentPlaceHolder";


			tblContent = new Table();
			Controls.Add( tblContent );
			//tblSimpleBanner.Attributes.Add("border", "1");
			tblContent.HorizontalAlign = HorizontalAlign.Center;

			tr = new TableRow();
			Controls.Add( tr );
			tblContent.Rows.Add( tr );

			tdC1 = new TableCell();
			Controls.Add( tdC1 );
			tr.Cells.Add( tdC1 );
			tdC1.VerticalAlign = VerticalAlign.Top;

			tdC2 = new TableCell();
			Controls.Add( tdC2 );
			tr.Cells.Add( tdC2 );
			tdC2.VerticalAlign = VerticalAlign.Top;
			
			tdC3 = new TableCell();
			Controls.Add( tdC3 );
			tr.Cells.Add( tdC3 );
			tdC3.VerticalAlign = VerticalAlign.Top;

			footerPlaceHolder = new PlaceHolder();
			Controls.Add( footerPlaceHolder );
			footerPlaceHolder.ID = "footerPlaceHolder";
		}


		protected override void RenderContents(HtmlTextWriter writer)
		{
			EnsureChildControls();

            if (skinProvider == null)
            {
                skinProvider = base.LoadSkinProvider(null, new Skins.SpecialCircumstances.Anaplian());
            }

            tblHeader = skinProvider.MakePageHeader(this.Page);
            Controls.Add(tblHeader);
			headerPlaceHolder.Controls.Add( tblHeader );
			//tblHeader.Width = Width;	// These should take their config only from the database, 
										// but perhaps they should accept some local settings?

			tblContent.Width = OveralWidth;
			tblContent.HorizontalAlign = OveralHorizontalAlign;
			tblContent.CellPadding = CellPadding;
			tblContent.CellSpacing = CellSpacing;
			tdC1.Width = TextC1width;
			tdC1.HorizontalAlign = TextC1HorizontalAlignment;
			tdC2.Width = TextC2width;
			tdC2.HorizontalAlign = TextC2HorizontalAlignment;
			tdC3.Width = TextC3width;
			tdC3.HorizontalAlign = TextC3HorizontalAlignment;

            if (ChildControls.Count > 0)
            {
                for (int c = 0; c < ChildControls.Count; c++)
                {
                    //tdC1.Controls.Add(ChildControls[c]);
                    tdC2.Controls.AddAt(c, ChildControls[c]);
                }
            }

            tblFooter = skinProvider.MakePageFooter(this.Page);
			Controls.Add( tblFooter );
			footerPlaceHolder.Controls.Add( tblFooter );

			base.RenderContents (writer);
		}
	
	}
}