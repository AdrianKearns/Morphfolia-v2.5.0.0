// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Drawing;
using System.IO;
using System.Collections.Specialized; 
using Morphfolia.Common.Logging;


namespace Morphfolia.WebControls
{
	/// <summary>
    /// Summary description for ThumbnailFactory.
	/// http://msdn.microsoft.com/msdnmag/issues/03/07/CuttingEdge/default.aspx
	/// http://msdn2.microsoft.com/en-us/library/system.drawing.image.getthumbnailimage(VS.80).aspx
	/// </summary>
	public class ThumbnailFactory
	{
		public bool ThumbnailCallback()
		{
			return false;
		}


		/// <summary>
		/// Instansiates the ThumbnailFactory.
		/// </summary>
		/// <param name="pathToWriteDirectory">The full path of the Directory, sets the PathToWriteDirectory property.</param>
		public ThumbnailFactory( string pathToWriteDirectory )
		{
			this.PathToWriteDirectory = pathToWriteDirectory;
		}
 

		private string pathToWriteDirectory;
		/// <summary>
		/// The directory to which Thumbnails will be written.
		/// </summary>
		public string PathToWriteDirectory
		{
			get{ return pathToWriteDirectory; }
			set{ pathToWriteDirectory = value; }
		}



		public enum ScaleToDimension{ Width, Height }

 

		public void MakeThumbnail( string pathToSourceImage, ScaleToDimension scaleToDimension, int presetDimension )
		{
			NameValueCollection AdditionalInfo = new NameValueCollection();
			AdditionalInfo.Add("pathToSourceImage", pathToSourceImage);
			Bitmap sourceBitmap;
			try
			{
				int newWidth;
				int newHeight;
				Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
				sourceBitmap = new Bitmap( pathToSourceImage );

				//---------------------------------------------------
				// For scaling an image to a preset width, where: 
				// N = New height
				// H = original Height
				// W = original Width
				// X = preset width
				//
				// N = H / (W / X)
				//
				// Or for scaling an image to a preset height: 
				// N = New width
				// H = original Height
				// W = original Width
				// X = preset height
				//
				// N = W / (H / X)
				//---------------------------------------------------

				//decimal decTemp1 = new decimal(); 
				//decimal decTemp2 = new decimal();

 
				if( scaleToDimension == ScaleToDimension.Height )
				{
					// N = W / (H / X)
					newHeight = presetDimension;
					newWidth = (int)decimal.Floor( decimal.Divide( new decimal(sourceBitmap.Width), decimal.Divide( new decimal(sourceBitmap.Height), new decimal(presetDimension) ) ) );
				}
				else
				{
					// N = H / (W / X)
					newWidth = presetDimension;

					// long hand: 
					// decTemp1 = decimal.Divide( new decimal(sourceBitmap.Width), new decimal(presetDimension) );
					// decTemp2 = decimal.Divide( new decimal(sourceBitmap.Height), decTemp1 );
					// newHeight = (int)decimal.Floor( decTemp2 );

					// short hand:
					newHeight = (int)decimal.Floor( decimal.Divide( new decimal(sourceBitmap.Height), decimal.Divide( new decimal(sourceBitmap.Width), new decimal(presetDimension) ) ) );
				}


				AdditionalInfo.Add("108 About to"," Image myThumbnail = sourceBitmap.GetThumbnailImage()");
				Image myThumbnail = sourceBitmap.GetThumbnailImage(newWidth, newHeight, myCallback, IntPtr.Zero);


				string shortFileName = pathToSourceImage;
				shortFileName = shortFileName.Replace("/", @"\");
				shortFileName = shortFileName.Substring( shortFileName.LastIndexOf(@"\")+1 );
				AdditionalInfo.Add("shortFileName", shortFileName);


				string fullFilename = string.Format(@"{0}\{1}", this.PathToWriteDirectory, shortFileName);
				AdditionalInfo.Add("fullFilename", fullFilename);


				AdditionalInfo.Add("myThumbnail.Width", myThumbnail.Width.ToString());
				AdditionalInfo.Add("myThumbnail.Height", myThumbnail.Height.ToString());


				AdditionalInfo.Add("126 About to"," myThumbnail.Save()");
				myThumbnail.Save( fullFilename, System.Drawing.Imaging.ImageFormat.Jpeg );
			}
			catch( System.Exception ex )
			{
				AdditionalInfo.Add("Error in", "MakeThumbnail()");
                ExceptionManager.Publish(ex, EventIds.Default.Error, AdditionalInfo);

				throw;
			}
		}

	}

}
