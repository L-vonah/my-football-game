namespace LucasFoot.Entities.Competitions.Continental;

public class UefaChampionsLeague : LeagueAndKnockoutCompetition
{
    public override int TeamsPerGroup => NumberOfTeams / NumberOfGroups;
    public override string Name => "UEFA Champions League";
    public override int ClassifiedByGroup => 2;
    public override int NumberOfGroups => 8;
    public override int NumberOfTeams => 32;
    public override Region Location => Region.EUR;
    public override CompetitionLevel Level => CompetitionLevel.Continental;
    public override CompetitionFormat Format => CompetitionFormat.LeagueAndKnockout;
    public override RelegationRule RelegationRule => RelegationRule.None;
    public override BrazilState State => BrazilState.None;

    public UefaChampionsLeague(int year) : base(year) { }
}
