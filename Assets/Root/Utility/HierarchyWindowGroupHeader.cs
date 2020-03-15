#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;


namespace NaughtyAttributes
{
    [InitializeOnLoad]
    public class HierarchyWindowGroupHeader : Editor
    {
        static HierarchyWindowGroupHeader()
        {
            EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGui;
        }

        private static void HierarchyWindowItemOnGui(int instanceId,
            Rect selectionRect)
        {
            var gameObject = EditorUtility.InstanceIDToObject(instanceId) as GameObject;
            if (gameObject == null || !gameObject.name.StartsWith("---", System.StringComparison.Ordinal)) return;
            EditorGUI.DrawRect(selectionRect, Color.gray);
            EditorGUI.DropShadowLabel(selectionRect, gameObject.name.Replace("-", "").ToUpperInvariant());
        }
    }
}
#endif