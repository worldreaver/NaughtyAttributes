using System;

namespace NaughtyAttributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class PreviewFieldAttribute : DrawerAttribute
    {
        public int Width { get; }
        public int Height { get; }
        public AttributeAlign Align { get; }

        public PreviewFieldAttribute(int width = 64,
            int height = 64,
            AttributeAlign align = AttributeAlign.Center)
        {
            Width = width;
            Height = height;
            Align = align;
        }
    }

    public enum AttributeAlign
    {
        Left = -1,
        Center = 0,
        Right = 1,
    }
}