// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using Morphfolia.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morphfolia.Common.Info;
using Morphfolia.IDataProvider;

namespace Morphfolia.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for CustomPropertyHelperTest and is intended
    ///to contain all CustomPropertyHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CustomPropertyHelperTest
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
        ///A test for InstanceId
        ///</summary>
        [TestMethod()]
        public void InstanceIdTest()
        {
            int instanceId = 10; // TODO: Initialize to an appropriate value
            CustomPropertyHelper target = new CustomPropertyHelper(instanceId); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.InstanceId;
            Assert.AreEqual(instanceId, actual);
            Assert.IsTrue(target.CurrentCount == Common.Constants.SystemTypeValues.NullInt);
            Assert.IsTrue(target.CustomProperties.Count > 0);
        }

        ///// <summary>
        /////A test for ICustomPropertiesDataProvider
        /////</summary>
        //[TestMethod()]
        //[DeploymentItem("Morphfolia.Business.dll")]
        //public void ICustomPropertiesDataProviderTest()
        //{
        //    ICustomPropertiesDataProvider actual;
        //    actual = CustomPropertyHelper_Accessor.ICustomPropertiesDataProvider;
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        /// <summary>
        ///A test for CustomProperties
        ///</summary>
        [TestMethod()]
        public void CustomPropertiesTest()
        {
            int instanceId = 4; // default.aspx
            CustomPropertyHelper target = new CustomPropertyHelper(instanceId);
            Assert.IsTrue( target.CustomProperties.Count > 0);

            bool instanceIsCorrect = true;
            foreach (CustomPropertyInstanceInfo info in target.CustomProperties)
            {
                if (!info.InstanceID.Equals(instanceId))
                {
                    instanceIsCorrect = false;
                    break;
                }
            }
            Assert.IsTrue(instanceIsCorrect);
        }

        ///// <summary>
        /////A test for GetSkinProviderTypeByInstanceID
        /////</summary>
        //[TestMethod()]
        //public void GetSkinProviderTypeByInstanceIDTest()
        //{
        //    int instanceId = 0; // TODO: Initialize to an appropriate value
        //    CustomPropertyHelper target = new CustomPropertyHelper(instanceId); // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = target.GetSkinProviderTypeByInstanceID();
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for GetLayoutWebControlTypeByInstanceID
        /////</summary>
        //[TestMethod()]
        //public void GetLayoutWebControlTypeByInstanceIDTest()
        //{
        //    int instanceId = 0; // TODO: Initialize to an appropriate value
        //    CustomPropertyHelper target = new CustomPropertyHelper(instanceId); // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = target.GetLayoutWebControlTypeByInstanceID();
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for GetFormTemplatePresenterTypeByInstanceID
        /////</summary>
        //[TestMethod()]
        //public void GetFormTemplatePresenterTypeByInstanceIDTest()
        //{
        //    int instanceId = 0; // TODO: Initialize to an appropriate value
        //    CustomPropertyHelper target = new CustomPropertyHelper(instanceId); // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = target.GetFormTemplatePresenterTypeByInstanceID();
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for GetCustomPropertyInstanceByInstanceID
        /////</summary>
        //[TestMethod()]
        //public void GetCustomPropertyInstanceByInstanceIDTest()
        //{
        //    int instanceId = 0; // TODO: Initialize to an appropriate value
        //    CustomPropertyHelper target = new CustomPropertyHelper(instanceId); // TODO: Initialize to an appropriate value
        //    string propertyKey = string.Empty; // TODO: Initialize to an appropriate value
        //    string expected = string.Empty; // TODO: Initialize to an appropriate value
        //    string actual;
        //    actual = target.GetCustomPropertyInstanceByInstanceID(propertyKey);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for GetControlPropertiesByInstanceIDAndPropertyKeyAndTypeAndValue
        /////</summary>
        //[TestMethod()]
        //public void GetControlPropertiesByInstanceIDAndPropertyKeyAndTypeAndValueTest()
        //{
        //    int instanceId = 0; // TODO: Initialize to an appropriate value
        //    CustomPropertyHelper target = new CustomPropertyHelper(instanceId); // TODO: Initialize to an appropriate value
        //    string propertyKey = string.Empty; // TODO: Initialize to an appropriate value
        //    string propertyTypeIdentifier = string.Empty; // TODO: Initialize to an appropriate value
        //    string propertyValue = string.Empty; // TODO: Initialize to an appropriate value
        //    CustomPropertyInstanceInfoCollection expected = null; // TODO: Initialize to an appropriate value
        //    CustomPropertyInstanceInfoCollection actual;
        //    actual = target.GetControlPropertiesByInstanceIDAndPropertyKeyAndTypeAndValue(propertyKey, propertyTypeIdentifier, propertyValue);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for GetControlPropertiesByInstanceIDAndPropertyKeyAndType
        /////</summary>
        //[TestMethod()]
        //public void GetControlPropertiesByInstanceIDAndPropertyKeyAndTypeTest()
        //{
        //    int instanceId = 0; // TODO: Initialize to an appropriate value
        //    CustomPropertyHelper target = new CustomPropertyHelper(instanceId); // TODO: Initialize to an appropriate value
        //    string propertyKey = string.Empty; // TODO: Initialize to an appropriate value
        //    string propertyTypeIdentifier = string.Empty; // TODO: Initialize to an appropriate value
        //    CustomPropertyInstanceInfoCollection expected = null; // TODO: Initialize to an appropriate value
        //    CustomPropertyInstanceInfoCollection actual;
        //    actual = target.GetControlPropertiesByInstanceIDAndPropertyKeyAndType(propertyKey, propertyTypeIdentifier);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for GetControlPropertiesByInstanceIDAndPropertyKey
        /////</summary>
        //[TestMethod()]
        //public void GetControlPropertiesByInstanceIDAndPropertyKeyTest()
        //{
        //    int instanceId = 0; // TODO: Initialize to an appropriate value
        //    CustomPropertyHelper target = new CustomPropertyHelper(instanceId); // TODO: Initialize to an appropriate value
        //    string propertyKey = string.Empty; // TODO: Initialize to an appropriate value
        //    CustomPropertyInstanceInfoCollection expected = null; // TODO: Initialize to an appropriate value
        //    CustomPropertyInstanceInfoCollection actual;
        //    actual = target.GetControlPropertiesByInstanceIDAndPropertyKey(propertyKey);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for GetControlPropertiesByInstanceID
        /////</summary>
        //[TestMethod()]
        //public void GetControlPropertiesByInstanceIDTest()
        //{
        //    int instanceId = 0; // TODO: Initialize to an appropriate value
        //    CustomPropertyHelper target = new CustomPropertyHelper(instanceId); // TODO: Initialize to an appropriate value
        //    string propertyTypeIdentifier = string.Empty; // TODO: Initialize to an appropriate value
        //    CustomPropertyInstanceInfoCollection expected = null; // TODO: Initialize to an appropriate value
        //    CustomPropertyInstanceInfoCollection actual;
        //    actual = target.GetControlPropertiesByInstanceID(propertyTypeIdentifier);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for GetContentItemIdsByInstanceID
        /////</summary>
        //[TestMethod()]
        //public void GetContentItemIdsByInstanceIDTest()
        //{
        //    int instanceId = 0; // TODO: Initialize to an appropriate value
        //    CustomPropertyHelper target = new CustomPropertyHelper(instanceId); // TODO: Initialize to an appropriate value
        //    IntCollection expected = null; // TODO: Initialize to an appropriate value
        //    IntCollection actual;
        //    actual = target.GetContentItemIdsByInstanceID();
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        ///// <summary>
        /////A test for DeleteControlPropertiesByInstanceAndPropertyType
        /////</summary>
        //[TestMethod()]
        //public void DeleteControlPropertiesByInstanceAndPropertyTypeTest()
        //{
        //    int instanceId = 0; // TODO: Initialize to an appropriate value
        //    CustomPropertyHelper target = new CustomPropertyHelper(instanceId); // TODO: Initialize to an appropriate value
        //    string propertyType = string.Empty; // TODO: Initialize to an appropriate value
        //    target.DeleteControlPropertiesByInstanceAndPropertyType(propertyType);
        //    Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //}

        ///// <summary>
        /////A test for DeleteControlPropertiesByInstanceAndPropertyKey
        /////</summary>
        //[TestMethod()]
        //public void DeleteControlPropertiesByInstanceAndPropertyKeyTest()
        //{
        //    int instanceId = 0; // TODO: Initialize to an appropriate value
        //    CustomPropertyHelper target = new CustomPropertyHelper(instanceId); // TODO: Initialize to an appropriate value
        //    string propertyKey = string.Empty; // TODO: Initialize to an appropriate value
        //    target.DeleteControlPropertiesByInstanceAndPropertyKey(propertyKey);
        //    Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //}

        ///// <summary>
        /////A test for DeleteControlPropertiesByInstance
        /////</summary>
        //[TestMethod()]
        //public void DeleteControlPropertiesByInstanceTest()
        //{
        //    int instanceId = 0; // TODO: Initialize to an appropriate value
        //    CustomPropertyHelper target = new CustomPropertyHelper(instanceId); // TODO: Initialize to an appropriate value
        //    target.DeleteControlPropertiesByInstance();
        //    Assert.Inconclusive("A method that does not return a value cannot be verified.");
        //}

        /// <summary>
        ///A test for ClearCustomProperties
        ///</summary>
        [TestMethod()]
        public void ClearCustomPropertiesTest()
        {
            int instanceId = 4; // default.aspx
            CustomPropertyHelper target = new CustomPropertyHelper(instanceId); // TODO: Initialize to an appropriate value
            Assert.IsTrue(target.CustomProperties.Count > 0);
            Assert.IsTrue(target.CurrentCount == target.CustomProperties.Count);
            target.ClearCustomProperties();
            Assert.IsTrue(target.CurrentCount == Common.Constants.SystemTypeValues.NullInt);
        }

        /// <summary>
        ///A test for CustomPropertyHelper Constructor
        ///</summary>
        [TestMethod()]
        public void CustomPropertyHelperConstructorTest()
        {
            int instanceId = 4; // default.aspx
            CustomPropertyHelper target = new CustomPropertyHelper(instanceId);
            Assert.IsTrue(target.CustomProperties.Count > 0);

            bool instanceIsCorrect = true;
            foreach (CustomPropertyInstanceInfo info in target.CustomProperties)
            {
                if (!info.InstanceID.Equals(instanceId))
                {
                    instanceIsCorrect = false;
                    break;
                }
            }
            Assert.IsTrue(instanceIsCorrect);
        }
    }
}
