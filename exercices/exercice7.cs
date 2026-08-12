List<string> menu = new List<string>();
int choix = 0;

while (choix != 4) {

    Console.WriteLine("""
        ============== Menu ==============
        1. Ajouter une tâche
        2. Afficher les tâches
        3. Supprimer une tâche
        4. Quitter
        5. Vider toutes les tâches
        6. Afficher le nombre de tâches
        ==================================
    """);

    Console.WriteLine("""
        choisis une action : 
    """);
    string input = Console.ReadLine() ?? "0";
    bool validInput = int.TryParse(input, out choix);

    if (choix > 6 || choix < 0 || !validInput) {
        Console.WriteLine("""
            !!   saisie invalide    !!

        """);
    }

    else {

        switch (choix) {

            case 1 :
                int n = 1;
                while (n == 1) {
                    Console.WriteLine("""
                        combien de tache voulez-vous ajouter ?

                    """);
                    string addInput = Console.ReadLine() ?? "0";
                    bool j = int.TryParse(addInput, out int nbTaskAdd);

                    if (nbTaskAdd >= 1 && j) {
                        for (int e = 0; e < nbTaskAdd; e++) {
                            Console.WriteLine("""
                                rentrez le titre de la tâche
                            """);
                            string taskName = Console.ReadLine() ?? "";
                            menu.Add(taskName);
                        }
                        n = 2;
                    }
                    else {
                        Console.WriteLine("""
                            saisie invalide
                        """);
                    }
                }
                break;

            case 2 :
                int f=1;
                Console.WriteLine("""
                    =========== MES TÂCHES ===========
                """);
                foreach (string task in menu) { 
                    Console.WriteLine($"""
                        {f}. {task}
                    """);
                    f++;
                }
                Console.WriteLine("""
                    ==================================
                    
                """);
                break;

            case 3 : 
                Console.WriteLine("""
                    combien de tache voulez-vous supprimer ?
                """);
                string delInput = Console.ReadLine() ?? "0";
                int.TryParse(delInput, out int nbTaskDel);
                int h = 1;
                int countTask = menu.Count;

                Console.WriteLine("""
                    =========== MES TÂCHES ===========
                """);
                foreach (string task in menu) { 
                    Console.WriteLine($"""
                        {h}. {task}
                    """);
                    h++;
                }
                Console.WriteLine("""
                    ==================================
                    
                """);

                for (int g = 1; g <= nbTaskDel; g++) {
                    Console.WriteLine("""
                        rentrez le numéro de la tâche
                    """);
                    string numInput = Console.ReadLine() ?? "";
                    int.TryParse(numInput, out int taskNumber);

                    if (taskNumber >= 1 && taskNumber <= countTask) {
                        menu.RemoveAt(taskNumber - g);
                    }
                    else {
                        Console.WriteLine("""
                            saisie invalide
                        """);
                        g--;
                    }
                }
                break;

            case 4 :
                Console.WriteLine("""
                    Au revoir
                """);
                break;

            case 5 :
                Console.WriteLine("""
                    suppression de toutes les tâches
                """); 
                menu.Clear();
                break;

            case 6 :
                int nbTask = menu.Count;
                if (nbTask < 2) {
                    Console.WriteLine($"""
                        Il y a {nbTask} tâche dans la liste !
                    """);
                }
                else {
                    Console.WriteLine($"""
                        Il y a {nbTask} tâches dans la liste !
                    """);
                }
                break;        

        } 
    }
} 
