// this programm is a typing game where the user has to type the fastest and without mistakes 
class Programm {

    static void Main(){

        string[] testSentences = new string[] {
            "the lazy programmer keeps forgetting to do his job",
            "the quick brown fox jumps over the lazy dog",
            "practice makes perfect when learning how to code",
            "a journey of a thousand miles begins with a single step",
            "clean code always looks like it was written by someone who cares",
            "debugging is twice as hard as writing the code in the first place",
            "simplicity is prerequisite for reliability",
            "it always seems impossible until it is done",
            "knowledge is of no value unless you put it into practice",
            "actions speak louder than words"
        };

        var random = new Random();
        string testSentence = testSentences[random.Next(testSentences.Length)];

        Console.WriteLine("Welcome to the Typing Game!");
        Console.WriteLine("Type the following sentence as fast as possible");
        Console.WriteLine("appuyer sur n'importe quelle touche pour commencer");

        Console.ReadKey(true);
        Console.Clear();

        Game(testSentence);
    }

    static void Game(string testSentence){

        Console.WriteLine($"""
        {testSentence}
        """);

        var startTime = DateTime.Now;
        string input = Console.ReadLine() ?? "";
        var endTime = DateTime.Now;
        var elapsedTime = endTime.Subtract(startTime);

        double wordcount = Countwords(testSentence);
        double wpm = wordcount / (elapsedTime.TotalSeconds / 60);

        int errorCount = CountErrors(testSentence, input);

        Console.WriteLine($"""
            phrase écrite en {elapsedTime.TotalSeconds:F2} secondes
            tu as fait {errorCount} erreurs
            tu écris à {wpm:F2} mots par minute
        """);

        Console.WriteLine("Voulez vous rejouer ? Y/N ");
        string reponse = Console.ReadLine() ?? "";
        if (reponse.Trim().Equals("Y", StringComparison.OrdinalIgnoreCase))
        {
            Console.Clear();
        }
    }

    static double Countwords(string testSentence){
        return testSentence.Split(" ").Length;
    }

    static int CountErrors(string original, string typed)
    {
        int errors = 0;
        int minLength = Math.Min(original.Length, typed.Length);

        for (int i = 0; i < minLength; i++)
        {
            if(original[i] != typed[i])
                errors++;
        }
        errors += Math.Abs(original.Length - typed.Length);

        return errors;
    }
}