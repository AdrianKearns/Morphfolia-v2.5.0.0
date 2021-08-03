// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.Text;
using Morphfolia.Common.Info;

namespace Morphfolia.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            Console.TreatControlCAsInput = true;
            Console.WriteLine("Press ESC to exit, or any other key to continue.");

            do
            {
                cki = Console.ReadKey(true);
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

                //Test_WebFormHelper_ContentForPageByPropertyKey();                
                //Test_WebFormHelper_ContentForPage();
                //Test_PageLayoutAndSkinAssistant_WebLayoutControlHelper_GetAvailableLayoutWebControls();
                //Test_Security_Principal_WindowsIdentity_GetCurrent();
                //Test_Business_Auditor_LogAuditEntry();
                //Test_Business_CustomPropertyHelper_CopySettings();
                //Test_SQLDataProvider_DataProviderInformation_GetTotalSize();
                //Test_SQLDataProvider_Content_SELECT_List_ById();
                Test_SQLDataProvider_Page_SELECT_PagesByID();

                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                Console.Write(Environment.NewLine);
            }
            while (cki.Key != ConsoleKey.Escape);
        }


        static void Test_WebFormHelper_ContentForPage()
        {
            Console.WriteLine("Test_WebFormHelper_ContentForPage");
            Console.WriteLine("-----------------------------------------------------------");

            Morphfolia.PublishingSystem.WebFormHelper webFormHelper = new Morphfolia.PublishingSystem.WebFormHelper("MyProfile/LicenseRequest.aspx");
            System.Web.UI.WebControls.Panel pnl = webFormHelper.ContentForPage();

            StringBuilder sb = new StringBuilder();
            System.IO.StringWriter sw = new System.IO.StringWriter(sb);
            System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
            pnl.RenderControl(htw);

            Console.Write(sb.ToString());
            Console.Write(Environment.NewLine);
        }


        static void Test_WebFormHelper_ContentForPageByPropertyKey()
        {
            Console.WriteLine("Test_WebFormHelper_ContentForPageByPropertyKey");
            Console.WriteLine("-----------------------------------------------------------");

            Morphfolia.PublishingSystem.WebFormHelper webFormHelper = new Morphfolia.PublishingSystem.WebFormHelper("MyProfile/LicenseRequest.aspx");

            Console.Write(webFormHelper.ContentForPageByPropertyKey("textc1"));
            Console.Write(Environment.NewLine);
        }


        static void Test_PageLayoutAndSkinAssistant_WebLayoutControlHelper_GetAvailableLayoutWebControls()
        {
            Console.WriteLine("Test_PageLayoutAndSkinAssistant_WebLayoutControlHelper_GetAvailableLayoutWebControls");
            Console.WriteLine("-----------------------------------------------------------");

            System.Collections.Specialized.StringCollection strCol = Morphfolia.PageLayoutAndSkinAssistant.WebLayoutControlHelper.GetAvailableLayoutWebControls();
            Console.WriteLine(strCol.Count.ToString() + " items to be returned...");
            foreach (string x in strCol)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("Complete.");
        }


        static void Test_Security_Principal_WindowsIdentity_GetCurrent()
        {
            Console.WriteLine("Test_Security_Principal_WindowsIdentity_GetCurrent");
            Console.WriteLine("-----------------------------------------------------------");

            Console.WriteLine(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
        }


        static void Test_Business_Auditor_LogAuditEntry()
        {
            Console.WriteLine("Test_X");
            Console.WriteLine("-----------------------------------------------------------");

            Business.Logs.Auditor.LogAuditEntry(-1, "Console Test", "Console Test");
        }

        static void Test_Business_CustomPropertyHelper_CopySettings()
        {
            Console.WriteLine("Test_X");
            Console.WriteLine("-----------------------------------------------------------");

            Business.StaticCustomPropertyHelper.CopySettings(4, 3);
        }

        static void Test_SQLDataProvider_DataProviderInformation_GetTotalSize()
        {
            Console.WriteLine("Test_SQLDataProvider_DataProviderInformation_GetTotalSize");
            Console.WriteLine("-----------------------------------------------------------");

            Morphfolia.SQLDataProvider.DataProviderInformation x = new Morphfolia.SQLDataProvider.DataProviderInformation();
            string currentSize = x.GetUsageSummary();
            Console.WriteLine(currentSize);
        }

        static void Test_SQLDataProvider_Content_SELECT_List_ById()
        {
            Console.WriteLine("Test_SQLDataProvider_Content_SELECT_List_ById");
            Console.WriteLine("-----------------------------------------------------------");

            Morphfolia.SQLDataProvider.ContentDataProvider x = new Morphfolia.SQLDataProvider.ContentDataProvider();

            IntCollection ids = new IntCollection();
            ids.Add(1004);
            ids.Add(51);
            ids.Add(52);
            ids.Add(53);
            ids.Add(54);

            ids.Add(55);
            ids.Add(61);
            ids.Add(62);
            ids.Add(63);
            ids.Add(1002);

            ids.Add(1003);

            ContentListInfoCollection items = x.Content_SELECT_List_ById(ids);
            foreach (ContentListInfo info in items)
            {
                Console.WriteLine(string.Format("{0} {1}", info.ContentID, info.Note));
            }

        }


        static void Test_SQLDataProvider_Page_SELECT_PagesByID()
        {
            Console.WriteLine("Test_SQLDataProvider_Page_SELECT_PagesByID");
            Console.WriteLine("-----------------------------------------------------------");

            Morphfolia.SQLDataProvider.PageDataProvider x = new Morphfolia.SQLDataProvider.PageDataProvider();

            IntCollection ids = new IntCollection();
            ids.Add(1004);
            ids.Add(1);
            ids.Add(2);
            ids.Add(3);
            ids.Add(4);

            ids.Add(5);
            ids.Add(6);
            ids.Add(7);
            ids.Add(8);
            ids.Add(1002);

            ids.Add(1003);

            PageInfoCollection items = x.Page_SELECT_PagesByID(ids);
            foreach (PageInfo info in items)
            {
                Console.WriteLine(string.Format("{0} {1}", info.PageID, info.Title));
            }

        }


        //static void Test_X()
        //{
        //    Console.WriteLine("Test_X");
        //    Console.WriteLine("-----------------------------------------------------------");

        //}
    }
}
