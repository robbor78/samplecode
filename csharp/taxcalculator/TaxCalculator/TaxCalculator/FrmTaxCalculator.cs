using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaxCalculatorApp
{
	public partial class FrmTaxCalculator : Form, IView
	{
		public FrmTaxCalculator()
		{
			InitializeComponent();
		}

		public IViewModel ViewModel { get; set; }

		public string LabelSalaryPerAnnum { set { lblSalaryPerAnnum.Text = value; } }

		public string LabelAge { set { lblAge.Text = value; } }

		public string LabelTaxPerAnnum { set { lblTaxPerAnnum.Text = value; } }

		public string SalaryPerAnnum { get { return txtBoxSalaryPerAnnum.Text; } }

		public string Age { get { return txtBoxAge.Text; } }

		public string TaxPerAnnum { set { txtBoxTaxPerAnnum.Text = value; } }

		public void InvalidSalaryPerAnnum(string message)
		{
			lblErrSalaryPerAnnum.Text = message;
		}

		public void InvalidAge(string message)
		{
			lblErrAge.Text = message;
		}

		public void ClearErrors()
		{
			lblErrAge.Text = String.Empty;
			lblErrSalaryPerAnnum.Text = String.Empty;
		}

		private void txtBoxSalaryPerAnnum_TextChanged(object sender, EventArgs e)
		{
			ViewModel.UpdateValues();
		}

		private void txtBoxAge_TextChanged(object sender, EventArgs e)
		{
			ViewModel.UpdateValues();
		}

	}
}
