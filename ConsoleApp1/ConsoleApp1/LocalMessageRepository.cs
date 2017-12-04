namespace ConsoleApp1
{
    /// <summary>
    /// Returns hard-coded messages without making any external service calls.
    /// </summary>
    public class LocalMessageRepository : IMessageRepository
    {
        public string GetMessage()
        {
            return "Hello World";
        }
    }
}