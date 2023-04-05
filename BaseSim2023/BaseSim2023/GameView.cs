using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BaseSim2023
{
    public partial class GameView : Form
    {
        private bool autoconfirm = false;
        private readonly WorldState theWorld;
        private Rectangle PolRectangle { get; set; } = new Rectangle(0, 700, 1920, 300);
        private Rectangle GrpRectangle { get; set; } = new Rectangle(500, 400, 600, 300);
        private Rectangle PerCrsRectangle { get; set; } = new Rectangle(0, 75, 1920, 300);
        private Rectangle I1Rectangle { get; set; } = new Rectangle(0, 400, 600, 300);
        private Rectangle I2Rectangle { get; set; } = new Rectangle(1200, 400, 600, 300);

        List<IndexedValueView> polViews;
        private List<IndexedValueView> grpViews;
        private List<IndexedValueView> perCrsViews;
        private List<IndexedValueView> I1Views;
        private List<IndexedValueView> I2Views;
        private List<IndexedValueView> globViews;
        List<Lien> listLiens = new List<Lien>();
        private List<IndexedValueView> listeNonLiens = new List<IndexedValueView>();
        IndexedValueView survole;
        bool déplacement;
        private int w;
        private int h;
        private int xPol;
        private int yPol;
        /// <summary>
        /// The constructor for the main window
        /// </summary>
        public GameView(WorldState world)
        {
            InitializeComponent();
            theWorld = world;
            int margin = 0;
            w = 200;
            h = 100;
            xPol = PolRectangle.X + margin;
            yPol = PolRectangle.Y + margin;
            polViews = new List<IndexedValueView>();

            foreach (IndexedValue p in theWorld.Policies)
            {
                IndexedValueView view = new IndexedValueView{ Origine = new Point(xPol, yPol), valeur = p, opacite = 255 }; 
                polViews.Add(view);
                xPol += w+margin;
                if (xPol + w > PolRectangle.Right)
                {
                    xPol = PolRectangle.X + margin;
                    yPol += h+margin;
                }
            }
            int yGrp = GrpRectangle.Y + margin;
            margin = 50;
            int xGrp = GrpRectangle.X + margin;
            grpViews = new List<IndexedValueView>();
            foreach (IndexedValue p in theWorld.Groups)
            {
                IndexedValueView view = new IndexedValueView { Origine = new Point(xGrp, yGrp), valeur = p, opacite = 255 };
                grpViews.Add(view);
                xGrp += w + margin;
                if (xGrp + w > GrpRectangle.Right)
                {
                    xGrp = GrpRectangle.X + margin;
                    yGrp += h + margin;
                }
            }
            margin = 5;
            int xPerCrs = PerCrsRectangle.X + margin;
            int yPerCrs = PerCrsRectangle.Y + margin;
            perCrsViews = new List<IndexedValueView>();
            foreach (IndexedValue p in theWorld.Perks)
            {
                IndexedValueView view = new IndexedValueView { Origine = new Point(xPerCrs, yPerCrs), valeur = p, opacite = 255 };
                perCrsViews.Add(view);
                xPerCrs += w + margin;
                if (xPerCrs + w > PerCrsRectangle.Right)
                {
                    xPerCrs = PerCrsRectangle.X + margin;
                    yPerCrs += h + margin;
                }
            }
            foreach (IndexedValue p in theWorld.Crises)
            {
                IndexedValueView view = new IndexedValueView { Origine = new Point(xPerCrs, yPerCrs), valeur = p, opacite = 255 };
                perCrsViews.Add(view);
                xPerCrs += w + margin;
                if (xPerCrs + w > PerCrsRectangle.Right)
                {
                    xPerCrs = PerCrsRectangle.X + margin;
                    yPerCrs += h + margin;
                }
            }
            int xI1 = I1Rectangle.X + margin;
            int yI1 = I1Rectangle.Y + margin;
            I1Views = new List<IndexedValueView>();
            margin = 1;
            for (int i = 0; i < theWorld.Indicators.Count/2; i++)
            {

                IndexedValue p = theWorld.Indicators[i];
                IndexedValueView view = new IndexedValueView { Origine = new Point(xI1, yI1), valeur = p, opacite = 255 };
                I1Views.Add(view);
                xI1 += w + margin;
                if (xI1 + w > I1Rectangle.Right)
                {
                    xI1 = I1Rectangle.X + margin;
                    yI1 += h + margin;
                }
            }
            int xI2 = I2Rectangle.X + margin;
            int yI2 = I2Rectangle.Y + margin;
            I2Views = new List<IndexedValueView>();
            for (int i = (theWorld.Indicators.Count/2)+1; i < theWorld.Indicators.Count; i++)
            {
                IndexedValue p = theWorld.Indicators[i];
                IndexedValueView view = new IndexedValueView { Origine = new Point(xI2, yI2), valeur = p, opacite = 255 };
                I2Views.Add(view);
                xI2 += w + margin;
                if (xI2 + w > I2Rectangle.Right)
                {
                    xI2 = I2Rectangle.X + margin;
                    yI2 += h + margin;
                }
            }
            globViews = new List<IndexedValueView>();
            globViews.AddRange(grpViews);
            globViews.AddRange(polViews);
            globViews.AddRange(perCrsViews);
            globViews.AddRange(I1Views);
            globViews.AddRange(I2Views);
        }
        
        /// <summary>
        /// Method called by the controler whenever some text should be displayed
        /// </summary>
        /// <param name="s"></param>
        public void WriteLine(string s)
        {
            List<string> strs = s.Split('\n').ToList();
            strs.ForEach(str => outputListBox.Items.Add(str));
            if (outputListBox.Items.Count > 0)
            {
                outputListBox.SelectedIndex = outputListBox.Items.Count - 1;
            }
            outputListBox.Refresh();
        }
        /// <summary>
        /// Method called by the controler whenever a confirmation should be asked
        /// </summary>
        /// <returns>Yes iff confirmed</returns>
        public bool ConfirmDialog()
        {
            if (autoconfirm) { return true; }
            string message = "Confirmer ?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            return MessageBox.Show(message, "", buttons) == DialogResult.Yes;
        }
        #region Event handling
        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                e.SuppressKeyPress = true; // Or beep.
                GameController.Interpret(inputTextBox.Text);
            }
        }

        private void GameView_Paint(object sender, PaintEventArgs e)
        {
            diffLabel.Text = "Difficulté : " + theWorld.TheDifficulty;
            turnLabel.Text = "Tour " + theWorld.Turns;
            moneyLabel.Text = "Trésor : " + theWorld.Money + " pièces d'or";
            gloryLabel.Text = "Gloire : " + theWorld.Glory;
            Pen p = new Pen(Color.Black, 2);
            e.Graphics.DrawRectangle(p, new Rectangle(PolRectangle.X, PolRectangle.Y, PolRectangle.Width-20, PolRectangle.Height-20));
            e.Graphics.DrawString("" + polViews[0].valeur.Type, new Font("Arial", 30, FontStyle.Bold), Brushes.Black, new Point(polViews[0].Origine.X, polViews[0].Origine.Y-50));
            foreach (IndexedValueView view in polViews)
            {
                view.Dessine(e.Graphics, theWorld);
            }
            e.Graphics.DrawRectangle(p, new Rectangle(GrpRectangle.X, GrpRectangle.Y, GrpRectangle.Width-30, GrpRectangle.Height-40));
            e.Graphics.DrawString("" + grpViews[0].valeur.Type, new Font("Arial", 30, FontStyle.Bold), Brushes.Black, new Point(grpViews[0].Origine.X, grpViews[0].Origine.Y - 50));
            foreach (IndexedValueView view in grpViews)
            {
                view.Dessine(e.Graphics, theWorld);
            }
            e.Graphics.DrawRectangle(p, new Rectangle(PerCrsRectangle.X, PerCrsRectangle.Y, PerCrsRectangle.Width, PerCrsRectangle.Height - 40));
            e.Graphics.DrawString("" + perCrsViews[0].valeur.Type, new Font("Arial", 30, FontStyle.Bold), Brushes.Black, new Point(perCrsViews[0].Origine.X, perCrsViews[0].Origine.Y - 50));
            foreach (IndexedValueView view in perCrsViews)
            {
                view.Dessine(e.Graphics, theWorld);
            }
            foreach (IndexedValueView view in I1Views)
            {
                view.Dessine(e.Graphics, theWorld);
            }
            foreach (IndexedValueView view in I2Views)
            {
                view.Dessine(e.Graphics, theWorld);
            }
            foreach (Lien l in listLiens)
            {
                l.Dessine(e.Graphics);
            }
        }
        private void NextButton_Click(object sender, EventArgs e)
        {
            theWorld.NextTurn();
        }

        private void GameView_DoubleClick(object sender, EventArgs e)
        {
            string[] cheat =
            {
                "politique gardes 100", "politique pretres 100", "politique impots 40", "suivant",
                "politique subventions 100", "politique doleances 100", "politique quetegraal 10", "suivant",
                "politique ecoles 100", "politique enchanteurs 100", "politique taxeluxe 10", "suivant",
                "politique theatres 100", "politique taxealcool 5", "politique agrandirterritoires 2", "politique monstres 2", "suivant",
                "suivant",
                "politique termes 100", "politique juges 100", "politique taxefonciere 5", "politique dragons 5"
            };
            autoconfirm = true;
            foreach (string cheatItem in cheat)
            {
                GameController.Interpret(cheatItem);
            }
            autoconfirm = false;
        }
        public void LoseDialog(IndexedValue indexedValue)
        {
            if (indexedValue == null)
            {
            MessageBox.Show("Partie perdue : dette insurmontable.");
            }
            else
            {
            MessageBox.Show("Partie perdue : "
            + indexedValue.CompletePresentation());
            }
            nextButton.Enabled = false;
            }
        public void WinDialog()
        {
            MessageBox.Show("Partie Gagnée !");
            nextButton.Enabled = false;
        }

        #endregion

        private void turnLabel_Click(object sender, EventArgs e)
        {

        }

        private IndexedValueView polSelection(Point p)
        {
            IndexedValueView res = null;
            int i = 0;
            while (res == null && i < polViews.Count)
            {
               
                if (polViews[i].Contient(p))
                {
                    res = polViews[i];
                }
                i++;
            }
            return res;
        }

        private IndexedValueView elementSelection(Point p)
        {
            IndexedValueView res = null;
            int i = 0;
            while (res == null && i < globViews.Count)
            {
                if (globViews[i].Contient(p))
                {
                    res = globViews[i];
                }
                i++;
            }
            return res;
        }

        private void GameView_MouseDown(object sender, MouseEventArgs e)
        {   
            if (e.Button == MouseButtons.Left)
            {
                IndexedValueView selection = polSelection(e.Location);
                if (selection != null && selection.valeur.Active == true)
                {
                    policyChange fen = new policyChange(selection.valeur.Name, selection.valeur.MinValue, selection.valeur.MaxValue, selection.valeur.Value);
                    if (fen.ShowDialog() == DialogResult.OK)
                    {
                        GameController.ApplyPolicyChanges(selection.valeur.Name + " " + fen.numVal());
                    }
                }
                else
                {
                    selection = elementSelection(e.Location);
                    if (selection != null)
                    {
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        MessageBox.Show(selection.valeur.Description, "", buttons);
                    }
                }
            }
            else
            {
                IndexedValueView selection = elementSelection(e.Location);
                if (selection != null)
                {
                    déplacement = true;
                }
            }
            Refresh();
        }

        private void GameView_MouseMove(object sender, MouseEventArgs e)
        {
            IndexedValueView survole = polSelection(e.Location);
            listLiens.Clear();
            listeNonLiens.Clear();
            listeNonLiens.AddRange(globViews);
            if (survole != null) {
                listeNonLiens.Remove(survole);
                foreach (IndexedValue iv in survole.valeur.OutputWeights.Keys)
                {
                    IndexedValueView v = null;
                    int i = 0;
                    while (v == null && i < globViews.Count())
                    {
                        if (globViews[i].valeur == iv)
                        {
                            v = globViews[i];
                            Console.WriteLine(v);
                        }
                        i++;
                    }
                    if (v != null)
                    {
                        Color color;
                        if (survole.valeur.OutputWeights[v.valeur] > 0)
                        {
                            color = Color.LawnGreen;
                        }
                        else
                        {
                            color = Color.Red;
                        }
                        double width = survole.valeur.OutputWeights[v.valeur] * 100;
                        if (width > 25)
                        {
                            width = 25;
                        }
                        Lien lien = new Lien { Source = survole, Destination = v, Color=color, Width = width };
                        listLiens.Add(lien);
                        listeNonLiens.Remove(v);
                    }
                }
            }
            else
            {
                survole = elementSelection(e.Location);
            }
            foreach (IndexedValueView ivv in globViews)
            {
                ivv.opacite = 255;
            }
            if (listeNonLiens.Count() != globViews.Count())
            {
                foreach (IndexedValueView ivv in listeNonLiens)
                {
                    ivv.opacite = 25;
                }
            }
            if (survole != null && déplacement)
            {
                survole.Deplace(new Point(e.Location.X - survole.taille.Width / 2, e.Location.Y - survole.taille.Height / 2));
            }
            Refresh();
        }

        private void GameView_MouseUp(object sender, MouseEventArgs e)
        {
            déplacement = false;
        }
    }
}
