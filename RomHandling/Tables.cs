using MG64Lib.Compression;
using MG64Lib.Constants;
using MG64Lib.GameData;
using MG64Lib.Utils;
using System.Collections.Generic;

namespace MG64Lib.RomHandling
{
    public static class Tables
    {
        public static class Assets
        {
            public static List<AssetTableEntry> GetAllEntries(byte[] rom)
            {
                var entries = new List<AssetTableEntry>();
                var address = RomAddresses.assetTable;
                var assetTableEnd = ArrayUtils.Read32(rom, address + 4) + address;
                while (address < assetTableEnd)
                {
                    entries.Add(new AssetTableEntry(ArrayUtils.Read32(rom, address + 4), ArrayUtils.Read32(rom, address)));
                    address += 8;
                }
                return entries;
            }

            public static byte[] GetEntryData(byte[] rom, AssetTableEntry entry)
            {
                return ArrayUtils.ReadData(rom, entry.Offset + RomAddresses.assetTable, entry.Size);
            }
        }

        public static class Objects
        {
            public static List<ObjectTableEntry> GetAllEntries(byte[] rom)
            {
                var entries = new List<ObjectTableEntry>();
                var address = RomAddresses.objectTable;
                for (var i = 0; i < RomAddresses.objectCount; i++)
                {
                    entries.Add(new ObjectTableEntry(ArrayUtils.Read32(rom, address), ArrayUtils.Read32(rom, address + 4)));
                    address += 0x58;
                }
                return entries;
            }

            public static byte[] GetEntryData(byte[] rom, ObjectTableEntry entry)
            {
                var compressedData = ArrayUtils.ReadData(rom, entry.RomStart, entry.RomEnd - entry.RomStart);
                return Decompressor.DecompressData(compressedData);
            }
        }
    }
}