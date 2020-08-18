namespace MG64Lib.Utils
{
    public class ArrayUtils
    {
        public static void Write(int src, byte[] dest, int address)
        {
            dest[address] = (byte)(src >> 24);
            dest[address + 1] = (byte)(src >> 16);
            dest[address + 2] = (byte)(src >> 8);
            dest[address + 3] = (byte)src;
        }

        public static void Write(short src, byte[] dest, int address)
        {
            dest[address] = (byte)(src >> 8);
            dest[address + 1] = (byte)src;
        }

        public static void Write(byte[] src, byte[] dest, int address)
        {
            for (var i = 0; i < src.Length; i++)
            {
                dest[address + i] = src[i];
            }
        }

        public static int Read32(byte[] src, int address)
        {
            return (src[address] << 24) | (src[address + 1] << 16) | (src[address + 2] << 8) | src[address + 3];
        }

        public static short Read16(byte[] src, int address)
        {
            return (short)((src[address] << 8) | src[address + 1]);
        }

        public static uint ReadU32(byte[] src, int address)
        {
            return (uint)((src[address] << 24) | (src[address + 1] << 16) | (src[address + 2] << 8) | src[address + 3]);
        }

        public static ushort ReadU16(byte[] src, int address)
        {
            return (ushort)((src[address] << 8) | src[address + 1]);
        }

        public static byte[] ReadData(byte[] src, int address, int length)
        {
            var dest = new byte[length];
            for (var i = 0; i < length; i++)
            {
                dest[i] = src[address + i];
            }
            return dest;
        }

        public static byte[] UshortToByte(ushort[] src)
        {
            var length = src.Length;
            var result = new byte[length * 2];
            for (var i = 0; i < length; i++)
            {
                Write((short)src[i], result, i * 2);
            }
            return result;
        }

        public static ushort[] ByteToUshort(byte[] src)
        {
            var length = src.Length;
            var shortLength = length / 2;
            var isOdd = length %= 2;
            var result = new ushort[shortLength + isOdd];
            for (var i = 0; i < shortLength; i++)
            {
                result[i] = ReadU16(src, i * 2);
            }
            if (isOdd == 1)
            {
                result[shortLength] = (ushort)(src[length - 1] << 8);
            }
            return result;
        }

        public static T[] GetNewArray<T>(int count) where T : new()
        {
            var result = new T[count];
            for (var i = 0; i < count; i++)
            {
                result[i] = new T();
            }
            return result;
        }
    }
}