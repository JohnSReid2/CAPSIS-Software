using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FrequencyAnalysis
{
	string cipherText;
	public FrequencyAnalysis(string mainInput)
	{
		cipherText = mainInput;
	}
	
	public void LetterFrequency()
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

		          
		for (int i = 0; i < (int)char.MaxValue; i++)
		{
			if (c[i] > 0 &&
			char.IsLetterOrDigit((char)i))
			{
				Console.WriteLine("Letter: {0}  Frequency: {1}",
					(char)i,
					c[i]);
			}
		}
	}
}
