BankAccount compte = new BankAccount("Arthur", 1000);

compte.AfficherCompte();

compte.Deposer(500);
compte.Retirer(250);

compte.AfficherCompte();

compte.Retirer(2000);

compte.Deposer(-50);

class BankAccount{
    public string Titulaire { get; set; } = "";
    public double Solde { get; private set; }

    public BankAccount(string titulaire, double solde)
    {
        Titulaire = titulaire;
        Solde = solde;
    }

    public void AfficherCompte() {
        Console.WriteLine($"""

        ============== COMPTE ==============
            Titulaire : {Titulaire}
            Solde : {Solde} $
        ====================================

        """);
    }

    public double Deposer(double montant) {
        if (montant <= 0) {
            Console.WriteLine("Montant invalide");
            return Solde;
        }
        else {
            Solde += montant;
            return Solde;
        }
    }

    public double Retirer(double montant) {
        if (montant > 0) {
            if (Solde > montant){
                Solde -= montant;
                return Solde;
            }
            else {
                Console.WriteLine("Solde insuffisant");
                return Solde;
            }
        }
        else {
            Console.WriteLine("Montant invalide");
            return Solde;
        }
    }

    public bool EstCrediteur() {
        return Solde >= 0 ;
    }
}