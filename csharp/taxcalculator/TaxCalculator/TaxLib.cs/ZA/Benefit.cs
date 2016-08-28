using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxLib.ZA
{
	public class Benefit
	{
		public Benefit(int ageMin, int ageMax, decimal relief, decimal deduction)
		{
			AgeMin = ageMin;
			AgeMax = ageMax;
			Relief = relief;
			Deduction = deduction;
		}

		public int AgeMin { get; private set; }
		public int AgeMax { get; private set; }
		public decimal Relief { get; private set; }
		public decimal Deduction { get; private set; }
	}
}
