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
        /// <param name="rings">List of rings</param>
        /// <returns>Byte array of triangle data</returns>
        public static byte[] ConvertToTriangles(List<TriangleData> triangles, List<RingData> rings)
        {
            var count = triangles.Count + rings.Count;
            if (count > 255)
            {
                throw new ConverterException($"Too many triangles and rings provided, max 255 but received {count}");
            }
            var length = count * 19 + 1;
            var result = new byte[length];
            result[0] = (byte)count;
            var offset = 1;
            for (var i = 0; i < triangles.Count; i++)
            {
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
                offset += 19;
            }
            for (var i = 0; i < rings.Count; i++)
            {
                result[offset] = (byte)rings[i].Type;
                ArrayUtils.Write(rings[i].Position.X, result, offset + 1);
                ArrayUtils.Write(rings[i].Position.Y, result, offset + 3);
                ArrayUtils.Write(rings[i].Position.Z, result, offset + 5);
                ArrayUtils.Write(rings[i].Rotation.X, result, offset + 7);
                ArrayUtils.Write(rings[i].Rotation.Y, result, offset + 9);
                ArrayUtils.Write(rings[i].Rotation.Z, result, offset + 11);
                ArrayUtils.Write(rings[i].Scale, result, offset + 13);
                offset += 19;
            }
            return result;
        }

        /// <summary>
        /// Convert from Mario Golf 64 triangle data
        /// </summary>
        /// <param name="triData">Mario Golf 64 tri data file</param>
        /// <param name="triangles">Return list of triangles</param>
        /// <param name="rings">Return list of rings</param>
        public static void ConvertFromTriangles(byte[] triData, List<TriangleData> triangles, List<RingData> rings)
        {
            triangles.Clear();
            rings.Clear();
            var dataLength = triData.Length;
            if (dataLength == 0)
            {
                return;
            }
            var count = triData[0];
            var readCount = 0;
            var address = 1;
            while ((readCount < count) && (address < dataLength))
            {
                try
                {
                    var type = (TriangleType)triData[address];
                    var data1 = ArrayUtils.Read16(triData, address + 1);
                    var data2 = ArrayUtils.Read16(triData, address + 3);
                    var data3 = ArrayUtils.Read16(triData, address + 5);
                    var data4 = ArrayUtils.Read16(triData, address + 7);
                    var data5 = ArrayUtils.Read16(triData, address + 9);
                    var data6 = ArrayUtils.Read16(triData, address + 11);
                    var data7 = ArrayUtils.Read16(triData, address + 13);
                    var data8 = ArrayUtils.Read16(triData, address + 15);
                    var data9 = ArrayUtils.Read16(triData, address + 17);
                    if (type == TriangleType.Ring)
                    {
                        rings.Add
                        (
                            new RingData
                            (
                                new GeometryCoordinates(data1, data2, data3),
                                new GeometryCoordinates(data4, data5, data6),
                                data7
                            )
                        );
                    }
                    else
                    {
                        triangles.Add
                        (
                            new TriangleData
                            (
                                type, 
                                new GeometryCoordinates(data1, data2, data3),
                                new GeometryCoordinates(data4, data5, data6),
                                new GeometryCoordinates(data7, data8, data9)
                             )
                        );
                    }
                }
                catch
                {
                    throw new ConverterException($"Error reading triangle data from address {address:X}");
                }
            }
        }
    }
}