using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FrequencyAnalysis
{
	string cipherText;

	public record struct LetterDist(char letter, int freq);

	public FrequencyAnalysis(string mainInput)
	{
		cipherText = mainInput;
	}

	public int[,] CharacterFreq()
	{
		//  create an array of integers of the length
		//  of the total number of characters 
		int[] c = new int[(int)char.MaxValue];

		string s = cipherText;

		//For each character in the string
		foreach (char t in s)
		{
			//increment it's value in the array by one
			//letter is converted to ascii to find 
			//position in array
			c[(int)t]++;
		}

		int total = 0;

		foreach (int n in c)
        {
			if (n > 0)
				total++;
        }

		int[,] frequency = new int[total, 2];

		int j = 0;
		int k = 0;
		foreach (int n in c)
        {
			if (n > 0)
            {
				frequency[j, 1] = n;
				frequency[j, 0] = k;
				j++;
            }
			k++;
        }

		return frequency;
	}

	public int[] LetterFreq()
	{ //count occurences of every letter in the text
		int[] observedFreq = new int[26];
		foreach (char c in cipherText)
			if (Software.isEnglishLetter(c))//just English letters are counted
				observedFreq[c - Software.indexOfLetter(c)]++;   //subtract UNICODE of A or a so the range will be always between 0-25										

		return observedFreq;
	}

	public int[] AdLetterFreq()
    {
		var count = cipherText.Distinct().Count();
		int[] observedFreq = new int[count];
		int i = 0;
		foreach (var c in LetterFreq())
        {
			if (c != 0)
            {
				observedFreq[i] = c;
				i++;
            }
        }
		return observedFreq;
	}
}
