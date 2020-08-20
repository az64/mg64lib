namespace MG64Lib.GameData
{
    public class ObstacleData
    {
        public Obstacle Obstacle { get; set; }
        public GeometryCoordinates Position { get; set; }
        public short Width { get; set; }
        public short Height { get; set; }

        public ObstacleData(Obstacle obstacle, GeometryCoordinates position, short width, short height)
        {
            Obstacle = obstacle;
            Position = position;
            Width = width;
            Height = height;
        }
    }
}