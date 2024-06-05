bool restart = false;

string[] options = new[]
{
    "Is this the real life? Is this just fantasy?",
    "Inside my heart is breaking, My make-up may be flaking, But my smile still stays on",
    "Snap back to reality, ope, there goes gravity, ope",
    "Da-da-dom, da-dom, dah-dah, dah-dah"
};

do
{
    Console.WriteLine("Please, press Enter to start typing...");
    Console.ReadLine();

    Random rnd = new Random();
    int index = rnd.Next(0, options.Length);
    string text = options[index];

    Console.WriteLine("Please, type the text below:");
    Console.WriteLine(text);

    string? message;
    DateTime startedAt = DateTime.Now;
    do
    {
        message = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(message));

    TimeSpan span = DateTime.Now - startedAt;

    TypingResult result = new TypingResult(index, span, CalculateErrors(text, message));

    Console.WriteLine(
        $"Typing the text: \"{message}\" took {span.TotalSeconds} seconds with {result.NumErrors} errors.");
    Console.WriteLine("If you want to continue, press 1, else press enter");

    string? choice = Console.ReadLine();

    restart = choice == "1";
} while (restart);


static int CalculateErrors(string expected, string actual)
{
    int errors = 0;
    int minLength = Math.Min(expected.Length, actual.Length);
    for (int i = 0; i < minLength; ++i)
    {
        if (expected[i] != actual[i])
        {
            errors++;
        }
    }

    errors += Math.Abs(expected.Length - actual.Length);
    return errors;
}

class TypingResult
{
    public int TextPosition { get; }
    public TimeSpan TimeTaken { get; }
    public int NumErrors { get; }

    public TypingResult(int textPosition, TimeSpan timeTaken, int numErrors)
    {
        TextPosition = textPosition;
        TimeTaken = timeTaken;
        NumErrors = numErrors;
    }
}