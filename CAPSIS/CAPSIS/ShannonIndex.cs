using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShannonIndex
{
    public string cipherText;

    public ShannonIndex(string mainInput)
    {
        cipherText = mainInput;
    }


	public double Index()
	{
		double si = 0;

		FrequencyAnalysis freqAnalysis = new FrequencyAnalysis(cipherText);


		double N = 0;
		foreach (char c in cipherText)
		{
			if (Software.isEnglishLetter(c))
				N++;
		}


		

		foreach (double c in freqAnalysis.AdLetterFreq())
		{
			double p = c / N;

			si += p * Math.Log2(p);
		}

		return -si;
	}
}

