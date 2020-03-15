#if UNITY_EDITOR
namespace NaughtyAttributes
{
    using UnityEngine;
    using UnityEditor;

    [CustomPropertyDrawer(typeof(Sprite))]
    public class SpritePropertyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property,
            GUIContent labelN)
        {
            return property.objectReferenceValue != null ? TEX_SIZE : base.GetPropertyHeight(property, labelN);
        }

        private const float TEX_SIZE = 70;


        public override void OnGUI(Rect position,
            SerializedProperty prop,
            GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, prop);

            if (prop.objectReferenceValue != null)
            {
                position.width = EditorGUIUtility.labelWidth;
                GUI.Label(position, prop.displayName);

                position.x += position.width;
                position.width = TEX_SIZE;
                position.height = TEX_SIZE;

                prop.objectReferenceValue = EditorGUI.ObjectField(position, prop.objectReferenceValue, typeof(Sprite), false);
            }
            else
            {
                EditorGUI.PropertyField(position, prop, true);
            }

            EditorGUI.EndProperty();
        }
    }
}
#endif