using MG64Lib.Exceptions;
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
        public static byte[] ConvertToInitialConditions(InitialHoleConditions initial)
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

        /// <summary>
        /// Convert from Mario Golf 64 hol data
        /// </summary>
        /// <param name="holData">Mario Golf 64 hol data</param>
        /// <returns>Initial hole conditions</returns>
        public static InitialHoleConditions ConvertFromInitialConditions(byte[] holData)
        {
            if (holData.Length != 0x34)
            {
                throw new ConverterException($"Invalid file length, expected 0x34 but got 0x{holData.Length:X}");
            }
            var initialConditions = new InitialHoleConditions();
            initialConditions.PinPosition = new LiveCoordinates(ArrayUtils.Read32(holData, 0x00), ArrayUtils.Read32(holData, 0x04), ArrayUtils.Read32(holData, 0x08));
            initialConditions.TeePosition = new LiveCoordinates(ArrayUtils.Read32(holData, 0x0C), ArrayUtils.Read32(holData, 0x10), ArrayUtils.Read32(holData, 0x14));
            initialConditions.WindSpeed = ArrayUtils.Read32(holData, 0x18);
            initialConditions.WindDirection = ArrayUtils.Read32(holData, 0x1C);
            initialConditions.Weather = ArrayUtils.Read32(holData, 0x20);
            initialConditions.Time = ArrayUtils.Read32(holData, 0x24);
            initialConditions.SunPosition1 = ArrayUtils.Read16(holData, 0x28);
            initialConditions.SunPosition2 = ArrayUtils.Read16(holData, 0x2A);
            initialConditions.Par = holData[0x2C];
            initialConditions.PinIndex = holData[0x2D];
            initialConditions.Unk1 = holData[0x2E];
            initialConditions.Unk2 = holData[0x2F];
            return initialConditions;
        }
    }
}