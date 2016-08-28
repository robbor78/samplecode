using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxLib.ZA
{
	public interface ITaxTable
	{
		List<TaxRange> Data { get; }
	}
}
