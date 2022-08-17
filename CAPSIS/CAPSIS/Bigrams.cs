using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigrams
{

    public class Blocks
    {
        string cipherText;
        int amount = 1;
        string[] BigramList;
        string[] UniqBigrams;
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
            amount = cipherText.Length / 2;
            BigramList = new string[amount];
            for (int i = 0; i < amount; i++)
            {
                BigramList[i] = cipherText.Substring(i * 2, 2);
                //Console.WriteLine(BigramList[i]);
            }
            UniqBigrams = BigramList.Distinct().ToArray();
        }


        public BigramCount[] frequency()
        {
            int length = UniqBigrams.Length;
            BigramCount[] bigramCounts = new BigramCount[length];

            int i = 0;
            foreach (string s in UniqBigrams)
            {
                bigramCounts[i] = new BigramCount();
                int occurrences = BigramList.Count(x => x == s);
                bigramCounts[i].bigram = s;

                bigramCounts[i].count = occurrences;
                i++;
            }
            return bigramCounts;
        }


        public int BigramTotal()
        {
            int total = BigramList.Length;
            return total;
        }

        public int UniqBigramTotal()
        {
            int total = UniqBigrams.Length;
            return total;
        }
    }








    public class SlidingWindow
    {
        string cipherText;
        int amount = 1;
        string[] BigramList;
        string[] UniqBigrams;
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
            amount = cipherText.Length - 1;
            BigramList = new string[amount];
            for (int i = 0; i < amount; i++)
            {
                BigramList[i] = cipherText.Substring(i, 2);
                //Console.WriteLine(BigramList[i]);
            }
            UniqBigrams = BigramList.Distinct().ToArray();
        }
        public BigramCount[] frequency()
        {
            int length = UniqBigrams.Length;
            BigramCount[] bigramCounts = new BigramCount[length];

            int i = 0;
            foreach (string s in UniqBigrams)
            {
                bigramCounts[i] = new BigramCount();
                int occurrences = BigramList.Count(x => x == s);
                bigramCounts[i].bigram = s;

                bigramCounts[i].count = occurrences;
                i++;
            }
            return bigramCounts;
        }

        public int BigramTotal()
        {
            int total = BigramList.Length;
            return total;
        }

        public int UniqBigramTotal()
        {
            int total = UniqBigrams.Length;
            return total;
        }
    }

    public class BigramCount
    {
        public int count
        {
            get;
            set;
        }
        public string bigram
        {
            get;
            set;
        }
    }
}
