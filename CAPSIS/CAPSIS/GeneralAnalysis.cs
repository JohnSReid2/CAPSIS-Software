using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		bool numerical = false;
		foreach (char c in cipherText)
        {
			if (Software.isEnglishLetter(c))
            {
				numerical = true;
            }
        }
		return numerical;
    }

	public bool Binary()
    {
		bool binary = false;
		foreach (char c in cipherText)
		{
			if (c != Convert.ToChar(0) && c != Convert.ToChar(1))
			{
				binary = true;
			}
		}
		return binary;
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
