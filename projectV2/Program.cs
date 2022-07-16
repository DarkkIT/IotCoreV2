using System.Threading.Tasks;

namespace projectV2
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var startUp = new StartUp.StartUp();
            await startUp.Start();
        }
    }
}
