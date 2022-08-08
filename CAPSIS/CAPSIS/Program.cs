using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Software
{
    public static string cipherText = "start";

    //General Analysis Data
    public static int characterCount;
    public static int uniqieCharacters;

    public static bool isEnglishLetter(char c) => (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
    public static int indexOfLetter(char c) => char.IsUpper(c) ? 65 : 97;

    static public void Main()
    {

        Console.WriteLine("Main Method initiated. Enter Cipher Text:");
        string input = Console.ReadLine(); //Take input from console

        if (input == null) 
        {cipherText = "null";}       
        else {cipherText = input;}

        //Remove all spaces and convert to uppercase
        cipherText = String.Concat(cipherText.Where(c => !Char.IsWhiteSpace(c))).ToUpper();

        Console.WriteLine("Reformatting cipher text...");
        Console.WriteLine(cipherText);


        //     ====== GENERAL ANALYSIS ======
        GeneralAnalysis general = new GeneralAnalysis(cipherText);

        characterCount = general.CharacterCount();
        uniqieCharacters = general.UniqueCharacters();

        OutputAnalysis();

        //     ====== Frequency Analysis ======
        FrequencyAnalysis freqAnalysis = new FrequencyAnalysis(cipherText);
        int[,] freq = freqAnalysis.CharacterFreq();
        
        for (int i = 0; i < freq.GetLength(0); i++)
        {
            Console.WriteLine(Convert.ToChar(freq[i , 0]) + ": " + freq[i, 1]);
        }


        
        IndexOfCoincedence indexOfCoincedence = new IndexOfCoincedence(cipherText);
        Console.WriteLine("Index of Coincedence " + indexOfCoincedence.Index());

        ShannonIndex shannonIndex = new ShannonIndex(cipherText);
        Console.WriteLine("Shannon index " + shannonIndex.Index());
    }

    static public void OutputAnalysis()
    {
        Console.WriteLine("--- General Analysis ---");
        Console.WriteLine("Character Count = " + characterCount);
        Console.WriteLine("Unique Character Count = " + uniqieCharacters);
    }
}