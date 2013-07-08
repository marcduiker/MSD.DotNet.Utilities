namespace MSD.DotNet.Utilities.ExtensionMethods
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;

    public static class XmlExtensions
    {
        /// <summary>
        /// Returns XElements that match the given regex pattern.
        /// If no elements match an empty list is returned.
        /// </summary>
        /// <param name="element">Parent XElement where the search will start.</param>
        /// <param name="regexPattern">Regular expression to match the XElements.</param>
        /// <returns>XElements that match the regex pattern.</returns>
        public static List<XElement> GetElements(this XElement element, string regexPattern, RegexOptions regexOptions = RegexOptions.None, bool useDescendants = false)
        {
            IEnumerable<XElement> result;

            if (useDescendants)
            {
                result = element.Descendants().Where(el => Regex.IsMatch(el.Name.ToString(), regexPattern, regexOptions));
            }
            else
            {
                result = element.Elements().Where(el => Regex.IsMatch(el.Name.ToString(), regexPattern, regexOptions));
            }

            if (result != null)
            {
                return result.ToList();
            }

            return new List<XElement>();
        }
    }
}
