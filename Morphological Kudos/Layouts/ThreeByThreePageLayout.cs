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
    public class ThreeByThreePageLayout : BasePageLayout, INamingContainer
	{
        private ISkinProvider skinProvider;

		private PlaceHolder headerPlaceHolder;
		private PlaceHolder contentPlaceHolder;
		private PlaceHolder footerPlaceHolder;

		private WebControl tblHeader;
		private Table tblContent;
        private WebControl tblFooter;

		protected TableRow tr;
        protected TableCell tdR0C0;
        protected TableCell tdR1C1;
        protected TableCell tdR1C2;
        protected TableCell tdR1C3;
        protected TableCell tdR2C1;
        protected TableCell tdR2C2;
        protected TableCell tdR2C3;
        protected TableCell tdR3C1;
        protected TableCell tdR3C2;
        protected TableCell tdR3C3;


        public ThreeByThreePageLayout()
        {
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
            public const string TextR0C0 = "TextR0C0";
            public const string TextR1C1 = "TextR1C1";
            public const string TextR1C2 = "TextR1C2";
            public const string TextR1C3 = "TextR1C3";
            public const string TextR2C1 = "TextR2C1";
            public const string TextR2C2 = "TextR2C2";
            public const string TextR2C3 = "TextR2C3";
            public const string TextR3C1 = "TextR3C1";
            public const string TextR3C2 = "TextR3C2";
            public const string TextR3C3 = "TextR3C3";
        }

		public class CustomPropertyKeys
		{
            //public const string FormTemplatePresenterType = "FormTemplatePresenterType";
            public const string TableInlineStyle = "TableInlineStyle";
            public const string CellR0C0InlineStyle = "CellR0C0InlineStyle";
            public const string CellR1C1InlineStyle = "CellR1C1InlineStyle";
            public const string CellR1C2InlineStyle = "CellR1C2InlineStyle";
            public const string CellR1C3InlineStyle = "CellR1C3InlineStyle";
            public const string CellR2C1InlineStyle = "CellR2C1InlineStyle";
            public const string CellR2C2InlineStyle = "CellR2C2InlineStyle";
            public const string CellR2C3InlineStyle = "CellR2C3InlineStyle";
            public const string CellR3C1InlineStyle = "CellR3C1InlineStyle";
            public const string CellR3C2InlineStyle = "CellR3C2InlineStyle";
            public const string CellR3C3InlineStyle = "CellR3C3InlineStyle"; 
            public const string Column1width = "Column1width";
            public const string Column2width = "Column2width";
            public const string Column3width = "Column3width";
            public const string OveralWidth = "OveralWidth";
            public const string OveralHorizontalAlign = "OveralHorizontalAlign";
            public const string CellPadding = "CellPadding";
            public const string CellSpacing = "CellSpacing";
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

                        case CustomPropertyKeys.TableInlineStyle:
                            TableInlineStyle = propertyValue;
                            break;

                        case CustomPropertyKeys.CellR0C0InlineStyle:
                            CellR0C0InlineStyle = propertyValue;
                            break;

                        case CustomPropertyKeys.CellR1C1InlineStyle:
                            CellR1C1InlineStyle = propertyValue;
                            break;

                        case CustomPropertyKeys.CellR1C2InlineStyle:
                            CellR1C2InlineStyle = propertyValue;
                            break;

                        case CustomPropertyKeys.CellR1C3InlineStyle:
                            CellR1C3InlineStyle = propertyValue;
                            break;

                        case CustomPropertyKeys.CellR2C1InlineStyle:
                            CellR2C1InlineStyle = propertyValue;
                            break;

                        case CustomPropertyKeys.CellR2C2InlineStyle:
                            CellR2C2InlineStyle = propertyValue;
                            break;

                        case CustomPropertyKeys.CellR2C3InlineStyle:
                            CellR2C3InlineStyle = propertyValue;
                            break;

                        case CustomPropertyKeys.CellR3C1InlineStyle:
                            CellR3C1InlineStyle = propertyValue;
                            break;

                        case CustomPropertyKeys.CellR3C2InlineStyle:
                            CellR3C2InlineStyle = propertyValue;
                            break;

                        case CustomPropertyKeys.CellR3C3InlineStyle:
                            CellR3C3InlineStyle = propertyValue;
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

                        case CustomPropertyKeys.Column3width:
                            try
                            {
                                Column3width = Unit.Parse(propertyValue);
                            }
                            catch
                            {
                            }
                            break;

                        case Constants.CommonPropertyKeys.OveralHorizontalAlign:
							OveralHorizontalAlign = HorizontalAlignFromstring( propertyValue );
							break;

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
                        case ContentPlugKeys.TextR0C0:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            AddContentToContentContainer(tdR0C0, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                            break;


                        case ContentPlugKeys.TextR1C1:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            AddContentToContentContainer(tdR1C1, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                            break;

                        case ContentPlugKeys.TextR1C2:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            AddContentToContentContainer(tdR1C2, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                            break;

                        case ContentPlugKeys.TextR1C3:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            AddContentToContentContainer(tdR1C3, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                            break;


                        case ContentPlugKeys.TextR2C1:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            AddContentToContentContainer(tdR2C1, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                            break;

                        case ContentPlugKeys.TextR2C2:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            AddContentToContentContainer(tdR2C2, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                            break;

                        case ContentPlugKeys.TextR2C3:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            AddContentToContentContainer(tdR2C3, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                            break;



                        case ContentPlugKeys.TextR3C1:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            AddContentToContentContainer(tdR3C1, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                            break;

                        case ContentPlugKeys.TextR3C2:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            AddContentToContentContainer(tdR3C2, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
                            break;

                        case ContentPlugKeys.TextR3C3:
                            temp = GetContentInfoIndexById(int.Parse(propertyValue));
                            AddContentToContentContainer(tdR3C3, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
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


        private string tableInlineStyle = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("Table Style"),
        PropertyDescription(Descriptions.Style),
        PropertySuggestedUsage(SuggestedUsageNotes.Style)]
        public string TableInlineStyle
        {
            get { return tableInlineStyle; }
            set { tableInlineStyle = value; }
        }



        private string cellR0C0InlineStyle = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("R0C0 Style"),
        PropertyDescription(Descriptions.Style),
        PropertySuggestedUsage(SuggestedUsageNotes.Style)]
        public string CellR0C0InlineStyle
        {
            get { return cellR0C0InlineStyle; }
            set { cellR0C0InlineStyle = value; }
        }

        private string cellR1C1InlineStyle = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("R1C1 Style"),
        PropertyDescription(Descriptions.Style),
        PropertySuggestedUsage(SuggestedUsageNotes.Style)]
        public string CellR1C1InlineStyle
        {
            get { return cellR1C1InlineStyle; }
            set { cellR1C1InlineStyle = value; }
        }

        private string cellR1C2InlineStyle = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("R1C2 Style"),
        PropertyDescription(Descriptions.Style),
        PropertySuggestedUsage(SuggestedUsageNotes.Style)]
        public string CellR1C2InlineStyle
        {
            get { return cellR1C2InlineStyle; }
            set { cellR1C2InlineStyle = value; }
        }

        private string cellR1C3InlineStyle = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("R1C3 Style"),
        PropertyDescription(Descriptions.Style),
        PropertySuggestedUsage(SuggestedUsageNotes.Style)]
        public string CellR1C3InlineStyle
        {
            get { return cellR1C3InlineStyle; }
            set { cellR1C3InlineStyle = value; }
        }

        private string cellR2C1InlineStyle = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("R2C1 Style"),
        PropertyDescription(Descriptions.Style),
        PropertySuggestedUsage(SuggestedUsageNotes.Style)]
        public string CellR2C1InlineStyle
        {
            get { return cellR2C1InlineStyle; }
            set { cellR2C1InlineStyle = value; }
        }

        private string cellR2C2InlineStyle = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("R2C2 Style"),
        PropertyDescription(Descriptions.Style),
        PropertySuggestedUsage(SuggestedUsageNotes.Style)]
        public string CellR2C2InlineStyle
        {
            get { return cellR2C2InlineStyle; }
            set { cellR2C2InlineStyle = value; }
        }

        private string cellR2C3InlineStyle = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("R2C3 Style"),
        PropertyDescription(Descriptions.Style),
        PropertySuggestedUsage(SuggestedUsageNotes.Style)]
        public string CellR2C3InlineStyle
        {
            get { return cellR2C3InlineStyle; }
            set { cellR2C3InlineStyle = value; }
        }

        private string cellR3C1InlineStyle = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("R3C1 Style"),
        PropertyDescription(Descriptions.Style),
        PropertySuggestedUsage(SuggestedUsageNotes.Style)]
        public string CellR3C1InlineStyle
        {
            get { return cellR3C1InlineStyle; }
            set { cellR3C1InlineStyle = value; }
        }

        private string cellR3C2InlineStyle = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("R3C2 Style"),
        PropertyDescription(Descriptions.Style),
        PropertySuggestedUsage(SuggestedUsageNotes.Style)]
        public string CellR3C2InlineStyle
        {
            get { return cellR3C2InlineStyle; }
            set { cellR3C2InlineStyle = value; }
        }

        private string cellR3C3InlineStyle = string.Empty;
        [IsCustomProperty,
        PropertyFriendlyName("R3C3 Style"),
        PropertyDescription(Descriptions.Style),
        PropertySuggestedUsage(SuggestedUsageNotes.Style)]
        public string CellR3C3InlineStyle
        {
            get { return cellR3C3InlineStyle; }
            set { cellR3C3InlineStyle = value; }
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


        private Unit column3width;
        [IsCustomProperty,
        PropertyFriendlyName("Column 3 Width"),
        PropertyDescription(Descriptions.Width),
        PropertySuggestedUsage(SuggestedUsageNotes.Width)]
        public Unit Column3width
        {
            get { return column3width; }
            set { column3width = value; }
        }




        //private string textR1C1 = string.Empty;
        //[IsContentContainer]
        //public string TextR1C1
        //{
        //    get{ return textR1C1; }
        //    set{ textR1C1 = value; }
        //}

        private string textR0C0 = string.Empty;
        [IsContentContainer, ContentContainerColour("#ffcc33")]
        public string TextR0C0
        {
            get { return textR0C0; }
            set { textR0C0 = value; }
        }

        private string textR1C1 = string.Empty;
        [IsContentContainer, ContentContainerColour("#FF0000")]
        public string TextR1C1
        {
            get { return textR1C1; }
            set { textR1C1 = value; }
        }

        private string textR1C2 = string.Empty;
        [IsContentContainer, ContentContainerColour("#FF6666")]
        public string TextR1C2
        {
            get { return textR1C2; }
            set { textR1C2 = value; }
        }

        private string textR1C3 = string.Empty;
        [IsContentContainer, ContentContainerColour("#FFaaaa")]
        public string TextR1C3
        {
            get { return textR1C3; }
            set { textR1C3 = value; }
        }

        private string textR2C1 = string.Empty;
        [IsContentContainer, ContentContainerColour("#00FF00")]
        public string TextR2C1
        {
            get { return textR2C1; }
            set { textR2C1 = value; }
        }

        private string textR2C2 = string.Empty;
        [IsContentContainer, ContentContainerColour("#66FF66")]
        public string TextR2C2
        {
            get { return textR2C2; }
            set { textR2C2 = value; }
        }

        private string textR2C3 = string.Empty;
        [IsContentContainer, ContentContainerColour("#aaFFaa")]
        public string TextR2C3
        {
            get { return textR2C3; }
            set { textR2C3 = value; }
        }

        private string textR3C1 = string.Empty;
        [IsContentContainer, ContentContainerColour("#0000FF")]
        public string TextR3C1
        {
            get { return textR3C1; }
            set { textR3C1 = value; }
        }

        private string textR3C2 = string.Empty;
        [IsContentContainer, ContentContainerColour("#6666FF")]
        public string TextR3C2
        {
            get { return textR3C2; }
            set { textR3C2 = value; }
        }

        private string textR3C3 = string.Empty;
        [IsContentContainer, ContentContainerColour("#aaaaFF")]
        public string TextR3C3
        {
            get { return textR3C3; }
            set { textR3C3 = value; }
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
            tblContent.ID = "ThreeByThreePageLayout";


            tr = new TableRow();
            Controls.Add(tr);
            tblContent.Rows.Add(tr);
            tr.ID = "R0";

            tdR0C0 = new TableCell();
            Controls.Add(tdR0C0);
            tr.Cells.Add(tdR0C0);
            tdR0C0.ColumnSpan = 3;
            tdR0C0.ID = "R0C0";


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

            tdR1C3 = new TableCell();
            Controls.Add(tdR1C3);
            tr.Cells.Add(tdR1C3);
            tdR1C3.VerticalAlign = VerticalAlign.Top;
            tdR1C3.ID = "R1C3";



			tr = new TableRow();
			Controls.Add( tr );
			tblContent.Rows.Add( tr );
            tr.ID = "R2";

            tdR2C1 = new TableCell();
            Controls.Add(tdR2C1);
            tr.Cells.Add(tdR2C1);
            tdR2C1.VerticalAlign = VerticalAlign.Top;
            tdR2C1.ID = "R2C1";

            tdR2C2 = new TableCell();
            Controls.Add(tdR2C2);
            tr.Cells.Add(tdR2C2);
            tdR2C2.VerticalAlign = VerticalAlign.Top;
            tdR2C2.ID = "R2C2";

            tdR2C3 = new TableCell();
            Controls.Add(tdR2C3);
            tr.Cells.Add(tdR2C3);
            tdR2C3.VerticalAlign = VerticalAlign.Top;
            tdR2C3.ID = "R2C3";



            tr = new TableRow();
            Controls.Add(tr);
            tblContent.Rows.Add(tr);
            tr.ID = "R3";

            tdR3C1 = new TableCell();
            Controls.Add(tdR3C1);
            tr.Cells.Add(tdR3C1);
            tdR3C1.VerticalAlign = VerticalAlign.Top;
            tdR3C1.ID = "R3C1";

            tdR3C2 = new TableCell();
            Controls.Add(tdR3C2);
            tr.Cells.Add(tdR3C2);
            tdR3C2.VerticalAlign = VerticalAlign.Top;
            tdR3C2.ID = "R3C2";

            tdR3C3 = new TableCell();
            Controls.Add(tdR3C3);
            tr.Cells.Add(tdR3C3);
            tdR3C3.VerticalAlign = VerticalAlign.Top;
            tdR3C3.ID = "R3C3";

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
                Controls.Add(tblHeader);
				headerPlaceHolder.Controls.Add( tblHeader );


				tblContent.HorizontalAlign = OveralHorizontalAlign;
				tblContent.Width = OveralWidth;
				tblContent.CellPadding = CellPadding;
				tblContent.CellSpacing = CellSpacing;
                tblContent.Attributes.Add("style", TableInlineStyle);


                if (ChildControls.Count > 0)
                {
                    for (int c = 0; c < ChildControls.Count; c++)
                    {
                        Controls.Add(ChildControls[c]);
                        tdR2C2.Controls.AddAt(c, ChildControls[c]);
                    }
                }

				tdR1C1.Width = Column1width;
				tdR1C2.Width = Column2width;
                tdR1C3.Width = Column3width;

                tdR2C1.Width = Column1width;
                tdR2C2.Width = Column2width;
                tdR2C3.Width = Column3width;

                tdR3C1.Width = Column1width;
                tdR3C2.Width = Column2width;
                tdR3C3.Width = Column3width;


                tdR0C0.Attributes.Add("style", CellR0C0InlineStyle);
                tdR1C1.Attributes.Add("style", CellR1C1InlineStyle);
                tdR1C2.Attributes.Add("style", CellR1C2InlineStyle);
                tdR1C3.Attributes.Add("style", CellR1C3InlineStyle);
                tdR2C1.Attributes.Add("style", CellR2C1InlineStyle);
                tdR2C2.Attributes.Add("style", CellR2C2InlineStyle);
                tdR2C3.Attributes.Add("style", CellR2C3InlineStyle);
                tdR3C1.Attributes.Add("style", CellR3C1InlineStyle);
                tdR3C2.Attributes.Add("style", CellR3C2InlineStyle);
                tdR3C3.Attributes.Add("style", CellR3C3InlineStyle);


                tblFooter = skinProvider.MakePageFooter(this.Page);
				Controls.Add( tblFooter );
				footerPlaceHolder.Controls.Add( tblFooter );


				base.RenderContents (writer);
			}
		}
	}
}