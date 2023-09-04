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
        StateController stateControler;
        NetworkHandler networkHandler;
        Translator translator;
        bool isHost = false;

        public ShipsForm()
        {
            InitializeComponent();
            HostModeBtn.Visible = false;
            JoinModeBtn.Visible = false;
            MultiBtn.Visible = false;
            SingleBtn.Visible = false;
            stateControler = new StateController(this);
            translator = new Translator(this);
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
            if (stateControler is not null)
            {
                if (stateControler.localPlan is not null)
                {
                    stateControler.localPlan.Resize(true);
                }
                if (stateControler.remotePlan is not null)
                {
                    stateControler.remotePlan.Resize(false);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R)
            {
                stateControler.localPlan.RotateCurrShip();
            }
        }

        private void SloopBtn_Click(object sender, EventArgs e)
        {
            stateControler.localPlan.PickShip(1);
        }

        private void BrigBtn_Click(object sender, EventArgs e)
        {
            stateControler.localPlan.PickShip(2);
        }

        private void FrigBtn_Click(object sender, EventArgs e)
        {
            stateControler.localPlan.PickShip(3);
        }

        private void GallBtn_Click(object sender, EventArgs e)
        {
            stateControler.localPlan.PickShip(4);
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

        private void ClientJoinBtn_Click(object sender, EventArgs e)
        {
            int port = int.Parse(ClientPortBox.Text);
            networkHandler = new NetworkHandler(ReceiveMessage, false, ClientIpBox.Text, port);
        }

        private void ServerHostBtn_Click(object sender, EventArgs e)
        {
            int port = int.Parse(ClientPortBox.Text);
            stateControler.ChangeStateTo(GameState.Connecting);
            networkHandler = new NetworkHandler(ReceiveMessage, true, ClientIpBox.Text, port);
            isHost = true;
        }

        private void ReadyBtn_Click(object sender, EventArgs e)
        {
            if (stateControler.localPlan.TryReadyLock())
            {
                networkHandler.Send("[PLN] " + stateControler.localPlan.ToString() + " <EOF>");
                networkHandler.Send("[STS] Other player is ready <EOF>");
                networkHandler.Send("[STS] READY <EOF>");
            }
            else
            {
                StatusLabel.Text = "You must place all ships";
            }
            if (stateControler.remotePlan.IsReady && stateControler.localPlan.IsReady)
            {
                if (isHost)
                {
                    stateControler.ChangeStateTo(GameState.GameHost);
                }
                else
                {
                    stateControler.ChangeStateTo(GameState.GameClient);
                }
            }
        }

        private void MenuBtn_Click(object sender, EventArgs e)
        {
            networkHandler?.Close();
            networkHandler = null;
            stateControler.ChangeStateTo(GameState.MainMenu);
        }

        private void ReplayBtn_Click(object sender, EventArgs e)
        {
            networkHandler?.Close();
            networkHandler = null;
            stateControler.ChangeStateTo(GameState.MultiMenu);
        }
    }
}
