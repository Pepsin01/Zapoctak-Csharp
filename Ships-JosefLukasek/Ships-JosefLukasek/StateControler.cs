using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships_JosefLukasek
{
    enum GameState {
        MainMenu, MultiMenu, SetHost, SetClient, 
        Connecting, Placing,
        GameClient, GameHost, MultiGameOver, 
        SinglePlacing, SigleGame, SingleGameOver }
    partial class ShipsForm
    {
        internal class StateControler
        {
            public GamePlan plan { get; private set; }
            ShipsForm f;
            GameState state;
            public StateControler(ShipsForm form)
            {
                this.f = form;
                ChangeStateTo(GameState.MainMenu);
            }
            void CreateGamePlan()
            {
                plan = new GamePlan(f, (f.ClientRectangle.Width / 2) - (10 * 40), (f.ClientRectangle.Height / 2) - (5 * 40), AfterShot);
            }
            void AfterShot(bool wasHit)
            {
                if (wasHit)
                {

                }
            }
            public void ChangeStateTo(GameState newState)
            {
                HideAll();
                switch (newState)
                {
                    case GameState.MainMenu:
                        ShowMainMenu();
                        break;
                    case GameState.MultiMenu:
                        ShowMultiMenu();
                        break;
                    case GameState.SetHost:
                        ShowGameHost();
                        break;
                    case GameState.SetClient:
                        ShowGameClient();
                        break;
                    case GameState.Connecting:
                        ShowConnecting();
                        break;
                    case GameState.Placing:
                        ShowPlacing();
                        break;
                    case GameState.GameClient:
                        ShowGameClient();
                        break;
                    case GameState.GameHost:
                        ShowGameHost();
                        break;
                    case GameState.MultiGameOver:
                        break;
                    case GameState.SinglePlacing:
                        break;
                    case GameState.SigleGame:
                        break;
                    case GameState.SingleGameOver:
                        break;
                    default:
                        break;
                }
            }
            void HideAll()
            {
                f.SingleBtn.Visible = false;
                f.MultiBtn.Visible = false;
                f.HostModeBtn.Visible = false;
                f.JoinModeBtn.Visible = false;
                f.SloopBtn.Visible = false;
                f.BrigBtn.Visible = false;
                f.FrigBtn.Visible = false;
                f.GallBtn.Visible = false;
                f.ClientIpLabel.Visible = false;
                f.ClientIpBox.Visible = false;
                f.ClientJoinBtn.Visible = false;
                f.ClientPortBox.Visible = false;
                f.ClientPortLabel.Visible = false;
                f.HostJoinBtn.Visible = false;
                f.HostModeBtn.Visible = false;
                f.HostPortLabel.Visible = false;
                f.HostPortBox.Visible = false;
                f.ReadyBtn.Visible = false;
                f.ReplayBtn.Visible = false;
                f.MenuBtn.Visible = false;
                f.StatusLabel.Visible = false;
            }
            void ShowMainMenu()
            {
                f.SingleBtn.Visible = true;
                f.MultiBtn.Visible = true;
            }

            void ShowMultiMenu()
            {
                f.HostModeBtn.Visible = true;
                f.JoinModeBtn.Visible = true;
            }

            void ShowSetHost()
            {
                f.HostPortLabel.Visible = true;
                f.HostPortBox.Visible = true;
                f.HostJoinBtn.Visible = true;
            }

            void ShowSetClient()
            {
                f.ClientIpLabel.Visible = true;
                f.ClientIpBox.Visible = true;
                f.ClientPortLabel.Visible = true;
                f.ClientPortBox.Visible = true;
                f.ClientJoinBtn.Visible = true;
            }

            void ShowPlacing()
            {
                f.SloopBtn.Visible = true;
                f.BrigBtn.Visible = true;
                f.FrigBtn.Visible = true;
                f.GallBtn.Visible = true;
                f.ReadyBtn.Visible = true;
                f.StatusLabel.Visible = true;
                f.StatusLabel.Text = "Place all your ships";
            }

            void ShowConnecting()
            {
                f.StatusLabel.Visible = true;
                f.StatusLabel.Text = "Waiting for client to join";
            }

            void ShowGameClient()
            {
                f.StatusLabel.Visible = true;
                f.StatusLabel.Text = "Successfully connected";
            }

            void ShowGameHost()
            {
                f.StatusLabel.Visible = true;
                f.StatusLabel.Text = "Successfully connected";
            }

            void ShowMultiGameOver()
            {
                f.StatusLabel.Visible = true;
                f.StatusLabel.Text = "Game Over";
                f.ReplayBtn.Visible = true;
                f.MenuBtn.Visible = true;
            }
        }
    }
}
