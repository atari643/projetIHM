using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSim2023
{
    internal class Lien
    {
        public IndexedValueView Source { get; set; }
        public IndexedValueView Destination { get; set; }
        public Color Color { get; set; }
        public double Width { get; set;  }
        public void Dessine(Graphics g)
        {
            g.DrawLine(new Pen(Color, (float) Width*100), new Point((Source.Origine.X + Destination.taille.Width / 2), Source.Origine.Y), new Point((Destination.Origine.X + Destination.taille.Width / 2), (Destination.Origine.Y + Destination.taille.Height / 2)));
        }
    }
}
