Inventaire inventaire = new Inventaire();

inventaire.AjouterObjet("Potion", 10, 10);
inventaire.AjouterObjet("Épée", 7, 35);

inventaire.AfficherInventaire();

Console.WriteLine(
    $"Valeur totale : {inventaire.ValeurTotale()} pièces"
);

inventaire.SupprimerObjet("Potion");

inventaire.AfficherInventaire();

Console.WriteLine(
    $"Nombre total d'objets : {inventaire.NbObjet()}"
);

class Inventaire
{
    private List<Objet> objets = new List<Objet>();

    public void AjouterObjet(string nom, int nombre, double valeur)
    {
        Objet objet = new Objet(nom, nombre, valeur);
        objets.Add(objet);
    }

    public void SupprimerObjet(string nom)
    {
        Objet? objet = objets.Find(objet =>
            objet.Nom.Contains(nom, StringComparison.OrdinalIgnoreCase));

        if (objet is null)
        {
            Console.WriteLine("Objet introuvable");
            return;
        }

        if (objet.Nb > 1)
        {
            objet.RetirerUn();

            Console.WriteLine($"""
                Suppression de 1 {objet.Nom}
                Il reste {objet.Nb} {objet.Nom}
            """);
        }
        else
        {
            objets.Remove(objet);

            Console.WriteLine($"""
                {objet.Nom} retiré de l'inventaire
            """);
        }
    }

    public void AfficherInventaire()
    {
        Console.WriteLine("""
            ========== Inventaire ==========
        """);

        foreach (Objet objet in objets)
        {
            Console.WriteLine(
                $"{objet.Nom} - {objet.Nb} - {objet.Val} pièces"
            );
        }

        Console.WriteLine("""
            ================================
        """);
    }

    public double ValeurTotale()
    {
        double total = 0;

        foreach (Objet objet in objets)
        {
            total += objet.Nb * objet.Val;
        }

        return total;
    }

    public int NbObjet()
    {
        int total = 0;

        foreach (Objet objet in objets)
        {
            total += objet.Nb;
        }

        return total;
    }
}

class Objet {
    public string Nom { get; set; } = "";
    public int Nb { get; private set; }
    public double Val {get; private set; }

    public void RetirerUn(){
        Nb--;
    }

    public Objet(string nom, int nb, double val)
    {
        Nom = nom;
        Nb = nb;
        Val = val;
    }
}