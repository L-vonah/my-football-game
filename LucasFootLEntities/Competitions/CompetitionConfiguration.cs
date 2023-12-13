namespace LucasFoot.Entities.Competitions
{
    public enum CompetitionLevel { Local, National, Continental, World }
    public enum CompetitionFormat { League, Knockout, LeagueAndKnockout }
    public enum LeagueFormat { Single, Double }
    public enum LeagueDivision { None, First, Second, Third }
    public enum GroupFormat { Single, Double }
    public enum KnockoutFormat { Single, Double }
    public enum CompetitionRound { Final, Semifinal, Quarterfinal, RoundOf16, RoundOf32, RoundOf64, GroupStage, LeagueStage }
    public enum RelegationRule { None, ByGroup, General }
}
