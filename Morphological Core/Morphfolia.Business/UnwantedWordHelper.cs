// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Collections.Specialized;
using System.Text;
using Morphfolia.Business.Constants;
using Morphfolia.Common.Info;
using Morphfolia.IDataProvider;

namespace Morphfolia.Business
{
    /// <summary>
    /// Designed to manage words that are unwanted in the search indexs.
    /// </summary>
    /// <remarks>Currently stores the words in a text file which this class 
    /// reads and writes, this should be refactored into 
    /// a seperate layer at some point.</remarks>
    public class UnwantedWordHelper
    {
        private const int UnwantedWordsInstanceId = -100;
        private const string UnwantedWordsPropertyKey = "UnwantedWords";

        private static ICustomPropertiesDataProvider iCustomPropertiesDataProvider;
        private static ICustomPropertiesDataProvider ICustomPropertiesDataProvider
        {
            get
            {
                if (iCustomPropertiesDataProvider == null)
                {
                    iCustomPropertiesDataProvider = Helpers.ProviderLoader.Load(Constants.DataProviderAppSettingKeys.ICustomPropertiesDataProvider) as IDataProvider.ICustomPropertiesDataProvider;
                }
                return iCustomPropertiesDataProvider;
            }
        }


        public static void SaveUnwantedWords(String[] unwantedWords)
        {
            string tempWord;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < unwantedWords.Length-1; i++)
            {
                tempWord = unwantedWords[i].Trim();
                if (!tempWord.Equals(string.Empty))
                {
                    sb.Append(tempWord);
                    sb.Append(" ");
                }
            }

            tempWord = unwantedWords[unwantedWords.Length-1].Trim();
            if (!tempWord.Equals(string.Empty))
            {
                sb.Append(tempWord);
            }



            SaveNewCustomPropertyInstanceInfo propertyToSave = new SaveNewCustomPropertyInstanceInfo(
                UnwantedWordsInstanceId, 
                Morphfolia.Common.ControlPropertyTypeFactory.GlobalPropertyType(), 
                UnwantedWordsPropertyKey,
                sb.ToString());

            ICustomPropertiesDataProvider.ControlProperties_DELETE_BYInstanceIDPropertyKey(UnwantedWordsInstanceId, UnwantedWordsPropertyKey);
            ICustomPropertiesDataProvider.ControlProperties_INSERT(propertyToSave);
        }

        public static String[] GetUnwantedWords()
        {
            string rawUnwantedWords;
            string[] unwantedWords;

            try
            {
                rawUnwantedWords = ICustomPropertiesDataProvider.ControlProperties_SELECT_BYInstanceIDPropertyKey(UnwantedWordsInstanceId, UnwantedWordsPropertyKey)[0].PropertyValue;
                unwantedWords = rawUnwantedWords.Split(Char.Parse(" "));
            }
            catch (System.Exception ex)
            {
                Morphfolia.Common.Logging.Logger.LogException("GetUnwantedWords() failed.", ex, Logging.EventIds._4049);
                unwantedWords = new string[2] { "and", "the" };
            }

            return unwantedWords;
        }
    }

}