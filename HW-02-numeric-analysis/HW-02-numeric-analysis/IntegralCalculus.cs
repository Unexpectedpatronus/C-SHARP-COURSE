namespace HW_02_numeric_analysis;

public class IntegralCalculus
{
    public static double Calculate(Func<double, double> func, double x1, double x2, double precision)
    {
        if (x1 >= x2)
        {
            throw new NotImplementedException("Invalid input: 'x1' must be less than 'x2'.");
        }

        int amountOfParts = 1;
        double previousResult = Integrate(func, x1, x2, amountOfParts);
        double currentResult;
        do
        {
            amountOfParts *= 2;
            currentResult = Integrate(func, x1, x2, amountOfParts);

            if (Math.Abs(currentResult - previousResult) < precision)
            {
                break;
            }

            previousResult = currentResult;
        } while (true);

        return currentResult;
    }

    private static double Integrate(Func<double, double> func, double x1, double x2, int amountOfParts)
    {
        double result = 0;
        double stepSize = (x2 - x1) / amountOfParts;

        for (int i = 0; i < amountOfParts; ++i)
        {
            double xStart = x1 + stepSize * i;
            double xEnd = xStart + stepSize;
            double yStart = func(xStart);
            double yEnd = func(xEnd);

            result += (yStart + yEnd) / 2 * stepSize;
        }

        return result;
    }
}
