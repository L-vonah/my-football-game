﻿using LucasFootEntities.Models.Player;

namespace LucasFootEntities.Models.TeamModels.Team;

public class Team
{
    public static readonly int MaxPlayers = 30;
    public static readonly int MinPlayers = 11;

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<PlayerBase> Players { get; set; } = null!;
    public ICollection<TeamAchievementRecord> Achievements { get; set; } = null!;
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
    public Manager Manager { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

public class TeamAchievementRecord
{
    public int TeamId { get; set; }
    public Team Team { get; set; } = null!;
    public Competition Competition { get; set; } = null!;
    public int CompetitionId { get; set; }
    public int Year { get; set; }
    public int Position { get; set; }
}