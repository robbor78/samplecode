using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MersenneLibTest
{
	[TestClass]
	public class MersennePrimesTest
	{
		[TestMethod]
		public void Get()
		{
			List<long> primes = MersenneLib.MersennePrimes.GetPrimes();

			Assert.IsTrue(primes.Count == 8);
			//hard coded list of Mersenne primes.
			long[] expectedMersennePrimes = { 3, 7, 31, 127, 8191, 131071, 524287, 2147483647 };

			for (int i = 0; i < expectedMersennePrimes.Length; i++)
			{
				long actual = primes[i];
				long expected = expectedMersennePrimes[i];
				Assert.AreEqual(expected, actual,"Incorrect Mersenne prime. Expected: "+expected+" Actual: "+actual);
			}

		}
	}
}
