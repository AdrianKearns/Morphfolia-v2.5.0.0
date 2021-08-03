// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using Morphfolia.Common.Info;
using Morphfolia.IDataProvider;
using Morphfolia.Business.Constants;

namespace Morphfolia.Business
{
    public class WordIndexListHelper
    {
        private static IContentIndexerDataProvider iContentIndexerDataProvider;
        private static IContentIndexerDataProvider IContentIndexerDataProvider
        {
            get
            {
                if (iContentIndexerDataProvider == null)
                {
                    iContentIndexerDataProvider = Helpers.ProviderLoader.Load(DataProviderAppSettingKeys.IContentIndexerDataProvider) as Morphfolia.IDataProvider.IContentIndexerDataProvider;
                }
                return iContentIndexerDataProvider;
            }
        }



        public static WordIndexListInfoCollection GetWordIndexListForLetter(string letter)
        {
            if (letter.Length > 1)
            {
                letter = letter.Remove(1);
            }

            return IContentIndexerDataProvider.ContentIndex_SELECT_WordIndexListForLetter(letter);
        }
    }
}
