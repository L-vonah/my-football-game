using LucasFoot.Entities.Competitions;
using LucasFoot.Entities.TeamModels.Team;

namespace LucasFoot.Entities.Match;

public class CompetitionMatch
{
    public Guid MatchId { get; set; }
    public int CompetitionId { get; set; }
    public Competition Competition { get; set; } = null!;
    public int HomeTeamId { get; set; }
    public Team HomeTeam { get; set; } = null!;
    public int AwayTeamId { get; set; }
    public Team AwayTeam { get; set; } = null!;
    public int HomeGoals { get; set; }
    public int AwayGoals { get; set; }
    public int? ExtraTime { get; set; }
    public ICollection<MatchEvent>? Events { get; set; }
}

public class MatchEvent
{
    public Guid MatchId { get; set; }
    public CompetitionMatch Match { get; set; } = null!;
    public MatchEventType Type { get; set; }
    public int Minute { get; set; }
    public int PrimaryPlayerId { get; set; }
    public Player.Player PrimaryPlayer { get; set; } = null!;
    public int? SecondaryPlayerId { get; set; }
    public Player.Player? SecondaryPlayer { get; set; }
}

public enum MatchEventType
{
    Goal, YellowCard, RedCard, Substitution, PenaltyGoal, PenaltyMiss
}