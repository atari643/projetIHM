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
    public partial class boiteFin : Form
    {
        public boiteFin(String etat)
        {
            
            InitializeComponent();
            LabelFin.Text = etat;
            MessageBox.Show(LabelFin.Text);
        }
    }
}
