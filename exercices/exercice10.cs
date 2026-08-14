Monstre monstre = new Monstre("minotaur", 50, 15, 10);
Player player = new Player("Arthur", 100, 20, 10, 3);

Console.WriteLine($"""
    Bienvenu dans l'arène !!

""");

int i = 0;
bool fuite = false;

while ( player.Pv > 0 && monstre.Pv > 0 && !fuite) {

    if (IsEven(i)) {

        AfficherCombat(player, monstre);
        Console.WriteLine($"""
            Choisissez une action !

        """);
        string inputAction = Console.ReadLine() ?? "0";
        int.TryParse(inputAction, out int choixAction);

        switch (choixAction) {
            case 1 :
                player.Attaquer(monstre);
                break;
            
            case 2 :
                Console.WriteLine($"""
                    {player.Nom} se défend !
                    
                """);
                player.Défendre();
                break;

            case 3 :
                Console.WriteLine($"""
                    {player.Nom} utilise une potion !
                    
                """);
                player.UtiliserPotion();
                break;

            case 4 :
                if (player.Fuir()) {
                    Console.WriteLine($"""
                        {player.Nom} prend la fuite !
                        
                    """);
                    fuite = true;
                }
                else {
                    Console.WriteLine($"""
                        {player.Nom} n'a pas réussi à fuir !
                        
                    """);
                }
                break;
        }
        i++;
    }
    else {
        monstre.Attaquer(player);
        player.Pd = player.PdBase;
        i++;
    }
}

if ( player.Pv <= 0 ){
    Console.WriteLine($"""
        Défaite de {player.Nom} vaincu par {monstre.Nom}
    """);
}
else if ( monstre.Pv <= 0 ){
    Console.WriteLine($"""
        Victoire de {player.Nom} contre {monstre.Nom}
    """);
}
else if (fuite == true){
    Console.WriteLine($"""
        {player.Nom} à pris la fuite contre {monstre.Nom}
    """);
}

static void AfficherCombat(Player player, Monstre monstre) {

    Console.WriteLine($"""
        =========== COMBAT ===========
        {player.Nom} :  
            pv : {player.Pv}
            pa : {player.Pa}
            pd : {player.Pd}
            potions : {player.Potions}

        {monstre.Nom} :
            pv : {monstre.Pv}
            pa : {monstre.Pa}
            pd : {monstre.Pd}

        Que veux tu faire ?

        1. Attaquer
        2. Défendre
        3. Potion
        4. fuir
        ==============================

    """);

}

static bool IsEven(int x) {
    return x % 2 == 0;
};

class Player
{
    public string Nom { get; set; } = "";
    public double PvMax { get; set; }
    public double Pv { get; set; }
    public double Pa { get; set; }
    public double Pd { get; set; }
    public double PdBase { get; set; }
    public int Potions { get; set; }

    public Player(string nom, double pv, double pa, double pd, int potion)
    {
        Nom = nom;
        Pv = pv;
        PvMax = pv;
        Pa = pa;
        Pd = pd;
        PdBase = pd;
        Potions = potion;
    }

    public void Attaquer(Monstre monstre){ 
        double degats = Pa - monstre.Pd;
        if (degats<=0){
            Console.WriteLine($"{monstre.Nom} ne prends pas de dégats");
        }
        else {
            Console.WriteLine($"{monstre.Nom} prends {degats} dégats");
            monstre.Pv -= degats;
            Console.WriteLine($"{monstre.Nom} à maintenant {monstre.Pv} pv");
        }
    }

    public void Défendre(){
        Pd += PdBase * 0.20;
    }

    public void UtiliserPotion(){ 
        if (Potions>0 && Pv<PvMax) {
            Pv = Math.Min(Pv + 15, PvMax);
            Potions--;
            Console.WriteLine($"""
                Il vous reste {Potions} potions
            """);
        }
        else if (Potions == 0) {
            Console.WriteLine($"""
                Vous n'avez plus de potions
            """);
        }
        else if (Pv == PvMax) {
            Console.WriteLine($"""
                Vos points de vie sont déja au maximum
            """);
        }
    }

    public bool Fuir(){
        var rand = new Random();
        return rand.Next(2) == 0;
    }
}

class Monstre
{
    public string Nom { get; set; } = "";
    public double Pv { get; set; }
    public double PvMax { get; set; }
    public double Pa { get; set; }
    public double Pd { get; set; }

    public Monstre(string nom, double pv, double pa, double pd)
    {
        Nom = nom;
        Pv = pv;
        PvMax = pv;
        Pa = pa;
        Pd = pd;
    }

    public void Attaquer(Player player){ 
        double degats = Pa - player.Pd;
        if (degats<=0){
            Console.WriteLine($"{player.Nom} ne prends pas de dégats");
        }
        else {
            Console.WriteLine($"{player.Nom} prends {degats} dégats");
            player.Pv -= degats;
            Console.WriteLine($"{player.Nom} à maintenant {player.Pv} pv");
        }
    }
}
