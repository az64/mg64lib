using MG64Lib.Utils;
using System.Collections.Generic;

namespace MG64Lib.Compression
{
    public class Compressor
    {
        private static readonly int maxLookback = 0x7FF;
        private static readonly int maxMatchLength = 0x21;

        /// <summary>
        /// Compress an array of bytes into Mario Golf 64's compression format
        /// </summary>
        /// <param name="data">Byte array containing data to be compressed</param>
        /// <returns>Byte array containing compressed data</returns>
        public static byte[] CompressData(byte[] data)
        {
            var length = data.Length;
            var shortData = ArrayUtils.ByteToUshort(data);
            return Compress(shortData, length);
        }

        private static byte[] Compress(ushort[] data, int decompressedLength)
        {
            List<ushort> compressedData = new List<ushort>();
            // The first word will be the size of the decompressed data
            compressedData.Add((ushort)(decompressedLength >> 16));
            compressedData.Add((ushort)decompressedLength);
            var dataAddress = 0;
            var dataLength = data.Length;
            var endDataWritten = false;
            var lookAheadOnPrevious = false;
            var resultOnLookAhead = new int[] { 0, 1 };
            while (dataAddress < dataLength)
            {
                var codeAddress = compressedData.Count;
                compressedData.Add(0);
                for (var i = 0; i < 16; i++)
                {
                    if (dataAddress >= dataLength)
                    {
                        compressedData[codeAddress] |= (ushort)(1 << (15 - i));
                        compressedData.Add(0);
                        endDataWritten = true;
                        break;
                    }
                    var result = SearchWithLookAhead(data, dataAddress, dataLength, ref resultOnLookAhead, ref lookAheadOnPrevious);
                    if (result[1] > 1)
                    {
                        var relativeAddress = dataAddress - result[0];
                        var combined = (ushort)(((relativeAddress & 0x7FF) << 5) | ((result[1] - 2) & 0x1F));
                        compressedData[codeAddress] |= (ushort)(1 << (15 - i));
                        compressedData.Add(combined);
                        dataAddress += result[1];
                    }
                    else
                    {
                        compressedData.Add(data[dataAddress]);
                        dataAddress++;
                    }
                }
            }
            if (!endDataWritten)
            {
                compressedData.Add(0x8000);
                compressedData.Add(0);
            }
            while (compressedData.Count % 8 != 0)
            {
                compressedData.Add(0);
            }
            var returnShortData = compressedData.ToArray();
            return ArrayUtils.UshortToByte(returnShortData);
        }

        private static int[] SearchWithLookAhead(ushort[] data, int address, int length, ref int[] resultOnLookAhead, ref bool lookAheadOnPrevious)
        {
            if (lookAheadOnPrevious)
            {
                lookAheadOnPrevious = false;
                return resultOnLookAhead;
            }
            var result = GetBestMatch(data, address, length);
            if (result[1] > 1)
            {
                resultOnLookAhead = GetBestMatch(data, address + 1, length);
                if (resultOnLookAhead[1] > result[1] + 1)
                {
                    result[1] = 1;
                    lookAheadOnPrevious = true;
                }
            }
            return result;
        }

        private static int[] GetBestMatch(ushort[] data, int address, int length)
        {
            var result = new int[] { 0, 1 };
            if (address + 1 < length)
            {
                var searchAddress = address - maxLookback;
                if (searchAddress < 0)
                {
                    searchAddress = 0;
                }
                var comparisonEnd = address + maxMatchLength;
                if (comparisonEnd > length)
                {
                    comparisonEnd = length;
                }
                while (searchAddress < address)
                {
                    searchAddress = FindMatch(data, searchAddress, address, data[address]);
                    if (searchAddress == -1)
                    {
                        break;
                    }
                    var searchComparison = searchAddress + 1;
                    var sourceComparison = address + 1;
                    while ((sourceComparison < comparisonEnd) && (data[searchComparison] == data[sourceComparison]))
                    {
                        searchComparison++;
                        sourceComparison++;
                    }
                    var matchLength = sourceComparison - address;
                    if (result[1] < matchLength)
                    {
                        result[1] = matchLength;
                        result[0] = searchAddress;
                        if (result[1] == maxMatchLength)
                        {
                            break;
                        }
                    }
                    searchAddress++;
                }
            }
            return result;
        }

        private static int FindMatch(ushort[] data, int start, int end, ushort searchValue)
        {
            for (var i = start; i < end; i++)
            {
                if (data[i] == searchValue)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
