using System;

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
}
