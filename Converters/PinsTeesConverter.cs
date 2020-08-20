using MG64Lib.Exceptions;
using MG64Lib.GameData;
using MG64Lib.Utils;
using System.Collections.Generic;

namespace MG64Lib.Converters
{
    public class PinsTeesConverter
    {
        /// <summary>
        /// Converts pin positions, tee position, and aim positions to Mario Golf 64 ".pnt" format
        /// </summary>
        /// <param name="pin">A list of possible pin positions</param>
        /// <param name="tee">A tee position</param>
        /// <param name="aim">A list of aim positions</param>
        /// <returns>Byte array containing pin, tee, and aim data</returns>
        public static byte[] ConvertToPins(List<LiveCoordinates> pin, LiveCoordinates tee, List<LiveCoordinates> aim = null)
        {
            var pinCount = pin.Count;
            if (pinCount == 0)
            {
                throw new ConverterException("No pin positions were provided");
            }
            var aimCount = aim == null ? 0 : aim.Count;
            var data = new byte[0x120];
            for (var i = 0; i < 4; i++)
            {
                var offset = i * 12;
                var index = i >= pinCount ? pinCount - 1 : i;
                ArrayUtils.Write(pin[index].X, data, offset);
                ArrayUtils.Write(pin[index].Y, data, offset + 4);
                ArrayUtils.Write(pin[index].Z, data, offset + 8);
            }
            for (var i = 0; i < 4; i++)
            {
                var offset = i * 12 + 48;
                ArrayUtils.Write(tee.X, data, offset);
                ArrayUtils.Write(tee.Y, data, offset + 4);
                ArrayUtils.Write(tee.Z, data, offset + 8);
            }
            for (var i = 0; i < 16; i++)
            {
                var offset = i * 12 + 96;
                if (aimCount == 0)
                {
                    ArrayUtils.Write(0, data, offset);
                    ArrayUtils.Write(0, data, offset + 4);
                    ArrayUtils.Write(0, data, offset + 8);
                }
                else
                {
                    var index = i >= aimCount ? aimCount - 1 : i;
                    ArrayUtils.Write(aim[index].X, data, offset);
                    ArrayUtils.Write(aim[index].Y, data, offset + 4);
                    ArrayUtils.Write(aim[index].Z, data, offset + 8);
                }
            }
            return data;
        }

        /// <summary>
        /// Convert from Mario Golf 64 pin data
        /// </summary>
        /// <param name="pntData">Mario Golf 64 pnt data</param>
        /// <param name="pins">Return list of pin positions</param>
        /// <param name="tee">Return tee position</param>
        /// <param name="aim">Return list of aim positions</param>
        public static void ConvertFromPins(byte[] pntData, List<LiveCoordinates> pins, out LiveCoordinates tee, List<LiveCoordinates> aim)
        {
            if (pntData.Length != 0x120)
            {
                throw new ConverterException($"invalid data length, expected 0x120 but got 0x{pntData.Length:X}");
            }
            pins.Clear();
            aim.Clear();
            for (var i = 0; i < 4; i++)
            {
                var address = i * 12;
                pins.Add
                (
                    new LiveCoordinates(ArrayUtils.Read32(pntData, address), ArrayUtils.Read32(pntData, address + 4), ArrayUtils.Read32(pntData, address + 8))
                );
            }
            tee = new LiveCoordinates(ArrayUtils.Read32(pntData, 48), ArrayUtils.Read32(pntData, 52), ArrayUtils.Read32(pntData, 56));
            for (var i = 0; i < 16; i++)
            {
                var address = i * 12 + 96;
                aim.Add
                (
                    new LiveCoordinates(ArrayUtils.Read32(pntData, address), ArrayUtils.Read32(pntData, address + 4), ArrayUtils.Read32(pntData, address + 8))
                );
            }
        }
    }
}