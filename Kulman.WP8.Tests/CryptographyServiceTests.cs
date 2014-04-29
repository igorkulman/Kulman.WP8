using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulman.WP8.Services;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Kulman.WP8.Tests
{
    [TestClass]
    public class CryptographyServiceTests
    {
        private CryptographyService _cryptographyService;

        [TestInitialize]
        public void Init()
        {
            _cryptographyService = new CryptographyService();
        }

        [TestMethod]
        public void MD5ShouldBeComputedCorrectly()
        {
            var s = "hsDkjdsa8dask";
            Assert.AreEqual("cd28d2fc1ece7a43c6d9ec8698c6a779", _cryptographyService.GetMd5(s));
        }

        [TestMethod]
        public void TextShouldBeEncryptedAndDecryptedCorrectly()
        {
            var s = "hsDkjdsa8dask";
            var password = "sadskjdasHJHJds";
            Assert.AreEqual(s, _cryptographyService.Decrypt(_cryptographyService.Encrypt(s, password), password));
        }
    }
}
