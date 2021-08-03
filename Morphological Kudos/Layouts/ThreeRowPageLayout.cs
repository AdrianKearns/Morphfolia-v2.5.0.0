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

namespace Morphological.Kudos.Layouts
{
	/// <summary>
	/// Summary description for SimpleBanner.
	/// </summary>
    [IsLayoutWebControl]
    public class ThreeRowPageLayout : BasePageLayout, INamingContainer
	{
        private ISkinProvider skinProvider;

		private PlaceHolder headerPlaceHolder;
		private PlaceHolder contentPlaceHolder;
		private PlaceHolder footerPlaceHolder;

		private WebControl tblHeader;
		private Table tblContent;
		private WebControl tblFooter;

		private TableRow tr;
		private TableCell tdR1;
		private TableCell tdR2;
		private TableCell tdR3;


        public ThreeRowPageLayout()
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
			public const string TextR1 = "TextR1";
			public const string TextR2 = "TextR2";
			public const string TextR3 = "TextR3";
		}

		public class CustomPropertyKeys
		{
            //public const string OveralWidth = "OveralWidth";
            //public const string OveralHorizontalAlign = "OveralHorizontalAlign";
			public const string TextR1HorizontalAlignment = "TextR1HorizontalAlignment";
			public const string TextR2HorizontalAlignment = "TextR2HorizontalAlignment";
			public const string TextR3HorizontalAlignment = "TextR3HorizontalAlignment";
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

                        case Constants.CommonPropertyKeys.OveralHorizontalAlign:
							OveralHorizontalAlign = HorizontalAlignFromstring( propertyValue );
							break;

						case CustomPropertyKeys.TextR1HorizontalAlignment:
							TextR1HorizontalAlignment = HorizontalAlignFromstring( propertyValue );
							break;

						case CustomPropertyKeys.TextR2HorizontalAlignment:
							TextR2HorizontalAlignment = HorizontalAlignFromstring( propertyValue );
							break;

						case CustomPropertyKeys.TextR3HorizontalAlignment:
							TextR3HorizontalAlignment = HorizontalAlignFromstring( propertyValue );
							break;

                        //case ContentPlugKeys.TextR1:
                        //    temp = GetContentInfoIndexById( int.Parse( propertyValue ) );
                        //    if (temp != Morphfolia.Common.Constants.SystemTypeValues.NullInt)
                        //    {
                        //        AddContentToContentContainer(tdR1, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                        //    }
                        //    break;

                        //case ContentPlugKeys.TextR2:
                        //    temp = GetContentInfoIndexById( int.Parse( propertyValue ) );
                        //    if (temp != Morphfolia.Common.Constants.SystemTypeValues.NullInt)
                        //    {
                        //        AddContentToContentContainer(tdR2, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                        //    }
                        //    break;

                        //case ContentPlugKeys.TextR3:
                        //    temp = GetContentInfoIndexById( int.Parse( propertyValue ) );
                        //    if (temp != Morphfolia.Common.Constants.SystemTypeValues.NullInt)
                        //    {
                        //        AddContentToContentContainer(tdR3, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                        //    }
                        //    break;

                        case Constants.CommonPropertyKeys.CellPadding:
                            CellPadding = Morphfolia.Common.VerySimpleMethodsThatShouldBeRefactored.SafeStringToInt(propertyValue);
							break;

                        case Constants.CommonPropertyKeys.CellSpacing:
                            CellSpacing = Morphfolia.Common.VerySimpleMethodsThatShouldBeRefactored.SafeStringToInt(propertyValue);
							break;
					}
				}
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
                        case ContentPlugKeys.TextR1:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            if (temp != Morphfolia.Common.Constants.SystemTypeValues.NullInt)
                            {
                                AddContentToContentContainer(tdR1, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                            }
                            break;

                        case ContentPlugKeys.TextR2:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            if (temp != Morphfolia.Common.Constants.SystemTypeValues.NullInt)
                            {
                                AddContentToContentContainer(tdR2, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                            }
                            break;

                        case ContentPlugKeys.TextR3:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            if (temp != Morphfolia.Common.Constants.SystemTypeValues.NullInt)
                            {
                                AddContentToContentContainer(tdR3, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
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

		private HorizontalAlign textR1HorizontalAlignment = HorizontalAlign.NotSet;
		[IsCustomProperty,
		PropertyFriendlyName("Column 1 Horizontal Alignment"),
		PropertyDescription(Descriptions.HorizontalAlignment),
		PropertySuggestedUsage(SuggestedUsageNotes.HorizontalAlignment)]
		public HorizontalAlign TextR1HorizontalAlignment
		{
			get{ return textR1HorizontalAlignment; }
			set{ textR1HorizontalAlignment = value; }
		}

		private HorizontalAlign textR2HorizontalAlignment = HorizontalAlign.NotSet;
		[IsCustomProperty,
		PropertyFriendlyName("Column 2 Horizontal Alignment"),
		PropertyDescription(Descriptions.HorizontalAlignment),
		PropertySuggestedUsage(SuggestedUsageNotes.HorizontalAlignment)]
		public HorizontalAlign TextR2HorizontalAlignment
		{
			get{ return textR2HorizontalAlignment; }
			set{ textR2HorizontalAlignment = value; }
		}

		private HorizontalAlign textR3HorizontalAlignment = HorizontalAlign.NotSet;
		[IsCustomProperty,
		PropertyFriendlyName("Column 3 Horizontal Alignment"),
		PropertyDescription(Descriptions.HorizontalAlignment),
		PropertySuggestedUsage(SuggestedUsageNotes.HorizontalAlignment)]
		public HorizontalAlign TextR3HorizontalAlignment
		{
			get{ return textR3HorizontalAlignment; }
			set{ textR3HorizontalAlignment = value; }
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


		private string textR1 = "&nbsp;";
		[IsContentContainer]
		public string TextR1
		{
			get{ return textR1; }
			set{ textR1 = value; }
		}


		private string textR2 = "&nbsp;";
		[IsContentContainer]
		public string TextR2
		{
			get{ return textR2; }
			set{ textR2 = value; }
		}


		private string textR3 = "&nbsp;";
		[IsContentContainer]
		public string TextR3
		{
			get{ return textR3; }
			set{ textR3 = value; }
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
			base.CreateChildControls ();


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

			tdR1 = new TableCell();
			Controls.Add( tdR1 );
			tr.Cells.Add( tdR1 );
			tdR1.VerticalAlign = VerticalAlign.Top;


			tr = new TableRow();
			Controls.Add( tr );
			tblContent.Rows.Add( tr );

			tdR2 = new TableCell();
			Controls.Add( tdR2 );
			tr.Cells.Add( tdR2 );
			tdR2.VerticalAlign = VerticalAlign.Top;
			

			tr = new TableRow();
			Controls.Add( tr );
			tblContent.Rows.Add( tr );

			tdR3 = new TableCell();
			Controls.Add( tdR3 );
			tr.Cells.Add( tdR3 );
			tdR3.VerticalAlign = VerticalAlign.Top;


			footerPlaceHolder = new PlaceHolder();
			Controls.Add( footerPlaceHolder );
			footerPlaceHolder.ID = "footerPlaceHolder";
		}


		protected override void RenderContents(HtmlTextWriter writer)
		{
			EnsureChildControls();

			if( Visible )
			{
                if (skinProvider == null)
                {
                    skinProvider = base.LoadSkinProvider(null, new Skins.SpecialCircumstances.Anaplian());
                }

                tblHeader = skinProvider.MakePageHeader(this.Page);
				Controls.Add( tblHeader );
				headerPlaceHolder.Controls.Add( tblHeader );
				//tblHeader.Width = Width;	// These should take their config only from the database, 
				// but perhaps they should accept some local settings?

				tblContent.Width = OveralWidth;
				tblContent.HorizontalAlign = OveralHorizontalAlign;
				tblContent.CellPadding = CellPadding;
				tblContent.CellSpacing = CellSpacing;
				tdR1.HorizontalAlign = TextR1HorizontalAlignment;
				tdR2.HorizontalAlign = TextR2HorizontalAlignment;
				tdR3.HorizontalAlign = TextR3HorizontalAlignment;

                if (ChildControls.Count > 0)
                {
                    for (int c = 0; c < ChildControls.Count; c++)
                    {
                        //tdC1.Controls.Add(ChildControls[c]);
                        tdR2.Controls.AddAt(c, ChildControls[c]);
                    }
                }

                tblFooter = skinProvider.MakePageFooter(this.Page);
				Controls.Add( tblFooter );
				footerPlaceHolder.Controls.Add( tblFooter );

				base.RenderContents (writer);
			}
		}


	}
}