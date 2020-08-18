namespace MG64Lib.GameData
{
    public class InitialHoleConditions
    {
        public LiveCoordinates PinPosition { get; set; }
        public LiveCoordinates TeePosition { get; set; }
        public int WindSpeed { get; set; }
        public int WindDirection { get; set; }
        public int Weather { get; set; }
        public int Time { get; set; }
        public short SunPosition1 { get; set; }
        public short SunPosition2 { get; set; }
        public byte Par { get; set; }
        public byte PinIndex { get; set; }
        public byte Unk1 { get; set; }
        public byte Unk2 { get; set; }
        public readonly int ConstEnd = 0x04000000;
    }
}