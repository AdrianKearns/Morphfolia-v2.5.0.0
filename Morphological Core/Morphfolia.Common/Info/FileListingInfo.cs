// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections;

namespace Morphfolia.Common.Info
{

	/// <summary>
	/// Used to save a new FileListing.
	/// </summary>
	public struct FileListingSaveNewInfo
	{
		public readonly string FileListingName;
		
		public FileListingSaveNewInfo(
			string _FileListingName
			)
		{
			FileListingName = _FileListingName;
		}
	}



	/// <summary>
	///  Summary description for FileListingInfo.
	/// </summary>
	public struct FileListingInfo
	{
		public readonly int ID;
		public readonly string FileListingName;

		public FileListingInfo(
			int _ID,
			string _FileListingName
			)
		{
			ID = _ID;
			FileListingName = _FileListingName;
		}
	}


	public class FileListingInfoCollection : CollectionBase
	{
		public FileListingInfo this[ int index ]
		{
			get { return( (FileListingInfo) List[index] ); }
			set { List[index] = value; }
		}

		public int Add( FileListingInfo value )
		{
			return( List.Add( value ) );
		}

		public int IndexOf( FileListingInfo value )
		{
			return( List.IndexOf( value ) );
		}

		public void Insert( int index, FileListingInfo value )
		{
			List.Insert( index, value );
		}

		public void Remove( FileListingInfo value )
		{
			List.Remove( value );
		}

		public bool Contains( FileListingInfo value )
		{
			// If value is not of type FileListingInfo, this will return false.
			return( List.Contains( value ) );
		}

		protected override void OnInsert( int index, Object value )
		{
			// Insert additional code to be run only when inserting values.
		}

		protected override void OnRemove( int index, Object value )
		{
			// Insert additional code to be run only when removing values.
		}

		protected override void OnSet( int index, Object oldValue, Object newValue )
		{
			// Insert additional code to be run only when setting values.
		}

		protected override void OnValidate( Object value )
		{
			if ( value.GetType() != Type.GetType("Morphfolia.Common.Info.FileListingInfo") )
				throw new ArgumentException( "value must be of type Morphfolia.Common.Info.FileListingInfo.", "value" );
		}
	}

}