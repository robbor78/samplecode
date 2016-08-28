using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordFrequencyLib;
using System.Collections.Generic;

namespace WordFrequencyLibTest
{
	[TestClass]
	public class UtilTest
	{
		[TestMethod]
		[DeploymentItem("war_and_peace.txt")]
		public void LoadFromFile()
		{
			WordCount wc = Util.LoadFromFile(@"war_and_peace.txt");
			WordOccurences result = wc.MostFrequent(10);
			Assert.AreEqual(result.Count, 10);
		}
	}
}
