char[,] plateau = new char[3, 3];
char joueur = 'X';
bool fin = false;
int scoreX = 0;
int scoreO = 0;

InitialiserPlateau(plateau);
while (!fin) {
    for (int tour = 0; tour < 9; tour++) {

        AfficherPlateau(plateau);
        JouerCoup(plateau, joueur);

        if (VerifierVictoire(plateau, joueur)){
            Console.WriteLine($"""
                Victoire du joueur {joueur}
            """);
            if (joueur == 'X'){
                scoreX++;
            }
            else {
                scoreO++;
            }
            break;
        }
        
        joueur = joueur == 'X' ? 'O' : 'X';

        if (tour == 8 ) {
            Console.WriteLine($"""
                Egalité !
            """);
        }
    }
    Console.WriteLine($"""
        Score : 
            X : {scoreX}
            O : {scoreO}

        Voulez vous rejouer ?
        1 : oui    0 : non
    """);

    string choix = Console.ReadLine() ?? "0";
    int rejouer = GetInput(choix);

    while (rejouer != 1 && rejouer != 0){
        Console.WriteLine($"""
            Saisie invalide !
            Voulez vous rejouer ?
            1 : oui    0 : non
        """);
        choix = Console.ReadLine() ?? "0";
        rejouer = GetInput(choix);
    }

    if (rejouer == 1) {
        Console.WriteLine($"""
            Nouvelle partie !
        """);

        InitialiserPlateau(plateau);
        joueur = 'X';
    } 
    else if (rejouer == 0){
        Console.WriteLine($"""
        Score Final : 
            X : {scoreX}
            O : {scoreO}

            Au revoir !
        """);
        fin = true;
    }
}
static void InitialiserPlateau(char[,] plateau){
    for (int ligne = 0; ligne < 3; ligne++) {
        for (int colonne = 0; colonne < 3; colonne++)
        {
            plateau[ligne, colonne] = ' ';
        }
    }

}
static void AfficherPlateau(char[,] plateau){
    Console.WriteLine($"""
               {plateau[0,0]}  |  {plateau[0,1]}  |  {plateau[0,2]}
            -------------------
               {plateau[1,0]}  |  {plateau[1,1]}  |  {plateau[1,2]}
            -------------------
               {plateau[2,0]}  |  {plateau[2,1]}  |  {plateau[2,2]}
    """);
}
static void JouerCoup(char[,] plateau, char joueur){
    bool coupValide = false;
    while (coupValide) {
        Console.WriteLine($"""
            Joueur {joueur}, choisis une ligne (1-3) :
            Joueur {joueur}, choisis une colonne (1-3) :
        """);
        string choix1 = Console.ReadLine() ?? "0";
        int ligne = GetInput(choix1) - 1;
        string choix2 = Console.ReadLine() ?? "0";
        int colonne = GetInput(choix2) - 1;
        // Console.Clear();

        if (ligne < 0 || ligne > 2 || colonne < 0 || colonne > 2) {
            Console.WriteLine($"""
                saisie invalide
            """);
            AfficherPlateau(plateau);
        }
        else if (!CaseDisponible(plateau,ligne, colonne)){
            Console.WriteLine($"""
                La case est déja prise
            """);
            AfficherPlateau(plateau);
        }
        else {
            plateau[ligne, colonne] = joueur;
            coupValide = false;
        }
    }
}
static bool CaseDisponible(char[,] plateau, int x, int y){
    return plateau[x, y] == ' ';
}
static bool VerifierVictoire(char[,] plateau, char joueur){
    for (int ligne = 0; ligne < 3; ligne++) {
        if (plateau[ligne,0] == joueur && plateau[ligne,1] == joueur && plateau[ligne,2] == joueur)
        {
            return true;
        }
    }
    for (int colonne = 0; colonne < 3; colonne++) {
        if (plateau[0,colonne] == joueur && plateau[1,colonne] == joueur && plateau[2,colonne] == joueur)
        {
            return true;
        }
    }
    if ((plateau[0,0] == joueur && plateau[1,1] == joueur && plateau[2,2] == joueur) || (plateau[0,2] == joueur && plateau[1,1] == joueur && plateau[2,0] == joueur))
    {
        return true;
    }
    return false;
}    

static int GetInput(string input) {
    int.TryParse(input, out int output);
    return output;
}
