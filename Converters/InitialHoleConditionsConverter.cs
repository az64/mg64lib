using MG64Lib.GameData;
using MG64Lib.Utils;

namespace MG64Lib.Converters
{
    public class InitialHoleConditionsConverter
    {
        /// <summary>
        /// Convert intial hole conditions to Mario Golf 64 format
        /// </summary>
        /// <param name="initial">Initial conditions</param>
        /// <returns>Byte array containing initial hole conditions data</returns>
        public static byte[] Convert(InitialHoleConditions initial)
        {
            var result = new byte[0x34];
            ArrayUtils.Write(initial.PinPosition.X, result, 0x00);
            ArrayUtils.Write(initial.PinPosition.Y, result, 0x04);
            ArrayUtils.Write(initial.PinPosition.Z, result, 0x08);
            ArrayUtils.Write(initial.TeePosition.X, result, 0x0C);
            ArrayUtils.Write(initial.TeePosition.Y, result, 0x10);
            ArrayUtils.Write(initial.TeePosition.Z, result, 0x14);
            ArrayUtils.Write(initial.WindSpeed, result, 0x18);
            ArrayUtils.Write(initial.WindDirection, result, 0x1C);
            ArrayUtils.Write(initial.Weather, result, 0x20);
            ArrayUtils.Write(initial.Time, result, 0x24);
            ArrayUtils.Write(initial.SunPosition1, result, 0x28);
            ArrayUtils.Write(initial.SunPosition2, result, 0x2A);
            result[0x2C] = initial.Par;
            result[0x2D] = initial.PinIndex;
            result[0x2E] = initial.Unk1;
            result[0x2F] = initial.Unk2;
            ArrayUtils.Write(initial.ConstEnd, result, 0x30);
            return result;
        }
    }
}