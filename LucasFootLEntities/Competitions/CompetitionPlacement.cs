using LucasFoot.Entities.TeamModels.Team;

namespace LucasFoot.Entities.Competitions;

public class CompetitionPlacement
{
    public int TeamId { get; set; }
    public Team Team { get; set; } = null!;
    public int ManagerId { get; set; }
    public Manager.Manager Manager { get; set; } = null!;
    public int CompetitionId { get; set; }
    public Competition Competition { get; set; } = null!;
    public int Position { get; set; }
    public int Wins { get; set; }
    public int Draws { get; set; }
    public int Losses { get; set; }
    public int TopScorePlayerId { get; set; }
    public Player.Player TopScorePlayer { get; set; } = null!;
    public int TopAssistPlayerId { get; set; }
    public Player.Player TopAssistPlayer { get; set; } = null!;
}
