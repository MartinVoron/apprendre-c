List<Contact> contacts = new List<Contact>();
int choix = 0;

while (choix != 4) {

    AfficherMenu();

    Console.WriteLine("""
        choisis une action : 
    """);
    string input = Console.ReadLine() ?? "0";
    choix = GetInput(input);

    if (choix > 5 || choix < 1 ) {
        Console.WriteLine("""
            !!   saisie invalide    !!

        """);
    }

    else {

        switch (choix) {

            case 1 :
                AjouterContact(contacts);
                break;

            case 2 :
                AfficherContacts(contacts);
                break;

            case 3 :
                RechercherContact(contacts);
                break;

            case 4 :
                Console.WriteLine("""
                    Au revoir
                """);
                break;

            case 5 :
                SupprimerContacts(contacts);
                break;     

        } 
    }
} 

static void AfficherMenu() {
    Console.WriteLine("""

        ============== Menu ==============
        1. Ajouter des contact
        2. Afficher les contacts
        3. Rechercher un contact
        4. Quitter
        5. Supprimer un contact
        ==================================

    """);
}
static void AjouterContact(List<Contact> contacts) {
    int n = 1;
    while (n == 1) {
        Console.WriteLine("""
            combien de contact voulez-vous ajouter ?

        """);
        string addInput = Console.ReadLine() ?? "0";
        int nbContactAdd = GetInput(addInput);
        if (nbContactAdd >= 1) {
            for (int e = 0; e < nbContactAdd; e++) {
                Console.WriteLine("""
                
                    - rentrez le Nom du Contact
                    - rentrez le Prénom du contact
                    - rentrez le Telephone du Contact
                    - rentrez le Mail du contact

                """);

                Contact contact = new Contact();
                contact.Nom = Console.ReadLine() ?? "";
                contact.Prenom = Console.ReadLine() ?? "";
                contact.Telephone = Console.ReadLine() ?? "";
                contact.Email = Console.ReadLine() ?? "";

                contacts.Add(contact);
            }
            n = 2;
        }
        else {
            Console.WriteLine("""
                saisie invalide
            """);
        }
    }
}
static void AfficherContacts(List<Contact> contacts) {
    Console.WriteLine("""

        =========== Contacts ===========
    """);
    int l = 1;
    foreach (Contact contact in contacts) {
        Console.WriteLine($"""
            Contact {l} :
                Nom : {contact.Nom}
                Prénom : {contact.Prenom}
                Téléphone : {contact.Telephone}
                Email : {contact.Email}
        """);
        l++;
    }
    
    Console.WriteLine("""
        ===============================
        
    """);
}
static void SupprimerContacts(List<Contact> contacts) {
    Console.WriteLine("""
        combien de contact voulez-vous supprimer ?
    """);
    string delInput = Console.ReadLine() ?? "0";
    int.TryParse(delInput, out int nbDel);
    int nbContact = contacts.Count;
    int h = 1;
    Console.WriteLine("""

        =========== Contacts ===========
    """);
    foreach (Contact contact in contacts) { 
        Console.WriteLine($"""
            {h}. {contact.Nom}
        """);
        h++;
    }
    Console.WriteLine("""
        ================================
        
    """);
     for (int g = 1; g <= nbDel; g++) {
        Console.WriteLine("""
            rentrez le numéro du contact à supprimer
        """);
        string numInput = Console.ReadLine() ?? "";
        int contactNumber = GetInput(numInput);

        if (contactNumber >= 1 && contactNumber <= nbContact) {
            contacts.RemoveAt(contactNumber - g);
        }
        else {
            Console.WriteLine("""
                saisie invalide
            """);
            g--;
        }
    }
}
static void RechercherContact(List<Contact> contacts) {
    Console.WriteLine("""
        Quel nom recherchez vous ?
    """);
    bool found = false;
    string nomInput = Console.ReadLine() ?? "0";

    foreach (Contact contact in contacts) { 

        if (contact.Nom.Contains(nomInput, StringComparison.OrdinalIgnoreCase)
            || contact.Prenom.Contains(nomInput, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"""
                Nom : {contact.Nom}
                Prénom : {contact.Prenom}
                Téléphone : {contact.Telephone}
                Email : {contact.Email}

            """);
            found = true;
        }
    }
    if (!found) {
        Console.WriteLine($"""
            Aucun contact trouvé pour {nomInput}
        """);
    }
}

static int GetInput(string input) {
    int.TryParse(input, out int output);
    return output;
}

class Contact
{
    public string Nom { get; set; } = "";
    public string Prenom { get; set; } = "";
    public string Telephone { get; set; } = "";
    public string Email { get; set; } = "";
}