using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MersennePrimesApp
{
	class Program
	{
		static void Main(string[] args)
		{
			List<long> primes = MersenneLib.MersennePrimes.GetPrimes();

			primes.ForEach(x => Console.WriteLine(x));
		}
	}
}
