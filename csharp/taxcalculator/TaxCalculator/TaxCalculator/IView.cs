using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculatorApp
{
	public interface IView
	{
		IViewModel ViewModel { get; set; }

		string SalaryPerAnnum { get; }

		string Age { get; }

		string TaxPerAnnum { set; }

		string LabelSalaryPerAnnum { set; }

		string LabelAge { set; }

		string LabelTaxPerAnnum { set; }

		void InvalidSalaryPerAnnum(string message);

		void InvalidAge(string message);

		void ClearErrors();
	}
}
