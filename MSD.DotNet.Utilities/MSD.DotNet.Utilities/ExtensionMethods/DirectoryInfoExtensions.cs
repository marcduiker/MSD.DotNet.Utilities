namespace MSD.DotNet.Utilities.ExtensionMethods
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class DirectoryInfoExtensions
    {
        public static IEnumerable<FileInfo> GetFiles(this DirectoryInfo directoryInfo, string regexPattern, RegexOptions regexOptions, SearchOption searchOption)
        {
            if (string.IsNullOrEmpty(regexPattern))
            {
                throw new ArgumentNullException("regexPattern");
            }

            IEnumerable<FileInfo> files = directoryInfo.GetFiles("*.*", searchOption);
            if (files.Any())
            {
                return files.Where(file => Regex.IsMatch(file.Name, regexPattern, regexOptions));
            }

            return new FileInfo[]{};
        }
    }
}
