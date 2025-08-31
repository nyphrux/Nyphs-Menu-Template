/*
 *  When using Nyphs Menu Template, feel free to modify or remove any code from this file.
 *  Please give credits to me, Nyph (@nyphrux), when using my template. 
 *          Love from Nyph (@nyphrux) <3
 *          (U) 2025
*/

using Photon.Pun;
using UnityEngine;
using static NyphsMenuTemp.Menu.Main;

namespace NyphsMenuTemp.Mods
{
    internal class Global
    {
        public static void Empty() { }
        public static void ReturnHome()
        {
            buttonsType = 0;
        }

        public static void Disconnect()
        {
            PhotonNetwork.Disconnect();
        }

        public static void Quit()
        {
            Application.Quit();
        }

        public static void ConnectRandom()
        {
            PhotonNetwork.JoinRandomRoom();
        }
    }
}
