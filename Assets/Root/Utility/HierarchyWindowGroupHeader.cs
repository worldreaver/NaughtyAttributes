#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;

namespace NaughtyAttributes
{
    [InitializeOnLoad]
    public static class HierarchyWindowGroupHeader
    {
        private static readonly GUIStyle Style;
        private const string NAME_STARTS_WITH = "---";
        private const string REMOVE_STRING = "-";
        private const FontStyle FONT_STYLE = FontStyle.Bold;
        private const int FONT_SIZE = 14;
        private const TextAnchor ALIGNMENT = TextAnchor.MiddleCenter;
        private static readonly Color TextColor = new Color(0.81f, 0.33f, 0.49f);
        private static readonly Color BackgroundColor = new Color(0.72f, 0.72f, 0.72f);

        static HierarchyWindowGroupHeader()
        {
            Style = new GUIStyle {fontSize = FONT_SIZE, fontStyle = FONT_STYLE, alignment = ALIGNMENT, normal = {textColor = TextColor}};
            EditorApplication.RepaintHierarchyWindow();
            EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
        }

        private static void HierarchyWindowItemOnGUI(int instanceId,
            Rect selectionRect)
        {
            var gameObject = EditorUtility.InstanceIDToObject(instanceId) as GameObject;

            if (gameObject != null && gameObject.name.StartsWith(NAME_STARTS_WITH, StringComparison.Ordinal))
            {
                EditorGUI.DrawRect(selectionRect, BackgroundColor);
                EditorGUI.LabelField(selectionRect, gameObject.name.Replace(REMOVE_STRING, "").ToUpperInvariant(), Style);
            }
        }
    }
}
#endif