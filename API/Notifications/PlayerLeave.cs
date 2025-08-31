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
    [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnPlayerLeftRoom")]
    internal class LeavePatch : MonoBehaviour
    {
        private static void Prefix(Player otherPlayer)
        {
            if (otherPlayer != PhotonNetwork.LocalPlayer && otherPlayer != a)
            {
                NotifiLib.SendNotification("<color=grey>[</color><color=red>" + otherPlayer.NickName + "</color><color=grey>]</color> <color=white>has left the lobby</color>");
                a = otherPlayer;
                Debug.Log(Customization.loggerPrefix + " > " + otherPlayer.NickName + "has left the lobby.");
            }
        }

        private static Player a;
    }
}