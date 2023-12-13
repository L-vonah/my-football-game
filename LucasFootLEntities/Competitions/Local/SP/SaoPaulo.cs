namespace LucasFoot.Entities.Competitions.Local.SP
{
    public class PaulistaoA1 : LeagueAndKnockoutCompetition
    {
        public override int TeamsPerGroup => NumberOfTeams / NumberOfGroups;
        public override string Name => "Campeonato Paulista Série A1";
        public override int ClassifiedByGroup => 2;
        public override int NumberOfGroups => 4;
        public override int NumberOfTeams => 16;
        public override CompetitionLevel Level => CompetitionLevel.Local;
        public override CompetitionFormat Format => CompetitionFormat.LeagueAndKnockout;
        public override RelegationRule RelegationRule => RelegationRule.General;

        public PaulistaoA1(int year) : base(year) { }
    }

    public class PaulistaoA2 : LeagueCompetition
    {
        public override string Name => "Campeonato Paulista Série A2";
        public override int NumberOfTeams => 20;
        public override LeagueDivision Division => LeagueDivision.Second;
        public override CompetitionLevel Level => CompetitionLevel.Local;
        public override CompetitionFormat Format => CompetitionFormat.League;
        public override RelegationRule RelegationRule => RelegationRule.General;

        public PaulistaoA2(int year) : base(year) { }
    }
}
