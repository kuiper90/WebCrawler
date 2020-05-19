using System;
using System.Collections.Generic;
using System.IO;

namespace HtmlParser
{
    public class Document
    {
        private FileInfo currentFile;

        private string fileName;

        private string filePath;

        public Document(string fullPath)
        {
            currentFile = new FileInfo(fullPath);
            filePath = fullPath;
            CreateFile();
        }

        public bool FileExists()
        {
            currentFile.Refresh();
            return currentFile.Exists;
        }

        public FileInfo GetCurrentFile
            => currentFile;

        public string FileName
            => currentFile.Name;

        public string FilePath
            => filePath;

        private void CreateFile()
        {
            if (FileExists())
                return;
            FileStream fileStream = currentFile.Create();
            currentFile.Refresh();
            fileStream.Close();
        }

        public List<string> TryReadFromFile()
        {
            if (currentFile.Length != 0)
            {
                StreamReader streamReader = File.OpenText(filePath);
                try
                {
                    return ReadFromFile(streamReader);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error reading from file.");
                    return null;
                }
                finally
                {
                    if (streamReader != null)
                    {
                        streamReader.Close();
                        streamReader.Dispose();
                        streamReader = null;
                    }
                }
            }
            return null;
        }

        private List<string> ReadFromFile(StreamReader streamReader)
        {
            List<string> lineList = new List<string>();
            while (!streamReader.EndOfStream)
            {
                lineList.Add(streamReader.ReadLine());
            }
            return lineList;
        }
    }
}