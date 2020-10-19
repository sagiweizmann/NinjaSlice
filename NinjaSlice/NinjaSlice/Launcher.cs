using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace NinjaSlice
{
    public partial class Launcher : Form
    {
        int val = 0;
        public Launcher()
        {
            InitializeComponent();
        }

        private void PictureBTNStartGame_Click(object sender, EventArgs e)
        {
            PictureBTNStartGame.Image = Resource.startgameclicked;
            StartXna.Start();
        }

        private void PictureBTNStartGame_MouseHover(object sender, EventArgs e)
        {
            PictureBTNStartGame.Image = Resource.startgamehover;
        }
        public void StartGame()
        {
            MainGame game = new MainGame();
            game.Run();
        }
        private void StartXna_Tick(object sender, EventArgs e)
        {
            if (val != 100)
            {
                val += 1;
                Loader.Value += 1;

            }
            if (Loader.Value == 100)
            {
                StartXna.Stop();
                this.Hide();
                Thread start = new Thread(StartGame);
                start.Start();

            }
        }

        private void PictureBTNStartGame_MouseLeave(object sender, EventArgs e)
        {
            PictureBTNStartGame.Image = Resource.startgame;
        }
  

    }
}
