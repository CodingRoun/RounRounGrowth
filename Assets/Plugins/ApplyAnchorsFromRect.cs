using UnityEngine;
using UnityEditor;

public class ApplyAnchorsFromRect : EditorWindow
{
    [MenuItem("Tools/UI/Apply Anchors From Rect")]
    private static void ApplyAnchors()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            RectTransform rt = obj.GetComponent<RectTransform>();
            if (rt == null || rt.parent == null) continue;

            RectTransform parent = rt.parent as RectTransform;
            Undo.RecordObject(rt, "Apply Anchors From Rect");

            Rect parentRect = parent.rect;

            Vector2 offsetMin = rt.offsetMin;
            Vector2 offsetMax = rt.offsetMax;

            Vector2 newAnchorMin = new Vector2(
                rt.anchorMin.x + offsetMin.x / parentRect.width,
                rt.anchorMin.y + offsetMin.y / parentRect.height
            );
            Vector2 newAnchorMax = new Vector2(
                rt.anchorMax.x + offsetMax.x / parentRect.width,
                rt.anchorMax.y + offsetMax.y / parentRect.height
            );

            rt.anchorMin = newAnchorMin;
            rt.anchorMax = newAnchorMax;

            rt.offsetMin = Vector2.zero;
            rt.offsetMax = Vector2.zero;

        }

        Debug.Log($" 已将 {Selection.gameObjects.Length} 个物体完成变换。");
    }
}
