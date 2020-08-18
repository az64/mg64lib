using MG64Lib.Attributes;

namespace MG64Lib.GameData
{
    public enum MusicSequence : short
    {
        [Name("Eagle fanfare")]
        Eagle,

        [Name("Birdie fanfare")]
        Birdie,

        [Name("Par fanfare")]
        Par,

        [Name("Match win")]
        MatchWin,

        [Name("Bogey fanfare")]
        Bogey,

        [Name("Over par fanfare")]
        OverPar,

        [Name("Win point")]
        WinPoint,

        [Name("Lose point")]
        LosePoint,

        [Name("Tie")]
        Tie,

        [Name("GBC remix 1")]
        GbcRemix1,

        [Name("GBC remix 2")]
        GbcRemix2,

        [Name("Hole intro 1")]
        HoleIntro1,

        [Name("Toad Highlands")]
        ToadHighlands,

        [Name("Koopa Park")]
        KoopaPark,

        [Name("Par putt")]
        ParPutt,

        [Name("Bogey putt")]
        BogeyPutt,

        [Name("Birdie putt")]
        BirdiePutt,

        [Name("Shy Guy Desert")]
        ShyGuyDesert,

        [Name("Boo Valley")]
        BooValley,

        [Name("Yoshi's Island")]
        YoshiIsland,

        [Name("Dormie")]
        Dormie,

        [Name("Training")]
        Training,

        [Name("GBC menu")]
        GbcMenu,

        [Name("Controls menu")]
        ControlsMenu,

        [Name("Speed golf hole intro")]
        SpeedGolfHoleIntro,

        [Name("Stroke hole intro")]
        StrokeHoleIntro,

        [Name("Training hole intro")]
        TrainingHoleIntro,

        [Name("Hole intro 2")]
        HoleIntro2,

        [Name("Unknown")]
        Unknown,

        [Name("Ring shot hole intro")]
        RingShotHoleIntro,

        [Name("Ring shot")]
        RingShot,

        [Name("Replay")]
        ShotReplay,

        [Name("Toad Tournament")]
        ToadTournament,

        [Name("Koopa Cup")]
        KoopaTournament,

        [Name("Shy Guy International")]
        ShyGuyTournament,

        [Name("Boo Clasic")] // This is the 'correct' spelling...
        BooTournament,

        [Name("Mario Open")]
        MarioTournament,

        [Name("Tournament results")]
        TournamentResults,

        [Name("Speed golf")]
        SpeedGolf,

        [Name("Main menu")]
        MainMenu,

        [Name("GBC remix 3")]
        GbcRemix3,

        [Name("Mario's Star")]
        MarioStar,

        [Name("Title screen")]
        TitleScreen,

        [Name("Club slots")]
        ClubSlots,

        [Name("Mini golf")]
        MiniGolf,

        [Name("Mini golf hole intro")]
        MiniGolfHoleIntro,

        [Name("Skins hole intro")]
        SkinsHoleIntro,

        [Name("Intro cutscene")]
        IntroCutscene,

        [Name("Yoshi Championship")]
        YoshiTournament,

        [Name("Credits")]
        Credits,

        [Name("The end")]
        TheEnd
    }
}