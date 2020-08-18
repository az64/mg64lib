using System;

namespace MG64Lib.Attributes
{
    public class ObstacleScaleAttribute : Attribute
    {
        public ushort Width { get; private set; }
        public ushort Height { get; private set; }

        public ObstacleScaleAttribute(ushort width, ushort height)
        {
            Width = width;
            Height = height;
        }
    }
}