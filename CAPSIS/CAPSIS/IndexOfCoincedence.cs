using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class IndexOfCoincedence
{
	public string cipherText;
	public IndexOfCoincedence(string mainInput)
	{
		cipherText = mainInput;
	}
	public double Index()
	{
		double ic = 0;

		FrequencyAnalysis freqAnalysis = new FrequencyAnalysis(cipherText);


		ulong N = 0;
		
		foreach (char c in cipherText)
        {
			if (Software.isEnglishLetter(c))
				N++;
        }

		double den = N * (N - 1);


		foreach (ulong c in freqAnalysis.AdLetterFreq())
        {
			double num = c * (c - 1);
			ic += (num / den);
		} 

		return ic;
	}
}





