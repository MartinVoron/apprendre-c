const int lim_1 = 9;
const int lim_2 = 11;
const int lim_3 = 13;
const int lim_4 = 15;
const int lim_5 = 20;

Console.WriteLine("donnez une note entre 0 et 20");
string nombre = Console.ReadLine()?? "0";

if (int.TryParse(nombre, out int note) && note>=0 && note<=20 ) {

    if (note <= lim_1) {
        Console.WriteLine("❌ Insuffisant");
    }
    else if (note <= lim_2) {
        Console.WriteLine("🟠 Passable");
    }
    else if (note <= lim_3) {
        Console.WriteLine("🟡 Assez bien");
    }
    else if (note <= lim_4) {
        Console.WriteLine("🟢 Bien");
    }
    else if (note <= lim_5) {
        Console.WriteLine("⭐ Très bien");
    }
}
else {
     Console.WriteLine("Veuillez entrer une note valide.");
}