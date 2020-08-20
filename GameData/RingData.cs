namespace MG64Lib.GameData
{
    public class RingData
    {
        public TriangleType Type { get => TriangleType.Ring; }
        public GeometryCoordinates Position { get; set; }
        public GeometryCoordinates Rotation { get; set; }
        public short Scale { get; set; }

        public RingData(GeometryCoordinates position, GeometryCoordinates rotation, short scale)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }
    }
}