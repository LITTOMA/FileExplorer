using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Utils
{
    public static class PathUtils
    {
        public static string[] ParsePathHierarchy(string path)
        {
            string[] segments = path.Split(System.IO.Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);
            string[] parsedPaths = new string[segments.Length];

            for (int i = 0; i < segments.Length; i++)
            {
                string[] subSegments = new string[i + 1];
                Array.Copy(segments, subSegments, i + 1);
                parsedPaths[i] = System.IO.Path.Combine(subSegments);
            }

            return parsedPaths;

        }
    }
}
