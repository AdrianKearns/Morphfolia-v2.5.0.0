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
    public class ArtWorkPageLayout : BasePageLayout, INamingContainer
	{
        private ISkinProvider skinProvider;

		private PlaceHolder headerPlaceHolder;
		private PlaceHolder contentPlaceHolder;
		private PlaceHolder footerPlaceHolder;
		private WebControl tblHeader;
		private WebControl tblFooter;
		private Morphfolia.WebControls.ArtWork artWork;

		private string bannerImageRootRelativeSrc = string.Empty;


		public ArtWorkPageLayout()
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
			public const string Blurb = "Blurb";
		}

		public class CustomPropertyKeys
		{
			public const string ImageUrl = "ImageUrl";
			public const string Title = "Title";
			public const string Year = "Year";
			public const string Dimensions = "Dimensions";
			public const string Media = "Media";
			public const string SignatureDetails = "SignatureDetails";
			public const string Acquisition = "Acquisition";
			public const string Publications = "Publications";
			public const string EditionNumber = "EditionNumber";
		}


        private CustomPropertyInstanceInfoCollection CustomProperties = null;

        public override void SetCustomProperties(CustomPropertyInstanceInfoCollection customProperties)
		{
			EnsureChildControls();

            CustomProperties = customProperties;

            string propertyKey = string.Empty;
            string propertyValue = string.Empty;

            try
            {
                if (CustomProperties != null)
                {
                    skinProvider = base.LoadSkinProvider(CustomProperties, new Skins.SpecialCircumstances.Anaplian());

                    for (int i = 0; i < CustomProperties.Count; i++)
                    {
                        propertyKey = CustomProperties[i].PropertyKey;
                        propertyValue = CustomProperties[i].PropertyValue;

                        switch (propertyKey)
                        {
                            case Constants.CommonPropertyKeys.FormTemplatePresenterType:
                                FormTemplatePresenterType = propertyValue;
                                break;

                            case ArtWorkPageLayout.CustomPropertyKeys.ImageUrl:
                                artWork.ImageUrl = propertyValue;
                                break;

                            case ArtWorkPageLayout.CustomPropertyKeys.Title:
                                artWork.Title = propertyValue;
                                break;

                            case ArtWorkPageLayout.CustomPropertyKeys.Year:
                                artWork.Year = propertyValue;
                                break;

                            case ArtWorkPageLayout.CustomPropertyKeys.Dimensions:
                                artWork.Dimensions = propertyValue;
                                break;

                            case ArtWorkPageLayout.CustomPropertyKeys.Media:
                                artWork.Media = propertyValue;
                                break;

                            case ArtWorkPageLayout.CustomPropertyKeys.SignatureDetails:
                                artWork.SignatureDetails = propertyValue;
                                break;

                            case ArtWorkPageLayout.CustomPropertyKeys.Publications:
                                artWork.Publications = propertyValue;
                                break;

                            case ArtWorkPageLayout.CustomPropertyKeys.Acquisition:
                                artWork.Acquisition = propertyValue;
                                break;

                            case ArtWorkPageLayout.CustomPropertyKeys.EditionNumber:
                                artWork.EditionNumber = propertyValue;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("PopulateContentContainers() failed, (propertyKey = propertyValue): {0} = {1}", propertyKey, propertyValue), ex);
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
                        case ArtWorkPageLayout.ContentPlugKeys.Blurb:
                            int tempId = GetContentInfoIndexById(int.Parse(propertyValue));
                            if (tempId != Morphfolia.Common.Constants.SystemTypeValues.NullInt)
                            {
                                temp = GetContentInfoIndexById(int.Parse(propertyValue));
                                AddContentToContentContainer(contentPlaceHolder, Page.ContentItems[temp].ContentEntryFilter, Page.ContentItems[temp].Content);
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



		private string blurb = "Blurb";
        [IsContentContainer, ContentContainerColour("#ddeeff"), ContentContainerDescription("Any additional content.")]
        public string Blurb
		{
			get{ return blurb; }
			set{ blurb = value; }
		}

		private string imageUrl = "ImageUrl";
		[IsCustomProperty,
		PropertyFriendlyName("Image Url"),
		PropertyDescription("Allows you specify the url of the image."),
		PropertySuggestedUsage("Guernica.jpg")]
		public string ImageUrl
		{
			get{ return imageUrl; }
			set{ imageUrl = value; }
		}

		private string title = "Title";
		[IsCustomProperty,
		PropertyFriendlyName("Title"),
		PropertyDescription("Allows you specify the name/title of the art work."),
		PropertySuggestedUsage("Impression Sunrise, Les Demoiselles d'Avignon...")]
		public string Title
		{
			get{ return title; }
			set{ title = value; }
		}

		private string year = "Year";
		[IsCustomProperty,
		PropertyFriendlyName("Year"),
		PropertyDescription("Allows you specify the year the art work was created."),
		PropertySuggestedUsage("2002")]
		public string Year
		{
			get{ return year; }
			set{ year = value; }
		}

		private string media = "Media";
		[IsCustomProperty,
		PropertyFriendlyName("Media"),
		PropertyDescription("Allows you specify the Media the art work is made from."),
		PropertySuggestedUsage("Oil on Canvas, Acrylic on Board, Silver Gelatin Print...")]
		public string Media
		{
			get{ return media; }
			set{ media = value; }
		}

		private string dimensions = "Dimensions";
		[IsCustomProperty,
		PropertyFriendlyName("Dimensions"),
		PropertyDescription("Allows you specify the dimensions of the art work."),
		PropertySuggestedUsage("1024 x 768 mm, 601 x 142mmm...")]
		public string Dimensions
		{
			get{ return dimensions; }
			set{ dimensions = value; }
		}

		private string signatureDetails = "SignatureDetails";
		[IsCustomProperty,
		PropertyFriendlyName("Signature Details"),
		PropertyDescription("Details of signature/inscription if present."),
		PropertySuggestedUsage("Initialed, bottom right-hand corner.")]
		public string SignatureDetails
		{
			get{ return signatureDetails; }
			set{ signatureDetails = value; }
		}

		private string acquisition = "Acquisition";
		[IsCustomProperty,
		PropertyFriendlyName("Acquisition"),
		PropertyDescription("Date and location of acquisition of work.")]
		public string Acquisition
		{
			get{ return acquisition; }
			set{ acquisition = value; }
		}

		private string publications = "Publications";
		[IsCustomProperty,
		PropertyFriendlyName("Publications"),
		PropertyDescription("Known publications and reproductions of work.")]
		public string Publications
		{
			get{ return publications; }
			set{ publications = value; }
		}

		private string editionNumber = "EditionNumber";
		[IsCustomProperty,
		PropertyFriendlyName("Edition Number"),
		PropertyDescription("Edition number (if applicable).")]
		public string EditionNumber
		{
			get{ return editionNumber; }
			set{ editionNumber = value; }
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
			base.CreateChildControls ();

			headerPlaceHolder = new PlaceHolder();
			Controls.Add( headerPlaceHolder );
			headerPlaceHolder.ID = "headerPlaceHolder";

			contentPlaceHolder = new PlaceHolder();
			Controls.Add( contentPlaceHolder );
			contentPlaceHolder.ID = "contentPlaceHolder";
			
			artWork = new Morphfolia.WebControls.ArtWork();
			Controls.Add( artWork );
			contentPlaceHolder.Controls.Add( artWork );
			artWork.ID = "artWork";
			artWork.HorizontalAlignment = HorizontalAlign.Center;
			artWork.TitleHorizontalAlignment = HorizontalAlign.Left;
			artWork.OtherTextHorizontalAlignment = HorizontalAlign.Right;

            //Label lblBlurb = new Label();
            //Controls.Add( lblBlurb );
            //contentPlaceHolder.Controls.Add( lblBlurb );
            //lblBlurb.ID = "lblBlurb";

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


                if (ChildControls.Count > 0)
                {
                    for (int c = 0; c < ChildControls.Count; c++)
                    {
                        //tdC1.Controls.Add(ChildControls[c]);
                        contentPlaceHolder.Controls.AddAt(c, ChildControls[c]);
                    }
                }


                tblFooter = skinProvider.MakePageFooter(this.Page);
				Controls.Add( tblFooter );
				footerPlaceHolder.Controls.Add( tblFooter );

				base.RenderContents( writer );
			}
		}
	}
}
