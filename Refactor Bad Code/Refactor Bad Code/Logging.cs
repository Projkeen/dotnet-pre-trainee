namespace Refactor_Bad_Code
{
    public class Logging : ILogging
    {
        public void Log(string message) => Console.WriteLine(message);
    }
}
