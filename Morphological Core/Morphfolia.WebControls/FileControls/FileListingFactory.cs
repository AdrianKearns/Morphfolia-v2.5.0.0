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


namespace Morphfolia.WebControls.FileControls

{

	/// <summary>
	/// Summary description for Class1.
	/// http://msdn.microsoft.com/msdnmag/issues/03/07/CuttingEdge/default.aspx
	/// http://msdn2.microsoft.com/en-us/library/system.drawing.image.getFileListingimage(VS.80).aspx
	/// </summary>

	public class FileListingFactory
	{

		public bool FileListingCallback()
		{
			return false;
		}


		/// <summary>
		/// Instansiates the FileListingFactory.
		/// </summary>
		/// <param name="pathToWriteDirectory">The full path of the Directory, sets the PathToWriteDirectory property.</param>
		public FileListingFactory( string pathToWriteDirectory )
		{
			this.PathToWriteDirectory = pathToWriteDirectory;
		}
 

		private string pathToWriteDirectory;
		/// <summary>
		/// The directory to which FileListings will be written.
		/// </summary>
		public string PathToWriteDirectory
		{
			get{ return pathToWriteDirectory; }
			set{ pathToWriteDirectory = value; }
		}



		public enum ScaleToDimension{ Width, Height }

 

		public void MakeFileListing( string pathToSourceImage, ScaleToDimension scaleToDimension, int presetDimension )
		{

		}
	}
}
