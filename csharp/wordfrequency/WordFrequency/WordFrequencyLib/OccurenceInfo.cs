using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFrequencyLib
{
	/// <summary>
	/// Helper class that stores an occurence and the words with that occurence.
	/// </summary>
	public class OccurenceInfo : IEnumerable<string>
	{
		public OccurenceInfo(int frequency)
		{
			Words = new SortedSet<string>();
			Occurence = frequency;
		}

		public SortedSet<string> Words { get; private set; }
		
		public int Occurence { get; private set; }

		public void Add(string word)
		{
			Words.Add(word);
		}

		public IEnumerator<string> GetEnumerator()
		{
			return Words.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}
