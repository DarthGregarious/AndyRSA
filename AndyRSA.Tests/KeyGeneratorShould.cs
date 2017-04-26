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
  public class KeyGeneratorShould
  {
    public void AcceptTwoPrimeNumbers()
    {
      var primeChecker = Substitute.For<ICheckForPrimes>();
      var p = PrimeNumber.CheckPrimacyAndBuild(primeChecker, 7);
      var q = PrimeNumber.CheckPrimacyAndBuild(primeChecker, 11);
      var key = new KeyGenerator().Generate(p, q);

      throw new NotImplementedException();
    }
  }
}
