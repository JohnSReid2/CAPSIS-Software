using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
public class GeneralAnalysis
{
	string cipherText;

	public GeneralAnalysis(string mainInput)
	{
		cipherText = mainInput;
	}


	public int CharacterCount() 
	{
		return cipherText.Length;
	}

	public int UniqueCharacters()
    {
		var count = cipherText.Distinct().Count();
		return count;
	}

	public bool Numerical()
    {
		bool numerical = true;
		foreach (char c in cipherText)
        {		
			if (!Char.IsNumber(c))
            {
				numerical = false;
            }
        }
		return numerical;
    }

	public bool Binary()
    {
		bool binary = true;
		foreach (char c in cipherText)
		{
			if (c != '0' && c != '1')
			{
				binary = false;
			}
		}
		return binary;
	}

	public bool Morse()
	{
		bool morse = true;
		foreach (char c in cipherText)
		{
			if (c != '.' && c != '-')
			{
				morse = false;
			}
		}
		return morse;
	}

	public bool Alphabetic()
	{
		bool alphabetic = true;
		foreach (char c in cipherText)
		{
			if (!Software.isEnglishLetter(c))
			{
				alphabetic = false;
			}
		}
		return alphabetic;
	}
}
