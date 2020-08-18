using MG64Lib.Attributes;

namespace MG64Lib.GameData
{
    public enum Obstacle : byte
    {
        [ObstacleScale(91, 352), Name("Sunflower")]
        Sunflower,

        [ObstacleScale(91, 352), Name("Buttercup 1")]
        Buttercup1,

        [ObstacleScale(91, 352), Name("Daisy")]
        Daisy,

        [ObstacleScale(108, 395), Name("Koopa Bush")]
        KoopaTroopaBush,

        [ObstacleScale(95, 307), Name("Green Koopa Shell 1")]
        GreenKoopaShell1,

        [ObstacleScale(108, 395), Name("Spruce Tree 1")]
        SpruceTree1,

        [ObstacleScale(108, 395), Name("Spruce Tree 2")]
        SpruceTree2,

        [ObstacleScale(104, 302), Name("Tall Toad Tree")]
        ToadTreeTall,

        [ObstacleScale(104, 302), Name("Short Toad Tree")]
        ToadTreeShort,

        [ObstacleScale(104, 302), Name("Toad Bush")]
        ToadBush,

        [ObstacleScale(104, 302), Name("Dark Toad Tree")]
        ToadTreeDark,

        [ObstacleScale(95, 307), Name("Koopa Tree")]
        KoopaTree,

        [ObstacleScale(95, 307), Name("Green Koopa Shell 2")]
        GreenKoopaShell2,

        [ObstacleScale(95, 307), Name("Red Koopa Shell")]
        RedKoopaShell,

        [ObstacleScale(95, 307), Name("Red Spiny Shell")]
        RedSpinyShell,

        [ObstacleScale(34, 128), Name("Flowering Cactus")]
        FloweringCactus,

        [ObstacleScale(76, 296), Name("Tall Cactus")]
        CactusTall,

        [ObstacleScale(49, 201), Name("Green Shy Guy Cactus")]
        GreenShyGuyCactus,

        [ObstacleScale(49, 201), Name("Red Shy Guy Cactus")]
        RedShyGuyCactus,

        [ObstacleScale(91, 352), Name("Shy Guy Statue")]
        ShyGuyStatue,

        [ObstacleScale(226, 744), Name("Green Boo Tree")]
        BooTreeGreen,

        [ObstacleScale(226, 744), Name("Red Boo Tree")]
        BooTreeRed,

        [ObstacleScale(226, 744), Name("Blue Boo Tree")]
        BooTreeBlue,

        [ObstacleScale(64, 256), Name("Red Mushroom")]
        MushroomRed,

        [ObstacleScale(64, 256), Name("Green Mushroom")]
        MushroomGreen,

        [ObstacleScale(97, 391), Name("Tall Tropical Tree")]
        TropicalTreeTall,

        [ObstacleScale(97, 391), Name("Mid Tropical Tree")]
        TropicalTreeMid,

        [ObstacleScale(97, 391), Name("Short Tropical Tree")]
        TropicalTreeShort,

        [ObstacleScale(97, 391), Name("Orange")]
        Orange,

        [ObstacleScale(97, 391), Name("Melon")]
        Melon,

        [ObstacleScale(91, 352), Name("Piranha Plant")]
        PiranhaPlant,

        [ObstacleScale(91, 352), Name("Tulip")]
        Tulip,

        [ObstacleScale(91, 352), Name("Short Daisy")]
        DaisyShort,

        [ObstacleScale(91, 352), Name("Buttercup 2")]
        Buttercup2,

        [ObstacleScale(91, 352), Name("Light Bush")]
        LightBush,

        [ObstacleScale(108, 395), Name("100 Sign")]
        Sign100,

        [ObstacleScale(108, 395), Name("200 Sign")]
        Sign200,

        [ObstacleScale(108, 395), Name("300 Sign")]
        Sign300,

        [ObstacleScale(108, 395), Name("400 Sign")]
        Sign400,

        [ObstacleScale(108, 395), Name("+50 Sign")]
        SignPlus50,

        [ObstacleScale(11, 48), Name("Training Sign")]
        SignTraining,

        [ObstacleScale(42, 129), Name("Black Bob-omb")]
        BlackBobOmb,

        [ObstacleScale(42, 129), Name("Red Bob-omb")]
        RedBobOmb,
        
        [ObstacleScale(137, 497), Name("Red Tree")]
        RedTree,

        [ObstacleScale(137, 497), Name("Blue Tree")]
        BlueTree,

        [ObstacleScale(137, 497), Name("Green Tree")]
        GreenTree
    }
}