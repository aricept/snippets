using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    static class Program
    {
        static void Main(string[] args)
        {
            var contents = File.ReadAllText("contents.txt");
            ParagraphParser(contents);
        }

        public static List<Match> ToList(this MatchCollection matches)
        {
            List<Match> matchList = new List<Match>();
            foreach (Match match in matches)
            {
                matchList.Add(match);
            }
            return matchList;
        }

        public static void ParagraphParser(string para)
        {
            var paraList = new List<string>();
            bool open = false;
            var newP = new StringBuilder((int)(para.Length * 1.1));
            var openTag = @"\<pre\>";
            var closeTag = @"\</pre\>";
            var openCode = @"\<pre\>\<code\>";
            var closeCode = @"\</code\>\</pre\>";
            List<Match> matches = new List<Match>();
            matches.AddRange(Regex.Matches(para, openTag).ToList());
            matches.AddRange(Regex.Matches(para, closeTag).ToList());
            
            matches.Sort((m, n) =>
            {
                return m.Index.CompareTo(n.Index);
            });

            for (var i = 0; i < matches.Count; i++)
            {
                var current
            }
        }
    }
}
