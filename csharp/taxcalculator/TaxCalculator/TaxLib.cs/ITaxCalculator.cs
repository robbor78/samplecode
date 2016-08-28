using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxLib
{
	public interface ITaxCalculator
	{
		decimal TaxPerAnnum(decimal salaryPerAnnum, int age);
	}
}
