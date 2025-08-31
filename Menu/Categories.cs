/*
 *  When using Nyphs Menu Template, feel free to modify or remove any code from this file.
 *  Please give credits to me, Nyph (@nyphrux), when using my template. 
 *          Love from Nyph (@nyphrux) <3
 *          (U) 2025
*/

using static NyphsMenuTemp.Menu.Main;

namespace NyphsMenuTemp.Menu
{
    internal class Categories
    {
        // Settings categories
        public static void EnterSettings() { buttonsType = 1; }
        public static void EnterMenuSettings() { buttonsType = 2; }
        public static void EnterCustomizationSettings() { buttonsType = 3; }
        public static void EnterNotificationSettings() { buttonsType = 4; }
        public static void EnterInfoPage() { buttonsType = 5; }

        // Mods categories
        public static void EnterGameMods() { buttonsType = 6; }
        public static void EnterMovementMods() { buttonsType = 7; }
        public static void EnterSafetyMods() { buttonsType = 8; }
        public static void EnterGorillaMods() { buttonsType = 9; }
    }
}
