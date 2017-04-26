using AndyRSA.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndyRSA
{
  public class AndyRsaConsoleApp
  {
    private readonly IConsole console;
    private readonly IGenerateRandomNumbers rng;

    public AndyRsaConsoleApp(IConsole console, IGenerateRandomNumbers rng)
    {
      this.console = console;
      this.rng = rng;
    }

    public void Run()
    {
      while(true)
      {
        this.console.Write("What would you like to do? (E-Encrypt, D-Decrypt, K-Key Gen, Q-Quit): ");
        char programChoice = this.console.ReadKeyChar();
        this.console.WriteLine(string.Empty);

        if (programChoice == 'K')
          RunKeyGenerationSubroutine();
        else if (programChoice == 'E')
          RunEncryptionSubroutine();
        else if (programChoice == 'Q')
          break;
      }
    }

    protected void RunEncryptionSubroutine()
    {
      this.console.WriteLine("Please enter the text to encrypt: ");
      var message = this.console.ReadLine();
      this.console.WriteLine("Please enter the recipient's public key: ");
    }

    protected void RunKeyGenerationSubroutine()
    {
      this.console.WriteLine(string.Format("Here is your public key: {0}", rng.Generate()));
      this.console.WriteLine(string.Format("Here is your private key: {0}", rng.Generate()));
    }
  }
}
