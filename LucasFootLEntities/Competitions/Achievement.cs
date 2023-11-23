using LucasFoot.Entities.Manager;
using LucasFoot.Entities.TeamModels.Team;

namespace LucasFoot.Entities.Competitions;

public class Achievement
{
    public int TeamId { get; set; }
    public Team Team { get; set; } = null!;
    public int ManagerId { get; set; }
    public TeamManager Manager { get; set; } = null!;
    public Competition Competition { get; set; } = null!;
    public int CompetitionId { get; set; }
    public int Year { get; set; }
    public int Position { get; set; }
}
