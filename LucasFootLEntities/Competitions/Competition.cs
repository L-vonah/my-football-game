using LucasFoot.Entities.TeamModels.Team;

namespace LucasFoot.Entities.Competitions;

public abstract class Competition
{
    public int Id { get; set; }
    public int Year { get; set; }
    public abstract string Name { get; }
    public abstract CompetitionLevel Level { get; }
    public abstract CompetitionFormat Format { get; }
    public abstract int NumberOfTeams { get; }
    public abstract string Discriminator { get; }
    public ICollection<CompetitionTeam>? Teams { get; set; }
}

public abstract class LeagueCompetition : Competition
{
    public static LeagueFormat LeagueFormat => LeagueFormat.Double;
    public override CompetitionFormat Format => CompetitionFormat.League;
    public override string Discriminator => nameof(LeagueCompetition);
    public abstract LeagueDivision Division { get; }
    public abstract int Relegated { get; }
    public abstract int Promoted { get; }
}

public abstract class MainLeagueCompetition : LeagueCompetition
{
    public override string Discriminator => nameof(MainLeagueCompetition);
    public abstract int MainClassifiedDirectly { get; }
    public abstract int MainClassifiedByPlayoff { get; }
    public abstract int SecondaryClassified { get; }
}

public abstract class KnockoutCompetition : Competition
{
    public override string Discriminator => nameof(KnockoutCompetition);
    public override CompetitionFormat Format => CompetitionFormat.Knockout;
    public abstract KnockoutFormat KnockoutFormat { get; }
    public CompetitionRound CompetitionRound { get; set; }
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
    public CompetitionRound CompetitionRound { get; set; }
}
