// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using Morphfolia.Common.Info;
using Morphfolia.Business.Constants;
using Morphfolia.Business.Logs;

namespace Morphfolia.Business
{
    public class ContentItemHelper
    {
        // Not sure if this is needed yet.

        ///// <summary>
        ///// Used to define the different types of Content that the system knows of.
        ///// </summary>
        //public struct ContentTypeDefinition
        //{
        //    public readonly string HumanReadableValue;
        //    public readonly string MachineValue;

        //    /// <summary>
        //    /// Defines a ContentTypeDefinition.
        //    /// </summary>
        //    /// <param name="humanReadableValue">The ContentType as a human would understand it.</param>
        //    /// <param name="machineValue">The ContentType as the system will understand it. Length of 4 characters only</param>
        //    public ContentTypeDefinition(string humanReadableValue, string machineValue)
        //    {
        //        HumanReadableValue = humanReadableValue;
        //        MachineValue = machineValue;
        //    }
        //}






        private static Morphfolia.IDataProvider.IContentDataProvider iContentDataProvider;
        private static Morphfolia.IDataProvider.IContentDataProvider IContentDataProvider
        {
            get
            {
                if (iContentDataProvider == null)
                {
                    iContentDataProvider = Morphfolia.Business.Helpers.ProviderLoader.Load(DataProviderAppSettingKeys.IContentDataProvider) as Morphfolia.IDataProvider.IContentDataProvider;
                }

                return iContentDataProvider;
            }
        }


        public static ContentItem GetContentItemById(int contentId)
		{
            ContentInfo contentInfo  = IContentDataProvider.Content_SELECT_ByContentID(contentId);
            ContentItem contentItem = new ContentItem();

            contentItem.ContentID = contentId;
            contentItem.Note = contentInfo.Note;
            contentItem.Content = contentInfo.Content;
            contentItem.TextContent = contentInfo.TextContent;
            contentItem.IsLive = contentInfo.IsLive;
            contentItem.IsSearchable = contentInfo.IsSearchable;
            contentItem.ContentEntryFilter = contentInfo.ContentEntryFilter;
            contentItem.LastModifiedBy = contentInfo.LastModifiedBy;

            return contentItem;
		}


        public static void DeleteContentItemById(int contentId)
        {
            Auditor.LogAuditEntry(contentId, AuditableObjects.ContentItem, "Deleted");
            IContentDataProvider.Content_DELETE(contentId);
        }

        /// <summary>
        /// Handles inserts and updates, automatically.
        /// </summary>
        /// <param name="contentItem"></param>
        /// <returns></returns>
        public static int Save(ContentItem contentItem)
        {
            if (contentItem.ContentID == Morphfolia.Common.Constants.SystemTypeValues.NullInt)
            {
                // Insert new.
                ContentSaveNewInfo contentSaveNewInfo = new ContentSaveNewInfo(
                    contentItem.Content,
                    contentItem.TextContent,
                    contentItem.Note,
                    contentItem.ContentType,
                    contentItem.IsLive,
                    contentItem.IsSearchable,
                    contentItem.ContentEntryFilter,
                    contentItem.LastModifiedBy
                );


                int id = IContentDataProvider.Content_INSERT(contentSaveNewInfo);

                Auditor.LogAuditEntry(id, AuditableObjects.ContentItem, "Created");

                return id;
            }
            else
            {
                // Update existing.
                ContentUpdateInfo contentUpdateInfo = new ContentUpdateInfo(
                    contentItem.ContentID,
                    contentItem.Content,
                    contentItem.TextContent,
                    contentItem.Note,
                    contentItem.IsLive,
                    contentItem.IsSearchable,
                    contentItem.LastModifiedBy
                );

                IContentDataProvider.Content_UPDATE(contentUpdateInfo);

                Auditor.LogAuditEntry(contentItem.ContentID, AuditableObjects.ContentItem, "Updated");

                return contentItem.ContentID;
            }
        }

        /// <summary>
        /// List all content items, regardless of ContentTypeDefinition or value of the isLive flag.
        /// </summary>
        /// <returns></returns>
		public static ContentListInfoCollection List()
		{
            return IContentDataProvider.Content_SELECT_List();
		}

        /// <summary>
        /// List all content items by ContentTypeDefinition, but regardless of the value of the isLive flag.
        /// </summary>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static ContentListInfoCollection List(Common.ContentTypes.ContentTypeDefinition contentType)
        {
            return IContentDataProvider.Content_SELECT_List(contentType);
        }


        public static ContentListInfoCollection Search(string notesFilter)
        {
            return IContentDataProvider.Content_SELECT_List_Search(notesFilter, Common.ContentTypes.All);
        }

        public static ContentListInfoCollection Search(string notesFilter, Common.ContentTypes.ContentTypeDefinition contentTypeDefinition)
        {
            Logging.Logger.LogVerboseInformation("ContentItemHelper.Search()", notesFilter);
            return IContentDataProvider.Content_SELECT_List_Search(notesFilter, contentTypeDefinition);
        }

        public static ContentListInfoCollection ListById(int id)
        {
            return IContentDataProvider.Content_SELECT_List_ById(id);
        }

        public static ContentListInfoCollection ListById(IntCollection ids)
        {
            //Logging.Logger.LogVerboseInformation("ContentItemHelper.ListById() input", ids.ToString());

            ContentListInfoCollection temp = IContentDataProvider.Content_SELECT_List_ById(ids);
            //Logging.Logger.LogVerboseInformation("ContentItemHelper.ListById() temp", temp.ToString());

            ContentListInfoCollection output = new ContentListInfoCollection();
            foreach (int id in ids)
            {
                output.Add(temp.GetByContentId(id));
            }
            //Logging.Logger.LogVerboseInformation("ContentItemHelper.ListById() output", output.ToString());

            return output;
        }

        public static ContentInfoCollection GetLiveContentByNotesFilter(string notesFilter)
        {
            return IContentDataProvider.Content_SELECT_SearchLiveOnly(notesFilter);
        }

        //public static ContentInfoCollection GetLiveContentByNotesFilter(string notesFilter, Common.ContentTypes.ContentTypeDefinition contentType)
        //{
        //    return IContentDataProvider.Content_SELECT_SearchLiveOnly(notesFilter, contentType);
        //}
    }
}
