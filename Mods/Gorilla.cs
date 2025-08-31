/*
 *  When using Nyphs Menu Template, feel free to modify or remove any code from this file.
 *  Please give credits to me, Nyph (@nyphrux), when using my template. 
 *          Love from Nyph (@nyphrux) <3
 *          (U) 2025
*/

using UnityEngine;

namespace NyphsMenuTemp.Mods
{
    internal class Gorilla
    {
        public static void FixGorillaBody()
        {
            VRRig.LocalRig.head.trackingRotationOffset.x = 0f;
            VRRig.LocalRig.head.trackingRotationOffset.y = 0f;
            VRRig.LocalRig.head.trackingRotationOffset.z = 0f;

            VRRig.LocalRig.leftHand.rigTarget.transform.rotation *= Quaternion.Euler(VRRig.LocalRig.leftHand.trackingRotationOffset);
            VRRig.LocalRig.rightHand.rigTarget.transform.rotation *= Quaternion.Euler(VRRig.LocalRig.rightHand.trackingRotationOffset);

            VRRig.LocalRig.leftHand.trackingPositionOffset.x = 0f;
            VRRig.LocalRig.leftHand.trackingPositionOffset.y = 0f;
            VRRig.LocalRig.leftHand.trackingPositionOffset.z = 0f;

            VRRig.LocalRig.rightHand.trackingPositionOffset.x = 0f;
            VRRig.LocalRig.rightHand.trackingPositionOffset.y = 0f;
            VRRig.LocalRig.rightHand.trackingPositionOffset.z = 0f;
        }

        public static void BrokenNeck()
        {
            VRRig.LocalRig.head.trackingRotationOffset.z = 90f;
        }

        public static void BackwardsHead()
        {
            VRRig.LocalRig.head.trackingRotationOffset.y = 180f;
        }

        public static void SidewaysHead()
        {
            VRRig.LocalRig.head.trackingRotationOffset.y = 90f;
        }

        public static void SpinHead()
        {
            VRRig.LocalRig.head.trackingRotationOffset = new Vector3(0f, 0f, Time.time * 360f);
        }

        public static void TiltHeadLeft()
        {
            VRRig.LocalRig.head.trackingRotationOffset.y = -60f;
        }

        public static void TiltHeadRight()
        {
            VRRig.LocalRig.head.trackingRotationOffset.y = 60f;
        }

        public static void HeadLookingDown()
        {
            VRRig.LocalRig.head.trackingRotationOffset.x = 90f;
        }

        public static void HeadLookingUp()
        {
            VRRig.LocalRig.head.trackingRotationOffset.x = -90f;
        }

        public static void WobbleHead()
        {
            VRRig.LocalRig.head.trackingRotationOffset = new Vector3(
                Mathf.Sin(Time.time * 5f) * 30f,
                Mathf.Cos(Time.time * 5f) * 30f,
                Mathf.Sin(Time.time * 3f) * 30f
            );
        }

        public static void SpazHead()
        {
            VRRig.LocalRig.head.trackingRotationOffset = new Vector3(
                UnityEngine.Random.Range(-180f, 180f),
                UnityEngine.Random.Range(-180f, 180f),
                UnityEngine.Random.Range(-180f, 180f)
            );
        }

        public static void SpazHands()
        {
            VRRig.LocalRig.leftHand.trackingRotationOffset = new Vector3(
                UnityEngine.Random.Range(-180f, 180f),
                UnityEngine.Random.Range(-180f, 180f),
                UnityEngine.Random.Range(-180f, 180f)
            );
            VRRig.LocalRig.rightHand.trackingRotationOffset = new Vector3(
                UnityEngine.Random.Range(-180f, 180f),
                UnityEngine.Random.Range(-180f, 180f),
                UnityEngine.Random.Range(-180f, 180f)
            );
        }

        public static void SpazArms()
        {
            VRRig.LocalRig.leftHand.trackingPositionOffset = new Vector3(
                UnityEngine.Random.Range(-180f, 180f),
                UnityEngine.Random.Range(-180f, 180f),
                UnityEngine.Random.Range(-180f, 180f)
            );
            VRRig.LocalRig.rightHand.trackingPositionOffset = new Vector3(
                UnityEngine.Random.Range(-180f, 180f),
                UnityEngine.Random.Range(-180f, 180f),
                UnityEngine.Random.Range(-180f, 180f)
            );
        }
    }
}
