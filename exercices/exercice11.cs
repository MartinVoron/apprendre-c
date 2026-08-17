
Perso hero = new Perso("Arthur", 100, 20, 10);
Perso ennemi = new Perso("bob", 200, 15, 5);

AfficherStatistiques(hero);

hero.RecevoirDegats(30);
hero.EstVivant();
Console.WriteLine(hero.Pv);

hero.Soigner(30.0);
Console.WriteLine(hero.Pv);

hero.Attaquer(ennemi);


static void AfficherStatistiques(Perso hero) {

    string etat = hero.EstVivant() ? "Vivant" : "Mort";

    Console.WriteLine($"""
    ==============================
    {hero.Nom} :  
        pv : {hero.Pv} / {hero.PvMax}
        pa : {hero.Pa}
        pd : {hero.Pd}
        État : {etat}

    ==============================

    """);
}

class Perso {
    public string Nom { get; set; } = "";
    public double Pv { get; private set; }
    public double PvMax { get; }
    public double Pa { get; set; }
    public double Pd { get; set; }

    public Perso(string nom, double pv, double pa, double pd)
    {
        Nom = nom;
        Pv = pv;
        PvMax = pv;
        Pa = pa;
        Pd = pd;
    }

    public void RecevoirDegats(double degats) {
        Pv = Math.Max(Pv - degats, 0);
    }
    public void Soigner(double soin) {
        if (Pv == PvMax){
            Console.WriteLine($"les pv de {Nom} sont déja au max");
        }
        else {
            Pv = Math.Min(Pv + soin, PvMax);
            Console.WriteLine($"{Nom} à maintenant {Pv} pv");
        }
    }
    public void Attaquer(Perso cible){
        double dégâts = Math.Max(Pa - cible.Pd, 0);
        cible.RecevoirDegats(dégâts);
        Console.WriteLine($"""
        ==============================
        {Nom} attaque {cible.Nom}  
        {cible.Nom} reçoit {dégâts} dégâts
        {cible.Nom} à maintenant {cible.Pv} / {cible.PvMax} PV

        ==============================

        """);
    }
    public bool EstVivant() {
        return Pv > 0;
    }
}
