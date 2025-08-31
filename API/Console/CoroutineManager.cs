/*
 *  When using Nyphs Menu Template, do not modify or remove any code from this file.
 *  Please give credits to me, Nyph (@nyphrux), when using my template. 
 *          Love from Nyph (@nyphrux) <3
 *          (U) 2025
*/

using System.Collections;
using UnityEngine;

namespace NyphsMenuTemp.API.Console
{
    public class CoroutineManager : MonoBehaviour
    {
        public static CoroutineManager instance = null;

        private void Awake() =>
            instance = this;

        public static Coroutine RunCoroutine(IEnumerator enumerator) =>
            instance.StartCoroutine(enumerator);
        
        public static void EndCoroutine(Coroutine enumerator) =>
            instance.StopCoroutine(enumerator);
    }
}
