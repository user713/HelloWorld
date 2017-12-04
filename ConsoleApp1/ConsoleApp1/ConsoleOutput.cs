using System;

namespace ConsoleApp1
{
    public class ConsoleOutput : IOutput
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}