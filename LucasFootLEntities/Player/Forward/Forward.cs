namespace LucasFoot.Entities.Player.Forward;

public class RightWinger : Player
{
    public override Position Position => Position.RightWinger;
}

public class LeftWinger : Player
{
    public override Position Position => Position.LeftWinger;
}

public class SecondStriker : Player
{
    public override Position Position => Position.SecondStriker;
}

public class CenterForward : Player
{
    public override Position Position => Position.CenterForward;
}
