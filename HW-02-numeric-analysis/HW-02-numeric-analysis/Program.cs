using HW_02_numeric_analysis;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

Func<double, double> func = Math.Sin;
double x1 = 0;
double x2 = Math.PI;
double precision = 0.0001;

double result = IntegralCalculus.Calculate(func, x1, x2, precision);
Console.WriteLine($"Приблизительная площадь криволинейной трапеции составляет: {result}");

