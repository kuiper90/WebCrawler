using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace HtmlParser
{
    public class Crawler
    {
        private Manager manager = new Manager();

        private HashSet<string> htmlHrefs = new HashSet<string>();

        public void ConnectToInternet(string url)
        {
            WebRequest request = WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            ExtractHtmlHrefs(reader.ReadToEnd());
            reader.Close();
            dataStream.Close();
            response.Close();
        }

        private void ExtractHtmlHrefs(string htmlDoc)
        {
            MatchCollection matchCollection = ParseUrl(htmlDoc);
            foreach (Match match in matchCollection)
            {
                htmlHrefs.Add(match.Groups[0].Value);
            }
        }

        public MatchCollection ParseUrl(string htmlDoc)
        {
            Regex searchRegex = new Regex("(href)=\\\"(http|https):\\/{2}w{3}\\.(?:[^\\s,.!?]|[,.!?](?!\\s))+\\\"", RegexOptions.Compiled);
            return searchRegex.Matches(htmlDoc);
        }

        public void PrintFilteredResults()
        {
            foreach (var item in htmlHrefs)
                Console.WriteLine(item);
        }
    }
}
