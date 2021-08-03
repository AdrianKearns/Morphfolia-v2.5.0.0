// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using Morphfolia.Common.Interfaces;

namespace Morphological.Kudos.FormTemplatePresenters
{
    public class LivewireProblem : IFormTemplatePresenterProvider
    {
        public System.Web.UI.WebControls.WebControl MakePresenter(IFormTemplate formTemplate)
        {
            throw new System.NotImplementedException();
        }

        public System.Web.UI.WebControls.WebControl MakePresenter(string formTemplateXml)
        {
            Morphfolia.Common.Logging.Logger.LogVerboseInformation("LivewireProblem", formTemplateXml, 1234);

            Morphological.Kudos.FormTemplatePresenters.DefaultFormTemplatePresenter x = new DefaultFormTemplatePresenter();
            x.FormTemplate = Morphfolia.Business.FormTemplateHelper.GetDefinitionAndDataFromXmlDefinition(formTemplateXml);
            return x;
        }
    }
}
