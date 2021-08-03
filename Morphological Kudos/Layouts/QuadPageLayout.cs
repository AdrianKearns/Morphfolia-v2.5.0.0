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
using Morphfolia.Common.Info;
using Morphfolia.Common.Interfaces;
using Morphfolia.Common.BaseClasses;
using Morphfolia.PageLayoutAndSkinAssistant;
using Morphfolia.PageLayoutAndSkinAssistant.Attributes;
using Morphfolia.PageLayoutAndSkinAssistant.Interfaces;

namespace Morphological.Kudos.Layouts
{
	/// <summary>
	/// Summary description for SimpleBanner.
	/// </summary>
	/// <remarks>The code for background images is in place but commented out - for now.</remarks>
	[IsLayoutWebControl]
    public class QuadPageLayout : BasePageLayout, INamingContainer, IDisplayTagCloud
	{
        private ISkinProvider skinProvider;

		private PlaceHolder headerPlaceHolder;
		private PlaceHolder contentPlaceHolder;
		private PlaceHolder footerPlaceHolder;

		private WebControl tblHeader;
		private Table tblContent;
        private WebControl tblFooter;

		protected TableRow tr;
		protected TableCell tdR1C1;
		protected TableCell tdR1C2;
		protected TableCell tdR2C1;
		protected TableCell tdR2C2;


        //public QuadPageLayout()
        //{
        //    kudosSkinProviderFactory = new KudosSkinProviderFactory();
        //}


		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// the values of these strings should be the same as 
		/// the att...?
		/// </remarks>
		public new class ContentPlugKeys
		{
			public const string TextR1C1 = "TextR1C1";
			public const string TextR1C2 = "TextR1C2";
			public const string TextR2C1 = "TextR2C1";
			public const string TextR2C2 = "TextR2C2";
		}

		public class CustomPropertyKeys
		{
            //public const string FormTemplatePresenterType = "FormTemplatePresenterType";
            public const string Column1width = "Column1width";
            public const string Column2width = "Column2width";
            //public const string OveralWidth = "OveralWidth";
            //public const string OveralHorizontalAlign = "OveralHorizontalAlign";
			public const string TextR1C1HorizontalAlignment = "TextR1C1HorizontalAlignment";
			public const string TextR1C2HorizontalAlignment = "TextR1C2HorizontalAlignment";
			public const string TextR2C1HorizontalAlignment = "TextR2C1HorizontalAlignment";
			public const string TextR2C2HorizontalAlignment = "TextR2C2HorizontalAlignment";
            //public const string CellPadding = "CellPadding";
            //public const string CellSpacing = "CellSpacing";
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


        private CustomPropertyInstanceInfoCollection CustomProperties = null;

        public override void SetCustomProperties(CustomPropertyInstanceInfoCollection customProperties)
        {
            EnsureChildControls();

            CustomProperties = customProperties;

            string propertyKey;
			string propertyValue;

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

						case CustomPropertyKeys.Column1width:
							try
							{
								Column1width = Unit.Parse(propertyValue);
							}
							catch
							{
							}
							break;

						case CustomPropertyKeys.Column2width:
							try
							{
								Column2width = Unit.Parse(propertyValue);
							}
							catch
							{
							}
							break;

                        case Constants.CommonPropertyKeys.OveralHorizontalAlign:
							OveralHorizontalAlign = HorizontalAlignFromstring( propertyValue );
							break;

						case CustomPropertyKeys.TextR1C1HorizontalAlignment:
							TextR1C1HorizontalAlignment = HorizontalAlignFromstring( propertyValue );
							break;

						case CustomPropertyKeys.TextR1C2HorizontalAlignment:
							TextR1C2HorizontalAlignment = HorizontalAlignFromstring( propertyValue );
							break;

						case CustomPropertyKeys.TextR2C1HorizontalAlignment:
							TextR2C1HorizontalAlignment = HorizontalAlignFromstring( propertyValue );
							break;

						case CustomPropertyKeys.TextR2C2HorizontalAlignment:
							TextR2C2HorizontalAlignment = HorizontalAlignFromstring( propertyValue );
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
                tagCloud.NavigateUrl = string.Format("{0}/SearchResults.aspx", Morphfolia.PublishingSystem.WebUtilities.VirtualApplicationRoot());

                if (!TagCloudCssClass.Equals(string.Empty))
                {
                    tagCloud.CssClass = TagCloudCssClass;
                }

                tdR1C2.Controls.Add(tagCloud);
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
                        case ContentPlugKeys.TextR1C1:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            AddContentToContentContainer(tdR1C1, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                            break;

                        case ContentPlugKeys.TextR1C2:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            AddContentToContentContainer(tdR1C2, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                            break;

                        case ContentPlugKeys.TextR2C1:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            AddContentToContentContainer(tdR2C1, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                            break;

                        case ContentPlugKeys.TextR2C2:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            AddContentToContentContainer(tdR2C2, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
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


		private HorizontalAlign textR1C1HorizontalAlignment = HorizontalAlign.NotSet;
		[IsCustomProperty,
		PropertyFriendlyName("Row 1 Column 1 Horizontal Alignment"),
		PropertyDescription(Descriptions.HorizontalAlignment),
		PropertySuggestedUsage(SuggestedUsageNotes.HorizontalAlignment)]
		public HorizontalAlign TextR1C1HorizontalAlignment
		{
			get{ return textR1C1HorizontalAlignment; }
			set{ textR1C1HorizontalAlignment = value; }
		}


		private HorizontalAlign textR1C2HorizontalAlignment = HorizontalAlign.NotSet;
		[IsCustomProperty,
		PropertyFriendlyName("Row 1 Column 2 Horizontal Alignment"),
		PropertyDescription(Descriptions.HorizontalAlignment),
		PropertySuggestedUsage(SuggestedUsageNotes.HorizontalAlignment)]
		public HorizontalAlign TextR1C2HorizontalAlignment
		{
			get{ return textR1C2HorizontalAlignment; }
			set{ textR1C2HorizontalAlignment = value; }
		}


		private HorizontalAlign textR2C1HorizontalAlignment = HorizontalAlign.NotSet;
		[IsCustomProperty,
		PropertyFriendlyName("Row 2 Column 1 Horizontal Alignment"),
		PropertyDescription(Descriptions.HorizontalAlignment),
		PropertySuggestedUsage(SuggestedUsageNotes.HorizontalAlignment)]
		public HorizontalAlign TextR2C1HorizontalAlignment
		{
			get{ return textR2C1HorizontalAlignment; }
			set{ textR2C1HorizontalAlignment = value; }
		}


		private HorizontalAlign textR2C2HorizontalAlignment = HorizontalAlign.NotSet;
		[IsCustomProperty,
		PropertyFriendlyName("Row 2 Column 2 Horizontal Alignment"),
		PropertyDescription(Descriptions.HorizontalAlignment),
		PropertySuggestedUsage(SuggestedUsageNotes.HorizontalAlignment)]
		public HorizontalAlign TextR2C2HorizontalAlignment
		{
			get{ return textR2C2HorizontalAlignment; }
			set{ textR2C2HorizontalAlignment = value; }
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


		private Unit column1width;
		[IsCustomProperty,
		PropertyFriendlyName("Column 1 Width"),
		PropertyDescription(Descriptions.Width),
		PropertySuggestedUsage(SuggestedUsageNotes.Width)]
		public Unit Column1width
		{
			get{ return column1width; }
			set{ column1width = value; }
		}


		private Unit column2width;
		[IsCustomProperty,
		PropertyFriendlyName("Column 2 Width"),
		PropertyDescription(Descriptions.Width),
		PropertySuggestedUsage(SuggestedUsageNotes.Width)]
		public Unit Column2width
		{
			get{ return column2width; }
			set{ column2width = value; }
		}

		private string textR1C1 = "Quad";
		[IsContentContainer]
		public string TextR1C1
		{
			get{ return textR1C1; }
			set{ textR1C1 = value; }
		}

		private string textR1C2 = "Quad";
		[IsContentContainer]
		public string TextR1C2
		{
			get{ return textR1C2; }
			set{ textR1C2 = value; }
		}

		private string textR2C1 = "Quad";
		[IsContentContainer]
		public string TextR2C1
		{
			get{ return textR2C1; }
			set{ textR2C1 = value; }
		}

		private string textR2C2 = "Quad";
		[IsContentContainer]
		public string TextR2C2
		{
			get{ return textR2C2; }
			set{ textR2C2 = value; }
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




		#endregion




		protected override void CreateChildControls()
		{
			base.CreateChildControls ();


			headerPlaceHolder = new PlaceHolder();
			Controls.Add( headerPlaceHolder );
			headerPlaceHolder.ID = "headerPlaceHolder";



			contentPlaceHolder = new PlaceHolder();
			Controls.Add( contentPlaceHolder );
			contentPlaceHolder.ID = "contentPlaceHolder";


			tblContent = new Table();
			Controls.Add( tblContent );
            //tblContent.Attributes.Add("border", "1");
			tblContent.HorizontalAlign = HorizontalAlign.Center;
            tblContent.ID = "QuadPageLayout";


			tr = new TableRow();
			Controls.Add( tr );
			tblContent.Rows.Add( tr );
            tr.ID = "R1";

			tdR1C1 = new TableCell();
			Controls.Add( tdR1C1 );
			tr.Cells.Add( tdR1C1 );
			tdR1C1.VerticalAlign = VerticalAlign.Top;
            tdR1C1.ID = "R1C1";

			tdR1C2 = new TableCell();
			Controls.Add( tdR1C2 );
			tr.Cells.Add( tdR1C2 );
			tdR1C2.VerticalAlign = VerticalAlign.Top;
            tdR1C2.ID = "R1C2";

			tr = new TableRow();
			Controls.Add( tr );
			tblContent.Rows.Add( tr );
            tr.ID = "R2";

			tdR2C1 = new TableCell();
			Controls.Add( tdR2C1 );
			tr.Cells.Add( tdR2C1 );
			tdR2C1.VerticalAlign = VerticalAlign.Top;
            tdR2C1.ID = "R2C1";

			tdR2C2 = new TableCell();
			Controls.Add( tdR2C2 );
			tr.Cells.Add( tdR2C2 );
			tdR2C2.VerticalAlign = VerticalAlign.Top;
            tdR2C2.ID = "R2C2";

			footerPlaceHolder = new PlaceHolder();
			Controls.Add( footerPlaceHolder );
			footerPlaceHolder.ID = "footerPlaceHolder";
		}


		protected override void RenderContents(HtmlTextWriter writer)
		{
			EnsureChildControls();

			if( Visible )
			{
                Morphfolia.Common.Logging.Logger.LogVerboseInformation("QuadPageLayout RenderContents()", string.Format("skinProvider = '{0}'", skinProvider.GetType().ToString()), 666);

                if (skinProvider == null)
                {
                    skinProvider = base.LoadSkinProvider(null, new Skins.SpecialCircumstances.Anaplian());
                }

                tblHeader = skinProvider.MakePageHeader(this.Page);
                Controls.Add(tblHeader);
				headerPlaceHolder.Controls.Add( tblHeader );


				tblContent.HorizontalAlign = OveralHorizontalAlign;
				tblContent.Width = OveralWidth;
				tblContent.CellPadding = CellPadding;
				tblContent.CellSpacing = CellSpacing;


                if (ChildControls.Count > 0)
                {
                    for (int c = 0; c < ChildControls.Count; c++)
                    {
                        Controls.Add(ChildControls[c]);
                        tdR1C2.Controls.AddAt(c, ChildControls[c]);
                    }
                }

				tdR1C1.HorizontalAlign = TextR1C1HorizontalAlignment;
				tdR1C1.Width = Column1width;

				tdR1C2.HorizontalAlign = TextR1C2HorizontalAlignment;
				tdR1C2.Width = Column2width;

				tdR2C1.HorizontalAlign = TextR2C1HorizontalAlignment;
				tdR2C1.Width = Column1width;

				tdR2C2.HorizontalAlign = TextR2C2HorizontalAlignment;
				tdR2C2.Width = Column2width;


                tblFooter = skinProvider.MakePageFooter(this.Page);
				Controls.Add( tblFooter );
				footerPlaceHolder.Controls.Add( tblFooter );


				base.RenderContents (writer);
			}
		}
	}
}