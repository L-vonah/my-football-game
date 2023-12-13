namespace LucasFoot.Entities.Competitions.National;

public class PremierLeague : LeagueCompetition
{
    public override string Name => "Premier League";
    public override int NumberOfTeams => 20;
    public override LeagueDivision Division => LeagueDivision.First;
    public override CompetitionLevel Level => CompetitionLevel.National;
    public override RelegationRule RelegationRule => RelegationRule.General;

    public PremierLeague(int year) : base(year) { }
}
