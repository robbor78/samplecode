using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFrequencyLib
{
	/// <summary>
	/// Container for the occurences of a list of words.
	/// </summary>
	public class WordOccurences : IEnumerable<OccurenceInfo>
	{
		public WordOccurences()
		{
			occurences = new List<OccurenceInfo>();
		}

		public int Count { get { return occurences.Count; } }

		public void Add(OccurenceInfo fi)
		{
			occurences.Add(fi);
		}

		public IEnumerator<OccurenceInfo> GetEnumerator()
		{
			occurences.Sort((x, y) => { return y.Occurence - x.Occurence; }); //sort in descending order
			return occurences.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		private List<OccurenceInfo> occurences;

	}
}
