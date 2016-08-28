using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculatorApp
{
	public class LocalResourceManager : IResourceManager
	{
		private LocalResourceManager()
		{
			locRM = new ResourceManager("TaxCalculatorApp.WinFormStrings", typeof(FrmTaxCalculator).Assembly);
		}

		public static LocalResourceManager GetManager()
		{
			if (manager == null)
			{
				manager = new LocalResourceManager();
			}
			return manager;
		}

		public string GetString(string name)
		{
			return locRM.GetString(name);
		}

		private static LocalResourceManager manager = null;
		private ResourceManager locRM = null;
	}
}
