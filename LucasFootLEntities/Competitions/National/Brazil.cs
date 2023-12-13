namespace LucasFoot.Entities.Competitions.National;

public class Brasileirao : LeagueCompetition
{
    public override string Name => "Brasileirão";
    public override int NumberOfTeams => 20;
    public override Region Location => Region.BRA;
    public override LeagueDivision Division => LeagueDivision.First;
    public override CompetitionLevel Level => CompetitionLevel.National;
    public override RelegationRule RelegationRule => RelegationRule.General;
    public override BrazilState State => BrazilState.None;

    public Brasileirao(int promoted, int relegated, int year) : base(promoted, relegated, year) { }
}

public class BrasileiraoB : LeagueCompetition
{
    public override string Name => "Brasileirão Série B";
    public override int NumberOfTeams => 20;
    public override Region Location => Region.BRA;
    public override LeagueDivision Division => LeagueDivision.Second;
    public override CompetitionLevel Level => CompetitionLevel.National;
    public override RelegationRule RelegationRule => RelegationRule.General;
    public override BrazilState State => BrazilState.None;

    public BrasileiraoB(int promoted, int relegated, int year) : base(promoted, relegated, year) { }

}

public class BrasileiraoC : LeagueCompetition
{
    public override string Name => "Brasileirão Série C";
    public override int NumberOfTeams => 20;
    public override Region Location => Region.BRA;
    public override LeagueDivision Division => LeagueDivision.Third;
    public override CompetitionLevel Level => CompetitionLevel.National;
    public override RelegationRule RelegationRule => RelegationRule.General;
    public override BrazilState State => BrazilState.None;

    public BrasileiraoC(int promoted, int relegated, int year) : base(promoted, relegated, year) { }
}
