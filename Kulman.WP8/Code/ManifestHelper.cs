using System;
using System.Xml;

namespace Kulman.WP8.Code
{
    /// <summary>
    /// Helper class to get info from app manifest
    /// </summary>
    public static class ManifestHelper
    {
        /// <summary>
        /// Gest an attribute from the manifest by name
        /// </summary>
        /// <param name="attributeName">Attribute name</param>
        /// <returns>Attribute value</returns>                
        private static string GetAppAttribute(string attributeName)
        {
            const string appManifestName = "WMAppManifest.xml";
            const string appNodeName = "App";

            var settings = new XmlReaderSettings { XmlResolver = new XmlXapResolver() };

            using (var rdr = XmlReader.Create(appManifestName, settings))
            {
                rdr.ReadToDescendant(appNodeName);
                if (!rdr.IsStartElement())
                {
                    throw new FormatException(appManifestName + " is missing " + appNodeName);
                }

                return rdr.GetAttribute(attributeName);
            }
        }

        /// <summary>
        /// Application title
        /// </summary>        
        public static string Title
        {
            get
            {
                return GetAppAttribute("Title");
            }
        }

        /// <summary>
        /// Application version
        /// </summary>        
        public static string Version
        {
            get
            {
                return GetAppAttribute("Version");
            }
        }

        /// <summary>
        /// Application author
        /// </summary>        
        public static string Author
        {
            get
            {
                return GetAppAttribute("Author");
            }
        }

        /// <summary>
        /// Application author
        /// </summary>        
        public static Guid Guid
        {
            get
            {
                return Guid.Parse(GetAppAttribute("ProductID"));
            }
        }
    }
}
