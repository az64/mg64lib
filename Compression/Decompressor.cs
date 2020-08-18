using MG64Lib.Utils;

namespace MG64Lib.Compression
{
    public class Decompressor
    {
        /// <summary>
        /// Decompress an array of bytes
        /// </summary>
        /// <param name="data">Byte array containing compressed data</param>
        /// <returns>Byta array containing decompressed data</returns>
        public static byte[] DecompressData(byte[] data)
        {
            var length = ArrayUtils.Read32(data, 0);
            var shortData = ArrayUtils.ByteToUshort(data);
            return Decompress(shortData, length);
        }

        private static byte[] Decompress(ushort[] data, int length)
        {
            var result = new ushort[length / 2];
            var resultAddress = 0;
            var resultLength = result.Length;
            var dataAddress = 2;
            var dataLength = data.Length;
            while ((resultAddress < resultLength) && (dataAddress < dataLength))
            {
                var codeWord = (data[dataAddress] << 16) | 0x8000;
                dataAddress++;
                while (true)
                {
                    if (codeWord < 0)
                    {
                        codeWord <<= 1;
                        if (codeWord == 0)
                        {
                            break;
                        }
                        var arg = data[dataAddress];
                        dataAddress++;
                        if (arg == 0)
                        {
                            break;
                        }
                        var copyEnd = resultAddress + (arg & 0x1F) + 2;
                        var copyOffset = arg >> 5;
                        while (resultAddress < copyEnd)
                        {
                            result[resultAddress] = result[resultAddress - copyOffset];
                            resultAddress++;
                        }
                    }
                    else
                    {
                        codeWord <<= 1;
                        result[resultAddress] = data[dataAddress];
                        resultAddress++;
                        dataAddress++;
                    }
                }
            }
            return ArrayUtils.UshortToByte(result);
        }
    }
}