namespace LucasFoot.Entities.Competitions.National
{
    public class Brasileirao : MainNationalCompetition
    {
        public static LeagueFormat LeagueFormat => LeagueFormat.Double;

        public override int MainClassifiedDirectly => 4;
        public override int MainClassifiedByPlayoff => 2;
        public override int SecondaryClassified => 6;
        public override int Relegated => 4;
        public override int Promoted => 0;
        public override string Name => "Brasileirão";
        public override int NumberOfTeams => 20;
        public override CompetitionType Type => CompetitionType.National;
        public override CompetitionFormat Format => CompetitionFormat.League;
    }

    public class BrasileiraoB : NationalCompetition
    {
        public static LeagueFormat LeagueFormat => LeagueFormat.Double;

        public override int Relegated => 4;
        public override int Promoted => 4;
        public override string Name => "Brasileirão Série B";
        public override int NumberOfTeams => 20;
        public override CompetitionType Type => CompetitionType.National;
        public override CompetitionFormat Format => CompetitionFormat.League;
    }

    public class BrasileiraoC : NationalCompetition
    {
        public static LeagueFormat LeagueFormat => LeagueFormat.Double;

        public override int Relegated => 4;
        public override int Promoted => 4;
        public override string Name => "Brasileirão Série C";
        public override int NumberOfTeams => 20;
        public override CompetitionType Type => CompetitionType.National;
        public override CompetitionFormat Format => CompetitionFormat.League;
    }
}
