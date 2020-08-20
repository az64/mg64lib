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
        public static byte[] ConvertToObstacles(List<ObstacleData> obstacles)
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

        /// <summary>
        /// Convert from Mario Golf 64 tre data
        /// </summary>
        /// <param name="treData">Mario Golf 64 tre data</param>
        /// <returns>List of obstacles</returns>
        public static List<ObstacleData> ConvertFromObstacles(byte[] treData)
        {
            var dataLength = treData.Length;
            var obstacleData = new List<ObstacleData>();
            if (dataLength == 0)
            {
                return obstacleData;
            }
            var count = treData[0];
            var readCount = 0;
            var address = 1;
            while ((readCount < count) && (address < dataLength))
            {
                try
                {
                    var position = new GeometryCoordinates
                    (
                        ArrayUtils.Read16(treData, address),
                        ArrayUtils.Read16(treData, address + 2),
                        ArrayUtils.Read16(treData, address + 4)
                    );
                    var type = (Obstacle)treData[address + 6];
                    var width = ArrayUtils.Read16(treData, address + 8);
                    var height = ArrayUtils.Read16(treData, address + 10);
                    obstacleData.Add
                    (
                        new ObstacleData(type, position, width, height)
                    );
                }
                catch
                {
                    throw new ConverterException($"Error reading tre data at address {address:X}");
                }
            }
            return obstacleData;
        }
    }
}