namespace ConsoleApp1
{
    /// <summary>
    /// A message provider.  To extend, implement a new class and change the program IoC.
    /// </summary>
    public interface IMessageRepository
    {
        string GetMessage();
    }
}