using LucasFoot.Entities.TeamModels.Team;
using System.ComponentModel.DataAnnotations;

namespace LucasFoot.Entities.Manager;

public class Manager
{
    public int Id { get; set; }

    [MaxLength(30)]
    public string Name { get; set; } = null!;
    public ICollection<TeamManagerRecord> Teams { get; set; } = null!;
}

public class TeamManagerRecord
{
    public int TeamId { get; set; }
    public Team Team { get; set; } = null!;
    public int ManagerId { get; set; }
    public Manager Manager { get; set; } = null!;
    public bool Active { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
