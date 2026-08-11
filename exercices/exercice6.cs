var random = new Random();

int secretNumber = random.Next(1, 101);
int attemptCount = 0;
int playerGuess = 0;

Console.WriteLine("Devine le nombre !");

while (secretNumber != playerGuess)
{
    if (attemptCount == 0)
    {
        Console.WriteLine("Donne-moi un chiffre entre 1 et 100 :");
    }
    else
    {
        Console.WriteLine("Essaie à nouveau :");
    }

    string userInput = Console.ReadLine() ?? "0";
    bool isValidNumber = int.TryParse(userInput, out playerGuess);

    if (isValidNumber)
    {
        if (playerGuess > 100)
        {
            Console.WriteLine("Le nombre est supérieur à 100.");
        }
        else if (playerGuess < 1)
        {
            Console.WriteLine("Le nombre doit être supérieur ou égal à 1.");
        }
        else if (playerGuess < secretNumber)
        {
            Console.WriteLine("Trop petit !");
            attemptCount++;
        }
        else if (playerGuess > secretNumber)
        {
            Console.WriteLine("Trop grand !");
            attemptCount++;
        }
    }
    else
    {
        Console.WriteLine("Saisie invalide. Entre un nombre entier.");
    }

    Console.WriteLine($"Essai n° {attemptCount}");
}

Console.WriteLine(
    $"Bravo ! Le nombre était {secretNumber}. " +
    $"Tu as trouvé en {attemptCount} essais !"
);
