/*
 *  When using Nyphs Menu Template, feel free to modify or remove any code from this file.
 *  Please give credits to me, Nyph (@nyphrux), when using my template. 
 *          Love from Nyph (@nyphrux) <3
 *          (U) 2025
*/

using NyphsMenuTemp.Classes;
using UnityEngine;
using static NyphsMenuTemp.Menu.Main;

namespace NyphsMenuTemp.Menu
{
    internal class Customization
    {
        public static ExtGradient bgColors = new ExtGradient { colors = GetMultiGradient(bgColorsA, bgColorsB) }; // Background Colors
        public static ExtGradient titleColors = new ExtGradient { colors = GetMultiGradient(titleColorsA, titleColorsB) }; // Background Colors

        public static ExtGradient[] btColors = new ExtGradient[]
        {
            new ExtGradient{ colors = GetMultiGradient(btDefaultA, btDefaultB) }, // Disabled Button Colors
            new ExtGradient{ colors = GetMultiGradient(btClickedA, btClickedB) } // Enabled Button Colors
        };

        public static ExtGradient[] txtColors = new ExtGradient[]
        {
            new ExtGradient{ colors = GetMultiGradient(txtDefaultA, txtDefaultB) }, // Disabled Text Colors
            new ExtGradient{ colors = GetMultiGradient(txtClickedA, txtClickedB) } // Enabled Text Colors
        };

        public static Font currentFont = sans;

        public static bool fpsCounter = true;
        public static bool disconnectButton = true;
        public static bool quitButton = true;
        public static bool settingsButton = true;
        public static bool rightHanded = false;
        public static bool disableNotifications = true;
        public static bool shouldOutline = true;
        public static bool highQualityText = false;
        public static bool overflowText = false;

        public static string modDir = "temp";
        public static string loggerPrefix = "temp";

        public static KeyCode keyboardButton = KeyCode.Q;

        public static Vector3 menuSize = new Vector3(0.1f, 1f, 1f); // Depth, Width, Height
        public static int buttonsPerPage = 9;

        public static void EnableOutlines()
        {
            shouldOutline = true;
        }

        public static void DisableOutlines()
        {
            shouldOutline = false;
        }

        public static void EnableHQText()
        {
            highQualityText = true;
        }

        public static void DisableHQText()
        {
            highQualityText = false;
        }

        public static void EnableOverflowText()
        {
            overflowText = true;
        }

        public static void DisableOverflowText()
        {
            overflowText = false;
        }

        public static void ChangeThemeTypeForwards()
        {
            themeType++;
            if (themeType > 5)
            {
                themeType = 1;
            }
            switch (themeType)
            {
                case 1: // Main
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Main] [1]";
                    bgColors = new ExtGradient{ colors = GetMultiGradient(new Color32(48, 25, 52, 255), new Color32(68, 36, 84, 255)) };
                    titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(220, 200, 255, 255), new Color32(240, 220, 255, 255)) };
                    btColors = new ExtGradient[]
                    {
                    new ExtGradient { colors = GetMultiGradient(new Color32(102, 51, 153, 255), new Color32(153, 102, 204, 255)) },
                    new ExtGradient { colors = GetMultiGradient(new Color32(124, 58, 237, 255), new Color32(165, 94, 234, 255)) }
                    };
                    txtColors = new ExtGradient[]
                    {
                    new ExtGradient { colors = GetMultiGradient(new Color32(230, 220, 255, 255), new Color32(230, 220, 255, 255)) },
                    new ExtGradient  { colors = GetMultiGradient(new Color32(230, 220, 255, 255), new Color32(230, 220, 255, 255)) }
                    };
                    return;
                case 2: // Midnight
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Midnight] [2]";
                    bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(1, 0, 62, 255), new Color32(2, 0, 93, 255)) };
                    titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(127, 124, 255, 255), new Color32(127, 124, 255, 255)) };
                    btColors = new ExtGradient[]
                    {
                        new ExtGradient{ colors = GetMultiGradient(new Color32(1, 0, 53, 255), new Color32(1, 0, 43, 255)) },
                        new ExtGradient{ colors = GetMultiGradient(new Color32(4, 0, 170, 255), new Color32(4, 0, 190, 255)) }
                    };
                    txtColors = new ExtGradient[]
                    {
                        new ExtGradient { colors = GetMultiGradient(new Color32(127, 124, 255, 255), new Color32(127, 124, 255, 255)) },
                        new ExtGradient { colors = GetMultiGradient(new Color32(2, 0, 94, 255), new Color32(2, 0, 94, 255)) }
                    };
                    return;
                case 3: // ii's Stupid Menu
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [ii's Stupid Menu] [3]";
                    bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 128, 0, 128), new Color32(255, 102, 0, 128)) };
                    titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 190, 125, 255), new Color32(255, 190, 125, 255)) };
                    btColors = new ExtGradient[]
                    {
                        new ExtGradient{ colors = GetMultiGradient(new Color32(170, 85, 0, 255), new Color32(170, 85, 0, 255)) },
                        new ExtGradient{ colors = GetMultiGradient(new Color32(85, 42, 0, 255), new Color32(85, 42, 0, 255)) }
                    };
                    txtColors = new ExtGradient[]
                    {
                        new ExtGradient { colors = GetMultiGradient(new Color32(255, 190, 125, 255), new Color32(255, 190, 125, 255)) },
                        new ExtGradient { colors = GetMultiGradient(new Color32(255, 190, 125, 255), new Color32(255, 190, 125, 255)) }
                    };
                    return;
            }
        }

        public static void ChangeThemeTypeBackwards()
        {
            themeType--;
            if (themeType < 1)
            {
                themeType = 5;
            }
            switch (themeType)
            {
                case 1: // Main
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Main] [1]";
                    bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(48, 25, 52, 255), new Color32(68, 36, 84, 255)) };
                    titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(220, 200, 255, 255), new Color32(240, 220, 255, 255)) };
                    btColors = new ExtGradient[]
                    {
                    new ExtGradient { colors = GetMultiGradient(new Color32(102, 51, 153, 255), new Color32(153, 102, 204, 255)) },
                    new ExtGradient { colors = GetMultiGradient(new Color32(124, 58, 237, 255), new Color32(165, 94, 234, 255)) }
                    };
                    txtColors = new ExtGradient[]
                    {
                    new ExtGradient { colors = GetMultiGradient(new Color32(230, 220, 255, 255), new Color32(230, 220, 255, 255)) },
                    new ExtGradient  { colors = GetMultiGradient(new Color32(230, 220, 255, 255), new Color32(230, 220, 255, 255)) }
                    };
                    return;
                case 2: // Midnight (Originally made by Bando, fixed by me)
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [Midnight] [2]";
                    bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(1, 0, 62, 255), new Color32(2, 0, 93, 255)) };
                    titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(127, 124, 255, 255), new Color32(127, 124, 255, 255)) };
                    btColors = new ExtGradient[]
                    {
                        new ExtGradient{ colors = GetMultiGradient(new Color32(1, 0, 53, 255), new Color32(1, 0, 43, 255)) },
                        new ExtGradient{ colors = GetMultiGradient(new Color32(4, 0, 170, 255), new Color32(4, 0, 190, 255)) }
                    };
                    txtColors = new ExtGradient[]
                    {
                        new ExtGradient { colors = GetMultiGradient(new Color32(127, 124, 255, 255), new Color32(127, 124, 255, 255)) },
                        new ExtGradient { colors = GetMultiGradient(new Color32(2, 0, 94, 255), new Color32(2, 0, 94, 255)) }
                    };
                    return;
                case 3: // ii's Stupid Menu
                    GetIndex("Theme: [Main] [1]").overlapText = "Theme: [ii's Stupid Menu] [3]";
                    bgColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 128, 0, 128), new Color32(255, 102, 0, 128)) };
                    titleColors = new ExtGradient { colors = GetMultiGradient(new Color32(255, 190, 125, 255), new Color32(255, 190, 125, 255)) };
                    btColors = new ExtGradient[]
                    {
                        new ExtGradient{ colors = GetMultiGradient(new Color32(170, 85, 0, 255), new Color32(170, 85, 0, 255)) },
                        new ExtGradient{ colors = GetMultiGradient(new Color32(85, 42, 0, 255), new Color32(85, 42, 0, 255)) }
                    };
                    txtColors = new ExtGradient[]
                    {
                        new ExtGradient { colors = GetMultiGradient(new Color32(255, 190, 125, 255), new Color32(255, 190, 125, 255)) },
                        new ExtGradient { colors = GetMultiGradient(new Color32(255, 190, 125, 255), new Color32(255, 190, 125, 255)) }
                    };
                    return;
            }
        }

        public static void ChangeFontTypeBackwards()
        {
            fontType--;
            if (fontType < 0) // to get the number of fonts exactly, add 1 onto this number
            {
                fontType = 26;
            }

            switch (fontType)
            {
                case 0:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Comic Sans] [1]";
                    currentFont = sans;
                    return;
                case 1:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Arial] [2]";
                    currentFont = Arial;
                    return;
                case 2:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Berdana] [3]";
                    currentFont = Verdana;
                    return;
                case 3:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Consolas] [5]";
                    currentFont = consolas;
                    return;
                case 4:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Ubuntu] [6]";
                    currentFont = ubuntu;
                    return;
                case 5:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Msgothic] [7]";
                    currentFont = MSGOTHIC;
                    return;
                case 6:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Impact] [8]";
                    currentFont = impact;
                    return;
                case 7:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Bahnschrift] [9]";
                    currentFont = bahnschrift;
                    return;
                case 8:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Calibri] [10]";
                    currentFont = calibri;
                    return;
                case 9:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Cambria] [11]";
                    currentFont = cambria;
                    return;
                case 10:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Cascadia Code] [12]";
                    currentFont = cascadiacode;
                    return;
                case 11:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Constantia] [13]";
                    currentFont = constantia;
                    return;
                case 12:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Corbel] [14]";
                    currentFont = corbel;
                    return;
                case 13:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Courier New] [15]";
                    currentFont = couriernew;
                    return;
                case 14:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Dengxian] [16]";
                    currentFont = dengxian;
                    return;
                case 15:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Ebrima] [17]";
                    currentFont = ebrima;
                    return;
                case 16:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Fangsong] [18]";
                    currentFont = fangsong;
                    return;
                case 17:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Franklin Gothic] [19]";
                    currentFont = franklingothic;
                    return;
                case 18:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Gabriola] [20]";
                    currentFont = gabriola;
                    return;
                case 19:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Gadugi] [21]";
                    currentFont = gadugi;
                    return;
                case 20:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Georgia] [22]";
                    currentFont = georgia;
                    return;
                case 21:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Hololens] [23]";
                    currentFont = hololens;
                    return;
                case 22:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Ink Free] [24]";
                    currentFont = inkfree;
                    return;
                case 23:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Javanese Text] [25]";
                    currentFont = javanesetext;
                    return;
                case 24:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Kaiti] [26]";
                    currentFont = kaiti;
                    return;
                case 25:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Lucida Console] [27]";
                    currentFont = lucidaconsole;
                    return;
            }
        }

        public static void ChangeFontTypeForwards()
        {
            fontType++;
            if (fontType > 26) // to get the number of fonts exactly, add 1 onto this number
            {
                fontType = 0;
            }

            switch (fontType)
            {
                case 0:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Comic Sans] [1]";
                    currentFont = sans;
                    return;
                case 1:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Arial] [2]";
                    currentFont = Arial;
                    return;
                case 2:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Berdana] [3]";
                    currentFont = Verdana;
                    return;
                case 3:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Consolas] [5]";
                    currentFont = consolas;
                    return;
                case 4:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Ubuntu] [6]";
                    currentFont = ubuntu;
                    return;
                case 5:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Msgothinc] [7]";
                    currentFont = MSGOTHIC;
                    return;
                case 6:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Impact] [8]";
                    currentFont = impact;
                    return;
                case 7:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Bahnschrift] [9]";
                    currentFont = bahnschrift;
                    return;
                case 8:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Calibri] [10]";
                    currentFont = calibri;
                    return;
                case 9:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Cambria] [11]";
                    currentFont = cambria;
                    return;
                case 10:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Cascadia Code] [12]";
                    currentFont = cascadiacode;
                    return;
                case 11:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Constantia] [13]";
                    currentFont = constantia;
                    return;
                case 12:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Corbel] [14]";
                    currentFont = corbel;
                    return;
                case 13:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Courier New] [15]";
                    currentFont = couriernew;
                    return;
                case 14:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Dengxian] [16]";
                    currentFont = dengxian;
                    return;
                case 15:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Ebrima] [17]";
                    currentFont = ebrima;
                    return;
                case 16:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Fangsong] [18]";
                    currentFont = fangsong;
                    return;
                case 17:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Franklin Gothic] [19]";
                    currentFont = franklingothic;
                    return;
                case 18:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Gabriola] [20]";
                    currentFont = gabriola;
                    return;
                case 19:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Gadugi] [21]";
                    currentFont = gadugi;
                    return;
                case 20:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Georgia] [22]";
                    currentFont = georgia;
                    return;
                case 21:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Hololens] [23]";
                    currentFont = hololens;
                    return;
                case 22:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Ink Free] [24]";
                    currentFont = inkfree;
                    return;
                case 23:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Javanese Text] [25]";
                    currentFont = javanesetext;
                    return;
                case 24:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Kaiti] [26]";
                    currentFont = kaiti;
                    return;
                case 25:
                    GetIndex("Font: [Comic Sans] [1]").overlapText = "Font: [Lucida Console] [27]";
                    currentFont = lucidaconsole;
                    return;
            }
        }
    }
}
