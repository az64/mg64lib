using MG64Lib.Exceptions;
using MG64Lib.GameData;
using MG64Lib.Utils;
using System.Collections.Generic;

namespace MG64Lib.Converters
{
    public class GeometryConverter
    {
        private static readonly int[] xzShifts = { 0, 8, 5, 6 };
        private static readonly int[] yShifts = { 0, 0, 1, 2 };

        /// <summary>
        /// Convert an array of co-ordinates to Mario Golf 64 geometry format
        /// </summary>
        /// <param name="vertices">Geometry vertices</param>
        /// <param name="expected">Expected vertices</param>
        /// <returns>A byte array containing geometry data</returns>
        public static byte[] ConvertToGeometry(GeometryCoordinates[] vertices, GeometryCoordinates[] expected)
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
                    var shifts = i == 1 ? yShifts : xzShifts;
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
            for (var i = 1; i < 4; i++)
            {
                var shiftedData = (sbyte)(position >> shift[i]);
                if (shiftedData << shift[i] == position)
                {
                    data = shiftedData;
                    type = i;
                    break;
                }
            }
            return new int[] { data, type };
        }

        /// <summary>
        /// Convert from Mario Golf 64 vtx and dtx formats
        /// </summary>
        /// <param name="data">Mario Golf 64 geometry data</param>
        /// <param name="expected">Expected vertices</param>
        /// <returns>List of vertices</returns>
        public static GeometryCoordinates[] ConvertFromGeometry(byte[] data, GeometryCoordinates[] expected)
        {
            var length = expected.Length;
            if ((length != 0x251) && (length != 0x800))
            {
                throw new ConverterException("Expected vertices supplied are of unexpected size.");
            }
            var geometryData = ArrayUtils.GetNewArray<GeometryCoordinates>(length);
            var address = 0;
            for (var i = 0; i < length; i++)
            {
                var encoding = data[address];
                address++;
                if (encoding == 9)
                {
                    break;
                }
                else
                {
                    var implicitZ = (encoding & 128) > 0;
                    var implicitX = (encoding & 64) > 0;
                    var shiftZ = (encoding & 48) >> 4;
                    var shiftY = (encoding & 12) >> 2;
                    var shiftX = encoding & 3;
                    if (implicitX)
                    {
                        geometryData[i].X = expected[i].X;
                    }
                    else
                    {
                        geometryData[i].X = GetCoordinate(shiftX, xzShifts, data, ref address);
                    }
                    geometryData[i].Y = GetCoordinate(shiftY, yShifts, data, ref address);
                    if (implicitZ)
                    {
                        geometryData[i].Z = expected[i].Z;
                    }
                    else
                    {
                        geometryData[i].Z = GetCoordinate(shiftZ, xzShifts, data, ref address);
                    }
                }
            }
            return geometryData;
        }

        private static short GetCoordinate(int shiftIndex, int[] shiftAmounts, byte[] data, ref int address)
        {
            short shiftedCoordinate;
            if (shiftIndex == 0)
            {
                shiftedCoordinate = ArrayUtils.Read16(data, address);
                address += 2;
            }
            else
            {
                shiftedCoordinate = data[address];
                address++;
            }
            return (short)(shiftedCoordinate << shiftAmounts[shiftIndex]);
        }
    }
}