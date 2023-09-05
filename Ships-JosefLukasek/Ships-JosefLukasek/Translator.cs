using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using static Ships_JosefLukasek.ShipsForm;

namespace Ships_JosefLukasek
{
    partial class ShipsForm
    {
        /// <summary>
        /// This class is responsible for translating messages from network to actions in game
        /// </summary>
        internal class Translator
        {
            ShipsForm f;
            /// <summary>
            /// Translates messages from network to actions in game
            /// </summary>
            /// <param name="form"> The form. </param>
            public Translator(ShipsForm form)
            {
                f = form;
            }
            /// <summary>
            /// Translates message from network to actions in game
            /// </summary>
            /// <param name="message"> The message. </param>
            public void TranslateMessage(string message)
            {
                List<string> messages = message.Split("<EOF>").ToList();

                while(messages.Count > 0)
                {
                    string msg = messages[0];
                    messages.RemoveAt(0);

                    msg = msg.Trim();

                    if(msg.Length < 5)
                    {
                        continue;
                    }

                    string signature = msg[..5];
                    
                    if (signature == "[STS]")
                    {
                        StatusHandler(msg[5..].Trim());
                    }
                    else if (signature == "[ERR]")
                    {
                        ErrHandler(msg[5..].Trim());
                    }
                    else if (signature == "[PLN]")
                    {
                        PlanHandler(msg[5..].Trim());
                    }
                    else if (signature == "[SHO]")
                    {
                        ShootHandler(msg[5..].Trim());
                    }
                }
            }
            /// <summary>
            /// Handles messages about status of the game
            /// </summary>
            /// <param name="message"></param>
            private void StatusHandler(string message)
            {
                if(message == "CONNECTED")
                {
                    f.stateControler.ChangeStateTo(GameState.Placing);
                }
                else if (message == "READY")
                {
                    if (f.stateControler.localPlan.IsReady)
                    {
                        if (f.isHost)
                        {
                            f.stateControler.ChangeStateTo(GameState.GameHost);
                        }
                        else
                        {
                            f.stateControler.ChangeStateTo(GameState.GameClient);
                        }
                    }
                }
                else if (message == "END_TURN")
                {
                    f.stateControler.remotePlan?.Unlock();
                }
                else if (message == "END_GAME")
                {
                    f.stateControler.localPlan?.Dispose();
                    f.stateControler.remotePlan?.Dispose();
                    f.stateControler.ChangeStateTo(GameState.MultiGameOver);
                }
                // if message is not recognized, it is displayed in status label
                else
                {
                    f.StatusLabel.Text = message;
                }

            }

            /// <summary>
            /// Handles error messages
            /// </summary>
            /// <param name="message"> The message. </param>
            private void ErrHandler(string message)
            {
                if(message == "CONNECTION_FAILED")
                {
                    f.stateControler.remotePlan?.Dispose();
                    f.stateControler.localPlan?.Dispose();
                    f.stateControler.ChangeStateTo(GameState.MainMenu);
                }
                else if(message == "CONNECTION_LOST")
                {
                    f.stateControler.remotePlan?.Dispose();
                    f.stateControler.localPlan?.Dispose();
                    f.stateControler.ChangeStateTo(GameState.MainMenu);
                }
                // if message is not recognized, it is displayed in status label
                else
                {
                    f.StatusLabel.Text = message;
                }
            }
            /// <summary>
            /// Handles messages about game plan
            /// </summary>
            /// <param name="message"> The message. </param>
            private void PlanHandler(string message)
            {
                f.stateControler.remotePlan?.LoadPlanFromString(message);
            }

            /// <summary>
            /// Handles messages about shooting
            /// </summary>
            /// <param name="message"> The message. </param>
            private void ShootHandler(string message)
            {
                var coords = (int.Parse(message.Split(',')[0]), int.Parse(message.Split(',')[1]));
                f.stateControler.localPlan?.MarkSquareAsHit(coords);
            }
        }

        /// <summary>
        /// Receives message from network and passes it to translator in GUI thread
        /// </summary>
        /// <param name="message"> The message. </param>
        public void ReceiveMessage(string message)
        {
            Invoke(new Action(() =>
            {
                translator.TranslateMessage(message);
            }));
        }
    }
}
