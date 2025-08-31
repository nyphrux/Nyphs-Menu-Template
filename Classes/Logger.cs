/*
 *  When using Nyphs Menu Template, feel free to modify or remove any code from this file.
 *  Please give credits to me, Nyph (@nyphrux), when using my template. 
 *          Love from Nyph (@nyphrux) <3
 *          (U) 2025
*/

using NyphsMenuTemp.API.Notifications;
using NyphsMenuTemp.Menu;
using UnityEngine;

namespace NyphsMenuTemp.Classes
{
    public static class Logger
    {
        public static void Info(string message)
        {
            Debug.Log(Customization.loggerPrefix + " > " + message);
        }

        public static void Warn(string message)
        {
            Debug.LogWarning(Customization.loggerPrefix + " > " + message);
        }

        public static void Error(string message)
        {
            Debug.LogError(Customization.loggerPrefix + " > " + message);
        }

        public static void LogInfoNotif(string message)
        {
            Debug.Log(Customization.loggerPrefix + " > " + message);
            NotifiLib.SendNotification("<color=grey>{Info}</color> " + message);
        }

        public static void LogWarnNotif(string message)
        {
            Debug.LogWarning(Customization.loggerPrefix + " > " + message);
            NotifiLib.SendNotification("<color=grey>{</color><color=yellow>Warn</color><color=grey>}</color> " + message);
        }

        public static void LogErrorNotif(string message)
        {
            Debug.LogError(Customization.loggerPrefix + " > " + message);
            NotifiLib.SendNotification("<color=grey>{</color><color=red>Error</color><color=grey>}</color> " + message);
        }
    }
}
