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
using Morphfolia.Common;
using Morphfolia.Common.Info;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace Morphfolia.SQLDataProvider
{
	/// <summary>
    /// Summary description for CustomPropertiesDataProvider.
	/// </summary>
	public class CustomPropertiesDataProvider : ICustomPropertiesDataProvider
	{
		private class TableColumnNames
		{
			public class ControlProperties
			{
				public static readonly string ID = "ID";
				public static readonly string InstanceID = "InstanceID";
				public static readonly string PropertyType = "PropertyType";
				public static readonly string PropertyKey = "PropertyKey";
				public static readonly string PropertyValue = "PropertyValue";
			}		
		}


		public void ControlProperties_INSERT( SaveNewCustomPropertyInstanceInfo controlPropertySaveNewInfo )
		{
			try
			{
                bool commitSave = true;

                if (controlPropertySaveNewInfo.PropertyType.PropertyTypeIdentifier == Morphfolia.Common.ControlPropertyTypeConstants.PropertyTypeIdentifiers.CONT)
                {
                    int i;
                    bool isNumeric = int.TryParse(controlPropertySaveNewInfo.PropertyValue, out i);
                    if (!isNumeric)
                    {
                        commitSave = false;
                        Logger.LogWarning("ControlProperties_INSERT() save aborted, value must be numeric if PropertyTypeIdentifiers == CONT", controlPropertySaveNewInfo.ToString(), 666);
                    }
                }

                if (commitSave)
                {
                    SqlDatabaseHelper.CurrentDatabase.ExecuteNonQuery(
                        "ControlProperties_INSERT",
                        controlPropertySaveNewInfo.InstanceID,
                        controlPropertySaveNewInfo.PropertyType.PropertyTypeIdentifier,
                        controlPropertySaveNewInfo.PropertyKey,
                        controlPropertySaveNewInfo.PropertyValue);
                }

			}
			catch( System.Exception ex )
			{
				throw new Morphfolia.IDataProvider.Exceptions.InsertFailedException("ControlProperties_INSERT failed.", ex);
			}
		}



		public void ControlProperties_DELETE_BYID( int id )
		{
            SqlDatabaseHelper.CurrentDatabase.ExecuteNonQuery("ControlProperties_DELETE_BYID", id);
		}


		public void ControlProperties_DELETE_BYInstanceID( int instanceID )
		{
            Logging.Logger.LogVerboseInformation("CustomPropertiesDataProvider.ControlProperties_DELETE_BYInstanceID", string.Format("invoked, instanceID = {0}", instanceID.ToString()), 666);

            SqlDatabaseHelper.CurrentDatabase.ExecuteNonQuery("ControlProperties_DELETE_BYInstanceID", instanceID);
		}


		public void ControlProperties_DELETE_BYInstanceIDPropertyKey( int instanceID, string propertyKey )
		{
            SqlDatabaseHelper.CurrentDatabase.ExecuteNonQuery("ControlProperties_DELETE_BYInstanceIDPropertyKey", instanceID, propertyKey);
		}


        public void ControlProperties_DELETE_BYInstanceIDPropertyType(int instanceID, string propertyType)
        {
            SqlDatabaseHelper.CurrentDatabase.ExecuteNonQuery("ControlProperties_DELETE_BYInstanceIDPropertyType", instanceID, propertyType);
        }


        public void ControlProperties_DELETE_BYPropertyKeyAndPropertyValue(string propertyKey, string propertyValue)
        {
            SqlDatabaseHelper.CurrentDatabase.ExecuteNonQuery("ControlProperties_DELETE_BYPropertyKeyAndPropertyValue", propertyKey, propertyValue);
        }

        public void ControlProperties_DELETE_BYPropertyTypeAndPropertyValue(string propertyType, string propertyValue)
        {
            SqlDatabaseHelper.CurrentDatabase.ExecuteNonQuery("ControlProperties_DELETE_BYPropertyTypeAndPropertyValue", propertyType, propertyValue);
        }




		/// <summary>
		/// Gets a single Control Property by its unique id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public CustomPropertyInstanceInfo ControlProperties_SELECT_BYID( int id )
		{
            Logging.Logger.LogVerboseInformation("CustomPropertiesDataProvider.ControlProperties_SELECT_BYID", string.Format("invoked, id = {0}", id.ToString()), 666);

			CustomPropertyInstanceInfo controlPropertyInfo;

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader("ControlProperties_SELECT_BYID", id))
			{
				if (dr.Read())
				{
					controlPropertyInfo = new CustomPropertyInstanceInfo(
						id,
						(int)dr[TableColumnNames.ControlProperties.InstanceID],
						Common.ControlPropertyTypeFactory.ControlPropertyType( dr[TableColumnNames.ControlProperties.PropertyType].ToString() ),
						dr[TableColumnNames.ControlProperties.PropertyKey].ToString(),
						dr[TableColumnNames.ControlProperties.PropertyValue].ToString()
						);
				}
				else
				{
					throw new Morphfolia.IDataProvider.Exceptions.DataNotFoundException( string.Format("Could not find a Control Property with this ID: {0}", id.ToString()) );
				}
			}

			return controlPropertyInfo;
		}


		public CustomPropertyInstanceInfoCollection ControlProperties_SELECT_BYInstanceIDPropertyKey( int instanceID, string propertyKey )
		{
			CustomPropertyInstanceInfoCollection controlPropertyInfoCollection = new CustomPropertyInstanceInfoCollection();
			CustomPropertyInstanceInfo controlPropertyInfo;

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
					   "ControlProperties_SELECT_BYInstanceIDPropertyKey", instanceID, propertyKey)
					   )
			{
				if (dr.HasRows)
				{
					while(dr.Read())
					{
						controlPropertyInfo = new CustomPropertyInstanceInfo(
							(int)dr[TableColumnNames.ControlProperties.ID],
							instanceID,
							Common.ControlPropertyTypeFactory.ControlPropertyType( dr[TableColumnNames.ControlProperties.PropertyType].ToString() ),
							propertyKey,
							dr[TableColumnNames.ControlProperties.PropertyValue].ToString()
							);
						controlPropertyInfoCollection.Add( controlPropertyInfo );
					}
				}
			}

			return controlPropertyInfoCollection;			
		}


        public CustomPropertyInstanceInfoCollection ControlProperties_SELECT_BYInstanceIDPropertyValueAndKey(int instanceID, string propertyValue, string propertyKey)
        {
            CustomPropertyInstanceInfoCollection controlPropertyInfoCollection = new CustomPropertyInstanceInfoCollection();
            CustomPropertyInstanceInfo controlPropertyInfo;

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
                       "ControlProperties_SELECT_BYInstanceIDPropertyValueAndKey", instanceID, propertyValue, propertyKey)
                       )
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        controlPropertyInfo = new CustomPropertyInstanceInfo(
                            (int)dr[TableColumnNames.ControlProperties.ID],
                            instanceID,
                            Common.ControlPropertyTypeFactory.ControlPropertyType(dr[TableColumnNames.ControlProperties.PropertyType].ToString()),
                            propertyKey,
                            dr[TableColumnNames.ControlProperties.PropertyValue].ToString()
                            );
                        controlPropertyInfoCollection.Add(controlPropertyInfo);
                    }
                }
            }

            return controlPropertyInfoCollection;	
        }

		/// <summary>
		/// Gets a collection of Control Properties by their InstanceID.
		/// </summary>
		/// <param name="instanceID"></param>
		/// <returns></returns>
        public CustomPropertyInstanceInfoCollection ControlProperties_SELECT_BYInstanceID(int instanceID)
		{
            Logging.Logger.LogVerboseInformation("CustomPropertiesDataProvider.ControlProperties_SELECT_BYInstanceID", string.Format("invoked, instanceID = {0}", instanceID.ToString()), 666);

            CustomPropertyInstanceInfo controlPropertyInfo;
            CustomPropertyInstanceInfoCollection controlPropertyInfoCollection = new CustomPropertyInstanceInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
					   "ControlProperties_SELECT_BYInstanceID",
                       instanceID))
			{
				if (dr.HasRows)
				{
					while(dr.Read())
					{
						controlPropertyInfo = new CustomPropertyInstanceInfo(
							(int)dr[TableColumnNames.ControlProperties.ID],
							instanceID,
							Common.ControlPropertyTypeFactory.ControlPropertyType( dr[TableColumnNames.ControlProperties.PropertyType].ToString() ),
							dr[TableColumnNames.ControlProperties.PropertyKey].ToString(),
							dr[TableColumnNames.ControlProperties.PropertyValue].ToString()
							);
						controlPropertyInfoCollection.Add( controlPropertyInfo );
					}
				}
			}

			return controlPropertyInfoCollection;
		}





        public GenericStringIntInfoCollection ControlProperties_SELECT_CTagsForLiveBlog(int pageId, bool orderAlphabetically)
        {
            GenericStringIntInfo tag;
            GenericStringIntInfoCollection tags = new GenericStringIntInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
                       "ControlProperties_SELECT_CTagsForLiveBlog", pageId, Utilities.BoolIntConverter.ToInt(orderAlphabetically)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        tag = new GenericStringIntInfo(
                            dr[TableColumnNames.ControlProperties.PropertyValue].ToString(),
                            (int)dr["TagCount"]
                            );
                        tags.Add(tag);
                    }
                }
            }

            return tags;
        }


        public GenericStringIntInfoCollection ControlProperties_SELECT_CTagsForLiveBlogs(bool orderAlphabetically)
        {
            GenericStringIntInfo tag;
            GenericStringIntInfoCollection tags = new GenericStringIntInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
                       "ControlProperties_SELECT_CTagsForLiveBlogs", Utilities.BoolIntConverter.ToInt(orderAlphabetically)))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        tag = new GenericStringIntInfo(
                            dr[TableColumnNames.ControlProperties.PropertyValue].ToString(),
                            (int)dr["TagCount"]
                            );
                        tags.Add(tag);
                    }
                }
            }
            
            return tags;            
        }




        public SearchResultInfoCollection ControlProperties_SELECT_BlogPostsByCTag(string tag)
        {
            SearchResultInfo info;
            SearchResultInfoCollection collection = new SearchResultInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
                       "ControlProperties_SELECT_BlogPostsByCTag", tag))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DateTime lastModified;

                        try
                        {
                            lastModified = DateTime.Parse(dr["LastModified"].ToString());
                        }
                        catch
                        {
                            lastModified = Morphfolia.Common.Constants.SystemTypeValues.NullDate;
                        }

                        info = new SearchResultInfo(
                            (int)dr["PageID"],
                            dr["Title"].ToString(),
                            dr["Url"].ToString(),
                            dr["MetaKeywords"].ToString(),
                            dr["MetaDescription"].ToString(),
                            lastModified,
                            dr["LastModifiedBy"].ToString(),
                            (int)dr["Matches"],
                            (int)dr["ContentId"],
                            dr["Note"].ToString(),
                            dr["ContentType"].ToString()
                            );
                        collection.Add(info);
                    }
                }
            }

            return collection;
        }


        /// <summary>
        /// Gets a collection of Control Properties by their InstanceID and PropertyType.
        /// </summary>
        /// <param name="instanceID"></param>
        /// <param name="propertyType">string (char(4)): CONT CUST</param>
        /// <returns></returns>
        public CustomPropertyInstanceInfoCollection ControlProperties_SELECT_BYInstanceIDPropertyType(int instanceID, string propertyType)
        {
            Logging.Logger.LogVerboseInformation("ControlProperties_SELECT_BYInstanceIDPropertyType", string.Format("instanceID={0}, propertyType={1}", instanceID.ToString(), propertyType));

            CustomPropertyInstanceInfo controlPropertyInfo;
            CustomPropertyInstanceInfoCollection controlPropertyInfoCollection = new CustomPropertyInstanceInfoCollection();

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
                       "ControlProperties_SELECT_BYInstanceIDPropertyType", instanceID, propertyType))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        controlPropertyInfo = new CustomPropertyInstanceInfo(
                            (int)dr[TableColumnNames.ControlProperties.ID],
                            instanceID,
                            Common.ControlPropertyTypeFactory.ControlPropertyType(dr[TableColumnNames.ControlProperties.PropertyType].ToString()),
                            dr[TableColumnNames.ControlProperties.PropertyKey].ToString(),
                            dr[TableColumnNames.ControlProperties.PropertyValue].ToString()
                            );
                        controlPropertyInfoCollection.Add(controlPropertyInfo);
                    }
                }
            }

            return controlPropertyInfoCollection;
        }


        public CustomPropertyInstanceInfoCollection ControlProperties_SELECT_BYPropertyKey(string propertyKey)
        {
            CustomPropertyInstanceInfoCollection controlPropertyInfoCollection = new CustomPropertyInstanceInfoCollection();
            CustomPropertyInstanceInfo controlPropertyInfo;

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
                       "ControlProperties_SELECT_BYPropertyKey", propertyKey))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        controlPropertyInfo = new CustomPropertyInstanceInfo(
                            (int)dr[TableColumnNames.ControlProperties.ID],
                            (int)dr[TableColumnNames.ControlProperties.InstanceID],
                            Common.ControlPropertyTypeFactory.ControlPropertyType(dr[TableColumnNames.ControlProperties.PropertyType].ToString()),
                            dr[TableColumnNames.ControlProperties.PropertyKey].ToString(),
                            dr[TableColumnNames.ControlProperties.PropertyValue].ToString()
                            );
                        controlPropertyInfoCollection.Add(controlPropertyInfo);
                    }
                }
            }

            return controlPropertyInfoCollection;
        }


        public CustomPropertyInstanceInfoCollection ControlProperties_SELECT_BYPropertyType(ControlPropertyType propertyType)
        {
            Logging.Logger.LogVerboseInformation("CustomPropertiesDataProvider.ControlProperties_SELECT_BYPropertyType", string.Format("invoked, propertyType = {0}", propertyType), 666);

            CustomPropertyInstanceInfoCollection controlPropertyInfoCollection = new CustomPropertyInstanceInfoCollection();
            CustomPropertyInstanceInfo controlPropertyInfo;

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
                       "ControlProperties_SELECT_BYPropertyType", propertyType.PropertyTypeIdentifier))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        controlPropertyInfo = new CustomPropertyInstanceInfo(
                            (int)dr[TableColumnNames.ControlProperties.ID],
                            (int)dr[TableColumnNames.ControlProperties.InstanceID],
                            Common.ControlPropertyTypeFactory.ControlPropertyType(dr[TableColumnNames.ControlProperties.PropertyType].ToString()),
                            dr[TableColumnNames.ControlProperties.PropertyKey].ToString(),
                            dr[TableColumnNames.ControlProperties.PropertyValue].ToString()
                            );
                        controlPropertyInfoCollection.Add(controlPropertyInfo);
                    }
                }
            }

            return controlPropertyInfoCollection;
        }


        public CustomPropertyInstanceInfoCollection ControlProperties_SELECT_BYPropertyType(ControlPropertyType propertyType, string propertyValue)
        {
            Logging.Logger.LogVerboseInformation("CustomPropertiesDataProvider.ControlProperties_SELECT_BYPropertyType", string.Format("invoked, propertyType = {0}, propertyValue = {1}", propertyType, propertyValue), 666);

            CustomPropertyInstanceInfoCollection controlPropertyInfoCollection = new CustomPropertyInstanceInfoCollection();
            CustomPropertyInstanceInfo controlPropertyInfo;

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
                       "ControlProperties_SELECT_BYPropertyType", propertyType.PropertyTypeIdentifier, propertyValue))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        controlPropertyInfo = new CustomPropertyInstanceInfo(
                            (int)dr[TableColumnNames.ControlProperties.ID],
                            (int)dr[TableColumnNames.ControlProperties.InstanceID],
                            Common.ControlPropertyTypeFactory.ControlPropertyType(dr[TableColumnNames.ControlProperties.PropertyType].ToString()),
                            dr[TableColumnNames.ControlProperties.PropertyKey].ToString(),
                            dr[TableColumnNames.ControlProperties.PropertyValue].ToString()
                            );
                        controlPropertyInfoCollection.Add(controlPropertyInfo);
                    }
                }
            }

            return controlPropertyInfoCollection;
        }


		public IntCollection ControlProperties_SELECT_ContentItemIdsBYInstanceID( int instanceID, string propertyTypeIdentifier )
		{
			IntCollection collection = new IntCollection();
			//ControlPropertyInfo controlPropertyInfo;

            using (SqlDataReader dr = (SqlDataReader)SqlDatabaseHelper.CurrentDatabase.ExecuteReader(
					   "ControlProperties_SELECT_ContentItemIdsBYInstanceID", instanceID, propertyTypeIdentifier))
			{
				if (dr.HasRows)
				{
					while(dr.Read())
					{
//						controlPropertyInfo = new ControlPropertyInfo(
//							(int)dr[TableColumnNames.ControlProperties.ID],
//							instanceID,
//							Common.ControlPropertyTypeFactory.ControlPropertyType( dr[TableColumnNames.ControlProperties.PropertyType].ToString() ),
//							dr[TableColumnNames.ControlProperties.PropertyKey].ToString(),
//							dr[TableColumnNames.ControlProperties.PropertyValue].ToString()
//							);
                        collection.Add(int.Parse(dr[TableColumnNames.ControlProperties.PropertyValue].ToString()));
					}
				}
			}

            return collection;
		}
	}
}