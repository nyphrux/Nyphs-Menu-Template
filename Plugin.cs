/*
 *  When using Nyphs Menu Template, feel free to modify or remove any code from this file.
 *  Please give credits to me, Nyph (@nyphrux), when using my template. 
 *          Love from Nyph (@nyphrux) <3
 *          (U) 2025
*/

using System.ComponentModel;
using BepInEx;
using NyphsMenuTemp.API.Console;
using NyphsMenuTemp.Menu;
using NyphsMenuTemp.Mods;
using UnityEngine;

namespace NyphsMenuTemp.Patches
{
    [Description(PluginInfo.Description)]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class HarmonyPatches : BaseUnityPlugin
    {
        private void OnEnable()
        {
            System.Console.Title = $"{PluginInfo.Name} [v{PluginInfo.Version}] | Gorilla Tag";
            Classes.Logger.Info($"Welcome to {PluginInfo.Name} - v{PluginInfo.Version}");
            Menu.ApplyHarmonyPatches();
            GorillaTagger.OnPlayerSpawned(OnPlayerSpawned);
        }

        private void OnDisable()
        {
            Menu.RemoveHarmonyPatches();
            Settings.SavePreferences();
        }

        private void OnPlayerSpawned()
        {
            string consoleName = $"goldentrophy_Console_{Console.ConsoleVersion}";
            GameObject consoleObj = GameObject.Find(consoleName);

            if (consoleObj == null)
            {
                consoleObj = new GameObject(consoleName);
                consoleObj.AddComponent<CoroutineManager>();
                consoleObj.AddComponent<Console>();

                if (ServerData.ServerDataEnabled)
                    consoleObj.AddComponent<ServerData>();
            }
        }
    }
}
