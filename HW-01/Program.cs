Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

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

bool restart = false;

var Statistics = new Statistics();

List<TypingResult> results = new List<TypingResult>();

do
{
    Console.WriteLine("Выберите язык (1 - English, 2 - Русский):");
    string? readInput;
    bool repeat = true;
    do
    {
        readInput = Console.ReadLine();
        if (readInput != "1" && readInput != "2")
        {
            Console.WriteLine("\rДопустимые значения 1 или 2!");
        }
        else
        {
            repeat = false;
        }
    } while (repeat);

    Language selectedLanguage = readInput == "1" ? Language.English : Language.Russian;

    Console.WriteLine("Нажмите \"Enter\", когда будете готовы печатать...");
    Console.ReadLine();

    Random rnd = new Random();
    string[] options = texts[selectedLanguage];
    int index = rnd.Next(0, options.Length);
    string text = options[index];

    DateTime startedAt = DateTime.Now;

    Console.WriteLine("Перепечатайте следующий текст:");
    Console.WriteLine(text);

    string? message;
    do
    {
        message = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(message));

    TimeSpan span = DateTime.Now - startedAt;

    TypingResult result = new TypingResult(index, span, CalculateErrors(text, message), text.Length);

    Console.WriteLine(
        $"Вы напечатали текст:\n\"{message}\"\n За {span.TotalSeconds} секунд\n В тексте: {result.NumErrors} ошибок" +
        $"\n Длина текста: {text.Length} знаков");

    Statistics.AddResult(result);
    Console.WriteLine(
        $"У вас было {Statistics.Attempts()} попыток, " +
        $"средняя скорость - {Statistics.AverageSpeed():F2} зн/мин, " +
        $"лучшая - {Statistics.BestSpeed():F2} зн/мин, худшая {Statistics.WorstSpeed():F2} зн/мин"
    );

    Console.WriteLine("Если хотите продолжить, нажмите \"1\", иначе нажмите \"Enter\"");
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

class Statistics
{
    private readonly List<TypingResult> _results = new List<TypingResult>();

    public void AddResult(TypingResult result)
    {
        _results.Add(result);
    }

    public int Attempts()
    {
        return _results.Count;
    }

    public double WorstSpeed()
    {
        return _results.Min(r => r.TextSize / r.TimeTaken.TotalSeconds * 60);
    }

    public double AverageSpeed()
    {
        return _results.Average(r => r.TextSize / r.TimeTaken.TotalSeconds * 60);
    }

    public double BestSpeed()
    {
        return _results.Max(r => r.TextSize / r.TimeTaken.TotalSeconds * 60);
    }
}

class TypingResult(int textPosition, TimeSpan timeTaken, int numErrors, int textLength)
{
    public int TextPosition { get; } = textPosition;
    public TimeSpan TimeTaken { get; } = timeTaken;
    public int NumErrors { get; } = numErrors;
    public int TextSize { get; } = textLength;
}

public enum Language
{
    English,
    Russian
}