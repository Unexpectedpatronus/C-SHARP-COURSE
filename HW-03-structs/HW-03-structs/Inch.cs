namespace HW_03_structs;

public struct Inch(double val) : IEquatable<Inch>
{
    public double Value { get; set; } = val;

    private const double MetersInInch = 1 / 39.3701;

    public static Inch operator +(Inch a, Inch b) => new Inch(a.Value + b.Value);
    public static Inch operator -(Inch a, Inch b) => new Inch(a.Value - b.Value);
    public static Inch operator *(Inch a, Inch b) => new Inch(a.Value * b.Value);
    public static Inch operator /(Inch a, Inch b) => new Inch(a.Value / b.Value);

    public static Inch operator +(Inch a, double b) => new Inch(a.Value + b);
    public static Inch operator -(Inch a, double b) => new Inch(a.Value - b);
    public static Inch operator *(Inch a, double b) => new Inch(a.Value * b);
    public static Inch operator /(Inch a, double b) => new Inch(a.Value / b);

    public static Inch operator +(double b, Inch a) => new Inch(b + a.Value);
    public static Inch operator -(double b, Inch a) => new Inch(b - a.Value);
    public static Inch operator *(double b, Inch a) => new Inch(b * a.Value);
    public static Inch operator /(double b, Inch a) => new Inch(b / a.Value);

    public static Inch operator +(Inch a) => new Inch(a.Value);
    public static Inch operator -(Inch a) => new Inch(-a.Value);

    public static explicit operator Inch(Meter meter) => new Inch(Math.Round(meter.Value / MetersInInch, 2));
    public static implicit operator Inch(double val) => new Inch(val);
    public static implicit operator double(Inch inch) => inch.Value;

    public static bool operator ==(Inch a, Inch b) => a.Value == b.Value;
    public static bool operator !=(Inch a, Inch b) => a.Value != b.Value;
    public static bool operator >(Inch a, Inch b) => a.Value > b.Value;
    public static bool operator <(Inch a, Inch b) => a.Value < b.Value;
    public static bool operator >=(Inch a, Inch b) => a.Value >= b.Value;
    public static bool operator <=(Inch a, Inch b) => a.Value <= b.Value;

    public static bool operator ==(Inch a, Meter b) => a == (Inch)b;
    public static bool operator !=(Inch a, Meter b) => a != (Inch)b;
    public static bool operator >(Inch a, Meter b) => a > (Inch)b;
    public static bool operator <(Inch a, Meter b) => a < (Inch)b;
    public static bool operator >=(Inch a, Meter b) => a >= (Inch)b;
    public static bool operator <=(Inch a, Meter b) => a <= (Inch)b;

    public bool Equals(Inch other) => Value == other.Value;

    public override bool Equals(object? obj)
    {
        return obj is Inch && ((Inch)obj).Value == Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString() => $"{Value} in";
}