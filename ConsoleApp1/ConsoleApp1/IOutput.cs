using System;

namespace ConsoleApp1
{
    /// <summary>
    /// A device for printing output.  To extend, implement a new class and change the program IoC.
    /// For example, to write to a database, create a DatabaseOutput class, implement the interface,
    /// then simply change the one line in the IoC file to reference the DatabaseOutput class.
    /// </summary>
    public interface IOutput
    {
        void Write(string message);
    }
}