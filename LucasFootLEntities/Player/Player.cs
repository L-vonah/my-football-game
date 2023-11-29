using LucasFoot.Entities.TeamModels.Team;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LucasFoot.Entities.Player;

public enum Position
{
    [Description("GK")] Goalkeeper,
    [Description("RB")] RightBack,
    [Description("LB")] LeftBack,
    [Description("CB")] CenterBack,
    [Description("DM")] DefensiveMidfielder,
    [Description("CM")] CentralMidfielder,
    [Description("AM")] AttackingMidfielder,
    [Description("RM")] RightMidfielder,
    [Description("LM")] LeftMidfielder,
    [Description("RW")] RightWinger,
    [Description("LW")] LeftWinger,
    [Description("SS")] SecondStriker,
    [Description("CF")] CenterForward
}

public enum Foot
{
    [Description("R")] Right,
    [Description("L")] Left,
    [Description("B")] Both
}

public abstract class PlayerBase
{
    public int Id { get; set; }

    [MaxLength(30)]
    public string Name { get; set; } = null!;
    public int Age { get; set; }
    public abstract Position Position { get; }
    public Foot Foot { get; set; }
    public int Energy { get; set; }
    public double Value { get; set; }
    public double LastSalary { get; set; }
    public int TotalGoals { get; set; }
    public int TotalAssists { get; set; }
    public int TotalYellowCards { get; set; }
    public int TotalRedCards { get; set; }
    public ICollection<TeamPlayerRecord> Teams { get; set; } = null!;
}

public class TeamPlayerRecord
{
    public int TeamId { get; set; }
    public Team Team { get; set; } = null!;
    public int PlayerId { get; set; }
    public PlayerBase Player { get; set; } = null!;
    public double Salary { get; set; }
    public int Goals { get; set; }
    public int Assists { get; set; }
    public int YellowCards { get; set; }
    public int RedCards { get; set; }
    public bool Active { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
