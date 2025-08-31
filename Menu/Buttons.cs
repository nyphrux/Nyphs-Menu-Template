/*
 *  When using Nyphs Menu Template, feel free to modify or remove any code from this file.
 *  Please give credits to me, Nyph (@nyphrux), when using my template. 
 *          Love from Nyph (@nyphrux) <3
 *          (U) 2025
*/

using NyphsMenuTemp.Classes;
using NyphsMenuTemp.Mods;
using static NyphsMenuTemp.Menu.Customization;
using static NyphsMenuTemp.Menu.Categories;
using NyphsMenuTemp.API.Notifications;

namespace NyphsMenuTemp.Menu
{
    internal class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Home Page [0]
                new ButtonInfo { buttonText = "Settings", method =() => EnterSettings(), isTogglable = false, toolTip = "Sends you to the settings page for the menu"},
                new ButtonInfo { buttonText = "Game", method =() => EnterGameMods(), isTogglable = false, toolTip = "Sends you to the game mods page for the menu"},
                new ButtonInfo { buttonText = "Movement", method =() => EnterMovementMods(), isTogglable = false, toolTip = "Sends you to the movement mods page for the menu"},
                new ButtonInfo { buttonText = "Safety", method =() => EnterSafetyMods(), isTogglable = false, toolTip = "Sends you to the safety mods page for the menu"},
                new ButtonInfo { buttonText = "Gorilla", method =() => EnterGorillaMods(), isTogglable = false, toolTip = "Sends you to the gorilla mods page for the menu"},
            },

            new ButtonInfo[] { // Settings [1]
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Sends you to the main page"},

                new ButtonInfo { buttonText = "Menu Settings", method =() => EnterMenuSettings(), isTogglable = false, toolTip = "Opens the settings page for the menu"},
                new ButtonInfo { buttonText = "Info", method =() => EnterInfoPage(), isTogglable = false, toolTip = "Sends you to the info page for the menu"},
                new ButtonInfo { buttonText = "Configuration", method =() => EnterCustomizationSettings(), isTogglable = false, toolTip = "Opens the settings page to configure certain things"},
                new ButtonInfo { buttonText = "Notification", method =() => EnterNotificationSettings(), isTogglable = false, toolTip = "Opens the settings page to change notification settings"},
            },

            new ButtonInfo[] { // Menu Settings [2]
                new ButtonInfo { buttonText = "Return to Settings", method =() => EnterSettings(), isTogglable = false, toolTip = "Sends you to the main page"},

                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => Settings.RightHand(), disableMethod =() => Settings.LeftHand(), toolTip = "Makes the menu appear on your right hand (for lefties)"},
                new ButtonInfo { buttonText = "Info Text", enableMethod =() => Settings.EnableInfoText(), disableMethod =() => Settings.DisableInfoText(), enabled = fpsCounter, toolTip = "Toggles info text on/off"},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => Settings.EnableDisconnectButton(), disableMethod =() => Settings.DisableDisconnectButton(), enabled = disconnectButton, toolTip = "Toggles disconnect button on/off"},
                new ButtonInfo { buttonText = "Quit Button", enableMethod =() => Settings.EnableQuitButton(), disableMethod =() => Settings.DisableQuitButton(), enabled = quitButton, toolTip = "Toggles quit button on/off"},
                new ButtonInfo { buttonText = "Settings Button", enableMethod =() => Settings.EnableSettingsButton(), disableMethod =() => Settings.DisableSettingsButton(), enabled = settingsButton, toolTip = "Toggles settings button on/off"},
            },
            
            new ButtonInfo[] { // Customization Settings [3]
                new ButtonInfo { buttonText = "Return to Settings", method =() => EnterSettings(), isTogglable = false, toolTip = "Sends you to the main page"},

                new ButtonInfo { buttonText = "Theme: [Main] [1]", isTogglable = false},
                new ButtonInfo { buttonText = "Change theme <", method =() => ChangeThemeTypeBackwards(), isTogglable = false, toolTip = "Changes the theme backwards by 1"},
                new ButtonInfo { buttonText = "Change theme >", method =() => ChangeThemeTypeForwards(), isTogglable = false, toolTip = "Changes the theme forwards by 1"},
                new ButtonInfo { buttonText = "Font: [Comic Sans] [1]", isTogglable = false},
                new ButtonInfo { buttonText = "Change font <", method =() => ChangeFontTypeBackwards(), isTogglable = false, toolTip = "Changes the font backwards by 1"},
                new ButtonInfo { buttonText = "Change font >", method =() => ChangeFontTypeForwards(), isTogglable = false, toolTip = "Changes the font forwards by 1"},
                new ButtonInfo { buttonText = "High quality text", disableMethod =() => DisableHQText(), enableMethod =() => EnableHQText(), toolTip = "Makes menu text more readable"},
                new ButtonInfo { buttonText = "Overflow text", disableMethod =() => DisableOverflowText(), enableMethod =() => EnableOverflowText(), toolTip = "All text is the same size, no matter the length"},
                new ButtonInfo { buttonText = "Disable Outlines", disableMethod =() => EnableOutlines(), enableMethod =() => DisableOutlines(), toolTip = "Adds outlines to the menu"},
                new ButtonInfo { buttonText = "Save configs", method =() => Settings.SavePreferences(), isTogglable = false, toolTip = "Saves your configs"},
                new ButtonInfo { buttonText = "Load configs", method =() => Settings.LoadPreferences(), isTogglable = false, toolTip = "Loads your configs"},
            },

            new ButtonInfo[] { // Notification Settings [4]
                new ButtonInfo { buttonText = "Return to Settings", method =() => EnterSettings(), isTogglable = false, toolTip = "Sends you to the main page"},

                new ButtonInfo { buttonText = "Allow Notifs", enableMethod =() => Settings.EnableNotifications(), disableMethod =() => Settings.DisableNotifications(), enabled = disableNotifications, toolTip = "Toggles notifications on/off"},
                new ButtonInfo { buttonText = "Clear Notifs", enableMethod =() => NotifiLib.ClearAllNotifications(), isTogglable = false, toolTip = "Empties notification history"},
            },

            new ButtonInfo[] { // Info [5]
                new ButtonInfo { buttonText = "Return to Settings", method =() => EnterSettings(), isTogglable = false, toolTip = "Sends you to the main page"},

                new ButtonInfo { buttonText = "W = Working", method =() => Global.Empty(), isTogglable = false},
                new ButtonInfo { buttonText = "NW = Not Working", method =() => Global.Empty(), isTogglable = false},
                new ButtonInfo { buttonText = "D = Detected", method =() => Global.Empty(), isTogglable = false},
                new ButtonInfo { buttonText = "KD = Kinda Detected", method =() => Global.Empty(), isTogglable = false},
                new ButtonInfo { buttonText = "DB = Delayed Ban", method =() => Global.Empty(), isTogglable = false},
                new ButtonInfo { buttonText = "IB = Insta Ban", method =() => Global.Empty(), isTogglable = false},
                new ButtonInfo { buttonText = "CS = Client Sided", method =() => Global.Empty(), isTogglable = false},
                new ButtonInfo { buttonText = "SS = Server Sided", method =() => Global.Empty(), isTogglable = false},
            },

            new ButtonInfo[]{ // Game [6]
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Sends you to the main page"},

                new ButtonInfo { buttonText = "Disconnect", method =() => Global.Disconnect(), isTogglable = false, toolTip = "Disconnects you from the room"},
                new ButtonInfo { buttonText = "Join Random", method =() => Global.ConnectRandom(), isTogglable = false, toolTip = "Connects you to a random room"},
                new ButtonInfo { buttonText = "Mute All", method =() => Game.MuteAllPlayers(), isTogglable = false, toolTip = "Mutes everyone"},
                new ButtonInfo { buttonText = "Unmute All", method =() => Game.UnmuteAllPlayers(), isTogglable = false, toolTip = "Unmutes everyone"},
                new ButtonInfo { buttonText = "Good Mic", method =() => Game.GoodMic(), isTogglable = false, toolTip = "Makes your mic good ingame"},
                new ButtonInfo { buttonText = "Shit Mic", method =() => Game.ShitMic(), isTogglable = false, toolTip = "Makes your mic shit ingame"},
            },

            new ButtonInfo[]{ // Movement [7]
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Sends you to the main page"},

                new ButtonInfo { buttonText = "WASD Fly", method =() => Movement.WASDFly(), toolTip = "Makes you flyyy with WASD on pc"},
                new ButtonInfo { buttonText = "Low Grav", method =() => Movement.LowGravity(), disableMethod =() => Movement.NormalGravity(), toolTip = "Makes your gravity very low"},
                new ButtonInfo { buttonText = "High Grav", method =() => Movement.HighGravity(), disableMethod =() => Movement.NormalGravity(), toolTip = "Makes your gravity very high"},
            },

            new ButtonInfo[]{ // Safety [8]
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Sends you to the main page"},

                new ButtonInfo { buttonText = "No Finger Movement", method =() => Safety.NoFinger(), toolTip = "Stops your fingers from moving"},
                new ButtonInfo { buttonText = "Panic", method =() => Settings.TurnOffAllMods(), toolTip = "Turns off every mod"},
            },

            new ButtonInfo[]{ // Gorilla [9]
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns you to the main page of the menu"},
                
                new ButtonInfo { buttonText = "Broken Neck", method =() => Gorilla.BrokenNeck(), disableMethod =() => Gorilla.FixGorillaBody(), toolTip = "Snap your neck"},
                new ButtonInfo { buttonText = "Backwards Neck", method =() => Gorilla.BackwardsHead(), disableMethod =() => Gorilla.FixGorillaBody(), toolTip = "Head go 180 turn"},
                new ButtonInfo { buttonText = "Sideways Neck", method =() => Gorilla.SidewaysHead(), disableMethod =() => Gorilla.FixGorillaBody(), toolTip = "Makes your head go sideways onto neck"},
                
                new ButtonInfo { buttonText = "Tilt Head Left", method =() => Gorilla.TiltHeadLeft(), disableMethod =() => Gorilla.FixGorillaBody(), toolTip = "Tilts your head to the left"},
                new ButtonInfo { buttonText = "Tilt Head Right", method =() => Gorilla.TiltHeadRight(), disableMethod =() => Gorilla.FixGorillaBody(), toolTip = "Tilts your head to the right"},
               
                new ButtonInfo { buttonText = "Look Down", method =() => Gorilla.HeadLookingDown(), disableMethod =() => Gorilla.FixGorillaBody(), toolTip = "Forces your head to look downward"},
                new ButtonInfo { buttonText = "Look Up", method =() => Gorilla.HeadLookingUp(), disableMethod =() => Gorilla.FixGorillaBody(), toolTip = "Forces your head to look upward"},
                
                new ButtonInfo { buttonText = "Spin Head", method =() => Gorilla.SpinHead(), disableMethod =() => Gorilla.FixGorillaBody(), toolTip = "Continuously spins your head around"},
                new ButtonInfo { buttonText = "Wobble Head", method =() => Gorilla.WobbleHead(), disableMethod =() => Gorilla.FixGorillaBody(), toolTip = "Makes your head wobble chaotically"},
                
                new ButtonInfo { buttonText = "Spaz Head", method =() => Gorilla.SpazHead(), disableMethod =() => Gorilla.FixGorillaBody(), toolTip = "Applies random rotation to your head on all axes"},
                new ButtonInfo { buttonText = "Spaz Hands", method =() => Gorilla.SpazHands(), disableMethod =() => Gorilla.FixGorillaBody(), toolTip = "Applies random rotation to your hands on all axes"},
                new ButtonInfo { buttonText = "Spaz Arms", method =() => Gorilla.SpazArms(), disableMethod =() => Gorilla.FixGorillaBody(), toolTip = "Applies random position to your arms on all axes"},
            },
        };
    }
}