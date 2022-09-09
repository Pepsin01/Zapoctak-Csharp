using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ships_JosefLukasek
{
    public partial class ShipsForm : Form
    {
        StateControler stateControler;

        public ShipsForm()
        {
            InitializeComponent();
            HostModeBtn.Visible = false;
            JoinModeBtn.Visible = false;
            MultiBtn.Visible = false;
            SingleBtn.Visible = false;
            stateControler = new StateControler(this);
        }



        enum ScreenState { FULLSCREEN, BORDERED };
        ScreenState screenState = ScreenState.BORDERED;
        private void fullscreenBtn_Click(object sender, EventArgs e)
        {
            if (screenState == ScreenState.BORDERED)
            {
                this.TopMost = true;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                screenState = ScreenState.FULLSCREEN;
            }
            else
            {
                this.TopMost = false;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                screenState = ScreenState.BORDERED;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (true)
            {
                stateControler.plan.Resize();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R)
            {
                stateControler.plan.RotateCurrShip();
            }
        }

        private void SloopBtn_Click(object sender, EventArgs e)
        {
            stateControler.plan.PickShip(1);
        }

        private void BrigBtn_Click(object sender, EventArgs e)
        {
            stateControler.plan.PickShip(2);
        }

        private void FrigBtn_Click(object sender, EventArgs e)
        {
            stateControler.plan.PickShip(3);
        }

        private void GallBtn_Click(object sender, EventArgs e)
        {
            stateControler.plan.PickShip(4);
        }

        private void HostModeBtn_Click(object sender, EventArgs e)
        {
            stateControler.ChangeStateTo(GameState.SetHost);
        }

        private void JoinModeBtn_Click(object sender, EventArgs e)
        {
            stateControler.ChangeStateTo(GameState.SetClient);
        }

        private void MultiBtn_Click(object sender, EventArgs e)
        {
            stateControler.ChangeStateTo(GameState.MultiMenu);
        }
    }
}
