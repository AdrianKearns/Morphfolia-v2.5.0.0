// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

//using System;
//using System.Collections.Generic;
//using System.Text;
//using Morphfolia.Common.Interfaces;
//using Morphfolia.Common.Utilities;
//using Morphfolia.Common.Constants.Framework;
//using Morphfolia.Common.Attributes;

//namespace Morphfolia.Common.Utilities
//{
//    [IsAppSettingKeyClass()]
//    public class LicenseChecker
//    {
//        public const string ExpectedPublicToken = "4e0fd0e010319c66";

//        [IsAppSettingKey("Morphfolia.ILicenseProvider", "Specifies the License Provider to use.", "Expected value is 'type, assembly'.")]
//        public const string ILicenseProviderAppSettingKey = "Morphfolia.ILicenseProvider";

//        private static string iLicenseProviderType = string.Empty;
//        private static string ILicenseProviderType
//        {
//            get
//            {
//                if(iLicenseProviderType.Equals(string.Empty))
//                {
//                    iLicenseProviderType = ConfigHelper.GetAppSetting(ILicenseProviderAppSettingKey);
//                }
//                return iLicenseProviderType;
//            }
//        }

//        private static ILicenseProvider iLicenseProvider;
//        private static ILicenseProvider ILicenseProvider
//        {
//            get
//            {
//                if (iLicenseProvider == null)
//                {
//                    iLicenseProvider = ProviderLoader.CreateInstance(ILicenseProviderType) as ILicenseProvider;
//                }
//                return iLicenseProvider;
//            }
//        }

//        private static string registeredDomains = string.Empty;

//        private static bool HasBeenCheckedAndIsOk = false;



//        private static bool weNeedToVerifyPublicToken = true;
//        /// <summary>
//        /// Checks the License Providers PublicToken.
//        /// </summary>
//        /// <remarks>Throws exception if not valid, otherwise silent.</remarks>
//        public static void VerifyPublicToken()
//        {
//            if (weNeedToVerifyPublicToken)
//            {
//                //4e0fd0e010319c66 core
//                //4e0fd0e010319c66 localhost license provider
//                //4efd0e010319c66                
//                if (ExtractedPublicKeyToken.Equals(ExpectedPublicToken))
//                {
//                    weNeedToVerifyPublicToken = false;
//                }
//                else
//                {
//                    Logging.Logger.LogWarning("VerifyPublicToken Check failed.", 
//                        string.Format("The public key token '{0}' is not valid, expect '{1}'.",
//                            ExtractedPublicKeyToken,
//                            ExpectedPublicToken), 
//                        Logging.EventIds.Licensing._50);

//                    throw new Exceptions.LicenseException(
//                        string.Format("The public key token '{0}' is not valid, expect '{1}'.", 
//                            ExtractedPublicKeyToken, 
//                            ExpectedPublicToken));
//                }
//            }
//        }


//        /// <summary>
//        /// 
//        /// </summary>
//        /// <remarks>Throws exception if not valid, otherwise silent.</remarks>
//        /// <param name="context"></param>
//        public static void CheckDomain(System.Web.HttpContext context)
//        {
//            if (context != null)
//            {
//                CheckDomain(context.Request.Url.DnsSafeHost);
//            }
//        }


//        /// <summary>
//        /// Checks the domain aganist a list of registered ones.
//        /// </summary>
//        /// <remarks>Throws exception if not valid, otherwise silent.</remarks>
//        /// <param name="domain">The name of the server, the IP address or domain name to be verified.</param>
//        private static void CheckDomain(string domain)
//        {
//            VerifyPublicToken();

//            if (registeredDomains.Equals(string.Empty))
//            {
//                registeredDomains = ILicenseProvider.GetRegisteredURLs();
//            }

//            if (!HasBeenCheckedAndIsOk)
//            {
//                if (!registeredDomains.Contains(domain))
//                {
//                    Logging.Logger.LogWarning("Url Check failed.", string.Format("The following Urls are licensed: {0}", registeredDomains), Logging.EventIds.Licensing._50);
//                    throw new Exceptions.LicenseException(string.Format("Url Check failed.  The following Urls are licensed: {0}", registeredDomains));
//                }
//                else
//                {
//                    Logging.Logger.LogInformation("Requested domain is licensed.", string.Empty, Logging.EventIds.Licensing._50);
//                    HasBeenCheckedAndIsOk = true;
//                }
//            }
//        }



//        private static string extractedPublicKeyToken = string.Empty;
//        /// <summary>
//        /// Stores the PublicKeyToken of the license provider.
//        /// </summary>
//        /// <remarks>Only genuine licenses provided by Morphological Software Solutions are permitted.</remarks>
//        internal static string ExtractedPublicKeyToken
//        {
//            get
//            {
//                if (extractedPublicKeyToken.Equals(string.Empty))
//                {
//                    Type concreteLicenseProviderType = null;

//                    if (!ILicenseProviderType.Equals(string.Empty))
//                    {
//                        // Check PublicKeyToken of the currently configured License provider, 
//                        // it must match with the valid one we expect: 
//                        try
//                        {
//                            concreteLicenseProviderType = Type.GetType(ILicenseProviderType, true);
//                        }
//                        catch (System.Exception ex)
//                        {
//                            throw new ApplicationException(string.Format("concreteLicenseProviderType = Type.GetType(ILicenseProviderType, true) failed.  ILicenseProviderType = {0}", ILicenseProviderType), ex);
//                        }
//                    }
//                    System.Reflection.Assembly licenseProviderAssembly = System.Reflection.Assembly.GetAssembly(concreteLicenseProviderType);


//                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
//                    byte[] pkt = licenseProviderAssembly.GetName().GetPublicKeyToken();
//                    string currentBit;
//                    for (int i = 0; i < pkt.GetLength(0); i++)
//                    {
//                        currentBit = string.Format("{0:x}", pkt[i]);
//                        if (currentBit.Length == 1)
//                        {
//                            currentBit = string.Format("0{0}", currentBit);
//                        }
//                        sb.Append(currentBit);
//                    }
//                    extractedPublicKeyToken = sb.ToString();
//                }

//                return extractedPublicKeyToken;
//            }
//        }

//    }
//}
