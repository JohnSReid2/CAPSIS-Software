using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using NTextCat;
public class Substitution
{
    string cipherText;
	int[] aList = {1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25 };

    public Substitution(string mainInput)
    {
        cipherText = mainInput;
		var sb = new StringBuilder();
		foreach (char c in cipherText)
		{
			if (!char.IsPunctuation(c))
				sb.Append(c);
		}
		cipherText = sb.ToString();
	}

	public string Solve()
    {
		
		LanguageDetect languageDetect = new LanguageDetect();
		bool solved = false;
		for(int i = 0; i != 27 && !solved; i++)
        {
			string y = Decipher(cipherText.ToUpper(), i);
			string x = languageDetect.Language(y.ToLower());
			if (x == "en" || x == "eng")
            {
				solved = false;
				Console.WriteLine("Ceaser shift of " + i);
				Console.WriteLine(y);
            }
        }
		Console.WriteLine("Ceaser Complete");
		
		foreach (int i in aList)
        {
			for (int j = 1; j != 27 && !solved; j++)
			{
				string y = AffineDecrypt(cipherText.ToUpper(), i, j);
				string x = languageDetect.Language(y.ToLower());
				
				if (x == "en" || x == "eng")
				{
					solved = false;
					Console.WriteLine("Affine shift of " + i + " and " + j);
					Console.WriteLine(y);
				}
			}
		}
		Console.WriteLine("Affine Complete");


		/*
		string input = cipherText;
		input = input.ToUpper();
		
		FrequencyAnalysis frequencyAnalysis = new FrequencyAnalysis(input);
        

		char[] actualFreq = { 'e', 't', 'a', 'o', 'i', 'n', 's', 'h', 'r', 'd', 'l', 'c', 'u', 'm', 'w', 'f', 'g', 'y', 'p', 'b', 'v', 'k', 'j', 'x', 'q', 'z' };
		int[] actualPos = { 5, 20, 1, 15, 9, 14, 19, 8, 18, 4, 12, 3, 21, 13, 23, 6, 7, 25, 16, 2, 22, 11, 10, 24, 17, 26 };
		char[] key = new char[26];
		double[,] temp = frequencyAnalysis.LetterProbability();
		double[] freq = new double[26];
		for (int i = 0; i != temp.Length/2; i++)
		{
			freq[i] = temp[i, 0];
		}
		Array.Reverse(freq);
		for (int i = 0; i !=freq.Length; i++)
        {
            key[actualPos[i] - 1] = Convert.ToChar(Convert.ToInt32(freq[i]));
        }

		
		string y = new string(key);
		Console.WriteLine(y);
		Console.WriteLine("Initiating substitution fail safe (likely to fail)");
		string decryptedText;
		XEncipher(input, y, out decryptedText);
		Console.WriteLine(decryptedText);
		*/
		return "Substitution Attempt Completed";
    }
	private static char Cipher(char ch, int key)
	{
		if (!char.IsLetter(ch))
			return ch;

		char offset = char.IsUpper(ch) ? 'A' : 'a';
		return (char)((((ch + key) - offset) % 26) + offset);
	}

	public static string Encipher(string input, int key)
	{
		string output = string.Empty;

		foreach (char ch in input)
			output += Cipher(ch, key);

		return output;
	}

	public static string Decipher(string input, int key)
	{
		return Encipher(input, 26 - key);
	}

	public static string AffineEncrypt(string plainText, int a, int b)
	{
		string cipherText = "";

		// Put Plain Text (all capitals) into Character Array
		char[] chars = plainText.ToUpper().ToCharArray();

		// Compute e(x) = (ax + b)(mod m) for every character in the Plain Text
		foreach (char c in chars)
		{
			int x = Convert.ToInt32(c - 65);
			cipherText += Convert.ToChar(((a * x + b) % 26) + 65);
		}

		return cipherText;
	}

	///

	/// This function takes cipher text and decrypts it using the Affine Cipher
	/// d(x) = aInverse * (e(x) − b)(mod m).
	///
	public static string AffineDecrypt(string cipherText, int a, int b)
	{
		string plainText = "";

		// Get Multiplicative Inverse of a
		int aInverse = MultiplicativeInverse(a);

		// Put Cipher Text (all capitals) into Character Array
		char[] chars = cipherText.ToUpper().ToCharArray();

		// Computer d(x) = aInverse * (e(x) − b)(mod m)
		foreach (char c in chars)
		{
			int x = Convert.ToInt32(c - 65);
			if (x - b < 0) x = Convert.ToInt32(x) + 26;
			plainText += Convert.ToChar(((aInverse * (x - b)) % 26) + 65);
		}

		return plainText;
	}

	///

	/// This functions returns the multiplicative inverse of integer a mod 26.
	///
	public static int MultiplicativeInverse(int a)
	{
		for (int x = 1; x < 27; x++)
		{
			if ((a * x) % 26 == 1)
				return x;
		}

		throw new Exception("No multiplicative inverse found!");
	}



	private static bool XCipher(string input, string oldAlphabet, string newAlphabet, out string output)
	{
		output = string.Empty;

		if (oldAlphabet.Length != newAlphabet.Length)
			return false;

		for (int i = 0; i < input.Length; ++i)
		{
			int oldCharIndex = oldAlphabet.IndexOf(char.ToLower(input[i]));

			if (oldCharIndex >= 0)
				output += char.IsUpper(input[i]) ? char.ToUpper(newAlphabet[oldCharIndex]) : newAlphabet[oldCharIndex];
			else
				output += input[i];
		}

		return true;
	}

	public static bool XEncipher(string input, string cipherAlphabet, out string output)
	{
		string plainAlphabet = "abcdefghijklmnopqrstuvwxyz";
		return XCipher(input, plainAlphabet, cipherAlphabet, out output);
	}

	public static bool XDecipher(string input, string cipherAlphabet, out string output)
	{
		string plainAlphabet = "abcdefghijklmnopqrstuvwxyz";
		return XCipher(input, cipherAlphabet, plainAlphabet, out output);
	}

}

