using System.Text.RegularExpressions;

namespace HtmlParser
{
    public class Url
    {
        private string url;
        private string domain;
        private string subDomain;
        private string topLevelDomain;
        private string path;

        public string Hyperlink
        {
            get => url;
            set => url = value;
        }

        public string Domain
        {
            get => domain;
            set => domain = value;
        }

        public string SubDomain
        {
            get => subDomain;
            set => subDomain = value;
        }

        public string TopLevelDomain
        {
            get => topLevelDomain;
            set => topLevelDomain = value;
        }

        public string Path
        {
            get => path;
            set => path = value;
        }

        public string ExtractDomain(string line)
        {
            Regex searchRegex = new Regex("(?<=w{3}\\.)([.\\w]*)", RegexOptions.Compiled);
            return searchRegex.Match(line).ToString();
        }

        public string ExtractQuery(string line)
        {
            Regex searchRegex = new Regex("(?<=w{3}\\.)([.\\w]*)", RegexOptions.Compiled);
            return searchRegex.Match(line).ToString();
        }

        public string ExtractFragment(string line)
        {
            Regex searchRegex = new Regex("(?<=w{3}\\.)([.\\w]*)", RegexOptions.Compiled);
            return searchRegex.Match(line).ToString();
        }
    }
}
