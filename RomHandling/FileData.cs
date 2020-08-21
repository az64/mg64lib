namespace MG64Lib.RomHandling
{
    public class FileData
    {
        public int Number { get; set; }
        public byte[] Data { get; set; }

        public FileData(int number, byte[] data)
        {
            Number = number;
            Data = data;
        }
    }
}