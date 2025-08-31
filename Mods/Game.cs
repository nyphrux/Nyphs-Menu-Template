/*
 *  When using Nyphs Menu Template, feel free to modify or remove any code from this file.
 *  Please give credits to me, Nyph (@nyphrux), when using my template. 
 *          Love from Nyph (@nyphrux) <3
 *          (U) 2025
*/

using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using System;
using POpusCodec.Enums;
using UnityEngine;
using KID;
using Photon.Pun;

namespace NyphsMenuTemp.Mods
{
    internal class Game
    {
        public static void NincompoopServers()
        {
            PhotonNetwork.ConnectToRegion("nincompoop");
        }

        public static void EuropeServers()
        {
            PhotonNetwork.ConnectToRegion("eu");
        }

        public static void NorthAmericaServers()
        {
            PhotonNetwork.ConnectToRegion("na");
        }

        public static void SetAllMuteState(bool shouldMute)
        {
            foreach (var playerLine in GorillaScoreboardTotalUpdater.allScoreboardLines)
            {
                bool isMuted = playerLine.muteButton.isAutoOn;

                if (shouldMute && !isMuted)
                    playerLine.PressButton(true, GorillaPlayerLineButton.ButtonType.Mute);

                else if (!shouldMute && isMuted)
                    playerLine.PressButton(false, GorillaPlayerLineButton.ButtonType.Mute);
            }
        }

        public static void MuteAllPlayers()
        {
            SetAllMuteState(true);
        }

        public static void UnmuteAllPlayers()
        {
            SetAllMuteState(false);
        }

        public static void GoodMic()
        {
            Photon.Voice.Unity.Recorder mic = GameObject.Find("Photon Manager").GetComponent<Photon.Voice.Unity.Recorder>();
            mic.SamplingRate = SamplingRate.Sampling16000;
            mic.Bitrate = 30000;

            mic.RestartRecording(true);
        }

        public static void ShitMic()
        {
            Photon.Voice.Unity.Recorder mic = GameObject.Find("Photon Manager").GetComponent<Photon.Voice.Unity.Recorder>();
            mic.SamplingRate = SamplingRate.Sampling08000;
            mic.Bitrate = 50;

            mic.RestartRecording(true);
        }
    }
}
