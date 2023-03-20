namespace BaseSim2023
{
    partial class boiteFin
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
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.LabelFin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelFin
            // 
            this.LabelFin.AutoSize = true;
            this.LabelFin.Location = new System.Drawing.Point(127, 50);
            this.LabelFin.Name = "LabelFin";
            this.LabelFin.Size = new System.Drawing.Size(0, 13);
            this.LabelFin.TabIndex = 1;
            // 
            // boiteFin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 226);
            this.Controls.Add(this.LabelFin);
            this.Name = "boiteFin";
            this.Text = "BoiteFin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label LabelFin;
    }
}