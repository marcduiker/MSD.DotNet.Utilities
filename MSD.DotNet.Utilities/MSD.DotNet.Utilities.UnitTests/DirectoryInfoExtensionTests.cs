using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using MSD.DotNet.Utilities.ExtensionMethods;
using NUnit.Framework;

namespace MSD.DotNet.Utilities.UnitTests
{
    [TestFixture]
    public class DirectoryInfoExtensionTests
    {
        [Test]
        public void GetFiles_WithMatchingRegexPattern_ReturnFilesThatMathRegex()
        {
            // Arrange
            var dirInfo = new DirectoryInfo(GetAssemblyPath());

            // Act
            var fileInfos = dirInfo.GetFiles("^MSD.DotNet.*.dll", RegexOptions.IgnoreCase, SearchOption.TopDirectoryOnly);

            // Assert
            Assert.IsTrue(fileInfos.Any());
        }

        [Test]
        public void GetFiles_WithNonMatchingRegexPattern_ReturnsEmptyIEnumerable()
        {
            // Arrange
            var dirInfo = new DirectoryInfo(GetAssemblyPath());

            // Act
            var fileInfos = dirInfo.GetFiles("^123.xyz", RegexOptions.IgnoreCase, SearchOption.TopDirectoryOnly);

            // Assert
            Assert.IsFalse(fileInfos.Any());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetFiles_WithEmptyRegexPattern_ThrowsArgumentNullException()
        {
            // Arrange
            var dirInfo = new DirectoryInfo(GetAssemblyPath());

            // Act
            var fileInfos = dirInfo.GetFiles(string.Empty, RegexOptions.IgnoreCase, SearchOption.TopDirectoryOnly);

            // Assert
            Assert.Fail("ArgumentNullException was expected.");
        }

        private string GetAssemblyPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
    }
}
