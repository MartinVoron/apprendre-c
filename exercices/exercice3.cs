Console.WriteLine("choisis un nombre");
float nb1 = float.Parse(Console.ReadLine()?? "0");
Console.WriteLine("premier nombre : " + nb1);
Console.WriteLine("choisis un 2eme nombre");
float nb2 = float.Parse(Console.ReadLine()?? "0");
Console.WriteLine("deuxieme nombre : " + nb2);
Console.WriteLine("addition : " + (nb1 + nb2));
Console.WriteLine("soustraction : " + (nb1 - nb2));
Console.WriteLine("multiplication : " + (nb1 * nb2));
if (nb2 == 0) {
    Console.WriteLine("division par zéro impossible");}
else {
    Console.WriteLine("division : " + (nb1 / nb2));
}  