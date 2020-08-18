using MG64Lib.Exceptions;
using MG64Lib.GameData;
using MG64Lib.Utils;
using System.Collections.Generic;

namespace MG64Lib.Converters
{
    public class TrianglesConverter
    {
        /// <summary>
        /// Convert triangle data to Mario Golf 64 format
        /// </summary>
        /// <param name="triangles">List of triangles</param>
        /// <returns>Byte array of triangle data</returns>
        public static byte[] Convert(List<TriangleData> triangles)
        {
            var count = triangles.Count;
            if (count > 255)
            {
                throw new ConverterException($"Too many triangles provided, max 255 but received {count}");
            }
            var length = count * 19 + 1;
            var result = new byte[length];
            result[0] = (byte)count;
            for (var i = 0; i < count; i++)
            {
                var offset = i * 19 + 1;
                result[offset] = (byte)triangles[i].Type;
                ArrayUtils.Write(triangles[i].Vertex1.X, result, offset + 1);
                ArrayUtils.Write(triangles[i].Vertex1.Y, result, offset + 3);
                ArrayUtils.Write(triangles[i].Vertex1.Z, result, offset + 5);
                ArrayUtils.Write(triangles[i].Vertex2.X, result, offset + 7);
                ArrayUtils.Write(triangles[i].Vertex2.Y, result, offset + 9);
                ArrayUtils.Write(triangles[i].Vertex2.Z, result, offset + 11);
                ArrayUtils.Write(triangles[i].Vertex3.X, result, offset + 13);
                ArrayUtils.Write(triangles[i].Vertex3.Y, result, offset + 15);
                ArrayUtils.Write(triangles[i].Vertex3.Z, result, offset + 17);
            }
            return result;
        }
    }
}