namespace LucasFoot.Models.Player.Defense
{
    public class Goalkeeper : PlayerBase
    {
        public override Position Position => Position.Goalkeeper;
    }

    public class RightBack : PlayerBase
    {
        public override Position Position => Position.RightBack;
    }

    public class LeftBack : PlayerBase
    {
        public override Position Position => Position.LeftBack;
    }

    public class CenterBack : PlayerBase
    {
        public override Position Position => Position.CenterBack;
    }
}
