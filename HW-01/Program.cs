using System.Data;
using HW_01;

bool restart = false;

var texts = new Dictionary<Language, string[]>()
{
    {
        Language.English, new[]
        {
            "Is this the real life? Is this just fantasy?",
            "Inside my heart is breaking, My make-up may be flaking, But my smile still stays on",
            "Snap back to reality, ope, there goes gravity, ope",
            "Da-da-dom, da-dom, dah-dah, dah-dah"
        }
    },
    {
        Language.Russian, new[]
        {
            "Это настоящая жизнь? Это просто фантазия?",
            "Внутри моё сердце разрывается, Мой макияж может осыпаться, Но моя улыбка всё ещё остаётся",
            "Вернись к реальности, оп, вот и гравитация, оп",
            "Да-да-дом, да-дом, да-да, да-да"
        }
    }
};


do
{
    Console.WriteLine("Choose language (1 - English, 2 - Russian):");
    string? readInput;
    bool repeat = true;
    do
    {
        readInput = Console.ReadLine();
        if (readInput != "1" && readInput != "2")
        {
            Console.WriteLine("\rInput number should be either 1 or 2");
        }
        else
        {
            repeat = false;
        }
    } while (repeat);

    Language selectedLanguage = readInput == "1" ? Language.English : Language.Russian;

    Console.WriteLine("Please, press Enter to start typing...");
    Console.ReadLine();

    Random rnd = new Random();
    string[] options = texts[selectedLanguage];
    int index = rnd.Next(0, options.Length);
    string text = options[index];

    DateTime startedAt = DateTime.Now;

    Console.WriteLine("Please, type the text below:");
    Console.WriteLine(text);

    string? message;
    do
    {
        message = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(message));

    TimeSpan span = DateTime.Now - startedAt;

    TypingResult result = new TypingResult(index, span, CalculateErrors(text, message));
    Console.WriteLine(
        $"Typing the text: \"{message}\" took {span.TotalSeconds} seconds with {result.NumErrors} errors");

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