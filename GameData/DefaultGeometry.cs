using MG64Lib.Utils;

namespace MG64Lib.GameData
{
    public static class DefaultGeometry
    {
        public static GeometryCoordinates[] VtxCoordinates { get; private set; }
        public static GeometryCoordinates[] DtxCoordinates { get; private set; }

        public static void Initialise()
        {
            var vtxXPattern = new short[]
            {
                0x0000,
                0x0200,
                0x0400,
                0x0600,
                0x0800,
                0x0A00,
                0x0C00,
                0x0E00,
                0x1000,
                0x0100,
                0x0300,
                0x0500,
                0x0700,
                0x0900,
                0x0B00,
                0x0D00,
                0x0F00
            };
            var dtxXPattern = new short[]
            {
                0x0080,
                0x0180,
                0x0000,
                0x0200,
                0x0000,
                0x0200,
                0x0080,
                0x0180,
                0x0080,
                0x0100,
                0x0180,
                0x0080,
                0x0180,
                0x0080,
                0x0100,
                0x0180
            };
            var dtxZPattern = new short[]
            {
                0x0000,
                0x0000,
                0x0080,
                0x0080,
                0x0180,
                0x0180,
                0x0200,
                0x0200,
                0x0080,
                0x0080,
                0x0080,
                0x0100,
                0x0100,
                0x0180,
                0x0180,
                0x0180
            };
            VtxCoordinates = ArrayUtils.GetNewArray<GeometryCoordinates>(0x231);
            DtxCoordinates = ArrayUtils.GetNewArray<GeometryCoordinates>(0x800);
            for (var j = 0; j < 33; j++)
            {
                for (var i = 0; i < 17; i++)
                {
                    var index = i + j * 17;
                    VtxCoordinates[index].X = vtxXPattern[i];
                    VtxCoordinates[index].Z = (short)(j << 8);
                }
            }
            for (var k = 0; k < 16; k++)
            {
                for (var j = 0; j < 8; j++)
                {
                    for (var i = 0; i < 16; i++)
                    {
                        var index = i + j * 16 + k * 128;
                        DtxCoordinates[index].X = (short)(dtxXPattern[i] + (j << 9));
                        DtxCoordinates[index].Z = (short)(dtxZPattern[i] + (k << 9));
                    }
                }
            }
        }
    }
}