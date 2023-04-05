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
        public void Dessine(Graphics g)
        {
            g.DrawLine(Pens.Black, Source.Origine, new Point((Destination.Origine.X + Destination.taille.Width / 2), (Destination.Origine.Y + Destination.taille.Height / 2)));
        }
    }
}
