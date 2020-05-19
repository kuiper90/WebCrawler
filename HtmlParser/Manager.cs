using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace HtmlParser
{
    public class Manager
    {
        private List<string> currentAdsList;

        private Dictionary<string, List<Ad>> adsDictionary = new Dictionary<string, List<Ad>>();

        private List<string> linesList;

        private Document currentFile;

        private string fileName = "htmlUrlListFile.txt";

        private SourceFolder sourceFolder = new SourceFolder();

        public List<string> LinesList
            => linesList;

        public Dictionary<string, List<Ad>> AdsDictionary
            => adsDictionary;

        public Document CurrentFile
            => currentFile;

        public List<string> GetCurrentAdsList
            => currentAdsList;

        public void InitializeFileWrapper()
        {
            ValidateFolder();         
            currentFile = new Document(sourceFolder.GetCurrentFolderPath + fileName);
        }

        private void ValidateFolder()
        {
            if (!Directory.Exists(sourceFolder.GetCurrentFolderPath))
                throw new DirectoryNotFoundException("Folder not found.");
        }

        private void ValidateFile(string fileName)
        {
            if (!currentFile.FileExists())
                throw new FileNotFoundException("File not found.");
        }

        public void MapUrlsToDictionaryKeys()
        {
            linesList = currentFile.TryReadFromFile();
            foreach (string line in linesList)
            {
                Console.WriteLine(line);
                adsDictionary.Add(line, null);
            }
        }

        public void AddHyperlinkToAdsList(string line)
        {
            currentAdsList.Add(ParseUrl(line));
            Console.WriteLine(line);
        }

        public string ParseUrl(string line)
        {
            Regex searchRegex = new Regex("^(http|https):\\/{2}w{3}\\.[a-z0-9]+([\\-\\.]{1}[a-z0-9]+)*\\.[a-z]{2,5}(:[0-9]{1,5})?(\\/.*)?$", RegexOptions.Compiled);
            return searchRegex.Match(line).ToString();
        }
    }
}