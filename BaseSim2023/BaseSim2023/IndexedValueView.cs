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

        private WorldState theWorld;

        public Point Origine { get; set; }

        public Size taille { get; set; } = new Size(165, 50);

        public Color couleur { get; set; }

        public int opacite { get; set; }

        public int Epaisseur { get; set; }

        public bool Contient(Point p)
        {
            Rectangle r = new Rectangle(Origine, taille);
            return r.Contains(p);
        }

        public void Dessine(Graphics g, WorldState world)
        {
            theWorld = world;
            if (valeur.Active == false && valeur.AvailableAt <= theWorld.Turns)
            {
                couleur = Color.FromArgb(opacite, 255, 255, 0);
            }
            else if (valeur.Active == false)
            {
                couleur = Color.FromArgb(opacite, 255, 0, 0);

            }
            else if (valeur.Active == true)
            {
                couleur = Color.FromArgb(opacite, 9, 150, 40);
            }
            Point PositionEcran = Origine;
            Rectangle r = new Rectangle(PositionEcran, taille);
            Pen p = new Pen(couleur, Epaisseur = 2);
            g.DrawRectangle(p, r);
            g.DrawString("" + valeur, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, Origine);
        }
        public void Deplace(Point p)
        {
            Origine = p;
        }
    }
    
    
}
