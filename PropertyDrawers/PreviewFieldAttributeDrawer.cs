#if UNITY_EDITOR
namespace NaughtyAttributes
{
    using UnityEngine;
    using UnityEditor;

    [CustomPropertyDrawer(typeof(PreviewFieldAttribute))]
    public class PreviewFieldAttributeDrawer : PropertyDrawerBase
    {
        protected override float GetPropertyHeight_Internal(SerializedProperty property,
            GUIContent label)
        {
            return GetPropertyHeight(property) + GetAssetPreviewSize(property).y;
        }

        protected override void OnGUI_Internal(Rect rect,
            SerializedProperty property,
            GUIContent label)
        {
            float PosX(AttributeAlign align)
            {
                switch (align)
                {
                    case AttributeAlign.Left:
                        return rect.x + NaughtyEditorGUI.GetIndentLength(rect);
                    case AttributeAlign.Center:
                        return rect.width / 2;
                    case AttributeAlign.Right:
                        return rect.width - rect.x - NaughtyEditorGUI.GetIndentLength(rect) - GetAssetPreviewSize(property).x / 2;
                    default:
                        return rect.x + NaughtyEditorGUI.GetIndentLength(rect);
                }
            }

            EditorGUI.BeginProperty(rect, label, property);
            EditorGUILayout.BeginHorizontal();
            if (property.propertyType == SerializedPropertyType.ObjectReference)
            {
                var sizePreview = GetAssetPreviewSize(property);
                var pewview = PropertyUtility.GetAttribute<PreviewFieldAttribute>(property);
                var ident = EditorGUI.indentLevel;
                EditorGUI.indentLevel = 0;

                var previewRect = new Rect()
                {
                    x = PosX(pewview.Align),
                    y = rect.y + EditorGUIUtility.singleLineHeight,
                    width = sizePreview.x,
                    height = sizePreview.y
                };

                property.objectReferenceValue = EditorGUI.ObjectField(previewRect, property.objectReferenceValue, typeof(Sprite), false);
                GUILayout.Space(GetPropertyHeight_Internal(property, GUIContent.none));
                EditorGUI.indentLevel = ident;
            }
            else
            {
                var message = property.name + " doesn't have an asset preview";
                DrawDefaultPropertyAndHelpBox(rect, property, message, MessageType.Warning);
            }

            EditorGUILayout.EndHorizontal();
            EditorGUI.EndProperty();
        }

        private static System.Type GetType(SerializedProperty property)
        {
            System.Type parentType = property.serializedObject.targetObject.GetType();
            System.Reflection.FieldInfo fi = parentType.GetField(property.propertyPath);
            return fi != null ? fi.FieldType : typeof(Object);
        }

        private Texture2D GetAssetPreview(SerializedProperty property)
        {
            if (property.propertyType == SerializedPropertyType.ObjectReference)
            {
                if (property.objectReferenceValue != null)
                {
                    Texture2D previewTexture = AssetPreview.GetAssetPreview(property.objectReferenceValue);
                    return previewTexture;
                }

                return null;
            }

            return null;
        }

        private Vector2 GetAssetPreviewSize(SerializedProperty property)
        {
            var previewTexture = GetAssetPreview(property);
            if (previewTexture == null)
            {
                return new Vector2(48, 48);
            }

            var preview = PropertyUtility.GetAttribute<PreviewFieldAttribute>(property);
            var width = Mathf.Clamp(preview.Width, 48, previewTexture.width);
            var height = Mathf.Clamp(preview.Height, 48, previewTexture.height);

            return new Vector2(width, height);
        }
    }
}

#endif