using MG64Lib.Exceptions;
using MG64Lib.GameData;
using MG64Lib.Utils;
using System.Collections.Generic;

namespace MG64Lib.Converters
{
    public class ObstacleListConverter
    {
        /// <summary>
        /// Convert an obstacle list to Mario Golf 64 format
        /// </summary>
        /// <param name="obstacles">A list of obstacles</param>
        /// <returns>A byte array containing obstacle data</returns>
        public static byte[] Convert(List<ObstacleData> obstacles)
        {
            var count = obstacles.Count;
            if (count > 255)
            {
                throw new ConverterException($"Too many obstacles provided, max 255 but received {count}");
            }
            var length = count * 12 + 1;
            var result = new byte[length];
            result[0] = (byte)count;
            for (var i = 0; i < count; i++)
            {
                var offset = i * 12 + 1;
                ArrayUtils.Write(obstacles[i].Position.X, result, offset);
                ArrayUtils.Write(obstacles[i].Position.Y, result, offset + 2);
                ArrayUtils.Write(obstacles[i].Position.Z, result, offset + 4);
                result[offset + 6] = (byte)obstacles[i].Obstacle;
                result[offset + 7] = 0;
                ArrayUtils.Write(obstacles[i].Width, result, offset + 8);
                ArrayUtils.Write(obstacles[i].Height, result, offset + 10);
            }
            return result;
        }
    }
}