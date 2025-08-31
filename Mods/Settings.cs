/*
 *  When using Nyphs Menu Template, feel free to modify or remove any code from this file.
 *  Please give credits to me, Nyph (@nyphrux), when using my template. 
 *          Love from Nyph (@nyphrux) <3
 *          (U) 2025
*/

using System.IO;
using NyphsMenuTemp.API.Notifications;
using NyphsMenuTemp.Classes;
using NyphsMenuTemp.Menu;
using static NyphsMenuTemp.Menu.Customization;
using static NyphsMenuTemp.Menu.Main;

namespace NyphsMenuTemp.Mods
{
    internal class Settings
    {
        public static void RightHand()
        {
            rightHanded = true;
        }

        public static void LeftHand()
        {
            rightHanded = false;
        }

        public static void EnableInfoText()
        {
            fpsCounter = true;
        }

        public static void DisableInfoText()
        {
            fpsCounter = false;
        }

        public static void EnableNotifications()
        {
            disableNotifications = false;
        }

        public static void DisableNotifications()
        {
            disableNotifications = true;
        }

        public static void EnableDisconnectButton()
        {
            disconnectButton = true;
        }

        public static void DisableDisconnectButton()
        {
            disconnectButton = false;
        }

        public static void EnableQuitButton()
        {
            quitButton = true;
        }

        public static void DisableQuitButton()
        {
            quitButton = false;
        }

        public static void EnableSettingsButton()
        {
            settingsButton = true;
        }

        public static void DisableSettingsButton()
        {
            settingsButton = false;
        }

        public static void SavePreferences()
        {
            string text = "";
            foreach (ButtonInfo[] buttonlist in Buttons.buttons)
            {
                foreach (ButtonInfo v in buttonlist)
                {
                    if (v.enabled && v.buttonText != "Save configs")
                    {
                        if (text == "")
                        {
                            text += v.buttonText;
                        }
                        else
                        {
                            text += "\n" + v.buttonText;
                        }
                    }
                }
            }

            if (!Directory.Exists(modDir))
            {
                Directory.CreateDirectory(modDir);
            }
            File.WriteAllText(modDir + "/EnabledMods.txt", text);
            File.WriteAllText(modDir + "/EnabledTheme.txt", themeType.ToString());
        }

        public static void LoadPreferences()
        {
            if (Directory.Exists(modDir))
            {
                TurnOffAllMods();
                try
                {
                    string config = File.ReadAllText(modDir + "/EnabledMods.txt");
                    string[] activebuttons = config.Split("\n");
                    for (int index = 0; index < activebuttons.Length; index++)
                    {
                        Toggle(activebuttons[index]);
                    }
                }
                catch { }
                string themer = File.ReadAllText(modDir + "/EnabledTheme.txt");

                themeType = int.Parse(themer) - 1;
                Toggle("Change theme >");
            }
        }

        public static void TurnOffAllMods()
        {
            foreach (ButtonInfo[] buttonlist in Buttons.buttons)
            {
                foreach (ButtonInfo v in buttonlist)
                {
                    if (v.enabled)
                    {
                        Toggle(v.buttonText);
                    }
                }
            }
            NotifiLib.ClearAllNotifications();
        }
    }
}
