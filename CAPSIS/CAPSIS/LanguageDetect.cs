using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using NTextCat;
public class LanguageDetect
{
	public string Language(string cipherText)
    {
        var factory = new RankedLanguageIdentifierFactory();
        var identifier = factory.Load("Wiki82.profile.xml"); // can be an absolute or relative path. Beware of 260 chars limitation of the path length in Windows. Linux allows 4096 chars.
        var languages = identifier.Identify(cipherText);
        var mostCertainLanguage = languages.FirstOrDefault();
        if (mostCertainLanguage != null)
            return mostCertainLanguage.Item1.Iso639_3;
        else
            return "null";
    }
}

