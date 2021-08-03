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
	///  Summary description for PageInfo.
	/// </summary>
	public struct PageInfo
	{
		public readonly int PageID;
		public readonly string Title;
		public readonly string Url;
		public readonly string Keywords;
		public readonly string Description;
		public readonly DateTime LastModified;
		public readonly string LastModifiedBy;
		public readonly bool IsSearchable;
		public readonly bool IsLive;

		public PageInfo(
			int pageID,
			string title,
			string url,
			string keywords,
			string description,
			DateTime lastModified,
			string lastModifiedBy,
			bool isSearchable,
			bool isLive)
		{
			PageID = pageID;
			Title = title;
			Url = url;
			Keywords = keywords;
			Description = description;
			LastModified = lastModified;
			LastModifiedBy = lastModifiedBy;
			IsSearchable = isSearchable;
			IsLive = isLive;
		}
	}




	/// <summary>
	/// Used to INSERT a page.
	/// </summary>
	public struct PageSaveNewInfo
	{
		public readonly string Title;
		public readonly string Url;
		public readonly string Keywords;
		public readonly string Description;
		public readonly string LastModifiedBy;
		public readonly bool IsSearchable;
		public readonly bool IsLive;

		public PageSaveNewInfo(
			string title,
			string url,
			string keywords,
			string description,
			string lastModifiedBy,
			bool isSearchable,
			bool isLive)
		{
			Title = title;
			Url = url;
			Keywords = keywords;
			Description = description;
			//LastModified = DateTime.Now;
			LastModifiedBy = lastModifiedBy;
			IsSearchable = isSearchable;
			IsLive = isLive;
		}
	}




	/// <summary>
	/// Used to UPDATE a page.
	/// </summary>
	public struct PageUpdateInfo
	{
		public readonly int PageID;
		public readonly string Title;
		public readonly string Url;
		public readonly string Keywords;
		public readonly string Description;
		public readonly DateTime LastModified;
		public readonly string LastModifiedBy;
		public readonly bool IsSearchable;
		public readonly bool IsLive;

		public PageUpdateInfo(
			int pageID,
			string title,
			string url,
			string keywords,
			string description,
			string lastModifiedBy,
			bool isSearchable,
			bool isLive)
		{
			PageID = pageID;
			Title = title;
			Url = url;
			Keywords = keywords;
			Description = description;
			LastModified = DateTime.Now;
			LastModifiedBy = lastModifiedBy;
			IsSearchable = isSearchable;
			IsLive = isLive;
		}
	}



	public class PageInfoCollection : CollectionBase
	{
		public Morphfolia.Common.Info.PageInfo this[ int index ]
		{
			get { 
				if((index > -1)&&(index < List.Count))
				{
					return( (Morphfolia.Common.Info.PageInfo) List[index] );
				}
				else
				{
					throw new ArgumentOutOfRangeException("index", index, string.Format("PageInfoCollection error: could not get the item with the index of: {0}", index.ToString()) );
				}
			}
			set { List[index] = value; }
		}


        public new void Clear()
        {
            List.Clear();
        }


		public int Add( Morphfolia.Common.Info.PageInfo value )
		{
			return( List.Add( value ) );
		}

		public int IndexOf( Morphfolia.Common.Info.PageInfo value )
		{
			return( List.IndexOf( value ) );
		}

		public void Insert( int index, Morphfolia.Common.Info.PageInfo value )
		{
			List.Insert( index, value );
		}

		public void Remove( Morphfolia.Common.Info.PageInfo value )
		{
			List.Remove( value );
		}

		public bool Contains( Morphfolia.Common.Info.PageInfo value )
		{
			// If value is not of type Morphfolia.Common.Info.PageInfo, this will return false.
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
			if ( value.GetType() != Type.GetType("Morphfolia.Common.Info.PageInfo") )
				throw new ArgumentException( "value must be of type Morphfolia.Common.Info.PageInfo.", "value" );
		}
	}

	
	public class UniquePageInfoCollection : CollectionBase
	{
		public object Add( Morphfolia.Common.Info.PageInfo pValue )
		{
			string dirValuePath = "";
			string dirTempPath = "";
			string returnValue = "";
			bool safeToAdd = true;


			if( pValue.Url.LastIndexOf("/") < 0)
			{
				dirValuePath = pValue.Url;
			}
			else
			{
				dirValuePath = pValue.Url.Substring( 0, pValue.Url.LastIndexOf("/") );
			}

			foreach( Morphfolia.Common.Info.PageInfo p in List )
			{
				// get the full directory path:
				if( p.Url.LastIndexOf("/") < 0)
				{
					dirTempPath = p.Url;
				}
				else
				{
					dirTempPath = p.Url.Substring( 0, p.Url.LastIndexOf("/") );
				}

				if( dirTempPath == dirValuePath )
				{
					safeToAdd = false;
					returnValue = "duplicatePath";
					break;
				}
			}

			if( safeToAdd )
			{
				// Page is unique in the List collection, add it and return the index:
				return( List.Add( pValue ) );
			}
			else
			{
				// The Page is already present, return 'error':
				return returnValue;
			}
		}
	}

}