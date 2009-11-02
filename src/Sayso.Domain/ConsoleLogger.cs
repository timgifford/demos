using System;

namespace Sayso.Domain
{
    public class ConsoleLogger
    {
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public void WriteLine(string format, params object[] arg)
        {
            Console.WriteLine(format, arg);
        }
    }
}