#if UNITY_EDITOR
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace NaughtyAttributes
{
    [CustomPropertyDrawer(typeof(NamedArrayAttribute))]
    public class NamedArrayDrawer : PropertyDrawerBase
    {
        protected override float GetPropertyHeight_Internal(SerializedProperty property,
            GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label);
        }

        protected override void OnGUI_Internal(Rect rect,
            SerializedProperty property,
            GUIContent label)
        {
            EditorGUI.BeginProperty(rect, label, property);
            try
            {
                var path = property.propertyPath;
                var pos = int.Parse(path.Split('[').LastOrDefault()?.TrimEnd(']') ?? throw new NullReferenceException());
                EditorGUI.PropertyField(rect, property, new GUIContent(ObjectNames.NicifyVariableName(((NamedArrayAttribute) attribute).names[pos])), true);
            }
            catch
            {
                EditorGUI.PropertyField(rect, property, label, true);
            }

            EditorGUI.EndProperty();
        }
    }
}
#endif