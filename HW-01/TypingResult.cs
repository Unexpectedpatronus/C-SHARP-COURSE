namespace HW_01;

class TypingResult(int textPosition, TimeSpan timeTaken, int numErrors)
{
    public int TextPosition { get; } = textPosition;
    public TimeSpan TimeTaken { get; } = timeTaken;
    public int NumErrors { get; } = numErrors;
}