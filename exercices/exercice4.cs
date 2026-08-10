const int high_limit = 18;
const int low_limit = 13;

Console.WriteLine("Quel âge as-tu ?");
string nombre = Console.ReadLine()?? "0";

if (int.TryParse(nombre, out int age)) {
    switch (age) {

        case < low_limit:
            Console.WriteLine($"Accès interdit au moins de {low_limit} ans");
            break;

        case < high_limit :
                Console.WriteLine($"Accès Limité en dessous de {high_limit} ans");
                break;

        default:
            Console.WriteLine($"Accès autorisé");
            break;
    }
}
else {
    Console.WriteLine("rentrez une valeur correcte");
}
