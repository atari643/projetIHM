
namespace BaseSim2023
{
    partial class DifficultyView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.easyButton = new System.Windows.Forms.Button();
            this.midButton = new System.Windows.Forms.Button();
            this.hardButton = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // easyButton
            // 
            this.easyButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.easyButton.Location = new System.Drawing.Point(46, 84);
            this.easyButton.Margin = new System.Windows.Forms.Padding(2);
            this.easyButton.Name = "easyButton";
            this.easyButton.Size = new System.Drawing.Size(58, 27);
            this.easyButton.TabIndex = 0;
            this.easyButton.Text = "Facile";
            this.easyButton.UseVisualStyleBackColor = true;
            this.easyButton.Click += new System.EventHandler(this.EasyButton_Click);
            // 
            // midButton
            // 
            this.midButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.midButton.Location = new System.Drawing.Point(165, 84);
            this.midButton.Margin = new System.Windows.Forms.Padding(2);
            this.midButton.Name = "midButton";
            this.midButton.Size = new System.Drawing.Size(58, 27);
            this.midButton.TabIndex = 1;
            this.midButton.Text = "Moyen";
            this.midButton.UseVisualStyleBackColor = true;
            this.midButton.Click += new System.EventHandler(this.MidButton_Click);
            // 
            // hardButton
            // 
            this.hardButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.hardButton.Location = new System.Drawing.Point(287, 84);
            this.hardButton.Margin = new System.Windows.Forms.Padding(2);
            this.hardButton.Name = "hardButton";
            this.hardButton.Size = new System.Drawing.Size(58, 27);
            this.hardButton.TabIndex = 2;
            this.hardButton.Text = "Difficile";
            this.hardButton.UseVisualStyleBackColor = true;
            this.hardButton.Click += new System.EventHandler(this.HardButton_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(165, 161);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(144, 163);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre de tour limité:";
            // 
            // DifficultyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 234);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.hardButton);
            this.Controls.Add(this.midButton);
            this.Controls.Add(this.easyButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DifficultyView";
            this.Text = "Choix de la difficulté";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button easyButton;
        private System.Windows.Forms.Button midButton;
        private System.Windows.Forms.Button hardButton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label1;
    }
}