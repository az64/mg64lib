namespace MG64Lib.GameData
{
    public class MapCoordinates
    {
        public short X { get; set; }
        public short Z { get; set; }

        public MapCoordinates()
        {
        }

        public MapCoordinates(short x, short z)
        {
            X = x;
            Z = z;
        }

        public MapCoordinates(GeometryCoordinates c)
        {
            X = (short)(c.X >> 4);
            Z = (short)(c.Z >> 4);
        }

        public MapCoordinates(LiveCoordinates c)
        {
            X = (short)(c.X >> 14);
            Z = (short)(c.Z >> 14);
        }
    }

    public class GeometryCoordinates
    {
        public short X { get; set; }
        public short Y { get; set; }
        public short Z { get; set; }

        public GeometryCoordinates()
        {
        }

        public GeometryCoordinates(short x, short y, short z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public GeometryCoordinates(MapCoordinates c)
        {
            X = (short)(c.X << 4);
            Y = 0;
            Z = (short)(c.Z << 4);
        }

        public GeometryCoordinates(LiveCoordinates c)
        {
            X = (short)(c.X >> 10);
            Y = (short)(c.Y >> 10);
            Z = (short)(c.Z >> 10);
        }
    }

    public class LiveCoordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public LiveCoordinates()
        {
        }

        public LiveCoordinates(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public LiveCoordinates(MapCoordinates c)
        {
            X = c.X << 14;
            Y = 0;
            Z = c.Z << 14;
        }

        public LiveCoordinates(GeometryCoordinates c)
        {
            X = c.X << 10;
            Y = c.Y << 10;
            Z = c.Z << 10;
        }
    }

    public enum CoordinatesType
    {
        Map,
        Geometry,
        Live
    }
}