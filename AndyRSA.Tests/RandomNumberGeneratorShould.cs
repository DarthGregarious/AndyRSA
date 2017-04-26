using AndyRSA.Core;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndyRSA.Tests
{
  [TestFixture]
  public class RandomNumberGeneratorShould
  {
    [Test]
    public void ShouldCheckPrimacyOfGeneratedNumber()
    {
      var primeChecker = Substitute.For<ICheckForPrimes>();
      primeChecker.IsPrime(Arg.Any<uint>()).Returns(true);

      var rng = new RandomNumberGenerator(primeChecker);
      rng.Generate();

      primeChecker.Received(1).IsPrime(Arg.Any<uint>());
    }

    [Test]
    public void ShouldCheckPrimacyOfGeneratedNumberAgain_WhenFirstAttemptIsNotPrime()
    {
      var primeChecker = Substitute.For<ICheckForPrimes>();
      primeChecker.IsPrime(Arg.Any<uint>()).Returns(false, true);

      var rng = new RandomNumberGenerator(primeChecker);
      rng.Generate();

      primeChecker.Received(2).IsPrime(Arg.Any<uint>());
    }
  }
}
