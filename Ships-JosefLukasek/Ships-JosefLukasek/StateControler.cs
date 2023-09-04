using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships_JosefLukasek
{
    enum GameState {
        MainMenu, // Default state of the game
        MultiMenu, // Multi-player menu
        SetHost, // Menu for setting up hosts IP address and port
        SetClient, // Menu for setting up clients IP address and port
        Connecting, // Not interactive state, just waiting for connection
        Placing, // Placing ships
        GameClient, // State for client during the game
        GameHost, // State for host during the game
        MultiGameOver, // Multi-player game over
        SinglePlacing, 
        SigleGame,
        SingleGameOver
    }
    partial class ShipsForm
    {
        internal class StateController
        {
            public GamePlan? localPlan { get; private set; } // game plan of local player
            public GamePlan? remotePlan { get; private set; } // game plan of remote player
            ShipsForm f;
            public GameState state { get; private set; }

            /// <summary>
            /// Holds state of the game and shows/hides controls and manages game plans.
            /// </summary>
            /// <param name="form"> The form. </param>
            public StateController(ShipsForm form)
            {
                f = form;
                ChangeStateTo(GameState.MainMenu);
            }
            /// <summary>
            /// Creates new game plan for multi-player game.
            /// </summary>
            void CreateMultiGamePlan()
            {
                localPlan = new GamePlan(f, (f.ClientRectangle.Width / 2) - (10 * 40) - 5, (f.ClientRectangle.Height / 2) - (5 * 40), null);
                remotePlan = new GamePlan(f, (f.ClientRectangle.Width / 2) + 5, (f.ClientRectangle.Height / 2) - (5 * 40), AfterRemoteShot);
                remotePlan?.Lock();
            }
            /// <summary>
            /// Decides what to do after shot to "remote" plan.
            /// If it was hit, it unlocks remote plan and checks if it was last ship and sends message to remote player.
            /// If it was not hit, it locks remote plan and sends message to remote player.
            /// </summary>
            /// <param name="wasHit"> If the shot was hit. </param>
            /// <param name="coords"> Coordinates of the shot. </param>
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
            /// <summary>
            /// Main entry point for handling state changes and showing/hiding controls and managing game plans.
            /// </summary>
            /// <param name="newState"> New state of the game. </param>
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
