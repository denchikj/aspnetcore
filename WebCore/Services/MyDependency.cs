using WebCore.Interfaces;

namespace WebCore.Services
{
    public class MyDependency : IMyDependency
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine($"MyDependency.WriteMessage: {message}");
        }
    }
}
