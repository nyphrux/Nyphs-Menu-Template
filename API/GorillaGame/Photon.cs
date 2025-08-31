/*
 *  When using Nyphs Menu Template, do not modify or remove any code from this file.
 *  Please give credits to me, Nyph (@nyphrux), when using my template. 
 *          Love from Nyph (@nyphrux) <3
 *          (U) 2025
*/

using Photon.Pun;
using Photon.Realtime;

namespace NyphsMenuTemp.API.GorillaGame
{
    internal class Photon
    {
        public static void JoinRoom(string roomName)
        {
            RoomOptions roomOptions = new RoomOptions() { MaxPlayers = 10 };
            PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
        }
    }
}
