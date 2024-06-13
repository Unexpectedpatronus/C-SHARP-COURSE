namespace HW_03_structs;

public struct Meter : IEquatable<Meter>
{
    public double Value { get; set; }

    public Meter(double val)
    {
        Value = val;
    }

    private const double InchesInMeter = 39.3701;

    public static Meter operator +(Meter a, Meter b) => new Meter(a.Value + b.Value);
    public static Meter operator -(Meter a, Meter b) => new Meter(a.Value - b.Value);
    public static Meter operator *(Meter a, Meter b) => new Meter(a.Value * b.Value);
    public static Meter operator /(Meter a, Meter b) => new Meter(a.Value / b.Value);

    public static Meter operator +(Meter a, double b) => new Meter(a.Value + b);
    public static Meter operator -(Meter a, double b) => new Meter(a.Value - b);
    public static Meter operator *(Meter a, double b) => new Meter(a.Value * b);
    public static Meter operator /(Meter a, double b) => new Meter(a.Value / b);

    public static Meter operator +(double b, Meter a) => new Meter(b + a.Value);
    public static Meter operator -(double b, Meter a) => new Meter(b - a.Value);
    public static Meter operator *(double b, Meter a) => new Meter(b * a.Value);
    public static Meter operator /(double b, Meter a) => new Meter(b / a.Value);

    public static Meter operator +(Meter a) => new Meter(a.Value);
    public static Meter operator -(Meter a) => new Meter(-a.Value);

    public static explicit operator Meter(Inch inch) => new Meter(Math.Round(inch.Value / InchesInMeter, 2));
    public static implicit operator Meter(double val) => new Meter(val);
    public static implicit operator double(Meter meter) => meter.Value;

    public static bool operator ==(Meter a, Meter b) => a.Value == b.Value;
    public static bool operator !=(Meter a, Meter b) => a.Value != b.Value;
    public static bool operator >(Meter a, Meter b) => a.Value > b.Value;
    public static bool operator <(Meter a, Meter b) => a.Value < b.Value;
    public static bool operator >=(Meter a, Meter b) => a.Value >= b.Value;
    public static bool operator <=(Meter a, Meter b) => a.Value <= b.Value;

    public static bool operator ==(Meter a, Inch b) => a == (Meter)b;
    public static bool operator !=(Meter a, Inch b) => a != (Meter)b;
    public static bool operator >(Meter a, Inch b) => a > (Meter)b;
    public static bool operator <(Meter a, Inch b) => a < (Meter)b;
    public static bool operator >=(Meter a, Inch b) => a >= (Meter)b;
    public static bool operator <=(Meter a, Inch b) => a <= (Meter)b;

    public bool Equals(Meter other) => Value == other.Value;

    public override bool Equals(object? obj)
    {
        return obj is Meter && ((Meter)obj).Value == Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString() => $"{Value} m";
}