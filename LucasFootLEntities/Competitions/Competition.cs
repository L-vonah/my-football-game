using LucasFoot.Entities.TeamModels.Team;

namespace LucasFoot.Entities.Competitions;

public abstract class Competition
{
    public int Id { get; set; }
    public int Year { get; set; }
    public abstract string Name { get; }
    public abstract Region Location { get; }
    public abstract CompetitionLevel Level { get; }
    public abstract CompetitionFormat Format { get; }
    public abstract RelegationRule RelegationRule { get; }
    public abstract BrazilState State { get; }
    public abstract int NumberOfTeams { get; }
    public abstract string Discriminator { get; }
    public ICollection<CompetitionTeam>? Teams { get; set; }

    public Competition(int year)
    {
        Year = year;
    }
}

public abstract class LeagueCompetition : Competition
{
    public int Relegated { get; private set; }
    public int Promoted { get; private set; }
    public int MainClassifiedDirectly { get; private set; }
    public int MainClassifiedByPlayoff { get; private set; }
    public int SecondaryClassified { get; private set; }
    public static LeagueFormat LeagueFormat => LeagueFormat.Double;
    public override CompetitionFormat Format => CompetitionFormat.League;
    public override string Discriminator => nameof(LeagueCompetition);
    public abstract LeagueDivision Division { get; }

    public LeagueCompetition(int promoted, int relegated, int year) : base(year)
    {
        Relegated = relegated;
        Promoted = promoted;

        if (IsMainCompetition() && IsNationalCompetition())
        {
            MainClassifiedDirectly = 4;
            MainClassifiedByPlayoff = 2;
            SecondaryClassified = 6;
        }
    }

    public bool IsMainCompetition()
    {
        return Division == LeagueDivision.First;
    }

    public bool IsNationalCompetition()
    {
        return Level == CompetitionLevel.National;
    }
}

public abstract class KnockoutCompetition : Competition
{
    public override string Discriminator => nameof(KnockoutCompetition);
    public override CompetitionFormat Format => CompetitionFormat.Knockout;
    public override RelegationRule RelegationRule => RelegationRule.None;
    public abstract KnockoutFormat KnockoutFormat { get; }
    public CompetitionRound CompetitionActualRound { get; set; }

    public KnockoutCompetition(int year) : base(year) { }
}

public abstract class LeagueAndKnockoutCompetition : Competition
{
    public override string Discriminator => nameof(LeagueAndKnockoutCompetition);
    public static GroupFormat GroupFormat => GroupFormat.Double;
    public static KnockoutFormat KnockoutFormat => KnockoutFormat.Double;
    public override CompetitionFormat Format => CompetitionFormat.LeagueAndKnockout;
    public abstract int ClassifiedByGroup { get; }
    public abstract int NumberOfGroups { get; }
    public abstract int TeamsPerGroup { get; }
    public CompetitionRound CompetitionActualRound { get; set; }

    public LeagueAndKnockoutCompetition(int year) : base(year) { }
}
