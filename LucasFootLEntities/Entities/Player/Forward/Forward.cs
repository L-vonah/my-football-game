namespace LucasFootEntities.Models.Player.Forward
{
    public class RightWinger : PlayerBase
    {
        public override Position Position => Position.RightWinger;
    }

    public class LeftWinger : PlayerBase
    {
        public override Position Position => Position.LeftWinger;
    }

    public class SecondStriker : PlayerBase
    {
        public override Position Position => Position.SecondStriker;
    }

    public class CenterForward : PlayerBase
    {
        public override Position Position => Position.CenterForward;
    }
}
