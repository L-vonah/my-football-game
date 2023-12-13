namespace LucasFoot.Entities.Competitions.Local.SP
{
    public class BrazilStateLeague : LeagueCompetition
    {
        public override BrazilState State { get; }
        public override string Name => "Campeonato Estadual";
        public override int NumberOfTeams => 8;
        public override Region Location => Region.BRA;
        public override LeagueDivision Division { get; }
        public override CompetitionLevel Level => CompetitionLevel.Local;
        public override RelegationRule RelegationRule => RelegationRule.General;

        public BrazilStateLeague(int promoted, int relegated, int year,
                                 BrazilState state, LeagueDivision division)
            : base(promoted, relegated, year)
        {
            State = state;
            Division = division;
        }
    }

    public class PaulistaoA1 : LeagueAndKnockoutCompetition
    {
        public override BrazilState State { get; }
        public override int TeamsPerGroup => NumberOfTeams / NumberOfGroups;
        public override string Name => "Campeonato Paulista Série A1";
        public override int ClassifiedByGroup => 2;
        public override int NumberOfGroups => 4;
        public override int NumberOfTeams => 16;
        public override Region Location => Region.BRA;
        public override CompetitionLevel Level => CompetitionLevel.Local;
        public override CompetitionFormat Format => CompetitionFormat.LeagueAndKnockout;
        public override RelegationRule RelegationRule => RelegationRule.General;

        public PaulistaoA1(int year, BrazilState state) : base(year)
        {
            State = state;
        }
    }

    public class PaulistaoA2 : LeagueCompetition
    {
        public override BrazilState State { get; }
        public override string Name => "Campeonato Paulista Série A2";
        public override int NumberOfTeams => 20;
        public override Region Location => Region.BRA;
        public override LeagueDivision Division => LeagueDivision.Second;
        public override CompetitionLevel Level => CompetitionLevel.Local;
        public override CompetitionFormat Format => CompetitionFormat.League;
        public override RelegationRule RelegationRule => RelegationRule.General;

        public PaulistaoA2(int promoted, int relegated, int year, BrazilState state) : base(promoted, relegated, year)
        {
            State = state;
        }
    }
}
