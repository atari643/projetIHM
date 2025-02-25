﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseSim2023
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WorldState.Difficulty diff = WorldState.Difficulty.Easy;
            DifficultyView dv = new DifficultyView();
            dv.ShowDialog();
            diff = dv.Difficulty;
            int turn = dv.turn;
            WorldState theWorld = new WorldState(diff, "../../Logres.xml", turn);
            GameView theView = new GameView(theWorld);
            GameController.SetView(theView);
            GameController.SetWorld(theWorld);
            Application.Run(theView);
        }
    }
}
