/*
 *  When using Nyphs Menu Template, feel free to modify or remove any code from this file.
 *  Please give credits to me, Nyph (@nyphrux), when using my template. 
 *          Love from Nyph (@nyphrux) <3
 *          (U) 2025
*/

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;
using NyphsMenuTemp.API.Notifications;
using NyphsMenuTemp.Classes;
using NyphsMenuTemp.Mods;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static NyphsMenuTemp.Menu.Buttons;
using static NyphsMenuTemp.Menu.Customization;

namespace NyphsMenuTemp.Menu
{
    [HarmonyPatch(typeof(GorillaLocomotion.GTPlayer))]
    [HarmonyPatch("LateUpdate", MethodType.Normal)]
    public class Main : MonoBehaviour
    {
        public static void Prefix()
        {
            // Initialize Menu
            try
            {
                bool toOpen = !rightHanded && ControllerInputPoller.instance.leftControllerSecondaryButton || rightHanded && ControllerInputPoller.instance.rightControllerSecondaryButton;
                bool keyboardOpen = UnityInput.Current.GetKey(keyboardButton);

                if (menu == null)
                {
                    if (toOpen || keyboardOpen)
                    {
                        CreateMenu();
                        RecenterMenu(rightHanded, keyboardOpen);
                        if (reference == null)
                        {
                            CreateReference(rightHanded);
                        }
                    }
                }
                else
                {
                    if (toOpen || keyboardOpen)
                    {
                        RecenterMenu(rightHanded, keyboardOpen);
                    }
                    else
                    {
                        GameObject.Find("Shoulder Camera").transform.Find("CM vcam1").gameObject.SetActive(true);

                        Rigidbody comp = menu.AddComponent(typeof(Rigidbody)) as Rigidbody;
                        if (rightHanded)
                        {
                            comp.velocity = GorillaLocomotion.GTPlayer.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                        }
                        else
                        {
                            comp.velocity = GorillaLocomotion.GTPlayer.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                        }

                        Destroy(menu, 2);
                        menu = null;

                        Destroy(reference);
                        reference = null;
                    }
                }
            }
            catch (Exception exc)
            {
                Classes.Logger.Error(string.Format("{0} // Error initializing at {1}: {2}", PluginInfo.Name, exc.StackTrace, exc.Message));
            }

            // Boards
            GameObject cocHeadingText = GameObject.Find("CodeOfConductHeadingText");
            GameObject cocBodyText = GameObject.Find("COCBodyText_TitleData");
            GameObject motdHeadingText = GameObject.Find("motdHeadingText");
            GameObject motdBodyText = GameObject.Find("motdBodyText");

            if (cocHeadingText != null) cocHeadingText.GetComponent<TMP_Text>().text = $"<color=purple>{PluginInfo.Name}</color> <color=blue>{PluginInfo.Version}</color>";
            if (cocBodyText != null)
            {
                cocBodyText.GetComponent<TMP_Text>().text = "Developer: @your_username\n\nTemplate Developer: @nyphrux\n\nCredits to @libyyyyy [liby/adlibs] for the menu. Now im using it as a template for people!";
                cocBodyText.GetComponent<TMP_Text>().alignment = TextAlignmentOptions.Center;
            }

            if (motdHeadingText != null) motdHeadingText.GetComponent<TMP_Text>().text = $"<color=purple>{PluginInfo.Name}</color> <color=blue>{PluginInfo.Version}</color>";
            if (motdBodyText != null)
            {
                motdBodyText.GetComponent<TMP_Text>().text = $"-LOADING-";
                motdBodyText.GetComponent<TMP_Text>().alignment = TextAlignmentOptions.Center;
            }

            // Constant
            try
            {
                // Pre-Execution
                if (fpsObject != null)
                {
                    fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString() + " | VER: " + PluginInfo.Version + " | PAGE: " + (pageNumber + 1).ToString();
                }
                if (Time.time > autoSaveDelay)
                {
                    autoSaveDelay = Time.time + 60f;
                    Settings.SavePreferences();
                    Classes.Logger.LogInfoNotif("Configs saved");
                }

                // Execute Enabled mods
                foreach (ButtonInfo[] buttonlist in buttons)
                {
                    foreach (ButtonInfo v in buttonlist)
                    {
                        if (v.enabled)
                        {
                            if (v.method != null)
                            {
                                try
                                {
                                    v.method.Invoke();
                                }
                                catch (Exception exc)
                                {
                                    Classes.Logger.Error(string.Format("{0} // Error with mod {1} at {2}: {3}", PluginInfo.Name, v.buttonText, exc.StackTrace, exc.Message));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Classes.Logger.Error(string.Format("{0} // Error with executing mods at {1}: {2}", PluginInfo.Name, exc.StackTrace, exc.Message));
            }
            if (!HasLoaded)
            {
                HasLoaded = true;
                OnLaunch();
            }
        }

        // Functions
        public static void CreateMenu()
        {
            // Menu Holder
            menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Destroy(menu.GetComponent<Rigidbody>());
            Destroy(menu.GetComponent<BoxCollider>());
            Destroy(menu.GetComponent<Renderer>());
            menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.3825f);

            // Menu Background
            menuBackground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Destroy(menuBackground.GetComponent<Rigidbody>());
            Destroy(menuBackground.GetComponent<BoxCollider>());
            menuBackground.transform.parent = menu.transform;
            menuBackground.transform.rotation = Quaternion.identity;
            menuBackground.transform.localScale = menuSize;
            menuBackground.GetComponent<Renderer>().material.color = bgColors.colors[0].color;
            menuBackground.transform.position = new Vector3(0.05f, 0f, 0f);
            if (shouldOutline)
            {
                OutlineObj(menuBackground, true);
            }

            ColorChanger colorChanger = menuBackground.AddComponent<ColorChanger>();
            colorChanger.colorInfo = bgColors;
            colorChanger.Start();

            // Canvas
            canvasObject = new GameObject();
            canvasObject.transform.parent = menu.transform;
            Canvas canvas = canvasObject.AddComponent<Canvas>();
            CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
            canvasObject.AddComponent<GraphicRaycaster>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvasScaler.dynamicPixelsPerUnit = 1000f;
            if (highQualityText == true)
            {
                canvasScaler.dynamicPixelsPerUnit = 2000f;
            }

            // Title and FPS
            Text text = new GameObject
            {
                transform =
                    {
                        parent = canvasObject.transform
                    }
            }.AddComponent<Text>();
            text.font = currentFont;
            text.text = PluginInfo.Name;
            text.fontSize = 1;
            text.color = titleColors.colors[0].color;
            text.supportRichText = true;
            text.fontStyle = FontStyle.Bold;
            text.alignment = TextAnchor.MiddleCenter;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.28f, 0.055f);
            component.position = new Vector3(0.06f, 0f, 0.1675f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

            if (fpsCounter)
            {
                fpsObject = new GameObject
                {
                    transform =
                    {
                        parent = canvasObject.transform
                    }
                }.AddComponent<Text>();
                fpsObject.font = currentFont;
                fpsObject.text = "FPS: " + Mathf.Ceil(1f / Time.unscaledDeltaTime).ToString() + " | VER: " + PluginInfo.Version + " | PAGE: " + (pageNumber + 1).ToString();
                fpsObject.color = txtColors[0].colors[0].color;;
                fpsObject.fontSize = 1;
                fpsObject.supportRichText = true;
                fpsObject.fontStyle = FontStyle.Italic;
                fpsObject.alignment = TextAnchor.MiddleCenter;
                fpsObject.horizontalOverflow = HorizontalWrapMode.Overflow;
                fpsObject.resizeTextForBestFit = true;
                fpsObject.resizeTextMinSize = 0;
                RectTransform component2 = fpsObject.GetComponent<RectTransform>();
                component2.localPosition = Vector3.zero;
                component2.sizeDelta = new Vector2(0.22f, 0.015f);
                component2.position = new Vector3(0.06f, 0f, 0.132f);
                component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }

            // Buttons
            // Disconnect
            if (disconnectButton)
            {
                GameObject disconnectbutton = GameObject.CreatePrimitive(PrimitiveType.Cube);
                if (!UnityInput.Current.GetKey(KeyCode.Q))
                {
                    disconnectbutton.layer = 2;
                }
                Destroy(disconnectbutton.GetComponent<Rigidbody>());
                disconnectbutton.GetComponent<BoxCollider>().isTrigger = true;
                disconnectbutton.transform.parent = menu.transform;
                disconnectbutton.transform.rotation = Quaternion.identity;
                disconnectbutton.transform.localScale = new Vector3(0.1f, 1f, 0.12f);
                disconnectbutton.transform.localPosition = new Vector3(0.5f, 0f, 0.6f);
                disconnectbutton.GetComponent<Renderer>().material.color = btColors[0].colors[0].color;
                disconnectbutton.AddComponent<Classes.Button>().relatedText = "Disconnect";
                if (shouldOutline)
                {
                    OutlineObj(disconnectbutton, true);
                }

                colorChanger = disconnectbutton.AddComponent<ColorChanger>();
                colorChanger.colorInfo = btColors[0];
                colorChanger.Start();

                Text disconnectText = new GameObject
                {
                    transform =
                            {
                                parent = canvasObject.transform
                            }
                }.AddComponent<Text>();
                disconnectText.text = "Disconnect";
                disconnectText.font = currentFont;
                disconnectText.fontSize = 1;
                disconnectText.color = txtColors[0].colors[0].color;;
                disconnectText.alignment = TextAnchor.MiddleCenter;
                disconnectText.resizeTextForBestFit = true;
                disconnectText.resizeTextMinSize = 0;

                RectTransform rectt = disconnectText.GetComponent<RectTransform>();
                rectt.localPosition = Vector3.zero;
                rectt.sizeDelta = new Vector2(0.2f, 0.03f);
                rectt.localPosition = new Vector3(0.064f, 0f, 0.23f);
                rectt.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }

            // Quit
            if (quitButton)
            {
                GameObject quitButton = GameObject.CreatePrimitive(PrimitiveType.Cube);
                if (!UnityInput.Current.GetKey(KeyCode.Q))
                {
                    quitButton.layer = 2;
                }
                Destroy(quitButton.GetComponent<Rigidbody>());
                quitButton.GetComponent<BoxCollider>().isTrigger = true;
                quitButton.transform.parent = menu.transform;
                quitButton.transform.rotation = Quaternion.identity;
                quitButton.transform.localScale = new Vector3(0.1f, 0.5f, 0.1f);
                quitButton.transform.localPosition = new Vector3(0.5f, 0f, -0.6f);
                quitButton.GetComponent<Renderer>().material.color = btColors[0].colors[0].color;
                quitButton.AddComponent<Classes.Button>().relatedText = "Quit Game";
                if (shouldOutline)
                {
                    OutlineObj(quitButton, true);
                }

                colorChanger = quitButton.AddComponent<ColorChanger>();
                colorChanger.colorInfo = btColors[0];
                colorChanger.Start();

                Text quitText = new GameObject
                {
                    transform =
                            {
                                parent = canvasObject.transform
                            }
                }.AddComponent<Text>();
                quitText.text = "Quit Game";
                quitText.font = currentFont;
                quitText.fontSize = 1;
                quitText.color = txtColors[0].colors[0].color; ;
                quitText.alignment = TextAnchor.MiddleCenter;
                quitText.resizeTextForBestFit = true;
                quitText.resizeTextMinSize = 0;

                RectTransform rectt = quitText.GetComponent<RectTransform>();
                rectt.localPosition = Vector3.zero;
                rectt.sizeDelta = new Vector2(0.2f, 0.03f);
                rectt.localPosition = new Vector3(0.064f, 0f, -0.22f);
                rectt.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }

            // Settings
            if (settingsButton)
            {
                GameObject settingsButton = GameObject.CreatePrimitive(PrimitiveType.Cube);
                if (!UnityInput.Current.GetKey(KeyCode.Q))
                {
                    settingsButton.layer = 2;
                }
                Destroy(settingsButton.GetComponent<Rigidbody>());
                settingsButton.GetComponent<BoxCollider>().isTrigger = true;
                settingsButton.transform.parent = menu.transform;
                settingsButton.transform.rotation = Quaternion.identity;
                settingsButton.transform.localScale = new Vector3(0.1f, 0.155f, 0.12f);
                settingsButton.transform.localPosition = new Vector3(0.5f, -0.635f, 0.6f);
                settingsButton.GetComponent<Renderer>().material.color = btColors[0].colors[0].color;
                settingsButton.AddComponent<Classes.Button>().relatedText = "SettingsButton";
                if (shouldOutline)
                {
                    OutlineObj(settingsButton, true);
                }

                colorChanger = settingsButton.AddComponent<ColorChanger>();
                colorChanger.colorInfo = btColors[0];
                colorChanger.Start();

                Text settingsText = new GameObject
                {
                    transform =
                            {
                                parent = canvasObject.transform
                            }
                }.AddComponent<Text>();
                settingsText.text = "#";
                settingsText.font = currentFont;
                settingsText.fontSize = 1;
                settingsText.color = txtColors[0].colors[0].color; ;
                settingsText.alignment = TextAnchor.MiddleCenter;
                settingsText.resizeTextForBestFit = true;
                settingsText.resizeTextMinSize = 0;

                RectTransform rectt = settingsText.GetComponent<RectTransform>();
                rectt.localPosition = Vector3.zero;
                rectt.sizeDelta = new Vector2(0.2f, 0.03f);
                rectt.localPosition = new Vector3(0.064f, -0.187f, 0.23f);
                rectt.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }

            // Page Buttons
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.1f, 0.16f, 0.85f);
            gameObject.transform.localPosition = new Vector3(0.5f, 0.64f, 0);
            gameObject.GetComponent<Renderer>().material.color = btColors[0].colors[0].color;
            gameObject.AddComponent<Classes.Button>().relatedText = "PreviousPage";
            if (shouldOutline)
            {
                OutlineObj(gameObject, true);
            }

            colorChanger = gameObject.AddComponent<ColorChanger>();
            colorChanger.colorInfo = btColors[0];
            colorChanger.Start();

            text = new GameObject
            {
                transform =
                        {
                            parent = canvasObject.transform
                        }
            }.AddComponent<Text>();
            text.font = currentFont;
            text.text = "<";
            text.fontSize = 1;
            text.color = txtColors[0].colors[0].color;
            text.alignment = TextAnchor.MiddleCenter;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.2f, 0.03f);
            component.localPosition = new Vector3(0.064f, 0.19f, 0f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

            gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.1f, 0.16f, 0.85f);
            gameObject.transform.localPosition = new Vector3(0.5f, -0.64f, 0);
            gameObject.GetComponent<Renderer>().material.color = btColors[0].colors[0].color;
            gameObject.AddComponent<Classes.Button>().relatedText = "NextPage";
            if (shouldOutline)
            {
                OutlineObj(gameObject, true);
            }

            colorChanger = gameObject.AddComponent<ColorChanger>();
            colorChanger.colorInfo = btColors[0];
            colorChanger.Start();

            text = new GameObject
            {
                transform =
                        {
                            parent = canvasObject.transform
                        }
            }.AddComponent<Text>();
            text.font = currentFont;
            text.text = ">";
            text.fontSize = 1;
            text.color = txtColors[0].colors[0].color;
            text.alignment = TextAnchor.MiddleCenter;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.2f, 0.03f);
            component.localPosition = new Vector3(0.064f, -0.19f, 0f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));

            // Mod Buttons
            ButtonInfo[] activeButtons = buttons[buttonsType].Skip(pageNumber * buttonsPerPage).Take(buttonsPerPage).ToArray();
            for (int i = 0; i < activeButtons.Length; i++)
            {
                CreateButton(i * 0.083f, activeButtons[i]);
            }
        }

        public static void CreateButton(float offset, ButtonInfo method)
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (!UnityInput.Current.GetKey(KeyCode.Q))
            {
                gameObject.layer = 2;
            }
            Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.09f, 0.9f, 0.07f);
            gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.28f - offset);
            gameObject.AddComponent<Classes.Button>().relatedText = method.buttonText;
            if (shouldOutline)
            {
                OutlineObj(gameObject, true);
            }

            ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
            if (method.enabled)
            {
                colorChanger.colorInfo = btColors[1];
            }
            else
            {
                colorChanger.colorInfo = btColors[0];
            }
            colorChanger.Start();

            Text text = new GameObject
            {
                transform =
                {
                    parent = canvasObject.transform
                }
            }.AddComponent<Text>();
            text.font = currentFont;
            text.text = method.buttonText;
            if (method.overlapText != null)
            {
                text.text = method.overlapText;
            }
            text.supportRichText = true;
            text.fontSize = 1;
            if (method.enabled)
            {
                text.color = txtColors[1].colors[1].color;
            }
            else
            {
                text.color = txtColors[0].colors[0].color;
            }
            text.alignment = TextAnchor.MiddleCenter;
            text.fontStyle = FontStyle.Normal;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(.2f, .02f);
            component.localPosition = new Vector3(.064f, 0, .111f - offset / 2.6f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            if (overflowText == true)
            {
                component.sizeDelta = new Vector2(.1f, .012f);
                text.horizontalOverflow = HorizontalWrapMode.Overflow;
                text.verticalOverflow = VerticalWrapMode.Truncate;
            }
        }

        public static void RecreateMenu()
        {
            if (menu != null)
            {
                Destroy(menu);
                menu = null;

                CreateMenu();
                RecenterMenu(rightHanded, UnityInput.Current.GetKey(keyboardButton));
            }
        }

        public static void RecenterMenu(bool isRightHanded, bool isKeyboardCondition)
        {
            if (!isKeyboardCondition)
            {
                if (!isRightHanded)
                {
                    menu.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                    menu.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
                }
                else
                {
                    menu.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                    Vector3 rotation = GorillaTagger.Instance.rightHandTransform.rotation.eulerAngles;
                    rotation += new Vector3(0f, 0f, 180f);
                    menu.transform.rotation = Quaternion.Euler(rotation);
                }
            }
            else
            {
                try
                {
                    TPC = GameObject.Find("Player Objects/Third Person Camera/Shoulder Camera").GetComponent<Camera>();
                }
                catch { }

                GameObject.Find("Shoulder Camera").transform.Find("CM vcam1").gameObject.SetActive(false);

                if (TPC != null)
                {
                    TPC.transform.position = new Vector3(-999f, -999f, -999f);
                    TPC.transform.rotation = Quaternion.identity;
                    GameObject bg = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    bg.transform.localScale = new Vector3(10f, 10f, 0.01f);
                    bg.transform.transform.position = TPC.transform.position + TPC.transform.forward;
                    bg.GetComponent<Renderer>().material.color = new Color32((byte)(bgColors.colors[0].color.r * 50), (byte)(bgColors.colors[0].color.g * 50), (byte)(bgColors.colors[0].color.b * 50), 255);
                    Destroy(bg, Time.deltaTime);
                    menu.transform.parent = TPC.transform;
                    menu.transform.position = TPC.transform.position + Vector3.Scale(TPC.transform.forward, new Vector3(0.5f, 0.5f, 0.5f)) + Vector3.Scale(TPC.transform.up, new Vector3(-0.02f, -0.02f, -0.02f));
                    Vector3 rot = TPC.transform.rotation.eulerAngles;
                    rot = new Vector3(rot.x - 90, rot.y + 90, rot.z);
                    menu.transform.rotation = Quaternion.Euler(rot);
                    TPC.GetComponent<Camera>().fieldOfView = 80;

                    if (reference != null)
                    {
                        if (Mouse.current.leftButton.isPressed)
                        {
                            Ray ray = TPC.ScreenPointToRay(Mouse.current.position.ReadValue());
                            RaycastHit hit;
                            bool worked = Physics.Raycast(ray, out hit, 100);
                            if (worked)
                            {
                                Classes.Button collide = hit.transform.gameObject.GetComponent<Classes.Button>();
                                if (collide != null)
                                {
                                    collide.OnTriggerEnter(buttonCollider);
                                }
                            }
                        }
                        else
                        {
                            reference.transform.position = new Vector3(999f, -999f, -999f);
                        }
                    }
                }
            }
        }

        public static void CreateReference(bool isRightHanded)
        {
            reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            if (isRightHanded)
            {
                reference.transform.parent = GorillaTagger.Instance.leftHandTransform;
            }
            else
            {
                reference.transform.parent = GorillaTagger.Instance.rightHandTransform;
            }
            reference.GetComponent<Renderer>().material.color = bgColors.colors[0].color;
            reference.transform.localPosition = new Vector3(0f, -0.1f, 0f);
            reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            buttonCollider = reference.GetComponent<SphereCollider>();

            ColorChanger colorChanger = reference.AddComponent<ColorChanger>();
            colorChanger.colorInfo = bgColors;
            colorChanger.Start();
        }

        public static void Toggle(string buttonText)
        {
            if (buttonText == "Disconnect")
            {
                Global.Disconnect();
                NotifiLib.SendNotification($"<color=grey>(</color><color=yellow>{buttonText}</color><color=grey>)</color> Leaves the current lobby");
            }
            if (buttonText == "Quit Game")
            {
                Global.Quit();
            }
            if (buttonText == "SettingsButton")
            {
                Categories.EnterSettings();
                NotifiLib.SendNotification($"<color=grey>(</color><color=yellow>{buttonText}</color><color=grey>)</color> Sends you to the settings page for the menu.");
            }

            int lastPage = (buttons[buttonsType].Length + buttonsPerPage - 1) / buttonsPerPage - 1;
            if (buttonText == "PreviousPage")
            {
                pageNumber--;
                if (pageNumber < 0)
                {
                    pageNumber = lastPage;
                }
            }
            else
            {
                if (buttonText == "NextPage")
                {
                    pageNumber++;
                    if (pageNumber > lastPage)
                    {
                        pageNumber = 0;
                    }
                }
                else
                {
                    ButtonInfo target = GetIndex(buttonText);
                    if (target != null)
                    {
                        if (target.isTogglable)
                        {
                            target.enabled = !target.enabled;
                            if (target.enabled)
                            {
                                NotifiLib.SendNotification($"<color=grey>(</color><color=green>{target.buttonText}</color><color=grey>)</color> {target.toolTip}");
                                if (target.enableMethod != null)
                                {
                                    try { target.enableMethod.Invoke(); } catch { }
                                }
                            }
                            else
                            {
                                NotifiLib.SendNotification($"<color=grey>(</color><color=red>{target.buttonText}</color><color=grey>)</color> {target.toolTip}");
                                if (target.disableMethod != null)
                                {
                                    try { target.disableMethod.Invoke(); } catch { }
                                }
                            }
                        }
                        else
                        {
                            NotifiLib.SendNotification($"<color=grey>(</color><color=yellow>{target.buttonText}</color><color=grey>)</color> {target.toolTip}");
                            if (target.method != null)
                            {
                                try { target.method.Invoke(); } catch { }
                            }
                        }
                    }
                    else
                    {
                        Classes.Logger.Error(buttonText + " does not exist");
                    }
                }
            }
            RecreateMenu();
        }

        public static GradientColorKey[] GetSolidGradient(Color color)
        {
            return new GradientColorKey[] { new GradientColorKey(color, 0f), new GradientColorKey(color, 1f) };
        }
        public static GradientColorKey[] GetMultiGradient(Color a, Color b)
        {
            return new GradientColorKey[] { new GradientColorKey(a, 0f), new GradientColorKey(b, 0.5f), new GradientColorKey(a, 1f) };
        }

        public static ButtonInfo GetIndex(string buttonText)
        {
            foreach (ButtonInfo[] buttons in buttons)
            {
                foreach (ButtonInfo button in buttons)
                {
                    if (button.buttonText == buttonText)
                    {
                        return button;
                    }
                }
            }

            return null;
        }
        public static void OutlineObj(GameObject toOut, bool shouldBeEnabled)
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(gameObject.GetComponent<BoxCollider>());
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localPosition = toOut.transform.localPosition;
            gameObject.transform.localScale = toOut.transform.localScale + new Vector3(-0.01f, 0.01f, 0.0075f);
            ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
            colorChanger.colorInfo = shouldBeEnabled ? btColors[1] : btColors[0];
            colorChanger.Start();
        }

        public static void OutlineObjNonMenu(GameObject toOut, bool shouldBeEnabled)
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
            UnityEngine.Object.Destroy(gameObject.GetComponent<BoxCollider>());
            gameObject.transform.parent = toOut.transform.parent;
            gameObject.transform.rotation = toOut.transform.rotation;
            gameObject.transform.localPosition = toOut.transform.localPosition;
            gameObject.transform.localScale = toOut.transform.localScale + new Vector3(0.005f, 0.005f, -0.001f);
            ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
            colorChanger.colorInfo = shouldBeEnabled ? btColors[1] : btColors[0];
            colorChanger.Start();
        }

        public static Texture2D LoadTextureFromURL(string resourcePath, string fileName)
        {
            Texture2D texture = new Texture2D(2, 2);

            if (!Directory.Exists(modDir))
            {
                Directory.CreateDirectory(modDir);
            }
            if (!File.Exists(modDir + "/" + fileName))
            {
                Classes.Logger.LogInfoNotif("Downloading " + fileName);
                WebClient stream = new WebClient();
                stream.DownloadFile(resourcePath, modDir + "/" + fileName);
            }

            byte[] bytes = File.ReadAllBytes(modDir + "/" + fileName);
            texture.LoadImage(bytes);

            return texture;
        }

        public static Texture2D LoadTextureFromResource(string resourcePath)
        {
            Texture2D texture = new Texture2D(2, 2);

            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath);
            if (stream != null)
            {
                byte[] fileData = new byte[stream.Length];
                stream.Read(fileData, 0, (int)stream.Length);
                texture.LoadImage(fileData);
            }
            else
            {
                Classes.Logger.LogErrorNotif("Failed to load texture from resource: " + resourcePath);
            }
            return texture;
        }

        public static void OnLaunch()
        {
            {
                if (File.Exists(modDir + "/EnabledMods.txt") || File.Exists(modDir + "/EnabledTheme.txt"))
                {
                    try
                    {
                        Settings.LoadPreferences();
                    }
                    catch
                    {
                        Task.Delay(1000).ContinueWith(t => Settings.LoadPreferences());
                    }
                }
                Classes.Logger.Error(string.Format("OnLaunch activated"));
            }
        }

        public static GameObject menu;
        public static GameObject menuBackground;
        public static GameObject reference;
        public static GameObject canvasObject;

        public static SphereCollider buttonCollider;
        public static Camera TPC;
        public static Text fpsObject;

        public static Color bgColorsA = new Color32(48, 25, 52, 255);
        public static Color bgColorsB = new Color32(68, 36, 84, 255);
        public static Color btDefaultA = new Color32(102, 51, 153, 255);
        public static Color btDefaultB = new Color32(153, 102, 204, 255);
        public static Color btClickedA = new Color32(124, 58, 237, 255);
        public static Color btClickedB = new Color32(165, 94, 234, 255);
        public static Color txtDefaultA = new Color32(230, 220, 255, 255);
        public static Color txtDefaultB = new Color32(230, 220, 255, 255);
        public static Color txtClickedA = new Color32(230, 220, 255, 255);
        public static Color txtClickedB = new Color32(230, 220, 255, 255);
        public static Color titleColorsA = new Color32(220, 200, 255, 255);
        public static Color titleColorsB = new Color32(240, 220, 255, 255);

        public static Font sans = Font.CreateDynamicFontFromOSFont("Comic Sans MS", 24);
        public static Font Arial = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        public static Font Verdana = Font.CreateDynamicFontFromOSFont("Verdana", 24);
        public static Font agency = Font.CreateDynamicFontFromOSFont("Agency FB", 24);
        public static Font consolas = Font.CreateDynamicFontFromOSFont("Consolas", 24);
        public static Font ubuntu = Font.CreateDynamicFontFromOSFont("Candara", 24);
        public static Font MSGOTHIC = Font.CreateDynamicFontFromOSFont("MS Gothic", 24);
        public static Font impact = Font.CreateDynamicFontFromOSFont("Impact", 24);
        public static Font bahnschrift = Font.CreateDynamicFontFromOSFont("Bahnschrift", 24);
        public static Font calibri = Font.CreateDynamicFontFromOSFont("Calibri", 24);
        public static Font cambria = Font.CreateDynamicFontFromOSFont("Cambria", 24);
        public static Font cascadiacode = Font.CreateDynamicFontFromOSFont("Cascadia Code", 24);
        public static Font cascadiamono = Font.CreateDynamicFontFromOSFont("Cascadia Mono", 24);
        public static Font constantia = Font.CreateDynamicFontFromOSFont("Constantia", 24);
        public static Font corbel = Font.CreateDynamicFontFromOSFont("Corbel", 24);
        public static Font couriernew = Font.CreateDynamicFontFromOSFont("Courier New", 24);
        public static Font dengxian = Font.CreateDynamicFontFromOSFont("DengXian", 24);
        public static Font ebrima = Font.CreateDynamicFontFromOSFont("Ebrima", 24);
        public static Font fangsong = Font.CreateDynamicFontFromOSFont("FangSong", 24);
        public static Font franklingothic = Font.CreateDynamicFontFromOSFont("Franklin Gothic Medium", 24);
        public static Font gabriola = Font.CreateDynamicFontFromOSFont("Gabriola", 24);
        public static Font gadugi = Font.CreateDynamicFontFromOSFont("Gadugi", 24);
        public static Font georgia = Font.CreateDynamicFontFromOSFont("Georgia", 24);
        public static Font hololens = Font.CreateDynamicFontFromOSFont("HoloLens MDL2 Assets", 24);
        public static Font inkfree = Font.CreateDynamicFontFromOSFont("Ink Free", 24);
        public static Font javanesetext = Font.CreateDynamicFontFromOSFont("Javanese Text", 24);
        public static Font kaiti = Font.CreateDynamicFontFromOSFont("KaiTi", 24);
        public static Font lucidaconsole = Font.CreateDynamicFontFromOSFont("Lucida Console", 24);

        public static int pageNumber = 0;
        public static int buttonsType = 0;
        public static int themeType = 1;
        public static int fontType = 0;
        public static float autoSaveDelay = Time.time + 60f;
        public static bool HasLoaded = false;
    }
}
