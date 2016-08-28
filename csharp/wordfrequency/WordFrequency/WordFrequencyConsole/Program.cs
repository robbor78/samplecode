
using System;
using System.Collections.Generic;
using WordFrequencyLib;
namespace WordFrequencyConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length != 1 || String.IsNullOrEmpty(args[0]))
			{
				Console.WriteLine("Please enter the path and name of the text file to process.");
				Console.WriteLine("Usage: wf <path and name of text file>");
				return;
			}

			string path = args[0];
			try
			{

				WordCount wc = Util.LoadFromFile(path);
				WordOccurences results = wc.MostFrequent(10);

				foreach (OccurenceInfo freq in results)
				{
					Print(freq);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Failed to determine the word occurences. Error message: "+e.Message);
				//Console.WriteLine(e.StackTrace);
			}
			
		}

		/// <summary>
		/// Print out the word occurences.
		/// </summary>
		/// <param name="freq"></param>
		private static void Print(OccurenceInfo freq)
		{
			Console.Write(freq.Occurence+" occurence(s): ");
			string printStr = String.Empty; //used to avoid redundant last comma
			foreach (string word in freq)
			{
				if (!String.IsNullOrEmpty(printStr))
				{
					Console.Write(printStr + ", ");
				}
				printStr = word;
			}
			Console.WriteLine(printStr);
		}
	}
}
