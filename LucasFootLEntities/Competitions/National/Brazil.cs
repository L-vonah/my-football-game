namespace LucasFoot.Entities.Competitions.National
{
    public class Brasileirao : MainNationalCompetition
    {
        public override int MainClassifiedDirectly => 4;
        public override int MainClassifiedByPlayoff => 2;
        public override int SecondaryClassified => 6;
        public override int Relegated => 4;
        public override int Promoted => 0;
        public override string Name => "Brasileirão";
        public override int NumberOfTeams => 20;
    }

    public class BrasileiraoB : NationalCompetition
    {
        public override int Relegated => 4;
        public override int Promoted => 4;
        public override string Name => "Brasileirão Série B";
        public override int NumberOfTeams => 20;
    }

    public class BrasileiraoC : NationalCompetition
    {
        public override int Relegated => 4;
        public override int Promoted => 4;
        public override string Name => "Brasileirão Série C";
        public override int NumberOfTeams => 20;
    }
}
