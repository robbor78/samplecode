using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxLib.ZA;

namespace TaxLibTests.ZA
{
	[TestClass]
	public class TaxCalculatorTests
	{
		[TestMethod]
		public void PoorPerson_NoTax()
		{
			decimal annualSalary = 3000 * 12;
			int age = 35;
			decimal expectedTaxPerAnnum = 0;
			RunTest(annualSalary, age, expectedTaxPerAnnum);
		}

		[TestMethod]
		public void Student()
		{
			decimal annualSalary = 8000 * 12;
			int age = 35;
			decimal expectedTaxPerAnnum = 50 * 12;
			RunTest(annualSalary, age, expectedTaxPerAnnum);
		}

		[TestMethod]
		public void Junior()
		{
			decimal annualSalary = 15000 * 12;
			int age = 35;
			decimal expectedTaxPerAnnum = (250 + (decimal)224.925) * 12;
			RunTest(annualSalary, age, expectedTaxPerAnnum);
		}

		[TestMethod]
		public void Bachelor()
		{
			decimal annualSalary = 25000 * 12;
			int age = 35;
			decimal expectedTaxPerAnnum = (250 + (decimal)749.925 + (decimal)269.91) * 12;
			RunTest(annualSalary, age, expectedTaxPerAnnum);
		}

		[TestMethod]
		public void Intermediate()
		{
			decimal annualSalary = 40000 * 12;
			int age = 35;
			decimal expectedTaxPerAnnum = (250 + (decimal)749.925 + (decimal)1349.91 + (decimal)449.85) * 12;
			RunTest(annualSalary, age, expectedTaxPerAnnum);
		}

		[TestMethod]
		public void Senior()
		{
			decimal annualSalary = 55000 * 12;
			int age = 35;
			decimal expectedTaxPerAnnum = (250 + (decimal)749.925 + (decimal)1349.91 + (decimal)2249.85 + (decimal)749.75) * 12;
			RunTest(annualSalary, age, expectedTaxPerAnnum);
		}

		[TestMethod]
		public void Rich()
		{
			decimal annualSalary = 75000 * 12;
			int age = 35;
			decimal expectedTaxPerAnnum = (250 + (decimal)749.925 + (decimal)1349.91 + (decimal)2249.85 + (decimal)4999.75 + (decimal)899.70) * 12;
			RunTest(annualSalary, age, expectedTaxPerAnnum);
		}

		[TestMethod]
		public void Pensioner()
		{
			decimal annualSalary = 41000 * 12;
			int age = 56;
			decimal expectedTaxPerAnnum = (250 + (decimal)749.925 + (decimal)1349.91 + (decimal)149.85) * 12 * (decimal)0.85;
			RunTest(annualSalary, age, expectedTaxPerAnnum);
		}
		private void RunTest(decimal annualSalary, int age, decimal expectedTaxPerAnnum)
		{
			TaxCalculator tc = GetCalculator();
			decimal actualTaxPerAnnum = tc.TaxPerAnnum(annualSalary, age);
			Assert.AreEqual(expectedTaxPerAnnum, actualTaxPerAnnum);
		}

		private TaxCalculator GetCalculator()
		{
			ITaxTable taxTable = new TaxTable();
			IBenefits benefits = new Benefits();
			TaxCalculator tc = new TaxCalculator(taxTable, benefits);
			return tc;
		}
	}
}
