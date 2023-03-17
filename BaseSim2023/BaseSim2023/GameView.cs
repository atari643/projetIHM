using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BaseSim2023
{
    public partial class GameView : Form
    {
        private bool autoconfirm = false;
        private readonly WorldState theWorld;
        /// <summary>
        /// The constructor for the main window
        /// </summary>
        public GameView(WorldState world)
        {
            InitializeComponent();
            theWorld = world;
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
            /*
            diffLabel.Text = "Difficulté : " + "?";
            turnLabel.Text = "Tour " + "?";
            moneyLabel.Text = "Trésor : " + "?" + " pièces d'or";
            gloryLabel.Text = "Gloire : " + "?";
            */
            nextButton.Visible = false;
        }
        private void NextButton_Click(object sender, EventArgs e)
        {

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
        #endregion
    }
}
