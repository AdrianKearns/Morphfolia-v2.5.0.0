// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace Morphfolia.SQLDataProvider.Utilities
{
    public class SqlDatabaseHelper
    {
        private static SqlDatabase currentDatabase = null;
        public static SqlDatabase CurrentDatabase
        {
            get
            {
                if (currentDatabase == null)
                {
                    // Create the Database object, using the default database service. 
                    // The default database service is determined through configuration.
                    currentDatabase = (SqlDatabase)DatabaseFactory.CreateDatabase();
                }

                return currentDatabase;
            }
        }
    }
}
