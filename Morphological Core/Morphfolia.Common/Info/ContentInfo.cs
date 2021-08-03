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
    public class ContentInfoFactory
    {
        public static ContentInfo NullContentInfo()
        {
            return new ContentInfo(
                Constants.SystemTypeValues.NullInt,
                string.Empty, string.Empty, string.Empty, Common.ContentTypes.All,
                true, false, string.Empty, DateTime.Now, "The System");
        }


        /// <summary>
        /// Allows you to specify some basic properties so that 
        /// the item can be used in a 'not found' senario.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="notes"></param>
        /// <returns></returns>
        public static ContentInfo NullContentInfo(string content, string notes)
        {
            return new ContentInfo(
                Constants.SystemTypeValues.NullInt,
                content, string.Empty, notes, Common.ContentTypes.All,
                true, false, string.Empty, DateTime.Now, "The System");
        }


        /// <summary>
        /// Use when you need to return a content item, but can't or 
        /// don't want to return the one requested (roughly equivalent 
        /// to a 404 page for a web page).
        /// </summary>
        /// <returns></returns>
        public static ContentInfo ContentNotFound()
        {
            return new ContentInfo(
                Constants.SystemTypeValues.NullInt,
                "Sorry, the content you requested is not available.", string.Empty, "Content not found.", Common.ContentTypes.All,
                true, false, string.Empty, DateTime.Now, "The System");
        }
    }


	/// <summary>
	///  Summary description for ContentInfo.
	/// </summary>
	public struct ContentInfo
	{
		public readonly int ContentID;
		public readonly string Content;
		public readonly string TextContent;
		public readonly string Note;
        public readonly Common.ContentTypes.ContentTypeDefinition ContentType;
		public readonly bool IsLive;
		public readonly bool IsSearchable;
        public readonly string ContentEntryFilter;
		public readonly DateTime LastModified;
		public readonly string LastModifiedBy;

		public ContentInfo(
			int contentID,
			string content,
			string textContent,
			string note,
            Common.ContentTypes.ContentTypeDefinition contentType,
			bool isLive,
			bool isSearchable,
            string contentEntryFilter,
			DateTime lastModified,
			string lastModifiedBy)
		{
			ContentID = contentID;
			Content = content;
			TextContent = textContent;
			Note = note;
            ContentType = contentType;
			IsLive = isLive;
			IsSearchable = isSearchable;
            ContentEntryFilter = contentEntryFilter;
			LastModified = lastModified;
			LastModifiedBy = lastModifiedBy;
		}
	}


	/// <summary>
	///  Summary description for ContentInfo.
	/// </summary>
	public struct ContentUpdateInfo
	{
		public readonly int ContentID;
		public readonly string Content;
		public readonly string TextContent;
		public readonly string Note;
		public readonly bool IsLive;
		public readonly bool IsSearchable;
		public readonly string LastModifiedBy;

		public ContentUpdateInfo(
			int _ContentID,
			string _Content,
			string _TextContent,
			string _Note,
			bool _IsLive,
			bool _IsSearchable,
			string _LastModifiedBy)
		{
			ContentID = _ContentID;
			Content = _Content;
			TextContent = _TextContent;
			Note = _Note;
			IsLive = _IsLive;
			IsSearchable = _IsSearchable;
			LastModifiedBy = _LastModifiedBy;
		}
	}

	
	/// <summary>
	///  Summary description for ContentInfo.
	/// </summary>
	public struct ContentSaveNewInfo
	{
		public readonly string Content;
		public readonly string TextContent;
		public readonly string Note;
        public readonly Common.ContentTypes.ContentTypeDefinition ContentType;
		public readonly bool IsLive;
		public readonly bool IsSearchable;
        public readonly string ContentEntryFilter;
		public readonly string LastModifiedBy;

		public ContentSaveNewInfo(
			string content,
			string textContent,
			string note,
            Common.ContentTypes.ContentTypeDefinition contentType,
			bool isLive,
			bool isSearchable,
            string contentEntryFilter,
			string lastModifiedBy)
		{
			Content = content;
			TextContent = textContent;
			Note = note;
            ContentType = contentType;
			IsLive = isLive;
			IsSearchable = isSearchable;
            ContentEntryFilter = contentEntryFilter;
			LastModifiedBy = lastModifiedBy;
		}
	}



	public struct ContentListInfo
	{
		public readonly int ContentID;
		public readonly string Note;
        public readonly Common.ContentTypes.ContentTypeDefinition ContentType;
		public readonly bool IsLive;
		public readonly bool IsSearchable;
		public readonly DateTime LastModified;
		public readonly string LastModifiedBy;
		public readonly int PageUsageCount;

		public ContentListInfo(
			int contentID,
			string note,
            Common.ContentTypes.ContentTypeDefinition contentType,
			bool isLive,
			bool isSearchable,
			DateTime lastModified,
			string lastModifiedBy,
			int pageUsageCount)
		{
			ContentID = contentID;
			Note = note;
            ContentType = contentType;
			IsLive = isLive;
			IsSearchable = isSearchable;
			LastModified = lastModified;
			LastModifiedBy = lastModifiedBy;
			PageUsageCount = pageUsageCount;
		}
	}



	public class ContentInfoCollection : CollectionBase
	{
		public ContentInfo this[ int index ]
		{
			get { 
				try
				{
					return( (ContentInfo) List[index] ); 
				}
				catch(System.Exception e)
				{
					throw new IndexOutOfRangeException( string.Format("index {0} not found.", index.ToString()), e );
				}
			}
			set { List[index] = value; }
		}

		/// <exclude />
		public int Add( ContentInfo value )
		{
			return( List.Add( value ) );
		}

		/// <exclude />
		public int IndexOf( ContentInfo value )
		{
			return( List.IndexOf( value ) );
		}

		/// <exclude />
		public void Insert( int index, ContentInfo value )
		{
			List.Insert( index, value );
		}

		/// <exclude />
		public void Remove( ContentInfo value )
		{
			List.Remove( value );
		}

		/// <exclude />
		public bool Contains( ContentInfo value )
		{
			// If value is not of type ContentInfo, this will return false.
			return( List.Contains( value ) );
		}

		/// <exclude />
		protected override void OnInsert( int index, Object value )
		{
			// Insert additional code to be run only when inserting values.
		}

		/// <exclude />
		protected override void OnRemove( int index, Object value )
		{
			// Insert additional code to be run only when removing values.
		}

		/// <exclude />
		protected override void OnSet( int index, Object oldValue, Object newValue )
		{
			// Insert additional code to be run only when setting values.
		}

		/// <exclude />
		protected override void OnValidate( Object value )
		{
			if ( value.GetType() != Type.GetType("Morphfolia.Common.Info.ContentInfo") )
				throw new ArgumentException( "value must be of type Morphfolia.Common.Info.ContentInfo.", "value" );
		}


        public ContentInfo ById(int contentId)
        {
            ContentInfo info;
            for (int i = 0; i < List.Count; i++)
            {
                info = (ContentInfo)List[i];

                if (info.ContentID.Equals(contentId))
                {
                    return info;
                }
            }
            return new ContentInfo();
        }  
	}



	
	public class ContentListInfoCollection : CollectionBase
	{
        public override string ToString()
        {
            //return base.ToString();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(base.ToString());
            foreach (ContentListInfo info in base.List)
            {
                sb.AppendFormat(" {0}", info.ContentID);
            }

            return sb.ToString();
        }


		public ContentListInfo this[ int index ]
		{
			get { return( (ContentListInfo) List[index] ); }
			set { List[index] = value; }
		}

		/// <exclude />
		public int Add( ContentListInfo value )
		{
			return( List.Add( value ) );
		}

		/// <exclude />
		public int IndexOf( ContentListInfo value )
		{
			return( List.IndexOf( value ) );
		}



        public ContentListInfo GetByContentId(int contentId)
        {
            foreach (ContentListInfo info in List)
            {
                if (info.ContentID.Equals(contentId))
                {
                    return info;
                }
            }

            return new ContentListInfo();
        }


		/// <exclude />
		public void Insert( int index, ContentListInfo value )
		{
			List.Insert( index, value );
		}

		/// <exclude />
		public void Remove( ContentListInfo value )
		{
			List.Remove( value );
		}

		/// <exclude />
		public bool Contains( ContentListInfo value )
		{
			// If value is not of type ContentInfo, this will return false.
			return( List.Contains( value ) );
		}

		/// <exclude />
		protected override void OnInsert( int index, Object value )
		{
			// Insert additional code to be run only when inserting values.
		}

		/// <exclude />
		protected override void OnRemove( int index, Object value )
		{
			// Insert additional code to be run only when removing values.
		}

		/// <exclude />
		protected override void OnSet( int index, Object oldValue, Object newValue )
		{
			// Insert additional code to be run only when setting values.
		}

		/// <exclude />
		protected override void OnValidate( Object value )
		{
			if ( value.GetType() != Type.GetType("Morphfolia.Common.Info.ContentListInfo") )
				throw new ArgumentException( "value must be of type Morphfolia.Common.Info.ContentListInfo.", "value" );
		}
	}


}
