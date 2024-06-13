namespace TestProject1;

using HW_03_structs;

public class MeterTest
{
    [Fact(DisplayName = "Meter + double")]
    public void Test1()
    {
        // arrange
        Meter m1 = new Meter(7);
        double val = 100;
        // act
        Meter m2 = m1 + val;
        // assert
        Assert.Equal(107, m2.Value);
    }

    [Fact(DisplayName = "double + Meter")]
    public void Test2()
    {
        // arrange
        Meter m1 = new Meter(7);
        double val = 100;
        // act
        Meter m2 = val + m1;
        // assert
        Assert.Equal(107, m2.Value);
    }

    [Fact(DisplayName = "-Meter")]
    public void Test3()
    {
        // arrange
        Meter m1 = new Meter(7);
        // act
        Meter m2 = -m1;
        // assert
        Assert.Equal(-7, m2.Value);
    }

    [Fact(DisplayName = "Inches in Meters")]
    public void Test4()
    {
        // arrange
        Inch inch = new Inch(100);
        // act
        Meter m1 = (Meter)inch;
        // assert
        Assert.Equal(Math.Round(100 / 39.3701, 2), m1.Value);
    }

    [Fact(DisplayName = "Meters == (Meter)Inches")]
    public void Test6()
    {
        // arrange
        Meter m1 = new Meter(100);
        Inch inch = new Inch(100 * 39.3701);
        // act
        Meter m2 = (Meter)inch;
        // assert
        Assert.Equal(m1, m2);
    }

    [Fact(DisplayName = "Meter Equality")]
    public void Test7()
    {
        // arrange
        Meter m1 = new Meter(5.0);
        Meter m2 = new Meter(5.0);
        Meter m3 = new Meter(7.0);

        // act & assert
        Assert.True(m1.Equals(m2), "Expected meters to be equal");
        Assert.False(m1.Equals(m3), "Expected meters to be not equal");
    }

    [Fact(DisplayName = "Meter Equality with Object")]
    public void Test8()
    {
        // arrange
        Meter m1 = new Meter(5.0);
        object m2 = new Meter(5.0);
        object m3 = new Meter(7.0);
        object nonMeter = new { Value = 5.0 }; // A non-Meter object for testing

        // act & assert
        Assert.True(m1.Equals(m2), "Expected meters to be equal");
        Assert.False(m1.Equals(m3), "Expected meters to be not equal");
        Assert.False(m1.Equals(nonMeter), "Expected meters to be not equal with a non-Meter object");
    }

    [Fact(DisplayName = "Meter's ToString() method testing")]
    public void Test9()
    {
        // arrange
        Meter m1 = new Meter(5.0);
        // act
        string meterToString = "5 m";
        // assert
        Assert.Equal(meterToString, m1.ToString());
    }
}

public class InchTest
{
    [Fact(DisplayName = "Inch + double")]
    public void Test1()
    {
        // arrange
        Inch inch = new Inch(7);
        double val = 100;
        // act
        Inch inch1 = inch + val;
        // assert
        Assert.Equal(107, inch1.Value);
    }

    [Fact(DisplayName = "double + Inch")]
    public void Test2()
    {
        // arrange
        Inch inch = new Inch(7);
        double val = 100;
        // act
        Inch inch1 = val + inch;
        // assert
        Assert.Equal(107, inch1.Value);
    }

    [Fact(DisplayName = "-Inch")]
    public void Test3()
    {
        // arrange
        Inch inch = new Inch(7);
        // act
        Inch inch1 = -inch;
        // assert
        Assert.Equal(-7, inch1.Value);
    }

    [Fact(DisplayName = "Meters in Inches")]
    public void Test4()
    {
        // arrange
        Meter meter = new Meter(100);
        // act
        Inch inch = (Inch)meter;
        // assert
        Assert.Equal(100 * 39.3701, inch.Value);
    }


    [Fact(DisplayName = "Inches == (Inch)Meters")]
    public void Test6()
    {
        // arrange
        Inch inch = new Inch(100);
        Meter m1 = new Meter(100 / 39.3701);
        // act
        Inch i2 = (Inch)m1;
        // assert
        Assert.Equal(inch, i2);
    }

    [Fact(DisplayName = "Inch Equality")]
    public void Test7()
    {
        // arrange
        Inch i1 = new Inch(5.0);
        Inch i2 = new Inch(5.0);
        Inch i3 = new Inch(7.0);

        // act & assert
        Assert.True(i1.Equals(i2), "Expected inches to be equal");
        Assert.False(i1.Equals(i3), "Expected inches to be not equal");
    }

    [Fact(DisplayName = "Inch Equality with Object")]
    public void Test8()
    {
        // arrange
        Inch i1 = new Inch(5.0);
        object i2 = new Inch(5.0);
        object i3 = new Inch(7.0);
        object nonInch = new { Value = 5.0 }; // A non-Inch object for testing

        // act & assert
        Assert.True(i1.Equals(i2), "Expected meters to be equal");
        Assert.False(i1.Equals(i3), "Expected meters to be not equal");
        Assert.False(i1.Equals(nonInch), "Expected meters to be not equal with a non-Meter object");
    }

    [Fact(DisplayName = "Inches' ToString() method testing")]
    public void Test9()
    {
        // arrange
        Inch i1 = new Inch(5.0);
        // act
        string inchToString = "5 in";
        // assert
        Assert.Equal(inchToString, i1.ToString());
    }
}