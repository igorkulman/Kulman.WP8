using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using Kulman.WP8.Interfaces;
using Microsoft.Phone.Tasks;

namespace Kulman.WP8.Services
{
    public class WindowsPhoneStoreUpdateService : IWindowsPhoneStoreUpdateService
    {

        private string GetManifestAttributeValue(string attributeName)
        {
            var xmlReaderSettings = new XmlReaderSettings
                                    {
                                        XmlResolver = new XmlXapResolver()
                                    };

            using (var xmlReader = XmlReader.Create("WMAppManifest.xml", xmlReaderSettings))
            {
                xmlReader.ReadToDescendant("App");

                return xmlReader.GetAttribute(attributeName);
            }
        }

        /// <summary>
        /// Checks the Windows Phone Store to see if a newer version of the app is available
        /// If it is, a dialog is shown
        /// </summary>
        /// <param name="updateDialogText">Dialog text</param>
        /// <param name="updateDialogTitle">Dialog title</param>
        public void CheckForUpdatedVersion(string updateDialogText, string updateDialogTitle)
        {

            var cultureInfoName = CultureInfo.CurrentUICulture.Name;

            var url =
                string.Format(
                    "http://marketplaceedgeservice.windowsphone.com/v8/catalog/apps/{0}?os={1}&cc={2}&oc=&lang={3}​",
                    GetManifestAttributeValue("ProductID"),
                    Environment.OSVersion.Version,
                    cultureInfoName.Substring(cultureInfoName.Length - 2).ToUpperInvariant(),
                    cultureInfoName);
            
            var wc = new WebClient();
            wc.DownloadStringCompleted += (s, e) =>
                                          {
                                              if (e.Error != null) return;
                                              var content = e.Result;

                                              try
                                              {
                                                  using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(content)))
                                                  {
                                                      using (var reader = XmlReader.Create(ms))
                                                      {
                                                          reader.MoveToContent();

                                                          var aNamespace = reader.LookupNamespace("a");
                                                          reader.ReadToFollowing("entry", aNamespace);
                                                          reader.ReadToDescendant("version");

                                                          var updatedVersion = new Version(reader.ReadElementContentAsString());
                                                          var currentVersion = new Version(GetManifestAttributeValue("Version"));
                                                          if (updatedVersion > currentVersion
                                                  &&
                                                  MessageBox.Show(updateDialogText, updateDialogTitle, MessageBoxButton.OKCancel) ==
                                                  MessageBoxResult.OK)
                                                          {
                                                              new MarketplaceDetailTask().Show();
                                                          }
                                                      }
                                                  }
                                              }
                                              catch
                                              {

                                              }
                                          };
            wc.DownloadStringAsync(new Uri(url));


        }
    }
}
