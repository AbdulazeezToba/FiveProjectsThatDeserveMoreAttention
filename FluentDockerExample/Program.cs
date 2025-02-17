using System.Linq;
using System.Threading.Tasks;
using Ductus.FluentDocker.Builders;

namespace FluentDockerExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var svc = new Builder()
                .UseContainer()
                .UseCompose()
                .FromFile("./docker-compose.yml")
                .RemoveOrphans()
                .Build().Start();

            await Task.Delay(20000);
        }
    }
}
