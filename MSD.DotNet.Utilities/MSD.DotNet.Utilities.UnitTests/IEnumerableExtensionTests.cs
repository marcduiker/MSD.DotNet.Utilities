namespace MSD.DotNet.Utilities.UnitTests
{
    using System.Collections.Generic;
    using MSD.DotNet.Utilities.ExtensionMethods;
    using NUnit.Framework;

    public class IEnumerableExtensionTests
    {
        [Test]
        public void IsNullOrEmpty_IEnumerableIsNull_ReturnsTrue()
        {
            // Arrange
            IEnumerable<string> list = null;

            // Act
            bool result = list.IsNullOrEmpty();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsNullOrEmpty_IEnumerableIsEmpty_ReturnsTrue()
        {
            // Arrange
            IEnumerable<string> list = new List<string>();

            // Act
            bool result = list.IsNullOrEmpty();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsNullOrEmpty_IEnumerableIsNotEmpty_ReturnsFalse()
        {
            // Arrange
            IEnumerable<string> list = new List<string> { "abc" };

            // Act
            bool result = list.IsNullOrEmpty();

            // Assert
            Assert.IsFalse(result);
        }
    }
}
