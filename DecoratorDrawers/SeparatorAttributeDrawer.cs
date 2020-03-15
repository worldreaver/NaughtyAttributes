#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Worldreaver.RectEx;

namespace NaughtyAttributes
{
    [CustomPropertyDrawer(typeof(SeparatorAttribute))]
    public class SeparatorAttributeDrawer : DecoratorDrawer
    {
        private SeparatorAttribute TheAttribute => attribute as SeparatorAttribute;

        private GUIStyle _textStyle;
        private const float SPACE_BEFORE = 0;

        public override float GetHeight()
        {
            return SPACE_BEFORE + Mathf.Max(TheAttribute.Thickness, EditorGUIUtility.singleLineHeight + 5);
        }

        public override void OnGUI(Rect rect)
        {
            PrepareStyles();
            rect.y += SPACE_BEFORE;
            rect.height -= SPACE_BEFORE;

            string text = TheAttribute.Text;
            float thickness = TheAttribute.Thickness;

            if (string.IsNullOrEmpty(text))
            {
                DrawLine(rect, thickness);
            }
            else
            {
                var textSize = _textStyle.CalcSize(new GUIContent(text));
                var rects = rect.Row(new float[] {1, 0, 1}, new[] {0, textSize.x, 0});

                DrawLine(rects[0], thickness);
                DrawText(rects[1], text);
                DrawLine(rects[2], thickness);
            }
        }

        private void PrepareStyles()
        {
            if (_textStyle != null)
            {
                return;
            }

            _textStyle = new GUIStyle {fontStyle = FontStyle.Bold, normal = {textColor = TheAttribute.Color.GetColor()}, alignment = TextAnchor.MiddleCenter};
        }

        private void DrawText(Rect rect,
            string text)
        {
            EditorGUI.LabelField(rect, text, _textStyle);
        }

        private void DrawLine(Rect rect,
            float thickness)
        {
            rect.y += (rect.height - thickness) / 2;
            rect.height = thickness;
            GuiUtil.DrawRect(rect, TheAttribute.Color.GetColor());
        }


        private static class GuiUtil
        {
            private static readonly Dictionary<Color, GUIStyle> Styles;

            static GuiUtil()
            {
                Styles = new Dictionary<Color, GUIStyle>();
            }

            public static void DrawRect(Rect rect,
                Color color)
            {
                PrepareStyle(color);
                EditorGUI.LabelField(rect, GUIContent.none, Styles[color]);
            }

            private static void PrepareStyle(Color color)
            {
                if (Styles.ContainsKey(color))
                {
                    return;
                }

                var texture = new Texture2D(1, 1);
                texture.SetPixel(0, 0, color);
                texture.Apply();

                var style = new GUIStyle();
                style.normal.background = texture;
                Styles[color] = style;
            }
        }
    }
}
#endif