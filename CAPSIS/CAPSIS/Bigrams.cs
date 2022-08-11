﻿using System;
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
        }




    }








    public class SlidingWindow
    {
        string cipherText;
        int amount = 1;
        string[] BigramList;
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
        }
    }
}
