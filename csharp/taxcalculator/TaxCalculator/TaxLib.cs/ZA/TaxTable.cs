using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxLib.ZA
{
	public class TaxTable : ITaxTable
	{
		public TaxTable()
		{
			Data = new List<TaxRange>() {
																					 new TaxRange(start:5000,end:10000,rate:5),
																					 new TaxRange(start:10001,end:20000,rate:(decimal)(7.5)),
																					 new TaxRange(start:20001,end:35000,rate:9),
																					 new TaxRange(start:35001,end:50000,rate:15),
																					 new TaxRange(start:50001,end:70000,rate:25),
																					 new TaxRange(start:70001,end:decimal.MaxValue,rate:30)
																				 };
		}
		public List<TaxRange> Data { get; private set; }
	}
}
