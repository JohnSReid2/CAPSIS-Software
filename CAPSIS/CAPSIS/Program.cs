using System;
using System.Text.RegularExpressions;

class Software
{
    public static string cipherText = "start";
    static public void Main()
    {
        string input = Console.ReadLine();

        if (input == null) {cipherText = "null";}           
        else {cipherText = input;}

        cipherText = String.Concat(cipherText.Where(c => !Char.IsWhiteSpace(c))).ToUpper();

        Console.WriteLine("Main Method initiated");
        Console.WriteLine(cipherText);

        GeneralAnalysis general = new GeneralAnalysis(cipherText);
        Console.WriteLine(general.CharacterCount());
        Console.WriteLine(general.UniqueCharacters());


    }

}