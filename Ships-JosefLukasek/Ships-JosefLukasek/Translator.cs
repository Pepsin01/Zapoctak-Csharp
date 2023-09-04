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
        internal class Translator
        {
            ShipsForm f;
            public Translator(ShipsForm form)
            {
                f = form;
            }
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
                }
            }
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
                else
                {
                    f.StatusLabel.Text = message;
                }

            }
            private void ErrHandler(string message)
            {
                if(message == "CONNECTION_FAILED")
                {
                    f.stateControler.ChangeStateTo(GameState.MainMenu);
                }
                else if(message == "CONNECTION_LOST")
                {
                    f.stateControler.ChangeStateTo(GameState.MainMenu);
                }
                else
                {
                    f.StatusLabel.Text = message;
                }
            }
            private void PlanHandler(string message)
            {
                f.stateControler.remotePlan.LoadPlanFromString(message);
            }
        }

        public void ReceiveMessage(string message)
        {
            Invoke(new Action(() =>
            {
                translator.TranslateMessage(message);
            }));
        }
    }
}
