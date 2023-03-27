using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseSim2023
{
    public partial class policyChange : Form
    {
        public int numVal() => (int) numericUpDown1.Value;
        public policyChange(string name, int min, int max, int val)
        {
            InitializeComponent();
            this.Text = "Modifier politique";
            labelPolChange.Text = name;
            numericUpDown1.Minimum = min;
            numericUpDown1.Maximum = max;
            numericUpDown1.Value = val;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
