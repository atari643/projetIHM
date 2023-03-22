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
        private Rectangle PolRectangle { get; set; } = new Rectangle(0, 600, 1800, 300);
        private Rectangle GrpRectangle { get; set; } = new Rectangle(600, 300, 600, 300);
        private Rectangle PerCrsRectangle { get; set; } = new Rectangle(0, 25, 1800, 300);

        private Rectangle I1Rectangle { get; set; } = new Rectangle(0, 300, 600, 300);
        private Rectangle I2Rectangle { get; set; } = new Rectangle(1200, 300, 600, 300);

        private List<IndexedValueView> polViews;
        private List<IndexedValueView> grpViews;
        private List<IndexedValueView> perCrsViews;
        private List<IndexedValueView> I1Views;
        private List<IndexedValueView> I2Views;
        /// <summary>
        /// The constructor for the main window
        /// </summary>
        public GameView(WorldState world)
        {
            InitializeComponent();
            theWorld = world;
            int margin = 15;
            int w = 200;
            int h = 100;
            int xPol = PolRectangle.X + margin;
            int yPol = PolRectangle.Y + margin;
            polViews = new List<IndexedValueView>();
            foreach (IndexedValue p in theWorld.Policies)
            {
                IndexedValueView view = new IndexedValueView{ Origine = new Point(xPol, yPol), valeur = p }; 
                polViews.Add(view);
                xPol += w+margin;
                if (xPol + w > PolRectangle.Right)
                {
                    xPol = PolRectangle.X + margin;
                    yPol += h+margin;
                }
            }
            int xGrp = GrpRectangle.X + margin;
            int yGrp = GrpRectangle.Y + margin;
            grpViews = new List<IndexedValueView>();
            foreach (IndexedValue p in theWorld.Groups)
            {
                IndexedValueView view = new IndexedValueView { Origine = new Point(xGrp, yGrp), valeur = p };
                grpViews.Add(view);
                xGrp += w + margin;
                if (xGrp + w > GrpRectangle.Right)
                {
                    xGrp = GrpRectangle.X + margin;
                    yGrp += h + margin;
                }
            }
            int xPerCrs = PerCrsRectangle.X + margin;
            int yPerCrs = PerCrsRectangle.Y + margin;
            perCrsViews = new List<IndexedValueView>();
            foreach (IndexedValue p in theWorld.Perks)
            {
                IndexedValueView view = new IndexedValueView { Origine = new Point(xPerCrs, yPerCrs), valeur = p };
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
                IndexedValueView view = new IndexedValueView { Origine = new Point(xPerCrs, yPerCrs), valeur = p };
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
            for (int i = 0; i < theWorld.Indicators.Count/2; i++)
            {
                IndexedValue p = theWorld.Indicators[i];
                IndexedValueView view = new IndexedValueView { Origine = new Point(xI1, yI1), valeur = p };
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
                IndexedValueView view = new IndexedValueView { Origine = new Point(xI2, yI2), valeur = p };
                I2Views.Add(view);
                xI2 += w + margin;
                if (xI2 + w > I2Rectangle.Right)
                {
                    xI2 = I2Rectangle.X + margin;
                    yI2 += h + margin;
                }
            }
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
            foreach (IndexedValueView view in polViews)
            {
                view.Dessine(e.Graphics);
            }
            foreach (IndexedValueView view in grpViews)
            {
                view.Dessine(e.Graphics);
            }
            foreach (IndexedValueView view in perCrsViews)
            {
                view.Dessine(e.Graphics);
            }
            foreach (IndexedValueView view in I1Views)
            {
                view.Dessine(e.Graphics);
            }
            foreach (IndexedValueView view in I2Views)
            {
                view.Dessine(e.Graphics);
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
    }
}
