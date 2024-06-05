bool restart = false;

do
{
    Console.WriteLine("Please, enter a message.");
    string? message = null;
    DateTime startedAt = DateTime.Now;
    
    do
    {
        message = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(message));

    DateTime stoppedAt = DateTime.Now;
    TimeSpan span = stoppedAt - startedAt;
    Console.WriteLine($"Time for typing was {span}\nIf you want to continue, press 1, else press enter");
    
    string? choice = Console.ReadLine();
    
    restart = choice == "1";
} while (restart);