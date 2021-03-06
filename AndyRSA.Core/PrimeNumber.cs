﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;

namespace AndyRSA.Core
{
  public interface ICheckForPrimes
  {
    bool IsPrime(BigInteger i);
  }

  public class PrimeChecker : ICheckForPrimes
  {
    public bool IsPrime(BigInteger i)
    {
      if (!IsOdd(i))
        return false;

      return IsInLowPrimeRange(i) ? IsLowPrime(i) : IsPredictedToBePrimeByRabinMillerTest(i);
    }

    protected static bool IsOdd(uint i)
    {
      return (1 & i) != 0;
    }

    protected static bool IsOdd(BigInteger i)
    {
      return (1 & i) != 0;
    }

    private static bool IsInLowPrimeRange(BigInteger i)
    {
      return i <= 1000;
    }

    private static bool IsPredictedToBePrimeByRabinMillerTest(BigInteger numToCheck)
    {
      var s = numToCheck - 1;
      var halfCount = 0;

      while (!IsOdd(s))
      {
        s = s / 2;
        halfCount = halfCount + 1;
      }

      var k = 0;

      while (k < 128)
      {
        var a = numToCheck;

        while(a >= numToCheck || a < 2) // is there a better way to implement a random range with big integers?
        {
          var aBytes = a.ToByteArray();
          new RNGCryptoServiceProvider().GetBytes(aBytes);
          a = new BigInteger(aBytes);
        }

        var v = BigInteger.ModPow(a, s, numToCheck);

        if (v != 1)
        {
          var i = 0;
          while (v != numToCheck - 1)
          {
            if (i == halfCount - 1)
              return false;
            else
            {
              i = i + 1;
              v = (v ^ 2) % numToCheck;
            }
          }
        }

        k += 2;
      }
      return true;
    }

    private static bool IsLowPrime(BigInteger i)
    {
      var lowPrimes = new BigInteger[] { 3u, 5u, 7u, 11u, 13u, 17u, 19u, 23u, 29u, 31u, 37u, 41u, 43u, 47u, 53u, 59u, 61u, 67u, 71u, 73u, 79u, 83u, 89u, 97u, 101u, 103u, 107u, 109u, 113u, 127u, 131u, 137u, 139u, 149u, 151u, 157u, 163u, 167u, 173u, 179u, 181u, 191u, 193u, 197u, 199u, 211u, 223u, 227u, 229u, 233u, 239u, 241u, 251u, 257u, 263u, 269u, 271u, 277u, 281u, 283u, 293u, 307u, 311u, 313u, 317u, 331u, 337u, 347u, 349u, 353u, 359u, 367u, 373u, 379u, 383u, 389u, 397u, 401u, 409u, 419u, 421u, 431u, 433u, 439u, 443u, 449u, 457u, 461u, 463u, 467u, 479u, 487u, 491u, 499u, 503u, 509u, 521u, 523u, 541u, 547u, 557u, 563u, 569u, 571u, 577u, 587u, 593u, 599u, 601u, 607u, 613u, 617u, 619u, 631u, 641u, 643u, 647u, 653u, 659u, 661u, 673u, 677u, 683u, 691u, 701u, 709u, 719u, 727u, 733u, 739u, 743u, 751u, 757u, 761u, 769u, 773u, 787u, 797u, 809u, 811u, 821u, 823u, 827u, 829u, 839u, 853u, 857u, 859u, 863u, 877u, 881u, 883u, 887u, 907u, 911u, 919u, 929u, 937u, 941u, 947u, 953u, 967u, 971u, 977u, 983u, 991u, 997 };
      return lowPrimes.Contains(i);
    }
  }

  public class PrimeNumber
  {
    private readonly BigInteger number;

    protected PrimeNumber(BigInteger i) { this.number = i; }

    public static PrimeNumber CheckPrimacyAndBuild(ICheckForPrimes primeChecker, BigInteger i)
    {
      if (!primeChecker.IsPrime(i))
        throw new ArgumentException("The integer provided is not valid");

      return new PrimeNumber(i);
    }
  }
}
