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
        internal class StateController
        {
            public GamePlan? localPlan { get; private set; }
            public GamePlan? remotePlan { get; private set; }
            ShipsForm f;
            public GameState state { get; private set; }
            public StateController(ShipsForm form)
            {
                f = form;
                ChangeStateTo(GameState.MainMenu);
            }
            void CreateMultiGamePlan()
            {
                localPlan = new GamePlan(f, (f.ClientRectangle.Width / 2) - (10 * 40) - 5, (f.ClientRectangle.Height / 2) - (5 * 40), AfterLocalShot);
                remotePlan = new GamePlan(f, (f.ClientRectangle.Width / 2) + 5, (f.ClientRectangle.Height / 2) - (5 * 40), AfterRemoteShot);
                remotePlan?.Lock();
            }
            void AfterLocalShot(bool wasHit, (int i, int j) coords)
            {

            }
            void AfterRemoteShot(bool wasHit, (int i, int j) coords)
            {
                f.networkHandler.Send($"[SHO] {coords.i},{coords.j} <EOF>");
                if (wasHit)
                {
                    remotePlan?.Unlock();
                    if(remotePlan?.hitCounter == 20)
                    {
                        remotePlan.Lock();
                        f.StatusLabel.Text = "You won";
                        f.networkHandler.Send("[STS] You lost <EOF>");
                        f.networkHandler.Send("[STS] END_GAME <EOF>");
                        localPlan?.Dispose();
                        remotePlan?.Dispose();
                        ChangeStateTo(GameState.MultiGameOver);
                    }
                }
                else
                {
                    remotePlan?.Lock();
                    f.networkHandler.Send("[STS] Your turn <EOF>");
                    f.networkHandler.Send("[STS] END_TURN <EOF>");
                    f.StatusLabel.Text = "Enemy turn";
                }
            }
            public void ChangeStateTo(GameState newState)
            {
                HideAll();
                switch (newState)
                {
                    case GameState.MainMenu:
                        state = GameState.MainMenu;
                        ShowMainMenu();
                        break;
                    case GameState.MultiMenu:
                        state = GameState.MultiMenu;
                        ShowMultiMenu();
                        break;
                    case GameState.SetHost:
                        state = GameState.SetHost;
                        ShowSetHost();
                        break;
                    case GameState.SetClient:
                        state = GameState.SetClient;
                        ShowSetClient();
                        break;
                    case GameState.Connecting:
                        state = GameState.Connecting;
                        ShowConnecting();
                        break;
                    case GameState.Placing:
                        state = GameState.Placing;
                        CreateMultiGamePlan();
                        ShowPlacing();
                        break;
                    case GameState.GameClient:
                        state = GameState.GameClient;
                        ShowGameClient();
                        break;
                    case GameState.GameHost:
                        state = GameState.GameHost;
                        ShowGameHost();
                        break;
                    case GameState.MultiGameOver:
                        state = GameState.MultiGameOver;
                        localPlan = null;
                        remotePlan = null;
                        ShowMultiGameOver();
                        break;
                    case GameState.SinglePlacing:
                        state = GameState.SinglePlacing;
                        break;
                    case GameState.SigleGame:
                        state = GameState.SigleGame;
                        break;
                    case GameState.SingleGameOver:
                        state = GameState.SingleGameOver;
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
                f.ServerHostBtn.Visible = false;
                f.ClientPortBox.Visible = false;
                f.ClientPortLabel.Visible = false;
                f.HostModeBtn.Visible = false;
                f.ReadyBtn.Visible = false;
                f.ReplayBtn.Visible = false;
                f.MenuBtn.Visible = false;
                f.StatusLabel.Visible = false;
            }
            void ShowMainMenu()
            {
                f.SingleBtn.Visible = true;
                f.MultiBtn.Visible = true;
                f.StatusLabel.Visible = false;
            }

            void ShowMultiMenu()
            {
                f.HostModeBtn.Visible = true;
                f.JoinModeBtn.Visible = true;
                f.StatusLabel.Visible = false;
            }

            void ShowSetHost()
            {
                f.ClientIpLabel.Visible = true;
                f.ClientIpBox.Visible = true;
                f.ClientPortLabel.Visible = true;
                f.ClientPortBox.Visible = true;
                f.ServerHostBtn.Visible = true;
                f.StatusLabel.Visible = true;
            }

            void ShowSetClient()
            {
                f.ClientIpLabel.Visible = true;
                f.ClientIpBox.Visible = true;
                f.ClientPortLabel.Visible = true;
                f.ClientPortBox.Visible = true;
                f.ClientJoinBtn.Visible = true;
                f.StatusLabel.Visible = true;
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
            }

            void ShowGameClient()
            {
                f.StatusLabel.Visible = true;
                remotePlan?.Lock();
                f.StatusLabel.Text = "Enemy turn";
            }

            void ShowGameHost()
            {
                f.StatusLabel.Visible = true;
                remotePlan?.Unlock();
                f.StatusLabel.Text = "Your turn";
            }

            void ShowMultiGameOver()
            {
                f.StatusLabel.Visible = true;
                f.ReplayBtn.Visible = true;
                f.MenuBtn.Visible = true;
            }
        }
    }
}
