using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxLib;

namespace TaxCalculatorApp
{
	public interface IViewModel
	{
		IView View { get; set; }
		IResourceManager ResourceManager { get; set; }
		ITaxCalculator TaxCalculator { get; set; }

		void UpdateValues();

		void UpdateLabels();

	}
}
