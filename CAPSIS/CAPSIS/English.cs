using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using log4net;
using VigenereSolver.Library.Helpers;

public class English
{
    private const int WordPercentage = 40;
    private const int LetterPercentage = 70;

    public Dictionary<int, List<string>> SortedDictionary = new Dictionary<int, List<string>>();

    /// <summary>
    ///     Static Constructor
    /// 
    ///     Loads the dictionary into memory
    /// </summary>
    public English()
    {
        Console.WriteLine("Loading Dictionary...");
        using (var sr = new StreamReader(@"C:\Users\johns\Githup Repos\Capsis_Software\CAPSIS\CAPSIS\dictionary.txt"))
        {
            while (sr.Peek() >= 0)
            {
                var word = sr.ReadLine();

                if (string.IsNullOrEmpty(word))
                    break;

                if (!SortedDictionary.ContainsKey(word.Length))
                {
                    SortedDictionary.Add(word.Length, new List<string>() { word });
                    continue;
                }

                SortedDictionary[word.Length].Add(word);
            }
        }
        Console.WriteLine("Dictionary Loaded!");
    }

    /// <summary>
    ///     Evaluates dictionary words against the specified message
    /// 
    ///     This works when the input message doesn't have spacing
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public double GetDictionaryWordsInStringRatio(string message)
    {
        var messageWords = message.ToUpper();

        //Order the dictionary by largest words first, so we'll start there
        foreach (var dict in SortedDictionary.OrderByDescending(k => k.Key))
        {
            foreach (var word in dict.Value)
            {
                messageWords = message.Replace(word, string.Empty);
            }
        }

        return (double)messageWords.Length / message.Length;
    }

    /// <summary>
    ///     The number of words in the string that appear in the loaded dictionary
    /// 
    ///     This works when the input message has spacing to denote words
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public double GetStringWordsInDictionaryRatio(string message)
    {
        var messageWords = message.ToUpper().Split(' ');
        var count = messageWords.Count(word => SortedDictionary.ContainsKey(word.Length) && SortedDictionary[word.Length].Contains(word));

        return (double)count / messageWords.Length;
    }


    /// <summary>
    ///     Determines if the specified message is an English string using a dictionary
    ///     and English patterns/sentence structure
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public bool IsEnglish(string message)
    {
        var sw = new Stopwatch();
        var englishWordCount2 = GetStringWordsInDictionaryRatio(message) * 100;
        var letterCount = message.Length -
                          (message.Length - Constants.NonlettersPattern.Replace(message.ToUpper(), string.Empty).Length);

        var letterPercentage = ((double)letterCount / message.Length) * 100;

        return englishWordCount2 >= WordPercentage && letterPercentage >= LetterPercentage;
    }
}
