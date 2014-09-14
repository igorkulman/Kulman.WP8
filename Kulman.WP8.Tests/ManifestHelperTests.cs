using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulman.WP8.Code;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Kulman.WP8.Tests
{
    [TestClass]
    public class ManifestHelperTests
    {
        [TestMethod]
        public void VersionShouldBeFetched()
        {
            var version = ManifestHelper.Version;
            Assert.IsFalse(String.IsNullOrEmpty(version));
        }

        [TestMethod]
        public void AuthorShouldBeFetched()
        {
            var author = ManifestHelper.Author;
            Assert.IsFalse(String.IsNullOrEmpty(author));
        }

        [TestMethod]
        public void TitleShouldBeFetched()
        {
            var title = ManifestHelper.Title;
            Assert.IsFalse(String.IsNullOrEmpty(title));
        }

        [TestMethod]
        public void GuidShouldBeFetched()
        {
            var guid = ManifestHelper.Guid;
            Assert.IsFalse(guid==Guid.Empty);
        }
    }
}
