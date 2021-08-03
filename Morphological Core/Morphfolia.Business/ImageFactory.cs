// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using Morphfolia.Common.Info;
using System;
using System.Collections.Specialized; 
using Morphfolia.Common.Logging;
using Morphfolia.Business.Constants;


namespace Morphfolia.Business
{
	/// <summary>
	/// Currently only deals with Morphfolia.Common.Info objects, will one day provide a richer layer of 
	/// functionality and deal with a 'proper' Morphfolia.Business.Image object type.
	/// </summary>
	public class ImageFactory
	{
        private static Morphfolia.IDataProvider.IImageDataProvider iImageDataProvider;
        private static Morphfolia.IDataProvider.IImageDataProvider IImageDataProvider
        {
            get
            {
                if (iImageDataProvider == null)
                {
                    iImageDataProvider = Helpers.ProviderLoader.Load(DataProviderAppSettingKeys.IImageDataProvider) as Morphfolia.IDataProvider.IImageDataProvider;
                }
                return iImageDataProvider;
            }
        }


		public static ImageInfo SaveImageDetails( string imageName, int width, int height )
		{
            IImageDataProvider.Image_INSERT(new ImageSaveNewInfo(imageName, width, height));
			return ByImageName( imageName );
		}


		public static ImageInfo ByImageName( string imageName )
		{
			if( imageName == null )
			{
				throw new ApplicationException("imageName cannot be null");
			}

			if( imageName.Length < 5 )
			{
				throw new ApplicationException("imageName cannot be less than 5 chars long");
			}

            return IImageDataProvider.Image_SELECT_ByImageName(imageName);
		}
	}
}
