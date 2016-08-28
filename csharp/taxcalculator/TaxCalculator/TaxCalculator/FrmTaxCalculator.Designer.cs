namespace TaxCalculatorApp
{
	partial class FrmTaxCalculator
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblSalaryPerAnnum = new System.Windows.Forms.Label();
			this.lblAge = new System.Windows.Forms.Label();
			this.lblTaxPerAnnum = new System.Windows.Forms.Label();
			this.txtBoxSalaryPerAnnum = new System.Windows.Forms.TextBox();
			this.txtBoxAge = new System.Windows.Forms.TextBox();
			this.txtBoxTaxPerAnnum = new System.Windows.Forms.TextBox();
			this.lblErrSalaryPerAnnum = new System.Windows.Forms.Label();
			this.lblErrAge = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblSalaryPerAnnum
			// 
			this.lblSalaryPerAnnum.AutoSize = true;
			this.lblSalaryPerAnnum.Location = new System.Drawing.Point(28, 23);
			this.lblSalaryPerAnnum.Name = "lblSalaryPerAnnum";
			this.lblSalaryPerAnnum.Size = new System.Drawing.Size(90, 13);
			this.lblSalaryPerAnnum.TabIndex = 0;
			this.lblSalaryPerAnnum.Text = "Salary per Annum";
			// 
			// lblAge
			// 
			this.lblAge.AutoSize = true;
			this.lblAge.Location = new System.Drawing.Point(28, 49);
			this.lblAge.Name = "lblAge";
			this.lblAge.Size = new System.Drawing.Size(26, 13);
			this.lblAge.TabIndex = 1;
			this.lblAge.Text = "Age";
			// 
			// lblTaxPerAnnum
			// 
			this.lblTaxPerAnnum.AutoSize = true;
			this.lblTaxPerAnnum.Location = new System.Drawing.Point(28, 75);
			this.lblTaxPerAnnum.Name = "lblTaxPerAnnum";
			this.lblTaxPerAnnum.Size = new System.Drawing.Size(79, 13);
			this.lblTaxPerAnnum.TabIndex = 2;
			this.lblTaxPerAnnum.Text = "Tax per Annum";
			// 
			// txtBoxSalaryPerAnnum
			// 
			this.txtBoxSalaryPerAnnum.Location = new System.Drawing.Point(122, 20);
			this.txtBoxSalaryPerAnnum.Name = "txtBoxSalaryPerAnnum";
			this.txtBoxSalaryPerAnnum.Size = new System.Drawing.Size(100, 20);
			this.txtBoxSalaryPerAnnum.TabIndex = 3;
			this.txtBoxSalaryPerAnnum.TextChanged += new System.EventHandler(this.txtBoxSalaryPerAnnum_TextChanged);
			// 
			// txtBoxAge
			// 
			this.txtBoxAge.Location = new System.Drawing.Point(122, 46);
			this.txtBoxAge.Name = "txtBoxAge";
			this.txtBoxAge.Size = new System.Drawing.Size(100, 20);
			this.txtBoxAge.TabIndex = 4;
			this.txtBoxAge.TextChanged += new System.EventHandler(this.txtBoxAge_TextChanged);
			// 
			// txtBoxTaxPerAnnum
			// 
			this.txtBoxTaxPerAnnum.Location = new System.Drawing.Point(122, 72);
			this.txtBoxTaxPerAnnum.Name = "txtBoxTaxPerAnnum";
			this.txtBoxTaxPerAnnum.ReadOnly = true;
			this.txtBoxTaxPerAnnum.Size = new System.Drawing.Size(100, 20);
			this.txtBoxTaxPerAnnum.TabIndex = 5;
			// 
			// lblErrSalaryPerAnnum
			// 
			this.lblErrSalaryPerAnnum.AutoSize = true;
			this.lblErrSalaryPerAnnum.Location = new System.Drawing.Point(229, 23);
			this.lblErrSalaryPerAnnum.Name = "lblErrSalaryPerAnnum";
			this.lblErrSalaryPerAnnum.Size = new System.Drawing.Size(35, 13);
			this.lblErrSalaryPerAnnum.TabIndex = 6;
			this.lblErrSalaryPerAnnum.Text = "label1";
			// 
			// lblErrAge
			// 
			this.lblErrAge.AutoSize = true;
			this.lblErrAge.Location = new System.Drawing.Point(229, 49);
			this.lblErrAge.Name = "lblErrAge";
			this.lblErrAge.Size = new System.Drawing.Size(35, 13);
			this.lblErrAge.TabIndex = 7;
			this.lblErrAge.Text = "label1";
			// 
			// FrmTaxCalculator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(468, 112);
			this.Controls.Add(this.lblErrAge);
			this.Controls.Add(this.lblErrSalaryPerAnnum);
			this.Controls.Add(this.txtBoxTaxPerAnnum);
			this.Controls.Add(this.txtBoxAge);
			this.Controls.Add(this.txtBoxSalaryPerAnnum);
			this.Controls.Add(this.lblTaxPerAnnum);
			this.Controls.Add(this.lblAge);
			this.Controls.Add(this.lblSalaryPerAnnum);
			this.Name = "FrmTaxCalculator";
			this.Text = "Tax Calculator";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblSalaryPerAnnum;
		private System.Windows.Forms.Label lblAge;
		private System.Windows.Forms.Label lblTaxPerAnnum;
		private System.Windows.Forms.TextBox txtBoxSalaryPerAnnum;
		private System.Windows.Forms.TextBox txtBoxAge;
		private System.Windows.Forms.TextBox txtBoxTaxPerAnnum;
		private System.Windows.Forms.Label lblErrSalaryPerAnnum;
		private System.Windows.Forms.Label lblErrAge;
	}
}

