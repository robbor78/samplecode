using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxLib.ZA
{
	public class TaxCalculator : ITaxCalculator
	{
		public TaxCalculator(ITaxTable taxTable, IBenefits benefits)
		{
			this.taxTable = taxTable;
			this.benefits = benefits;
		}

		public decimal TaxPerAnnum(decimal salaryPerAnnum, int age)
		{
			decimal salaryPerMonth = salaryPerAnnum / 12;

			Benefit benefit = GetBenefit(age);

			if (benefit != null)
			{
				salaryPerMonth = salaryPerMonth - benefit.Relief;
			}

			decimal taxDeduction = 0;

			taxTable.Data.ForEach(x =>
			{
				CalculateTaxForRange(x, salaryPerMonth, ref taxDeduction);
			});

			if (benefit != null)
			{
				taxDeduction *= benefit.Deduction / 100;
			}

			return taxDeduction * 12;

		}

		private Benefit GetBenefit(int age)
		{
			return benefits.Data.FirstOrDefault(x => age >= x.AgeMin && age <= x.AgeMax);
		}

		private void CalculateTaxForRange(TaxRange taxRange, decimal salaryPerMonth, ref decimal taxDeduction)
		{
			if (salaryPerMonth >= taxRange.Start && salaryPerMonth <= taxRange.End)
			{
				taxDeduction += (salaryPerMonth - taxRange.Start) * taxRange.Rate / 100;
			}
			else if (salaryPerMonth > taxRange.End)
			{
				taxDeduction += (taxRange.End - taxRange.Start) * taxRange.Rate / 100;
			}
		}

		private ITaxTable taxTable;

		private IBenefits benefits;

	}
}
