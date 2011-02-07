    using System;
    using fit;

public class CalculatorFixture : ColumnFixture
{
    public int x;
    public int y;

    private readonly Calculator calculator = new Calculator();

    public int Product()
    {
        return calculator.Multiply(x, y);
    }

    public int Sum()
    {
        return calculator.Add(x, y);
    }

    public int Difference()
    {
        return calculator.Subtract(x, y);
    }
}