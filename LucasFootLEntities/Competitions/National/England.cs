namespace LucasFoot.Entities.Competitions.National;

public class PremierLeague : LeagueCompetition
{
    public override string Name => "Premier League";
    public override int NumberOfTeams => 20;
    public override Region Location => Region.ENG;
    public override LeagueDivision Division => LeagueDivision.First;
    public override CompetitionLevel Level => CompetitionLevel.National;
    public override RelegationRule RelegationRule => RelegationRule.General;
    public override BrazilState State => BrazilState.None;

    public PremierLeague(int promoted, int relegated, int year) : base(promoted, relegated, year) { }
}
