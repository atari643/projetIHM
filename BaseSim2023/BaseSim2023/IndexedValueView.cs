using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseSim2023
{
    class IndexedValueView
    {
        public IndexedValue valeur;

        public Point Origine { get; set; }

        public Size taille { get; set;}

        public Color couleur { get; set; }

        public int Epaisseur { get; set; }

        public void Dessine(Graphics g)
        {
            Point PositionEcran = Origine;
            Rectangle r = new Rectangle(PositionEcran, new Size(100,50));
            Pen p = new Pen(couleur = Color.Black, Epaisseur = 2);
            g.DrawRectangle(p, r);
            g.DrawString("" + valeur, new Font("Arial", 10, FontStyle.Bold), Brushes.Fuchsia, Origine);
        }
    }
    
    
}
