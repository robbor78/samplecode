using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordFrequencyLib;
using System.Collections.Generic;

namespace WordFrequencyLibTest
{
	[TestClass]
	public class WordCountTest
	{
		[TestMethod]
		public void NoWords()
		{
			WordCount wc = new WordCount();
			WordOccurences results = wc.MostFrequent(10);
			Assert.IsTrue(results.Count == 0);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void ZeroWordFrequency()
		{
			WordCount wc = new WordCount();
			WordOccurences results = wc.MostFrequent(0);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void NegativeWordFrequency()
		{
			WordCount wc = new WordCount();
			WordOccurences results = wc.MostFrequent(-1);
		}

		[TestMethod]
		public void ValidTest1()
		{
			TestData td1 = new TestData()
			{
				words = new[] { "A" },
				frequency = 6
			};

			TestData td2 = new TestData()
			{
				words = new[] { "B" },
				frequency = 3
			};

			TestData td3 = new TestData()
			{
				words = new[] { "D" },
				frequency = 2
			};

			TestData td4 = new TestData()
			{
				words = new[] { "C" },
				frequency = 1
			};


			TestData[] testSet = new[] { td1, td2, td3, td4 };
			RunTest(testSet, 2, 2);
		}

		[TestMethod]
		public void ValidTest2()
		{
			TestData td1 = new TestData()
			{
				words = new[] { "A", "B" },
				frequency = 6
			};

			TestData td2 = new TestData()
			{
				words = new[] { "D" },
				frequency = 2
			};

			TestData td3 = new TestData()
			{
				words = new[] { "C" },
				frequency = 1
			};

			TestData[] testSet = new[] { td1, td2, td3 };
			RunTest(testSet, 2, 2);
		}

		/// <summary>
		/// There are 4 distinct words but ask the program to give the 5 most reoccuring words.
		/// </summary>
		[TestMethod]
		public void ValidTest3_nTooHigh()
		{
			TestData td1 = new TestData()
			{
				words = new[] { "A" },
				frequency = 6
			};

			TestData td2 = new TestData()
			{
				words = new[] { "B" },
				frequency = 3
			};

			TestData td3 = new TestData()
			{
				words = new[] { "D" },
				frequency = 2
			};

			TestData td4 = new TestData()
			{
				words = new[] { "C" },
				frequency = 1
			};


			TestData[] testSet = new[] { td1, td2, td3, td4 };
			RunTest(testSet, 5, 4);
		}

		/// <summary>
		/// Add the test data to the WordCount object.
		/// </summary>
		/// <param name="wc"></param>
		/// <param name="testSet"></param>
		private void AddTestData(WordCount wc, TestData[] testSet)
		{
			for (int i = 0; i < testSet.Length; i++)
			{
				TestData testData = testSet[i];
				for (int k = 0; k < testData.words.Length; k++)
				{
					AddWord(wc, testData.words[k], testData.frequency);
				}
			}
		}

		/// <summary>
		/// Add a single world X times to the WordCount object.
		/// </summary>
		/// <param name="wc"></param>
		/// <param name="word"></param>
		/// <param name="repeat"></param>
		private void AddWord(WordCount wc, string word, int repeat)
		{
			for (int i = 0; i < repeat; i++)
			{
				wc.Add(word);
			}
		}

		/// <summary>
		/// Run the test and compare the output with the test data set.
		/// </summary>
		/// <param name="testSet"></param>
		/// <param name="nRequest">n most frequently occuring words</param>
		/// <param name="nExpected">the expected number of frequently occuring words, i.e. when nRequest is greater than the number of words</param>
		private void RunTest(TestData[] testSet, int nRequest, int nExpected)
		{
			WordCount wc = new WordCount();
			AddTestData(wc, testSet);
			WordOccurences results = wc.MostFrequent(nRequest);
			TestResult(results, nExpected, testSet);
		}

		/// <summary>
		/// Compare results with the original test set.
		/// </summary>
		/// <param name="results"></param>
		/// <param name="nMostFrequent"></param>
		/// <param name="testSet"></param>
		private void TestResult(WordOccurences results, int nMostFrequent, TestData[] testSet)
		{
			Assert.AreEqual(results.Count, nMostFrequent, "Incorrect number of results.");

			int i = 0;
			foreach (OccurenceInfo oi in results)
			{
				TestResult(oi, testSet[i++]);
			}

		}

		/// <summary>
		/// Compare a single frequencyInfo object to the original test data.
		/// </summary>
		/// <param name="frequencyInfo"></param>
		/// <param name="testData"></param>
		private void TestResult(OccurenceInfo frequencyInfo, TestData testData)
		{
			Assert.AreEqual(frequencyInfo.Words.Count, testData.words.Length);

			for (int i = 0; i < testData.words.Length; i++)
			{
				Assert.IsTrue(frequencyInfo.Words.Contains(testData.words[i]));
			}
		}

		/// <summary>
		/// Helper structure for sample test data.
		/// </summary>
		struct TestData
		{
			/// <summary>
			/// All words with this frequency.
			/// </summary>
			public string[] words;

			/// <summary>
			/// Frequency for the words.
			/// </summary>
			public int frequency;
		}
	}
}
