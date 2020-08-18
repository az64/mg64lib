using MG64Lib.Exceptions;
using MG64Lib.GameData;
using System.Collections.Generic;

namespace MG64Lib.Converters
{
    public class GeometryConverter
    {
        /// <summary>
        /// Convert an array of co-ordinates to Mario Golf 64 geometry format
        /// </summary>
        /// <param name="vertices">Geometry vertices</param>
        /// <param name="expected">Expected vertices</param>
        /// <returns>A byte array containing geometry data</returns>
        public static byte[] Convert(GeometryCoordinates[] vertices, GeometryCoordinates[] expected)
        {
            var verticesLength = vertices.Length;
            var expectedLength = expected.Length;
            if (verticesLength != expectedLength)
            {
                throw new ConverterException("Number of vertices does not match number of expected vertices");
            }
            var result = new List<byte>();
            for (var i = 0; i < verticesLength; i++)
            {
                EncodeVertex(vertices[i], expected[i], result);
            }
            result.Add(9);
            while (result.Count % 16 != 0)
            {
                result.Add(0xFF);
            }
            return result.ToArray();
        }

        private static void EncodeVertex(GeometryCoordinates vertex, GeometryCoordinates expected, List<byte> data)
        {
            var implicitPosition = new bool[3];
            var position = new int[3];
            var shifted = new bool[3];
            position[0] = vertex.X;
            position[1] = vertex.Y;
            position[2] = vertex.Z;
            implicitPosition[0] = vertex.X == expected.X;
            implicitPosition[2] = vertex.Z == expected.Z;
            var encodeCommand = 0;
            for (var i = 0; i < 3; i++)
            {
                if (implicitPosition[i])
                {
                    switch (i)
                    {
                        case 0:
                            encodeCommand += 0x40;
                            break;
                        case 1:
                            throw new ConverterException("Y co-ordinate cannot be implicit");
                        case 2:
                            encodeCommand += 0x80;
                            break;
                    }
                }
                else
                {
                    var shifts = i == 1 ? new int[] { 0, 1, 2 } : new int[3] { 8, 5, 6 };
                    var shiftData = GetShift(position[i], shifts);
                    position[i] = shiftData[0];
                    encodeCommand += shiftData[1] << (i << 1);
                    shifted[i] = shiftData[1] != 0;
                }
            }
            if (encodeCommand == 9)
            {
                // Avoid this value as it signals end of data...
                // Reset y co-ordinate
                encodeCommand = 1;
                position[1] = vertex.Y;
                shifted[1] = false;
            }
            data.Add((byte)encodeCommand);
            for (var i = 0; i < 3; i++)
            {
                if (!implicitPosition[i])
                {
                    if (!shifted[i])
                    {
                        data.Add((byte)(position[i] >> 8));
                    }
                    data.Add((byte)position[i]);
                }
            }
        }

        private static int[] GetShift(int position, int[] shift)
        {
            var data = position;
            var type = 0;
            for (var i = 0; i < 3; i++)
            {
                var shiftedData = (sbyte)(position >> shift[i]);
                if (shiftedData << shift[i] == position)
                {
                    data = shiftedData;
                    type = i + 1;
                    break;
                }
            }
            return new int[] { data, type };
        }
    }
}