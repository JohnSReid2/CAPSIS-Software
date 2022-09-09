using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
public class Reverse
{
	string cipherText;

	public Reverse(string mainInput)
	{
		cipherText = mainInput;
	}

	public string putItInReverseTerr()
	{
		string temp = cipherText.Reverse().ToString();
		return temp;
	}
}