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
	/// Used to save a new Image.
	/// </summary>
	public struct ImageSaveNewInfo
	{
		public readonly string ImageName;
		public readonly int Width;
		public readonly int Height;

		public ImageSaveNewInfo(
			string _ImageName,
			int _Width,
			int _Height)
		{
			ImageName = _ImageName;
			Width = _Width;
			Height = _Height;
		}
	}



	/// <summary>
	///  Summary description for ImageInfo.
	/// </summary>
	public struct ImageInfo
	{
		public readonly int ID;
		public readonly string ImageName;
		public readonly int Width;
		public readonly int Height;

		public ImageInfo(
			int _ID,
			string _ImageName,
			int _Width,
			int _Height)
		{
			ID = _ID;
			ImageName = _ImageName;
			Width = _Width;
			Height = _Height;
		}
	}


	public class ImageInfoCollection : CollectionBase
	{
		public ImageInfo this[ int index ]
		{
			get { return( (ImageInfo) List[index] ); }
			set { List[index] = value; }
		}

		public int Add( ImageInfo value )
		{
			return( List.Add( value ) );
		}

		public int IndexOf( ImageInfo value )
		{
			return( List.IndexOf( value ) );
		}

		public void Insert( int index, ImageInfo value )
		{
			List.Insert( index, value );
		}

		public void Remove( ImageInfo value )
		{
			List.Remove( value );
		}

		public bool Contains( ImageInfo value )
		{
			// If value is not of type ImageInfo, this will return false.
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
			if ( value.GetType() != Type.GetType("Morphfolia.Common.Info.ImageInfo") )
				throw new ArgumentException( "value must be of type Morphfolia.Common.Info.ImageInfo.", "value" );
		}
	}

}