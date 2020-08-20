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
        public static byte[] ConvertToGroundMap(GroundType[,] ground)
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

        /// <summary>
        /// Convert from Mario Golf 64 att data
        /// </summary>
        /// <param name="attData">Mario Golf 64 att data</param>
        /// <returns>Ground type data</returns>
        public static GroundType[,] ConvertFromGroundMap(byte[] attData)
        {
            var length = attData.Length;
            if (length != 0x20000)
            {
                throw new ConverterException($"Invalid file size, expected 0x20000 but got 0x{length:X}");
            }
            var groundMap = new GroundType[256, 512];
            Buffer.BlockCopy(attData, 0, groundMap, 0, length);
            return groundMap;
        }

        /// <summary>
        /// Decompress and convert from Mario Golf 64 att data
        /// </summary>
        /// <param name="attData">Mario Golf 64 att data</param>
        /// <returns>Ground type data</returns>
        public static GroundType[,] DecompressAndConvertFromGroundMap(byte[] attData)
        {
            var decompressedData = Decompressor.DecompressData(attData);
            return ConvertFromGroundMap(decompressedData);
        }
    }
}