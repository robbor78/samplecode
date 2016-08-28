using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxLib;

namespace TaxCalculatorApp
{
	public class ViewModel : IViewModel
	{
		public ViewModel()
		{
		}

		public IView View { get; set; }
		public IResourceManager ResourceManager { get; set; }
		public ITaxCalculator TaxCalculator { get; set; }

		public void UpdateLabels()
		{
			View.ClearErrors();
			View.LabelSalaryPerAnnum = ResourceManager.GetString("LblSalaryPerAnnum");
			View.LabelAge = ResourceManager.GetString("LblAge");
			View.LabelTaxPerAnnum = ResourceManager.GetString("LblTaxPerAnnum");
		}

		public void UpdateValues()
		{
			View.ClearErrors();

			string strSalaryPerAnnum = View.SalaryPerAnnum;

			decimal salaryPerAnnum;
			bool isValidSalary = decimal.TryParse(strSalaryPerAnnum, out salaryPerAnnum) && salaryPerAnnum >= 0;
			if (!isValidSalary)
			{
				View.InvalidSalaryPerAnnum(ResourceManager.GetString("LblErrSalaryPerAnnum"));
			}

			string strAge = View.Age;
			int age;
			bool isValidAge = int.TryParse(strAge, out age) && age > 0;
			if (!isValidAge)
			{
				View.InvalidAge(ResourceManager.GetString("LblErrAge"));
			}

			if (!isValidSalary || !isValidAge)
			{
				return;
			}

			View.ClearErrors();

			decimal taxPerAnnum = TaxCalculator.TaxPerAnnum(salaryPerAnnum, age);

			View.TaxPerAnnum = String.Format(ResourceManager.GetString("FrmtTaxPerAnnum"), taxPerAnnum);
		}

		private bool TryParseSalaryPerAnnum(string strSalaryPerAnnum, out decimal salaryPerAnnum)
		{
			bool isValid = decimal.TryParse(strSalaryPerAnnum, out salaryPerAnnum);
			return isValid;
		}


	}
}
