using System;
using System.Linq;

namespace HtmlParser
{
    public static class Program
    {
        private static Ad adList = new Ad();
        private static string filePath;
        private static Manager manager = new Manager();
        private static Crawler spider = new Crawler();

        public static void PrintHyperlinkList()
        {
            manager.InitializeFileWrapper();
            manager.MapUrlsToDictionaryKeys();
            Console.WriteLine(manager.AdsDictionary.Count);
            string test = manager.AdsDictionary.Take(1).Select(k => k.Key).First();
            spider.ConnectToInternet(test);
            spider.PrintFilteredResults();
        }

        static void Main(string[] args)
        {
            PrintHyperlinkList();
            Console.ReadLine();
        }
    }
}
