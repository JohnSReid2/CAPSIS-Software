using System;
using System.Text.RegularExpressions;

class Software
{
    public static string cipherText = "start";

    //General Analysis Data
    public static int characterCount;
    public static int uniqieCharacters;
    static public void Main()
    {
        string input = Console.ReadLine(); //Take input from console

        if (input == null) {cipherText = "null";}       
        else {cipherText = input;}

        //Remove all spaces and convert to uppercase
        cipherText = String.Concat(cipherText.Where(c => !Char.IsWhiteSpace(c))).ToUpper();

        Console.WriteLine("Main Method initiated");
        Console.WriteLine(cipherText);

        //     ====== GENERAL ANALYSIS ======
        GeneralAnalysis general = new GeneralAnalysis(cipherText);

        characterCount = general.CharacterCount();
        uniqieCharacters = general.UniqueCharacters();

        Console.WriteLine("--- General Analysis ---");
        Console.WriteLine("Character Count = " + characterCount);
        Console.WriteLine("Unique Character Count = " + uniqieCharacters);


    }

}