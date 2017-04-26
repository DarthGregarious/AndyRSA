using AndyRSA.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndyRSA
{
  class Program
  {
    static void Main(string[] args)
    {
      var console = new SystemConsole();
      var rng = new RandomNumberGenerator(new PrimeChecker());
      var app = new AndyRsaConsoleApp(console, rng);
      app.Run();
    }
  }
}
