using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

namespace Com.SoulSki.UI
{
    public static class ButtonGameObject
    {
        [MenuItem("GameObject/SoulSki/UI/Button", false, 1)]
        static void CreateButtonGameObject(MenuCommand menuCommand)
        {
            // Create the object
            GameObject go = new GameObject("Button");
            var btnRT = go.AddComponent<RectTransform>();
            btnRT.sizeDelta = new Vector2(160f, 30f);

            go.AddComponent<CanvasRenderer>();
            var img = go.AddComponent<Image>();
            img.sprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
            img.type = Image.Type.Tiled;


            go.AddComponent<Button>();

            var textGo = new GameObject("Text (TMP)");
            var rectTransform = textGo.AddComponent<RectTransform>();
            textGo.transform.SetParent(go.transform);
            rectTransform.anchorMin = new Vector2(0f, 0f);
            rectTransform.anchorMax = new Vector2(1f, 1f);
            rectTransform.SetAnchoredSize();
            

            var text = textGo.AddComponent<TextMeshProUGUI>();
            text.text = "New Button";
            text.fontSize = 20f;
            text.fontStyle = FontStyles.SmallCaps | FontStyles.Bold;
            //text.fontWeight = FontWeight.Bold;
            text.color = Color.black;
            text.alignment = TextAlignmentOptions.Center;
            text.alignment = TextAlignmentOptions.Capline;

            GameObject context = menuCommand.context as GameObject;

            if(context == null || !IsChildOfCanvas(context))
            {
                CreateDefaultCanvas(go);
            }
            else
            {
                // Parent this gameobject under the context
                GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
            }

            // Register the creation in the undo system
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }

        static bool IsChildOfCanvas(GameObject go)
        {
            if (!go)
            {
                Debug.LogError("IsChildOfCanvas(Gameobject) - go null");
            }
            // check for canvas
            var canvas = go.GetComponent<Canvas>();
            if (canvas != null)
                return true;

            // if none check parent
            if (go.transform.parent != null)
                return IsChildOfCanvas(go.transform.parent.gameObject);

            // Otherwise there is none
            return false;
        }

        static void CreateDefaultCanvas(GameObject go)
        {
            // Create a Canvas
            var canvasGo = new GameObject("Canvas");

            var canvas = canvasGo.AddComponent<Canvas>();
            canvasGo.AddComponent<CanvasRenderer>();
            var canvasScaler = canvasGo.AddComponent<CanvasScaler>();
            GameObjectUtility.SetParentAndAlign(go, canvasGo);

            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.referenceResolution = new Vector2(1920f, 1080f);

            Undo.RegisterCreatedObjectUndo(canvasGo, "Create " + canvasGo.name);
        }
    }
}