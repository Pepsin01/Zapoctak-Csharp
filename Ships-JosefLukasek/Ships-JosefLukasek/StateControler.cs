﻿using System;
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
            public GamePlan localPlan { get; private set; }
            public GamePlan remotePlan { get; private set; }
            ShipsForm f;
            public GameState state { get; private set; }
            public StateControler(ShipsForm form)
            {
                f = form;
                ChangeStateTo(GameState.MainMenu);
            }
            void CreateMultiGamePlan()
            {
                localPlan = new GamePlan(f, (f.ClientRectangle.Width / 2) - (10 * 40) - 2, (f.ClientRectangle.Height / 2) - (10 * 40), AfterLocalShot);
                remotePlan = new GamePlan(f, (f.ClientRectangle.Width / 2) + (10 * 40) + 2, (f.ClientRectangle.Height / 2) - (10 * 40), AfterRemoteShot);
                remotePlan.state = PlanState.Locked;
            }
            void AfterLocalShot(bool wasHit, (int i, int j) coords)
            {

            }
            void AfterRemoteShot(bool wasHit, (int i, int j) coords)
            {
                if (wasHit)
                {
                    remotePlan.state = PlanState.Hidden;
                }
                else
                {
                    remotePlan.state = PlanState.Locked;
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
                CreateMultiGamePlan();
            }

            void ShowConnecting()
            {
                f.StatusLabel.Visible = true;
            }

            void ShowGameClient()
            {
                f.StatusLabel.Visible = true;
            }

            void ShowGameHost()
            {
                f.StatusLabel.Visible = true;
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
