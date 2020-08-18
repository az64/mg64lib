namespace MG64Lib.Utils
{
    public class CrcUtrils
    {
        public class Crc
        {
            public uint Crc1 { get; set; }
            public uint Crc2 { get; set; }

            public Crc(uint crc1, uint crc2)
            {
                Crc1 = crc1;
                Crc2 = crc2;
            }
        }

        private static readonly Crc MG64_US_CRC = new Crc(0x664BA3D4, 0x678A80B7);
        private static readonly int crcStartAddress = 0x1000;
        private static readonly int crcLength = 0x100000;
        private static readonly uint crcSeed = 0xF8CA4DDC;

        public static bool IsValidCrc(Crc romCrc)
        {
            return ((romCrc.Crc1 == MG64_US_CRC.Crc1) & (romCrc.Crc2 == MG64_US_CRC.Crc2));
        }

        public static Crc GetCrc(byte[] rom)
        {
            uint t1, t2, t3, t4, t5, t6, r, d;
            var i = crcStartAddress;
            t1 = t2 = t3 = t4 = t5 = t6 = crcSeed;
            while (i < crcStartAddress + crcLength)
            {
                d = ArrayUtils.ReadU32(rom, i);
                if ((t6 + d) < t6) { t4++; }
                t6 += d;
                t3 ^= d;
                r = (d << (byte)(d & 0x1F)) | (d >> (byte)(32 - (d & 0x1F)));
                t5 += r;
                if (t2 < d)
                {
                    t2 ^= (t6 ^ d);
                }
                else
                {
                    t2 ^= r;
                }
                t1 += t5 ^ d;
                i += 4;
            }
            return new Crc(t6 ^ t4 ^ t3, t5 ^ t2 ^ t1);
        }

        public static void SetCrc(byte[] rom, Crc romCrc)
        {
            ArrayUtils.Write((int)romCrc.Crc1, rom, 0x10);
            ArrayUtils.Write((int)romCrc.Crc2, rom, 0x14);
        }

        public static void FixCrc(byte[] rom)
        {
            Crc romCrc = GetCrc(rom);
            SetCrc(rom, romCrc);
        }

        public static bool CheckCrc(byte[] rom)
        {
            Crc romCrc = GetCrc(rom);
            return IsValidCrc(romCrc);
        }
    }
}