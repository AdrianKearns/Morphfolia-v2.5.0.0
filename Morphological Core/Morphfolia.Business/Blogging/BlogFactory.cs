// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Generic;
using System.Text;
using Morphfolia.Common.Info;
using Morphfolia.IDataProvider;
using Morphfolia.Business.Constants;

namespace Morphfolia.Business.Blogging
{
    public class BlogFactory
    {
        private static PageInfo pageInformation;


        private static IPageDataProvider iPageDataProvider;
        private static IPageDataProvider IPageDataProvider
        {
            get
            {
                if (iPageDataProvider == null)
                {
                    iPageDataProvider = Helpers.ProviderLoader.Load(DataProviderAppSettingKeys.IPageDataProvider) as IPageDataProvider;
                }

                return iPageDataProvider;
            }
        }



        private static IContentDataProvider iContentDataProvider;
        private static IContentDataProvider IContentDataProvider
        {
            get
            {
                if (iContentDataProvider == null)
                {
                    iContentDataProvider = Helpers.ProviderLoader.Load(DataProviderAppSettingKeys.IContentDataProvider) as IContentDataProvider;
                }
                return iContentDataProvider;
            }
        }


        private static ICustomPropertiesDataProvider iCustomPropertiesDataProvider;
        private static ICustomPropertiesDataProvider ICustomPropertiesDataProvider
        {
            get
            {
                if (iCustomPropertiesDataProvider == null)
                {
                    iCustomPropertiesDataProvider = Helpers.ProviderLoader.Load(DataProviderAppSettingKeys.ICustomPropertiesDataProvider) as ICustomPropertiesDataProvider;
                }
                return iCustomPropertiesDataProvider;
            }
        }


        /// <summary>
        /// Builds a Blog based on its Id, which is the underlying pages Id.
        /// </summary>
        /// <param name="pageId"></param>
        /// <returns></returns>
        public static Blog ById(int pageId)
        {
            try
            {
                pageInformation = IPageDataProvider.Page_SELECT_PageByID(pageId);
                return new Blog(pageInformation);
            }
            catch (Exception ex)
            {
                Logging.Logger.LogException("BlogFactory.ById() failed", ex);
                return NotFound();
            }
        }


        /// <summary>
        /// Builds a Blog based on its name, which is the underlying pages Title.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Blog ByName(string name)
        {
            try
            {
                pageInformation = IPageDataProvider.Page_SELECT_PageByTitle(name);
                return new Blog(pageInformation);
            }
            catch(Exception ex)
            {
                Logging.Logger.LogException("BlogFactory.ByName() failed", ex);
                return NotFound();
            }
        }


        /// <summary>
        /// Builds a Blog based on its name, which is the underlying pages Title.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Blog ByUrl(string derivedPageUrl)
        {
            try
            {
                pageInformation = IPageDataProvider.Page_SELECT_ByURLForLivePublishing(derivedPageUrl);
                return new Blog(pageInformation);
            }
            catch (Exception ex)
            {
                Logging.Logger.LogException("BlogFactory.ByName() failed", ex);
                return NotFound();
            }
        }


        public static Blog NotFound()
        {
            pageInformation = new PageInfo(Morphfolia.Common.Constants.SystemTypeValues.NullInt,
                "Blog Not Found",
                string.Empty,
                string.Empty,
                "Sorry, the information you want is not available.",
                DateTime.Now,
                "The System", false, true);
            return new Blog(pageInformation);
        }
    }
}
