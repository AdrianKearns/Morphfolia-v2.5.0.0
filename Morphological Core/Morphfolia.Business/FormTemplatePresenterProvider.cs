// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using Morphfolia.Common.Interfaces;

namespace Morphfolia.Business
{
    public class FormTemplatePresenterProvider
    {
        public static IFormTemplatePresenterProvider Load(string formTemplatePresenterType)
        {
            if (formTemplatePresenterType == null)
            {
                formTemplatePresenterType = string.Empty;
            }

            if (!formTemplatePresenterType.Equals(string.Empty))
            {
                try
                {
                    return Morphfolia.Common.Utilities.ProviderLoader.CreateInstance(formTemplatePresenterType) as IFormTemplatePresenterProvider;
                }
                catch (System.Exception ex)
                {
                    Morphfolia.Common.Logging.Logger.LogException(string.Format("FormTemplatePresenterProvider.Load() failed. The specified formTemplatePresenterType '{0}' could not be loaded, will attempt to load default Form-Template Presenter.", formTemplatePresenterType), ex, 8765);
                    return LoadDefaultFormTemplatePresenter();
                }
            }
            else
            {
                Morphfolia.Common.Logging.Logger.LogVerboseInformation("FormTemplatePresenterProvider.Load()", "No formTemplatePresenterType was specified, using default.", 8976);
                return LoadDefaultFormTemplatePresenter();
            }            
        }


        public static IFormTemplatePresenterProvider LoadDefaultFormTemplatePresenter()
        {
            string defaultFormTemplatePresenter = Morphfolia.Common.Utilities.ConfigHelper.GetAppSetting(Morphfolia.Common.AppSettingKeys.DefaultFormTemplatePresenter);

            if (defaultFormTemplatePresenter.Equals(string.Empty))
            {
                throw new Exceptions.BusinessException(string.Format("AppSetting '{0}' not set.", Morphfolia.Common.AppSettingKeys.DefaultFormTemplatePresenter));
            }

            try
            {
                Logging.Logger.LogVerboseInformation("FormTemplatePresenterProvider, LoadDefaultFormTemplatePresenter()", string.Format("About to create instance of: {0}", defaultFormTemplatePresenter));
                return Morphfolia.Common.Utilities.ProviderLoader.CreateInstance(defaultFormTemplatePresenter) as IFormTemplatePresenterProvider;
            }
            catch (System.Exception ex)
            {
                Morphfolia.Common.Logging.Logger.LogException("LoadDefaultFormTemplatePresenter failed.", ex, 8766);
                throw;
            }
        }
    }
}