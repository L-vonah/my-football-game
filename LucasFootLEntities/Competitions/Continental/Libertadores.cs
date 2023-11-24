namespace LucasFoot.Entities.Competitions.Continental
{
    public class Libertadores : Competition
    {
        public static GroupFormat GroupFormat => GroupFormat.Double;
        public static int ClassifiedByGroup => 2;
        public static int NumberOfGroups => 8;

        public override string Name => "Copa Libertadores";
        public override int NumberOfTeams => 32;
        public int TeamsPerGroup => NumberOfTeams / NumberOfGroups;
        public override CompetitionType Type => CompetitionType.Continental;
        public override CompetitionFormat Format => CompetitionFormat.GroupAndKnockout;
    }
}
