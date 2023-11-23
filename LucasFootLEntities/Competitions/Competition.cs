using System.ComponentModel;

namespace LucasFoot.Entities.Competitions
{
    public enum CompetitionType
    {
        [Description("Local")] Local,
        [Description("National")] National,
        [Description("Continental")] Continental,
        [Description("World")] World
    }
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public CompetitionType Type { get; set; }
    }
}
