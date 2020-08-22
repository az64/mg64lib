using MG64Lib.Attributes;

namespace MG64Lib.GameData
{
    public enum MusicSequence : short
    {
        [Name("Eagle fanfare"), InternalName("jing1")]
        Eagle,

        [Name("Birdie fanfare"), InternalName("jing02")]
        Birdie,

        [Name("Par fanfare"), InternalName("jing03")]
        Par,

        [Name("Match win"), InternalName("jing04")]
        MatchWin,

        [Name("Bogey fanfare"), InternalName("jing05")]
        Bogey,

        [Name("Over par fanfare"), InternalName("jing06")]
        OverPar,

        [Name("Win point"), InternalName("shori")]
        WinPoint,

        [Name("Lose point"), InternalName("make")]
        LosePoint,

        [Name("Tie"), InternalName("hikiwa")]
        Tie,

        [Name("GBC remix 1"), InternalName("mode-ok")]
        GbcRemix1,

        [Name("GBC remix 2"), InternalName("score")]
        GbcRemix2,

        [Name("Hole intro 1"), InternalName("coace3")]
        HoleIntro1,

        [Name("Toad Highlands"), InternalName("trad1")]
        ToadHighlands,

        [Name("Koopa Park"), InternalName("trad2")]
        KoopaPark,

        [Name("Par putt"), InternalName("par")]
        ParPutt,

        [Name("Bogey putt"), InternalName("bar")]
        BogeyPutt,

        [Name("Birdie putt"), InternalName("dan1")]
        BirdiePutt,

        [Name("Shy Guy Desert"), InternalName("bgm04")]
        ShyGuyDesert,

        [Name("Boo Valley"), InternalName("bgm05")]
        BooValley,

        [Name("Yoshi's Island"), InternalName("bgm06")]
        YoshiIsland,

        [Name("Dormie"), InternalName("coace5")]
        Dormie,

        [Name("Training"), InternalName("training")]
        Training,

        [Name("GBC menu"), InternalName("gbdata")]
        GbcMenu,

        [Name("Controls menu"), InternalName("coace9")]
        ControlsMenu,

        [Name("Speed golf hole intro"), InternalName("coace8")]
        SpeedGolfHoleIntro,

        [Name("Stroke hole intro"), InternalName("coace7")]
        StrokeHoleIntro,

        [Name("Training hole intro"), InternalName("coace6")]
        TrainingHoleIntro,

        [Name("Hole intro 2"), InternalName("coace10")]
        HoleIntro2,

        [Name("Unknown"), InternalName("coace4")]
        Unknown,

        [Name("Ring shot hole intro"), InternalName("pop1")]
        RingShotHoleIntro,

        [Name("Ring shot"), InternalName("pop2")]
        RingShot,

        [Name("Replay"), InternalName("replay")]
        ShotReplay,

        [Name("Toad Tournament"), InternalName("trad3")]
        ToadTournament,

        [Name("Koopa Cup"), InternalName("trad4")]
        KoopaTournament,

        [Name("Shy Guy International"), InternalName("pop3")]
        ShyGuyTournament,

        [Name("Boo Clasic"), InternalName("pop4")] // Clasic is the 'correct' spelling...
        BooTournament,

        [Name("Mario Open"), InternalName("pop5")]
        MarioTournament,

        [Name("Tournament results"), InternalName("pop6")]
        TournamentResults,

        [Name("Speed golf"), InternalName("time")]
        SpeedGolf,

        [Name("Main menu"), InternalName("64theme")]
        MainMenu,

        [Name("GBC remix 3"), InternalName("nangoku")]
        GbcRemix3,

        [Name("Mario's Star"), InternalName("mariobgm")]
        MarioStar,

        [Name("Title screen"), InternalName("mario20")]
        TitleScreen,

        [Name("Club slots"), InternalName("clav")]
        ClubSlots,

        [Name("Mini golf"), InternalName("patar1")]
        MiniGolf,

        [Name("Mini golf hole intro"), InternalName("patar2")]
        MiniGolfHoleIntro,

        [Name("Skins hole intro"), InternalName("skins")]
        SkinsHoleIntro,

        [Name("Intro cutscene"), InternalName("openning")]
        IntroCutscene,

        [Name("Yoshi Championship"), InternalName("bgm20")]
        YoshiTournament,

        [Name("Credits"), InternalName("ending")]
        Credits,

        [Name("The end"), InternalName("end-jingle")]
        TheEnd
    }
}