using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndyRSA;
using AndyRSA.Core;

namespace AndyRSA.Tests
{
  [TestFixture]
  public class ConsoleAppShould
  {
    [Test]
    public void PromptForKeyGenerationOrEncryptionOrDecryption()
    {
      var fakeConsole = Substitute.For<IConsole>();
      fakeConsole.ReadKeyChar().Returns('Q');

      var fakeRandomNumberGenerator = Substitute.For<IGenerateRandomNumbers>();
      var app = new AndyRsaConsoleApp(fakeConsole, fakeRandomNumberGenerator);
      app.Run();

      fakeConsole.Received().Write("What would you like to do? (E-Encrypt, D-Decrypt, K-Key Gen, Q-Quit): ");
    }

    [Test]
    public void WriteNewLineAfterReceivingInput()
    {
      var fakeConsole = Substitute.For<IConsole>();
      fakeConsole.ReadKeyChar().Returns('%', 'Q');

      var fakeRandomNumberGenerator = Substitute.For<IGenerateRandomNumbers>();
      var app = new AndyRsaConsoleApp(fakeConsole, fakeRandomNumberGenerator);
      app.Run();

      fakeConsole.Received().Write("What would you like to do? (E-Encrypt, D-Decrypt, K-Key Gen, Q-Quit): ");
      fakeConsole.Received().WriteLine(string.Empty);
    }

    [Test]
    public void GeneratePublicKey_WhenUserPressesK()
    {
      var fakeConsole = Substitute.For<IConsole>();
      fakeConsole.ReadKeyChar().Returns('K', 'Q');

      var fakeRandomNumberGenerator = Substitute.For<IGenerateRandomNumbers>();
      fakeRandomNumberGenerator.Generate().Returns(7u, 11u);

      var app = new AndyRsaConsoleApp(fakeConsole, fakeRandomNumberGenerator);

      app.Run();

      fakeConsole.Received().WriteLine("Here is your public key: 7");
      fakeConsole.Received().WriteLine("Here is your private key: 11");
    }

    [Test]
    public void EnterEncryptionMode_WhenUserPressesE()
    {
      var fakeConsole = Substitute.For<IConsole>();
      fakeConsole.ReadKeyChar().Returns('E', 'Q');

      var fakeRandomNumberGenerator = Substitute.For<IGenerateRandomNumbers>();

      var app = new AndyRsaConsoleApp(fakeConsole, fakeRandomNumberGenerator);

      app.Run();

      fakeConsole.Received().WriteLine("Please enter the text to encrypt: ");
    }

    [Test]
    public void PromptsForPublicKey_WhenUserPressesE_ThenEntersMessage()
    {
      var fakeConsole = Substitute.For<IConsole>();
      fakeConsole.ReadKeyChar().Returns('E', 'Q');
      fakeConsole.ReadLine().Returns("hello, world!");

      var fakeRandomNumberGenerator = Substitute.For<IGenerateRandomNumbers>();

      var app = new AndyRsaConsoleApp(fakeConsole, fakeRandomNumberGenerator);

      app.Run();

      fakeConsole.Received().WriteLine("Please enter the recipient's public key: ");
    }
  }
}
