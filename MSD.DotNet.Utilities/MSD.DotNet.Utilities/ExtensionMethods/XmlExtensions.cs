using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;


namespace MSD.DotNet.Utilities.ExtensionMethods
{
    public static class XmlExtensions
    {
        /// <summary>
        /// Returns XElements that match the given regex pattern.
        /// the element is not found.
        /// </summary>
        /// <param name="element">Parent XElement where the search will start.</param>
        /// <param name="regexPattern">Regular expression pattern to match the XElements.</param>
        /// <returns>XElements which match the regex pattern.</returns>
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
