/*
 *  When using Nyphs Menu Template, do not modify or remove any code from this file.
 *  Please give credits to me, Nyph (@nyphrux), when using my template. 
 *          Love from Nyph (@nyphrux) <3
 *          (U) 2025
*/

using GorillaNetworking;
using Photon.Pun;
using UnityEngine;

namespace NyphsMenuTemp.API.GorillaGame
{
    internal class Gorilla
    {
        public static void SetName(string newName)
        {
            var gc = GorillaComputer.instance;
            gc.currentName = newName;
            gc.SetLocalNameTagText(newName);
            gc.savedName = newName;

            PlayerPrefs.SetString("playerName", newName);
            PlayerPrefs.Save();

            PhotonNetwork.LocalPlayer.NickName = newName;

            try
            {
                var localUserId = PhotonNetwork.LocalPlayer.UserId;
                bool inFriendZone = gc.friendJoinCollider.playerIDsCurrentlyTouching.Contains(localUserId);
                bool nearWardrobe = CosmeticWardrobeProximityDetector.IsUserNearWardrobe(localUserId);

                if (inFriendZone || nearWardrobe)
                {
                    var col = VRRig.LocalRig.playerColor;
                    GorillaTagger.Instance.myVRRig.SendRPC(
                        "RPC_InitializeNoobMaterial",
                        RpcTarget.All,
                        new object[] { col.r, col.g, col.b }
                    );
                }
            }
            catch { }
        }

        public static void SetColor(Color newCol)
        {
            PlayerPrefs.SetFloat("redValue", Mathf.Clamp01(newCol.r));
            PlayerPrefs.SetFloat("greenValue", Mathf.Clamp01(newCol.g));
            PlayerPrefs.SetFloat("blueValue", Mathf.Clamp01(newCol.b));

            GorillaTagger.Instance.UpdateColor(newCol.r, newCol.g, newCol.b);
            PlayerPrefs.Save();

            try
            {
                GorillaTagger.Instance.myVRRig.SendRPC(
                    "RPC_InitializeNoobMaterial",
                    RpcTarget.All,
                    new object[] { newCol.r, newCol.g, newCol.b }
                );
            }
            catch { }
        }
    }
}
