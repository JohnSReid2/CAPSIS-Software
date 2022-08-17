using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trigrams
{

    public class Blocks
    {
        string cipherText;
        int amount = 1;
        string[] TrigramList;
        string[] UniqTrigrams;
        public Blocks(string mainInput)
        {
            var sb = new System.Text.StringBuilder();
            foreach (char c in mainInput)
            {
                if (Software.isEnglishLetter(c))
                {
                    sb.Append(c.ToString());
                }
            }
            cipherText = sb.ToString();
            amount = cipherText.Length / 3;
            TrigramList = new string[amount];
            for (int i = 0; i < amount; i++)
            {
                TrigramList[i] = cipherText.Substring(i * 3, 3);
            }
            UniqTrigrams = TrigramList.Distinct().ToArray();
        }


        public TrigramCount[] frequency()
        {
            int length = UniqTrigrams.Length;
            TrigramCount[] trigramCounts = new TrigramCount[length];

            int i = 0;
            foreach (string s in UniqTrigrams)
            {
                trigramCounts[i] = new TrigramCount();
                int occurrences = TrigramList.Count(x => x == s);
                trigramCounts[i].trigram = s;

                trigramCounts[i].count = occurrences;
                i++;
            }
            var qry = from p in trigramCounts
                      orderby p.count
                      select p;

            TrigramCount[] trigramCounts20 = qry.TakeLast(20).ToArray();
            return trigramCounts20;
        }


        public int TrigramTotal()
        {
            int total = TrigramList.Length;
            return total;
        }

        public int UniqTrigramTotal()
        {
            int total = UniqTrigrams.Length;
            return total;
        }

        public bool IdenticalTrigram()
        {
            bool identical = false;

            foreach (string s in UniqTrigrams)
            {
                if (s[0] == s[1] && s[0] == s[2])
                {
                    identical = true;
                }
            }
            return identical;
        }
    }








    public class SlidingWindow
    {
        string cipherText;
        int amount = 1;
        string[] TrigramList;
        string[] UniqTrigrams;
        public SlidingWindow(string mainInput)
        {
            var sb = new System.Text.StringBuilder();
            foreach (char c in mainInput)
            {
                if (Software.isEnglishLetter(c))
                {
                    sb.Append(c.ToString());
                }
            }
            cipherText = sb.ToString();
            amount = cipherText.Length - 2;
            if (amount < 0)
            {
                amount = 0;
            }
            TrigramList = new string[amount];
            for (int i = 0; i < amount; i++)
            {
                TrigramList[i] = cipherText.Substring(i, 3);
                //Console.WriteLine(TrigramList[i]);
            }
            UniqTrigrams = TrigramList.Distinct().ToArray();
        }
        public TrigramCount[] frequency()
        {
            int length = UniqTrigrams.Length;
            TrigramCount[] trigramCounts = new TrigramCount[length];

            int i = 0;
            foreach (string s in UniqTrigrams)
            {
                trigramCounts[i] = new TrigramCount();
                int occurrences = TrigramList.Count(x => x == s);
                trigramCounts[i].trigram = s;

                trigramCounts[i].count = occurrences;
                i++;
            }
            var qry = from p in trigramCounts
                      orderby p.count
                      select p;

            TrigramCount[] trigramCounts20 = qry.TakeLast(20).ToArray();
            return trigramCounts20;
        }

        public int TrigramTotal()
        {
            int total = TrigramList.Length;
            return total;
        }

        public int UniqTrigramTotal()
        {
            int total = UniqTrigrams.Length;
            return total;
        }

        public bool IdenticalTrigram()
        {
            bool identical = false;

            foreach (string s in UniqTrigrams)
            {
                if (s[0] == s[1] && s[0] == s[2])
                {
                    identical = true;
                }
            }
            return identical;
        }
    }

    public class TrigramCount
    {
        public int? count
        {
            get;
            set;
        }
        public string? trigram
        {
            get;
            set;
        }
    }
}
