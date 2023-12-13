namespace LucasFoot.Entities.Competitions.Continental;

public class Libertadores : LeagueAndKnockoutCompetition
{
    public override int TeamsPerGroup => NumberOfTeams / NumberOfGroups;
    public override string Name => "Copa Libertadores";
    public override int ClassifiedByGroup => 2;
    public override int NumberOfGroups => 8;
    public override int NumberOfTeams => 32;
    public override CompetitionLevel Level => CompetitionLevel.Continental;
    public override CompetitionFormat Format => CompetitionFormat.LeagueAndKnockout;
    public override RelegationRule RelegationRule => RelegationRule.None;

    public Libertadores(int year) : base(year) { }
}
