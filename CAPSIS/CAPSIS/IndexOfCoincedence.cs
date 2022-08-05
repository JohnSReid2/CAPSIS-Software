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
		foreach (var c in freqAnalysis.AdLetterFreq())
        {
			ic = ic + ((c * (c - 1)) / (N * (N - 1)));
			Console.WriteLine(ic);
        } 

		return ic;
	}
}





