/*
 *  When using Nyphs Menu Template, feel free to modify or remove any code from this file.
 *  Please give credits to me, Nyph (@nyphrux), when using my template. 
 *          Love from Nyph (@nyphrux) <3
 *          (U) 2025
*/

using BepInEx;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

namespace NyphsMenuTemp.Mods
{
    internal class Movement
    {
        private static float flySpeed = 10f;
        private static float yaw;
        private static float pitch;
        private static Collider[] playerColliders;
        private static bool initialized = false;

        public static void WASDFly()
        {
            Rigidbody rb = GorillaTagger.Instance.rigidbody;
            Transform cam = GorillaTagger.Instance.headCollider.transform;

            if (!initialized)
            {
                playerColliders = GorillaTagger.Instance.GetComponentsInChildren<Collider>(true);

                if (cam.parent != null)
                {
                    yaw = cam.parent.eulerAngles.y;
                    pitch = GetSignedAngle(cam.localEulerAngles.x);
                }

                initialized = true;
            }

            rb.velocity = Vector3.zero;
            rb.useGravity = false;

            Vector3 moveDirection = Vector3.zero;
            float speed = flySpeed;

            if (Keyboard.current.leftShiftKey.isPressed) speed *= 3f;
            if (Keyboard.current.cKey.isPressed) speed *= 10f;
            if (Keyboard.current.vKey.isPressed) speed *= 50f;

            if (Keyboard.current.wKey.isPressed) moveDirection += cam.forward;
            if (Keyboard.current.sKey.isPressed) moveDirection -= cam.forward;
            if (Keyboard.current.aKey.isPressed) moveDirection -= cam.right;
            if (Keyboard.current.dKey.isPressed) moveDirection += cam.right;
            if (Keyboard.current.spaceKey.isPressed) moveDirection += cam.up;
            if (Keyboard.current.leftCtrlKey.isPressed || (Keyboard.current.leftShiftKey.isPressed && Keyboard.current.sKey.isPressed)) moveDirection -= cam.up; // it doesnt fit :(

            moveDirection.Normalize();
            rb.transform.position += moveDirection * speed * Time.unscaledDeltaTime;

            if (Mouse.current.rightButton.isPressed)
            {
                yaw += Mouse.current.delta.x.ReadValue() * 0.3f;
                pitch -= Mouse.current.delta.y.ReadValue() * 0.3f;
                pitch = Mathf.Clamp(pitch, -89f, 89f);

                if (cam.parent != null)
                {
                    cam.parent.rotation = Quaternion.Euler(0f, yaw, 0f);
                    cam.localRotation = Quaternion.Euler(pitch, 0f, 0f);
                }
            }
        }

        private static float GetSignedAngle(float angle)
        {
            return angle > 180f ? angle - 360f : angle;
        }

        public static void LowGravity()
        {
            Physics.gravity = new Vector3(0, -3f, 0f);
        }

        public static void HighGravity()
        {
            Physics.gravity = new Vector3(0, -15f, 0);
        }

        public static void NormalGravity()
        {
            Physics.gravity = new Vector3(0, -9.81f, 0);
        }
    }
}
