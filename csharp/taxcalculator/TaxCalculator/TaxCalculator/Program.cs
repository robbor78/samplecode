using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaxCalculatorApp;
using TaxLib;
using TaxLib.ZA;

namespace TaxCalculatorApp
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{


			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			FrmTaxCalculator frm = InitForm();

			Application.Run(frm);
		}

		private static FrmTaxCalculator InitForm()
		{
			ITaxCalculator tc = InitTaxCalculator();

			IViewModel viewModel = new ViewModel();

			FrmTaxCalculator frmTaxCalculator = new FrmTaxCalculator();
			frmTaxCalculator.ViewModel = viewModel;

			viewModel.View = frmTaxCalculator;
			viewModel.TaxCalculator = tc;
			viewModel.ResourceManager = LocalResourceManager.GetManager();
			viewModel.UpdateLabels();

			return frmTaxCalculator;
		}

		private static ITaxCalculator InitTaxCalculator()
		{
			ITaxTable taxTable = new TaxTable();
			IBenefits benefits = new Benefits();
			TaxCalculator tc = new TaxCalculator(taxTable, benefits);
			return tc;
		}
	}
}
