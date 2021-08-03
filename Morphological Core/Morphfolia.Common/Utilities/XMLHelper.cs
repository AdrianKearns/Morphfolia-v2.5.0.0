// Copyright (C) 2010 Adrian Kearns / Morphological Software Solutions Limited.
// You can redistribute this software and/or modify it under the terms of the 
// Microsoft Reciprocal License (Ms-RL).  This program is distributed in the hope 
// that it will be useful, but WITHOUT ANY WARRANTY; without even the implied 
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
// See Licence.txt for more details. 

using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Morphfolia.Common.Utilities
{
    /// 
    /// Summary description for XMLHelper.
    /// 
    public class XMLHelper
    {
        public static XmlDocument AddXMLNameSpace(XmlDocument doc, string prefix, string nameSpaceValue)
        {
            const string XMLNS = "xmlns";

            string attributeName;
            XmlAttribute attribute;

            if (prefix != null && prefix.Trim().Length > 0)
            {
                attributeName = XMLNS + ":" + prefix.Trim();
            }
            else
            {
                attributeName = XMLNS;
            }

            attribute = doc.CreateAttribute(attributeName);
            attribute.Value = nameSpaceValue;

            doc.DocumentElement.Attributes.Append(attribute);

            return doc;
        }

        /// 
        /// Serialize the object into XML string.
        /// 
        /// The object to be serialized.
        /// The output xml string.
        public static string ObjectToXMLString(object obj)
        {
            string serializationString = string.Empty;
            XmlSerializer serializer;
            MemoryStream memoryStream;

            serializer = new XmlSerializer(obj.GetType());
            memoryStream = new MemoryStream();

            serializer.Serialize(memoryStream, obj);

            serializationString = SystemHelper.ByteArrayToString(memoryStream.ToArray());

            return serializationString;
        }

        /// 
        /// Deserialize the xml string into the object.
        /// 
        /// The xml string to be deserialized.
        /// The ouput object type.
        /// The output object.
        public static object XMLStringToObject(string xmlString, Type objectType)
        {
            object outputObject = null;
            MemoryStream memoryStream;
            XmlSerializer serializer;
            XmlReader reader;

            serializer = new XmlSerializer(objectType);

            memoryStream = new MemoryStream(SystemHelper.StringToByteArray(xmlString));
            reader = new XmlTextReader(memoryStream);

            if (serializer.CanDeserialize(reader))
            {
                outputObject = serializer.Deserialize(reader);
            }
            else
            {
                throw new Exception("Deserialization error: the xml string can't be deserialized.");
            }

            return outputObject;
        }
    }



    /// 
    /// Summary description for SystemHelper.
    /// 
    public class SystemHelper
    {
        /// 
        /// Convert the byte array into string
        /// 
        /// The input byte array.
        /// The converted string.
        public static string ByteArrayToString(byte[] bytes)
        {
            string result = string.Empty;
            UTF8Encoding utf8;

            utf8 = new UTF8Encoding();
            result = utf8.GetString(bytes);

            return result;

        }

        /// 
        /// Convert the string into the byte array.
        /// 
        /// The input string.
        /// The return byte array.
        public static byte[] StringToByteArray(string inputString)
        {
            byte[] byteArray;

            byteArray = Encoding.UTF8.GetBytes(inputString);

            return byteArray;
        }
    }
}
