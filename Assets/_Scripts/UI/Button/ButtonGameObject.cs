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
            //var text = textGo.AddComponent<TextMeshProUGUI>();
            //text.text = "New Button";

            //rectTransform.anchorMin = new Vector2(0f, 0f);
            //rectTransform.anchorMax = new Vector2(1f, 1f);
            //rectTransform.anchoredPosition = new Vector2(0f, 0f); 

            // Ensure it gets reparented if this was a context click (otherwise does nothing)
            //GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);

            GameObject context = menuCommand.context as GameObject;
            if (IsChildOfCanvas(context))
            {
                // Parent this gameobject under the context
                GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
            }
            else
            {
                // Create a Canvas
                var canvas = new GameObject("Canvas");
                canvas.AddComponent<CanvasRenderer>();
                canvas.AddComponent<CanvasScaler>();
                GameObjectUtility.SetParentAndAlign(go, canvas);
            }

            var parentGo = menuCommand.context as GameObject;
            if(parentGo.GetComponent<Canvas>() != null)

            // Register the creation in the undo system
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }

        static bool IsChildOfCanvas(GameObject go)
        {
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
    }
}