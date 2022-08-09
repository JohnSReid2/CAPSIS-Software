using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

	public double[,] LetterProbability()
    {
        double[,] probability = new double[26, 2];

		double length = 0;
		foreach (char x in cipherText)
        {
			if (Software.isEnglishLetter(x))
            {
				length++;
            }
        }
		int c = 0;
		foreach (double i in LetterFreq())
        {
			probability[c, 0] = c + 65;
			probability[c, 1] = (i / length);
			c++;
        }

		
		double[][] pj = new double[26][];
		pj = JaggedSort.ToJagged(probability);
		JaggedSort.Sort(pj, 1);
		probability = JaggedSort.ToRectangular(pj);
		
		return probability;
    }
}

public static class JaggedSort
{
	public static T[][] ToJagged<T>(this T[,] array)
	{
		int height = array.GetLength(0), width = array.GetLength(1);
		T[][] jagged = new T[height][];

		for (int i = 0; i < height; i++)
		{
			T[] row = new T[width];
			for (int j = 0; j < width; j++)
			{
				row[j] = array[i, j];
			}
			jagged[i] = row;
		}
		return jagged;
	}
	public static T[,] ToRectangular<T>(this T[][] array)
	{
		int height = array.Length, width = array[0].Length;
		T[,] rect = new T[height, width];
		for (int i = 0; i < height; i++)
		{
			T[] row = array[i];
			for (int j = 0; j < width; j++)
			{
				rect[i, j] = row[j];
			}
		}
		return rect;
	}
	// fill an existing rectangular array from a jagged array
	public static void WriteRows<T>(this T[,] array, params T[][] rows)
	{
		for (int i = 0; i < rows.Length; i++)
		{
			T[] row = rows[i];
			for (int j = 0; j < row.Length; j++)
			{
				array[i, j] = row[j];
			}
		}
	}

	public static void Sort<T>(T[][] data, int col)
	{
		Comparer<T> comparer = Comparer<T>.Default;
		Array.Sort<T[]>(data, (x, y) => comparer.Compare(x[col], y[col]));
	}
}
