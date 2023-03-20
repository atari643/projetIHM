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

        public Point Origine { get; set; } = new Point(0, 0);

        public Size taille { get; set;}

        public Color couleur;

        public int Epaiseur;


        public void Dessine(Graphics g)
        {
            Point PositionEcran = Origine;
            Rectangle r = new Rectangle(PositionEcran, taille);
            Pen p = new Pen(couleur, Epaiseur);
            g.DrawRectangle(p, r);
        }
    }
    
    
}
