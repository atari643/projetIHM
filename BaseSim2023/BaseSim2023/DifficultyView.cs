﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseSim2023
{
    /// <summary>
    /// A difficulty dialog
    /// </summary>
    public partial class DifficultyView : Form
    {
        public WorldState.Difficulty Difficulty { get; private set; }
        public int turn { get; set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        public DifficultyView()
        {
            InitializeComponent();
            turn = -1;
        }
        private void EasyButton_Click(object sender, EventArgs e) => Difficulty = WorldState.Difficulty.Easy;
        private void MidButton_Click(object sender, EventArgs e) => Difficulty = WorldState.Difficulty.Medium;
        private void HardButton_Click(object sender, EventArgs e) => Difficulty = WorldState.Difficulty.Hard;
    }
}
