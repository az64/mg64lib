using MG64Lib.Exceptions;
using MG64Lib.GameData;
using MG64Lib.Utils;

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
        public static byte[] Convert(LiveCoordinates[] pin, LiveCoordinates tee, LiveCoordinates[] aim)
        {
            var pinCount = pin.Length;
            if (pinCount == 0)
            {
                throw new ConverterException("No pin positions were provided");
            }
            var aimCount = aim.Length;
            if (aimCount == 0)
            {
                throw new ConverterException("No aim positions were provided");
            }
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
                var index = i >= aimCount ? aimCount - 1 : i;
                ArrayUtils.Write(aim[index].X, data, offset);
                ArrayUtils.Write(aim[index].Y, data, offset + 4);
                ArrayUtils.Write(aim[index].Z, data, offset + 8);
            }
            return data;
        }
    }
}