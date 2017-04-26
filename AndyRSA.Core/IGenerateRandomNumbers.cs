using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AndyRSA.Core
{
  public interface IGenerateRandomNumbers
  {
    uint Generate();
  }

  public class RandomNumberGenerator : IGenerateRandomNumbers
  {
    private readonly RNGCryptoServiceProvider rngcsp;
    private readonly ICheckForPrimes primeChecker;

    public RandomNumberGenerator(ICheckForPrimes primeChecker)
    {
      this.rngcsp = new RNGCryptoServiceProvider();
      this.primeChecker = primeChecker;
    }

    public uint Generate()
    {
      byte[] bits32 = new byte[4];
      this.rngcsp.GetBytes(bits32);
      var randomNumber = BitConverter.ToUInt32(bits32, 0);

      return this.primeChecker.IsPrime(randomNumber) ? randomNumber : Generate();
    }
  }
}
