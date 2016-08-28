using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersenneLib
{
	/// <summary>
	/// This class provides a function to calculate the Mersenne primes.
	/// 
	/// Due to overflow issues only the first 8 Mersenne primes can be calculated.
	/// </summary>
	public static class MersennePrimes
	{
		/// <summary>
		/// Return all Mersenne primes that this program can calculate.
		/// </summary>
		/// <returns></returns>
		public static List<long> GetPrimes()
		{
			List<long> mersennePrimes = new List<long>();
			mersennePrimes.Add(Calculate(2));
			for (int candidate = 3; candidate <= maxCandidates; candidate++)
			{
				if (LucasLehmerTest(candidate))
				{
					mersennePrimes.Add(Calculate(candidate));
				}
			}
			return mersennePrimes;
		}

		/// <summary>
		/// Calculate the Mersenne prime for a given prime p.
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		private static long Calculate(long p)
		{
			return (long)Math.Pow(2, p) - 1;
		}

		/// <summary>
		/// Determine if a number p is a Mersenne prime.
		/// 
		/// Source: http://en.wikipedia.org/wiki/Lucas%E2%80%93Lehmer_primality_test
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		private static bool LucasLehmerTest(long p)
		{
			long s = 4;
			long M = Calculate(p); ;
			//repeat p − 2 times:
			for (int i = 0; i < (p - 2); i++)
			{
				// s = ((s × s) − 2) mod M
				s = ((s * s) - 2) % M;
			}
			//if s = 0 return PRIME else return COMPOSITE
			return s == 0;
		}

		/// <summary>
		/// Maximum number of possible prime numbers to consider.
		/// </summary>
		private const int maxCandidates = 32;
	}
}
