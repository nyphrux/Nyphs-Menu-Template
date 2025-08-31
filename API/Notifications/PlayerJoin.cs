/*
 *  When using Nyphs Menu Template, feel free to modify or remove any code from this file.
 *  Please give credits to me, Nyph (@nyphrux), when using my template. 
 *          Love from Nyph (@nyphrux) <3
 *          (U) 2025
*/

using HarmonyLib;
using NyphsMenuTemp.Menu;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace NyphsMenuTemp.API.Notifications
{
    [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnPlayerEnteredRoom")]
    internal class JoinPatch : MonoBehaviour
    {
        private static void Prefix(Player newPlayer)
        {
            if (newPlayer != oldnewplayer)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=green>" + newPlayer.NickName + "</color><color=grey>] </color><color=white>has joined the lobby</color>");
                oldnewplayer = newPlayer;
                Debug.Log(Customization.loggerPrefix + " > " + newPlayer.NickName + "has joined the lobby.");
            }
        }

        private static Player oldnewplayer;
    }
}