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
		//int N = freqAnalysis.AdLetterFreq().Length;
		int N = cipherText.Length;
		double dn = N * (N - 1);

		foreach (int c in freqAnalysis.AdLetterFreq())
        {
			double numerator = c * (c - 1);
			ic += ( numerator / dn );
		} 

		return ic;
	}
}





