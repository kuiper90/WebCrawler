using System;
using System.IO;
using System.Reflection;

namespace HtmlParser
{
    public class SourceFolder
    {
        private string currentFolderPath;

        public SourceFolder()
        {
            string dirtyAss = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            Uri dirtyAssUri = new Uri(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            currentFolderPath = AppDomain.CurrentDomain.BaseDirectory;
        }

        public string GetCurrentFolderPath
            => currentFolderPath;

        public string[] GetFileNames()
            => Directory.GetFiles(currentFolderPath);
    }
}
