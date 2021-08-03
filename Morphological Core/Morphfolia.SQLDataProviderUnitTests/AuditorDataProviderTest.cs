// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using Morphfolia.SQLDataProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morphfolia.Common.Info;
using System;

namespace Morphfolia.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for AuditorDataProviderTest and is intended
    ///to contain all AuditorDataProviderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AuditorDataProviderTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Search
        ///</summary>
        [TestMethod()]
        public void SearchTest()
        {
            // Example calls:
            //AuditLog_SELECT_Search 30, '%', '%', '%', '%', '%', '2009-01-11 14:51:44.000', '2019-01-11 19:21:00.000'
            //AuditLog_SELECT_Search -1, 'Page', '%', '%', '%', '%', '2009-01-11 14:51:44.000', '2019-01-11 19:21:00.000'
            //AuditLog_SELECT_Search -1, '%', '%', '%', '%', '%', '2000-01-11 14:51:44.000', '2019-01-11 19:21:00.000'

            AuditorDataProvider target = new AuditorDataProvider();
            int objectId = Morphfolia.Common.Constants.SystemTypeValues.NullInt;
            string objectType = "%";
            string auditInformation = "%";
            string userIdentity = "%";
            string windowsIdentity = "%";
            string appDomainName = "%";
            DateTime whenLoggedRangeStart = DateTime.Now.AddYears(-3);
            DateTime whenLoggedRangeEnd = DateTime.Now;
            //AuditLogInfoCollection expected = null; // TODO: Initialize to an appropriate value
            AuditLogInfoCollection actual;
            actual = target.Search(objectId, objectType, auditInformation, userIdentity, windowsIdentity, appDomainName, whenLoggedRangeStart, whenLoggedRangeEnd);
            Assert.IsTrue(actual.Count > 0);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        ///// <summary>
        /////A test for SafeSearchText
        /////</summary>
        //[TestMethod()]
        //[DeploymentItem("Morphfolia.SQLDataProvider.dll")]
        //public void SafeSearchTextTest()
        //{
        //    AuditorDataProvider_Accessor target = new AuditorDataProvider_Accessor(); // TODO: Initialize to an appropriate value
        //    string inputValue = string.Empty; // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = target.SafeSearchText(inputValue);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        /// <summary>
        ///A test for LogAuditEntry
        ///</summary>
        [TestMethod()]
        public void LogAuditEntryTest()
        {
            AuditorDataProvider target = new AuditorDataProvider();

            int objectId = -2;
            string objectType = "UnitTest";
            string auditInformation = "UnitTest"; //string.Format("Test Entry @ {0}", DateTime.Now.ToString());
            string userIdentity = "UnitTest";
            string windowsIdentity = "UnitTest";
            string appDomainName = "UnitTest";
            DateTime whenLoggedRangeStart = DateTime.Now.AddSeconds(-30);
            DateTime whenLoggedRangeEnd = DateTime.Now.AddSeconds(30);
            //AuditLogInfoCollection expected = null; // TODO: Initialize to an appropriate value
            AuditLogInfoCollection actual;
            actual = target.Search(objectId, objectType, auditInformation, userIdentity, windowsIdentity, appDomainName, whenLoggedRangeStart, whenLoggedRangeEnd);
            //Assert.IsTrue(actual.Count > 0);

            int currentCount = actual.Count;

            // Now perform the LogAuditEntry() bit - which is what we are testing:

            target.LogAuditEntry(objectId, objectType, auditInformation, userIdentity, windowsIdentity, appDomainName);

            actual = target.Search(objectId, objectType, auditInformation, userIdentity, windowsIdentity, appDomainName, whenLoggedRangeStart, whenLoggedRangeEnd);
            Assert.IsTrue(actual.Count.Equals(currentCount + 1));
        }

        ///// <summary>
        /////A test for GetAuditLogEntries
        /////</summary>
        //[TestMethod()]
        //public void GetAuditLogEntriesTest()
        //{
        //    AuditorDataProvider target = new AuditorDataProvider(); // TODO: Initialize to an appropriate value
        //    int objectId = 0; // TODO: Initialize to an appropriate value
        //    string objectType = string.Empty; // TODO: Initialize to an appropriate value
        //    AuditLogInfoCollection expected = null; // TODO: Initialize to an appropriate value
        //    AuditLogInfoCollection actual;
        //    actual = target.GetAuditLogEntries(objectId, objectType);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for AuditorDataProvider Constructor
        /////</summary>
        //[TestMethod()]
        //public void AuditorDataProviderConstructorTest()
        //{
        //    AuditorDataProvider target = new AuditorDataProvider();
        //    Assert.Inconclusive("TODO: Implement code to verify target");
        //}
    }
}
