bool restart = false;
bool useTestData = false;

string[] options = new[]
{
    "This is the first string",
    "This is the second string",
    "This is the third string",
    "This is the fourth string"
};

do
{
    string? message = null;

    DateTime startedAt = DateTime.Now;
    if (useTestData == false)
    {
        Console.WriteLine("Please, enter a message.");
        do
        {
            message = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(message));
    }
    else
    {
        Random rnd = new Random();
        message = options[rnd.Next(0, options.Length)];
    }

    TimeSpan span = DateTime.Now - startedAt;
    Console.WriteLine($"Time for typing message \"{message}\" was {span} seconds");
    Console.WriteLine("If you want to continue, press 1, else press enter");

    string? choice = Console.ReadLine();

    restart = choice == "1";
} while (restart);