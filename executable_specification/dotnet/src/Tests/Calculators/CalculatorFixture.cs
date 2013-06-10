using fit;

public class CalculatorFixture : ColumnFixture
{
    public int X;
    public int Y;

    private readonly Calculator calculator = new Calculator();

    public int Product()
    {
        return calculator.Multiply(X, Y);
    }

    public int Sum()
    {
        return calculator.Add(X, Y);
    }

    public int Difference()
    {
        return calculator.Subtract(X, Y);
    }
}