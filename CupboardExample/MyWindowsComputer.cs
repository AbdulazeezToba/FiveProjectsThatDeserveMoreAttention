using System.Runtime.InteropServices;
using Cupboard;

namespace CupboardExample
{
    public sealed class MyWindowsComputer : Catalog
    {
        public override void Execute(CatalogContext context)
        {
            if (!context.Facts.IsWindows())
            {
                return;
            }

            context.UseManifest<Chocolatey>();
        }
    }
}
