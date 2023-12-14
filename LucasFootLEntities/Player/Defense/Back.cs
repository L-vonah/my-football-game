namespace LucasFoot.Entities.Player.Defense;

public class Goalkeeper : Player
{
    public override Position Position => Position.Goalkeeper;
}

public class RightBack : Player
{
    public override Position Position => Position.RightBack;
}

public class LeftBack : Player
{
    public override Position Position => Position.LeftBack;
}

public class CenterBack : Player
{
    public override Position Position => Position.CenterBack;
}
