using LucasFootEntities.Models.TeamModels.Team;
using System.ComponentModel.DataAnnotations;

namespace LucasFootEntities.Models.Manager;

public class Manager
{
    public int Id { get; set; }

    [MaxLength(20)]
    public string Name { get; set; } = null!;
    public Team? ActualTeam { get; set; }

    public ICollection<Team> LastTeams { get; set; } = null!;

    public List<Achievement> Achievements { get; set; } = null!;
}

public class Achievement
{
}
