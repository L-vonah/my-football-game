using System.ComponentModel;

namespace LucasFoot.Models.Player
{
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
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public abstract Position Position { get; }
        public Foot Foot { get; set; }
        public int Energy { get; set; }
        public double Value { get; set; }
        public double Salary { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
    }
}
