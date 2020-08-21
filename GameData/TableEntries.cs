namespace MG64Lib.GameData
{
    public class AssetTableEntry
    {
        public int Offset { get; set; }
        public int Size { get; set; }

        public AssetTableEntry(int offset, int size)
        {
            Offset = offset;
            Size = size;
        }
    }

    public class ObjectTableEntry
    {
        public int RomStart { get; set; }
        public int RomEnd { get; set; }
        //public int MainDisplayList { get; set; }
        //todo - add the rest of this structure if needed and once known

        public ObjectTableEntry(int romStart, int romEnd)
        {
            RomStart = romStart;
            RomEnd = romEnd;
        }
    }
}