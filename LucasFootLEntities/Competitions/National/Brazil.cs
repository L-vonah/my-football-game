namespace LucasFoot.Entities.Competitions.National;

public class Brasileirao : MainLeagueCompetition
{
    public override string Name => "Brasileirão";
    public override int MainClassifiedDirectly => 4;
    public override int MainClassifiedByPlayoff => 2;
    public override int SecondaryClassified => 6;
    public override int Relegated => 4;
    public override int Promoted => 0;
    public override int NumberOfTeams => 20;
    public override LeagueDivision Division => LeagueDivision.First;
    public override CompetitionLevel Level => CompetitionLevel.National;
}

public class BrasileiraoB : LeagueCompetition
{
    public override int Relegated => 4;
    public override int Promoted => 4;
    public override string Name => "Brasileirão Série B";
    public override int NumberOfTeams => 20;
    public override LeagueDivision Division => LeagueDivision.Second;
    public override CompetitionLevel Level => CompetitionLevel.National;
}

public class BrasileiraoC : LeagueCompetition
{
    public override int Relegated => 4;
    public override int Promoted => 4;
    public override string Name => "Brasileirão Série C";
    public override int NumberOfTeams => 20;
    public override LeagueDivision Division => LeagueDivision.Third;
    public override CompetitionLevel Level => CompetitionLevel.National;
}
