using LucasFoot.Entities.TeamModels.Team;

namespace LucasFoot.Entities.Competitions;

public abstract class Competition
{
    public int Id { get; set; }
    public int Year { get; set; }
    public string Name { get; }
    public int NumberOfTeams { get; }
    public Region Region { get; }
    public CompetitionLevel Level { get; }
    public abstract CompetitionFormat Format { get; }
    public abstract RelegationRule RelegationRule { get; }
    public abstract BrazilState State { get; }
    public abstract string Discriminator { get; }
    public ICollection<CompetitionTeam>? Teams { get; set; }

    public Competition(string name, int numberOfTeams, int year, Region region, CompetitionLevel level)
    {
        Name = name;
        NumberOfTeams = numberOfTeams;
        Year = year;
        Region = region;
        Level = level;
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

    public LeagueCompetition(string name, int numberOfTeams, int promoted, int relegated,
                             Region region, CompetitionLevel level, int year)
        : base(name, numberOfTeams, year, region, level)
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

    public KnockoutCompetition(string name, int numberOfTeams, int year,
                               Region region, CompetitionLevel level)
        : base(name, numberOfTeams, year, region, level) { }
}

public abstract class LeagueAndKnockoutCompetition : Competition
{
    public override string Discriminator => nameof(LeagueAndKnockoutCompetition);
    public static GroupFormat GroupFormat => GroupFormat.Double;
    public static KnockoutFormat KnockoutFormat => KnockoutFormat.Double;
    public override CompetitionFormat Format => CompetitionFormat.LeagueAndKnockout;
    public int ClassifiedByGroup { get; }
    public int NumberOfGroups { get; }
    public int TeamsPerGroup => NumberOfTeams / NumberOfGroups;
    public CompetitionRound CompetitionActualRound { get; set; }

    public LeagueAndKnockoutCompetition(string name, int numberOfTeams, int classifiedByGroup, int numberOfGroups,
                                        int year, Region region, CompetitionLevel level)
        : base(name, numberOfTeams, year, region, level)
    {
        ClassifiedByGroup = classifiedByGroup;
        NumberOfGroups = numberOfGroups;
    }
}
