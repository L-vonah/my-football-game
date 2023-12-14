namespace LucasFoot.Entities.Player.Midfielder;

public class DefensiveMidfielder : Player
{
    public override Position Position => Position.DefensiveMidfielder;
}

public class CentralMidfielder : Player
{
    public override Position Position => Position.CentralMidfielder;
}

public class AttackingMidfielder : Player
{
    public override Position Position => Position.AttackingMidfielder;
}

public class RightMidfielder : Player
{
    public override Position Position => Position.RightMidfielder;
}

public class LeftMidfielder : Player
{
    public override Position Position => Position.LeftMidfielder;
}
