using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxLib.ZA
{
	public class TaxRange
	{
		public TaxRange(decimal start, decimal end, decimal rate)
		{
			Start = start;
			End = end;
			Rate = rate;
		}

		public decimal Start { get; private set; }
		public decimal End { get; private set; }
		public decimal Rate { get; private set; }
	}
}
