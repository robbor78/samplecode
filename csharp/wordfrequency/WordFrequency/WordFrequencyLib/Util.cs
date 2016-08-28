using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFrequencyLib
{
	/// <summary>
	/// Helper class.
	/// </summary>
	public static class Util
	{
		/// <summary>
		/// Build a WordCount object from a text file.
		/// Source: http://stackoverflow.com/questions/2161895/reading-large-text-files-with-streams-in-c-sharp
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static WordCount LoadFromFile(string path)
		{
			WordCount wc = new WordCount();

			using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
			using (BufferedStream bs = new BufferedStream(fs))
			using (StreamReader sr = new StreamReader(bs))
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					string[] words = line.Split(new[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);

					words.ToList().ForEach(x => wc.Add(x));
				}
			}

			return wc;
		}

	}
}
