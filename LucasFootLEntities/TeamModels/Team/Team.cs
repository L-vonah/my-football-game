using LucasFoot.Entities.Competitions;
using LucasFoot.Entities.Manager;
using LucasFoot.Entities.Player;
using System.ComponentModel.DataAnnotations;

namespace LucasFoot.Entities.TeamModels.Team;

public class Team
{
    public static readonly int MaxPlayers = 30;
    public static readonly int MinPlayers = 11;

    public int Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; } = null!;
    public TeamLevel Level { get; set; }
    public ICollection<CompetitionPlacement> Placements { get; set; } = null!;
    public ICollection<TeamManagerRecord> Managers { get; set; } = null!;
    public ICollection<TeamPlayerRecord> Players { get; set; } = null!;

    public bool CanAddPlayer(PlayerBase player)
    {
        return Players.Count < MaxPlayers && !Players.Any(p => p.Player.Id == player.Id);
    }

    public bool CanRemovePlayer(PlayerBase player)
    {
        return Players.Count > MinPlayers && Players.Any(p => p.Player.Id == player.Id);
    }
}

public abstract class CompetitionTeam
{
    public int TeamId { get; set; }
    public Team Team { get; set; } = null!;
    public int CompetitionId { get; set; }
    public Competition Competition { get; set; } = null!;
    public int? ActualPosition { get; set; }
    public int? FinalPosition { get; set; }
    public int? BracketLocation { get; set; }
    public int Points { get; set; }
    public int Wins { get; set; }
    public int Draws { get; set; }
    public int Losses { get; set; }
    public int GoalsFor { get; set; }
    public int GoalsAgainst { get; set; }
    public int GoalDifference => GoalsFor - GoalsAgainst;
    public TeamLevel InitialLevel { get; init; }
    public abstract string Discriminator { get; }
}

public enum TeamLevel
{
    VeryLow = 0,
    Low = 10,
    LowMedium = 20,
    Medium = 30,
    HighMedium = 40,
    High = 50,
    VeryHigh = 60
}