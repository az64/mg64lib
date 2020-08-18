using MG64Lib.Exceptions;

namespace MG64Lib.Utils
{
    public class RomUtils
    {
        private static readonly int expectedRomSize = 0x2000000;

        public static bool ValidateRom(byte[] rom)
        {
            var romLength = rom.Length;
            if (romLength != expectedRomSize)
            {
                throw new RomException($"Expected ROM size 0x{expectedRomSize:X8}, got 0x{romLength:X8}");
            }
            if (!CrcUtrils.CheckCrc(rom))
            {
                throw new RomException($"Could not verify input ROM is Mario Golf 64 (USA)");
            }
            return true;
        }
    }
}