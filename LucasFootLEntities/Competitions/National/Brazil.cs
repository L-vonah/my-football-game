namespace LucasFoot.Entities.Competitions.National;

public class Brasileirao : LeagueCompetition
{
    public override string Name => "Brasileirão";
    public override LeagueDivision Division => LeagueDivision.First;
    public override CompetitionLevel Level => CompetitionLevel.National;
    public override RelegationRule RelegationRule => RelegationRule.General;
    public override int NumberOfTeams => 20;

    public Brasileirao(int year) : base(year) { }
}

public class BrasileiraoB : LeagueCompetition
{
    public override string Name => "Brasileirão Série B";
    public override int NumberOfTeams => 20;
    public override LeagueDivision Division => LeagueDivision.Second;
    public override CompetitionLevel Level => CompetitionLevel.National;
    public override RelegationRule RelegationRule => RelegationRule.General;

    public BrasileiraoB(int year) : base(year) { }

}

public class BrasileiraoC : LeagueCompetition
{
    public override string Name => "Brasileirão Série C";
    public override int NumberOfTeams => 20;
    public override LeagueDivision Division => LeagueDivision.Third;
    public override CompetitionLevel Level => CompetitionLevel.National;
    public override RelegationRule RelegationRule => RelegationRule.General;

    public BrasileiraoC(int year) : base(year) { }
}
