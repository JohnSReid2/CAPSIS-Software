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

		int[,] freq2 = freqAnalysis.CharacterFreq();
		int rows = freq2.GetLength(0);
		double N = cipherText.Length;
		int[] freq = new int[rows];

		for (int i = 0; i < rows; i++)
        {
			freq[i] = freq2[i, 1];
        }

		foreach (double c in freq)
		{
			double p = c / N;

			si += p * Math.Log2(p);
		}

		return -si;
	}
}