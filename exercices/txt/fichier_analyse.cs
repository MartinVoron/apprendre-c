using System;
using System.IO;

string folder = Environment.CurrentDirectory;
string file = "txt/journal.txt";

string[] paths = [folder, file];
string fullPath = Path.Combine(paths);

Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);

string text = """
Arthur: connexion
Bob: connexion
Arthur: deconnexion
Charlie: connexion
Arthur: connexion
Bob: deconnexion
""";

File.WriteAllText(fullPath, text);

// Console.WriteLine($""" {File.ReadAllText(fullPath)} """);

Console.WriteLine($""" {fullPath} """);

try {
    using (StreamReader reader = new StreamReader(fullPath)) {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }
}
catch (Exception e) {
    Console.WriteLine("Exception: " + e.Message);
}

// bool ligne = true;


// while (ligne == true) {
//     if (File.ReadAllLines)
// }