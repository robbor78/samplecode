using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFrequencyLib
{
	/// <summary>
	/// Provides a function to calculate the occurences of words.
	/// </summary>
	public class WordCount
	{
		public WordCount()
		{
			wordCount = new Dictionary<string, int>();
			maxWordCount = 0;
		}

		/// <summary>
		/// Add a word.
		/// </summary>
		/// <param name="word"></param>
		public void Add(string word)
		{
			if (String.IsNullOrEmpty(word)) return;

			string upper = word.ToUpper();
			if (!wordCount.ContainsKey(upper))
			{
				wordCount.Add(upper, 0);
			}
			wordCount[upper]++;

			int latestCount = wordCount[upper];
			if (latestCount > maxWordCount)
			{
				maxWordCount = latestCount;
			}
		}

		/// <summary>
		/// Determines the top n most frequently occurring words.
		/// Source: idea of the algorithm from stack overflow.
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		public WordOccurences MostFrequent(int n)
		{
			if (n <= 0) throw new ArgumentException("n must be greater zero.");

			if (wordCount.Count() == 0 || maxWordCount == 0) return new WordOccurences();

			if (n > wordCount.Keys.Count())
			{
				n = wordCount.Keys.Count();
			}

			OccurenceInfo[] frequencyArray = BuildFrequencyArray();

			WordOccurences filteredResult = GetTopNWords(frequencyArray, n);

			return filteredResult;

		}

		/// <summary>
		/// Use the word frequency as an index into an array where each entry in the 
		/// array contains the word(s) with that frequency.
		/// </summary>
		/// <returns></returns>
		private OccurenceInfo[] BuildFrequencyArray()
		{
			OccurenceInfo[] result = new OccurenceInfo[maxWordCount + 1];
			foreach (string word in wordCount.Keys)
			{
				int frequency = wordCount[word];
				if (result[frequency] == null)
				{
					result[frequency] = new OccurenceInfo(frequency);
				}
				result[frequency].Add(word);
			}
			return result;
		}

		/// <summary>
		/// Traverse frequency array from the back to get n most frequency words.
		/// </summary>
		/// <param name="frequencyArray"></param>
		/// <param name="n"></param>
		/// <returns></returns>
		private WordOccurences GetTopNWords(OccurenceInfo[] frequencyArray, int n)
		{
			WordOccurences result = new WordOccurences();

			//have to filter out null array entries
			int len = frequencyArray.Length;
			int index = 0;
			int count = 0;
			while (count < n)
			{
				OccurenceInfo fi = frequencyArray[len - index - 1]; //start at the back of the array
				if (fi != null)
				{
					result.Add(fi);
					count++;
				}
				index++;
			}

			return result;
		}

		/// <summary>
		/// Dictionary of word to occurences of that word.
		/// </summary>
		private Dictionary<string, int> wordCount;

		/// <summary>
		/// Running count of the highest count for a distince word.
		/// </summary>
		private int maxWordCount;
	}
}
