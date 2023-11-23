using LucasFoot.Entities.Competitions;
using LucasFoot.Entities.TeamModels.Team;
using System.ComponentModel.DataAnnotations;

namespace LucasFoot.Entities.Manager;

public class TeamManager
{
    public int Id { get; set; }

    [MaxLength(20)]
    public string Name { get; set; } = null!;
    public Team? ActualTeam { get; set; }

    public ICollection<TeamManagerRecord> LastTeams { get; set; } = null!;

    public ICollection<Achievement> Achievements { get; set; } = null!;
}
