// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using Morphfolia.SQLDataProvider.Logging;
using Morphfolia.SQLDataProvider.Utilities;
using Morphfolia.IDataProvider;
using Morphfolia.Common.Info;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace Morphfolia.SQLDataProvider
{
	/// <summary>
	/// Summary description for ImageDataProvider.
	/// </summary>
	public class ImageDataProvider : Morphfolia.IDataProvider.IImageDataProvider
	{
		public void Image_INSERT( ImageSaveNewInfo imageSaveNewInfo )
		{
			try
			{
                SqlDatabaseHelper.CurrentDatabase.ExecuteNonQuery(
					"Image_INSERT",
					imageSaveNewInfo.ImageName,
					imageSaveNewInfo.Width,
					imageSaveNewInfo.Height);
			}
			catch( System.Exception ex )
			{
				throw new ApplicationException("Image_INSERT: the execution of Morphological.Utilities.SQLCommandHelper.ExecuteNonQuery() failed.", ex);
			}
		}


		public ImageInfo Image_SELECT_ByImageName( string imageName )
		{
			ImageInfo imageInfo;
            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
					   "Image_SELECT_ByImageName", imageName))
			{
				if (dr.Read())
				{
					imageInfo = new Morphfolia.Common.Info.ImageInfo(
						(int)dr["ID"],
						dr["ImageName"].ToString(),
						(int)dr["Width"],
						(int)dr["Height"]
						);
				}
				else
				{
					// Not sure what to do here.
					//throw new ApplicationException( string.Format("Could not find an image with this name: {0}", imageName) );
					return new ImageInfo(-1, null, -1, -1);
				}
			}
			return imageInfo;
		}
	}
}