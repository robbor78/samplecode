using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxLib.ZA
{
	public class Benefits : IBenefits
	{
		public Benefits()
		{
			Data = new List<Benefit>() {new Benefit(ageMin:18, ageMax:50, relief:2000,deduction:100),
																								new Benefit(ageMin:51, ageMax:200, relief:5000,deduction:85)};
		}

		public List<Benefit> Data { get; private set; }



	}
}
