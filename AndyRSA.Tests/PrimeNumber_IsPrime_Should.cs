using AndyRSA.Core;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndyRSA.Tests
{
  [TestFixture]
  public class PrimeNumber_IsPrime_Should
  {
    [TestCase(2u)]
    [TestCase(4u)]
    [TestCase(92000u)]
    public void ReturnFalse_WhenNumberIsEven(uint i)
    {
      new PrimeChecker().IsPrime(i).ShouldBe(false);
    }

    [TestCase(9u)]
    [TestCase(15u)]
    [TestCase(39u)]
    [TestCase(121u)]
    public void ReturnFalse_WhenNumberIsOddAndComposite(uint i)
    {
      new PrimeChecker().IsPrime(i).ShouldBe(false);
    }

    [TestCase(104743u)]
    [TestCase(15485867u)]
    public void ReturnTrue_WhenNumberIsPrimeAndLarge(uint i)
    {
      new PrimeChecker().IsPrime(i).ShouldBe(true);
    }

    [TestCase(104745u)]
    [TestCase(15485869u)]
    public void ReturnFalse_WhenNumberIsCompositeAndLarge(uint i)
    {
      new PrimeChecker().IsPrime(i).ShouldBe(false);
    }

    [TestCase(3u)]
    [TestCase(5u)]
    [TestCase(7u)]
    [TestCase(11u)]
    [TestCase(13u)]
    [TestCase(991u)]
    [TestCase(997u)]
    public void ReturnTrue_WhenNumberIsPrime(uint i)
    {
      new PrimeChecker().IsPrime(i).ShouldBe(true);
    }
  }
}
