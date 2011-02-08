public class BetterCalculator
{
    private int result = 0;

    public BetterCalculator Add(int p)
    {
        result = result + p;
        return this;
    }

    public int Total()
    {
        return result;
    }

    public BetterCalculator Multiply(int p)
    {
        result = result * p;
        return this;
    }

    public BetterCalculator Divide(int p)
    {
        result = result / p;
        return this;
    }
}

public class Calculator
{
    public int Multiply(int x, int y)
    {
        return x*y;
    }

    public int Add(int x, int y)
    {
        return x + y;
    }

    public int Subtract(int x, int y)
    {
        return 0;
    }
}