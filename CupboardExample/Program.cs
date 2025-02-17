using System;
using Cupboard;

namespace CupboardExample
{
    class Program
    {
        static int Main(string[] args)
        {
            return CupboardHost.CreateBuilder()
                .AddCatalog<MyWindowsComputer>()
                .Build()
                .Run(args);
        }
    }
}
