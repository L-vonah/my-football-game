using LucasFoot.Entities.Competitions;
using LucasFoot.Entities.Manager;
using LucasFoot.Entities.Player;

namespace LucasFoot.Entities.TeamModels.Team;

public class Team
{
    public static readonly int MaxPlayers = 30;
    public static readonly int MinPlayers = 11;

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<PlayerBase> Players { get; set; } = null!;
    public ICollection<Achievement> Achievements { get; set; } = null!;
    public ICollection<TeamManagerRecord> Managers { get; set; } = null!;

    public bool CanAddPlayer(PlayerBase player)
    {
        return Players.Count < MaxPlayers && !Players.Any(p => p.Position == player.Position);
    }

    public bool CanRemovePlayer(PlayerBase player)
    {
        return Players.Count > MinPlayers && Players.Any(p => p.Position == player.Position);
    }
}

public class TeamManagerRecord
{
    public int TeamId { get; set; }
    public Team Team { get; set; } = null!;
    public int ManagerId { get; set; }
    public TeamManager Manager { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}