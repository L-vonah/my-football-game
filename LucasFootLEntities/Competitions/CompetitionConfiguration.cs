namespace LucasFoot.Entities.Competitions
{
    public enum CompetitionType
    {
        Local,
        National,
        Continental,
        World
    }

    public enum CompetitionFormat
    {
        League,
        Knockout,
        GroupAndKnockout
    }

    public enum LeagueFormat { Single, Double }
    public enum GroupFormat { Single, Double }
    public enum KnockoutFormat { Single, Double }
}
