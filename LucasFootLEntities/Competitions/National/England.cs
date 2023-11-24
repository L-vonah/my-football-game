namespace LucasFoot.Entities.Competitions.National
{
    public class PremierLeague : MainNationalCompetition
    {
        public override string Name => "Premier League";
        public override int MainClassifiedDirectly => 4;
        public override int MainClassifiedByPlayoff => 0;
        public override int SecondaryClassified => 6;
        public override int Relegated => 4;
        public override int Promoted => 0;
        public override int NumberOfTeams => 20;
    }
}
