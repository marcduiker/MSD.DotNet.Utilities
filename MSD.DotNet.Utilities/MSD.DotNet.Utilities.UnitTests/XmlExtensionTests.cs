namespace MSD.DotNet.Utilities.UnitTests
{
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;
    using MSD.DotNet.Utilities.ExtensionMethods;
    using NUnit.Framework;

    [TestFixture]
    public class XmlExtensionTests
    {
        [Test]
        public void GetElements_RegexMatchStartXName_ReturnsMatchingElements()
        {
            // Arrange
            var xdoc = GetXDocument();

            // Act
            var matches = xdoc.Element("elements").GetElements("^first");

            // Assert
            Assert.AreEqual(1, matches.Count);
        }

        [Test]
        public void GetElements_RegexMatchStartXNameUseDescendants_ReturnsMatchingElements()
        {
            // Arrange
            var xdoc = GetXDocument();

            // Act
            var matches = xdoc.Element("elements").GetElements("^first", useDescendants: true);

            // Assert
            Assert.AreEqual(2, matches.Count);
        }

        [Test]
        public void GetElements_RegexMatchEndXName_ReturnsMatchingElements()
        {
            // Arrange
            var xdoc = GetXDocument();

            // Act
            var matches = xdoc.Element("elements").GetElements("element$", RegexOptions.IgnoreCase);

            // Assert
            Assert.AreEqual(3, matches.Count);
        }

        [Test]
        public void GetElements_RegexNonMatchingCase_ReturnsEmptyList()
        {
            // Arrange
            var xdoc = GetXDocument();

            // Act
            var matches = xdoc.Element("elements").GetElements("^FIRST");

            // Assert
            Assert.IsFalse(matches.Any());
        }

        private XDocument GetXDocument()
        {
            return XDocument.Parse(
                @"<elements>
                    <firstelement>FirstValue</firstelement>
                    <secondelement>SecondValue</secondelement>
                    <thirdelement>
                        <firstelement>NestedFirstValue</firstelement>
                        <secondelement>NestedSecondValue</secondelement>
                    </thirdelement>
                </elements>");
        }
    }
}
