Mersenne Primes(console application):

........



Structure of the Solution
The solution consists of 3 assemblies. 
1. MersenneLib assembly contains the logic. This assembly has a single static class MersennePrimes which calculates the primes.
2. A unit test assembly. MersenneLibTest.
3. A console application which prints out the first 8 Mersenne primes.

The focus of this solution was on implementing the algorithm.

Source of the algorithm: http://en.wikipedia.org/wiki/Mersenne_prime

The algorithm is limited because of overflow issues. The size of the Mersenne primes grows quickly, e.g. the 9th Mersenne prime has 19 digits. In C# a varialbe of  type long is up to 19 digits long.
