using System.Collections.Generic;
using System.Linq;

string text ="";
char[] separateurs = new char[] { ' ', '\t', '\n', '\r' };

Console.WriteLine($"""
    Rentrez votre texte :
""");
text = Console.ReadLine() ?? " ";

Console.WriteLine($"""
    il y a {NombreDeMots(text, separateurs)} mots dans votre texte
    il y a {NombreDeCharacteres(text)} charactères dans votre texte

    Le mots le plus long est : '{MotLePlusLong(text, separateurs)}'
        Il représente {(((float)MotLePlusLong(text, separateurs).Length / text.Length) * 100):F2} % du texte !

""");

var resultat = NombreFoisChaqueLettre(text);
foreach (var lettre in resultat){
    Console.WriteLine($"""
        '{lettre.Key}' : {lettre.Value} => {(((float)lettre.Value / text.Replace(" ", "").Length)*100):F2} %
    """);
}

Console.WriteLine("""

    Quel mmot recherchez vous ?
""");
string input =  Console.ReadLine() ?? "0";
if (RechercheMot(text, input) != "") {
    Console.WriteLine($"""
        Mot trouvé : '{input}'
    """);
}


static int NombreDeMots(string text, char[] separateurs){
    return text.Split(separateurs, StringSplitOptions.RemoveEmptyEntries).Length;
}

static int NombreDeCharacteres(string text){
    return text.Trim().Length;
}

static string MotLePlusLong(string text, char[] separateurs){
    string[] mots = text.Split(separateurs);
    return mots.OrderByDescending(w => w.Length).First();
}

static Dictionary<char, int> NombreFoisChaqueLettre(string text){
    string texte = text.Replace(" ", "");
    return texte.GroupBy(c => c)
                .ToDictionary(g => g.Key, g => g.Count())
                .OrderByDescending(k => k.Value)
                .ToDictionary(k => k.Key, k => k.Value);
}

static string RechercheMot(string text, string input)
{
    foreach (string mot in text.Split(" "))
    {
        if (mot.Equals(input, StringComparison.OrdinalIgnoreCase))
        {
            return mot;
        }
    }

    Console.WriteLine("Aucune correspondance");
    return "";
}
