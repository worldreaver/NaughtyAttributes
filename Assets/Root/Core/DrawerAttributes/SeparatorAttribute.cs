using System;

namespace NaughtyAttributes
{
    [AttributeUsage(validOn: AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public class SeparatorAttribute : DrawerAttribute
    {
        public const float DEFAULT_HEIGHT = 2.0f;
        public const EColor DEFAULT_COLOR = EColor.Gray;
        public string Text { get; }
        public float Thickness { get; }
        public EColor Color { get; }


        public SeparatorAttribute(float thickness = DEFAULT_HEIGHT,
            EColor color = DEFAULT_COLOR)
        {
            Text = "";
            Thickness = thickness;
            Color = color;
        }

        public SeparatorAttribute(string text) : this()
        {
            Text = text;
        }

        public SeparatorAttribute(string text,
            float thickness = DEFAULT_HEIGHT,
            EColor color = DEFAULT_COLOR) : this(text)
        {
            Thickness = thickness;
            Color = color;
        }
    }
}