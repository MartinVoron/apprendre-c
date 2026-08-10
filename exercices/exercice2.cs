Console.WriteLine("Quel est ton prénom ?");
String prenom = Console.ReadLine()?? string.Empty;
Console.WriteLine("Quel est ton âge ?");
int age = int.Parse(Console.ReadLine() ?? "0");
Console.WriteLine("Bonjour "+prenom+" !");
Console.WriteLine("Tu as "+age+" ans !");
Console.WriteLine("L'année prochaine tu auras "+(age+1)+" ans.");