using System;
using System.Threading.Tasks;
using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Plugins.Http.CSharp;

namespace NBomberExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpFactory = HttpClientFactory.Create();

            var step = Step.Create("step", httpFactory, async context =>
            {
                var response = await context.Client.GetAsync("https://localhost:5001/youtube", context.CancellationToken);

                return response.IsSuccessStatusCode
                    ? Response.Ok(statusCode: (int) response.StatusCode)
                    : Response.Fail(statusCode: (int) response.StatusCode);
            });

            var scenario = ScenarioBuilder
                .CreateScenario("simple_http", step)
                .WithWarmUpDuration(TimeSpan.FromSeconds(5))
                //.WithLoadSimulations(Simulation.InjectPerSec(rate: 100, during: TimeSpan.FromSeconds(20)));
                .WithLoadSimulations(Simulation.KeepConstant(16, TimeSpan.FromSeconds(20)));

            NBomberRunner
                .RegisterScenarios(scenario)
                .Run();
        }
    }
}
