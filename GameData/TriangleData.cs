namespace MG64Lib.GameData
{
    public class TriangleData
    {
        public TriangleType Type { get; set; }
        public GeometryCoordinates Vertex1 { get; set; }
        public GeometryCoordinates Vertex2 { get; set; }
        public GeometryCoordinates Vertex3 { get; set; }

        public TriangleData(TriangleType type, GeometryCoordinates vertex1, GeometryCoordinates vertex2, GeometryCoordinates vertex3)
        {
            Type = type;
            Vertex1 = vertex1;
            Vertex2 = vertex2;
            Vertex3 = vertex3;
        }
    }
}