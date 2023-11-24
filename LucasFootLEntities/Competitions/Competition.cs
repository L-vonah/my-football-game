using LucasFoot.Entities.TeamModels.Team;

namespace LucasFoot.Entities.Competitions;

public abstract class Competition
{
    public int Id { get; set; }
    public int Year { get; set; }
    public abstract string Name { get; }
    public abstract CompetitionType Type { get; }
    public abstract CompetitionFormat Format { get; }
    public abstract int NumberOfTeams { get; }
    public abstract string Discriminator { get; }
}

public abstract class NationalCompetition : Competition
{
    public static LeagueFormat LeagueFormat => LeagueFormat.Double;
    public override CompetitionType Type => CompetitionType.National;
    public override CompetitionFormat Format => CompetitionFormat.League;
    public override string Discriminator => "National";
    public abstract LeagueDivision Division { get; }
    public abstract int Relegated { get; }
    public abstract int Promoted { get; }
    public ICollection<TeamGroupOrLeague>? Teams { get; set; }
}

public abstract class MainNationalCompetition : NationalCompetition
{
    public override string Discriminator => "MainNational";
    public abstract int MainClassifiedDirectly { get; }
    public abstract int MainClassifiedByPlayoff { get; }
    public abstract int SecondaryClassified { get; }
}

public abstract class CupCompetition : Competition
{
    public override string Discriminator => "Cup";
    public override CompetitionType Type => CompetitionType.National;
    public override CompetitionFormat Format => CompetitionFormat.Knockout;
    public abstract KnockoutFormat KnockoutFormat { get; }
    public ICollection<TeamCup>? Teams { get; set; }
}

public abstract class ContinentalCompetition : Competition
{
    public override string Discriminator => "Continental";
    public static GroupFormat GroupFormat => GroupFormat.Double;
    public static KnockoutFormat KnockoutFormat => KnockoutFormat.Double;
    public override CompetitionType Type => CompetitionType.Continental;
    public override CompetitionFormat Format => CompetitionFormat.GroupAndKnockout;
    public abstract int ClassifiedByGroup { get; }
    public abstract int NumberOfGroups { get; }
    public ICollection<TeamGroupOrLeague>? GroupTeams { get; set; }
    public ICollection<TeamCup>? CupTeams { get; set; }
}
