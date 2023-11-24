namespace LucasFoot.Entities.Competitions
{
    public abstract class Competition
    {
        public int Id { get; set; }
        public abstract string Name { get; }
        public abstract CompetitionType Type { get; }
        public abstract CompetitionFormat Format { get; }
        public abstract int NumberOfTeams { get; }
    }

    public abstract class NationalCompetition : Competition
    {
        public abstract int Relegated { get; }
        public abstract int Promoted { get; }
    }

    public abstract class MainNationalCompetition : NationalCompetition
    {
        public abstract int MainClassifiedDirectly { get; }
        public abstract int MainClassifiedByPlayoff { get; }
        public abstract int SecondaryClassified { get; }
    }
}
