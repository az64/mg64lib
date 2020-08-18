using MG64Lib.Compression;
using MG64Lib.Exceptions;
using MG64Lib.GameData;
using System;

namespace MG64Lib.Converters
{
    public class GroundMapConverter
    {
        /// <summary>
        /// Converts an array of ground types to Mario Golf 64 ".att" format and compresses the resulting data
        /// </summary>
        /// <param name="ground">Array of ground type data</param>
        /// <returns>Byte array containing compressed ground type data</returns>
        public static byte[] Convert(GroundType[,] ground)
        {
            var length = ground.Length;
            if (length != 0x20000)
            {
                throw new ConverterException($"Ground map is of unexpected size, expected 0x20000 but got 0x{length:X}");
            }
            var data = new byte[length];
            Buffer.BlockCopy(ground, 0, data, 0, length);
            return Compressor.CompressData(data);
        }
    }
}