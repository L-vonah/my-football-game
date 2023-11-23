namespace LucasFoot.Entities.Player.Midfielder;

public class DefensiveMidfielder : PlayerBase
{
    public override Position Position => Position.DefensiveMidfielder;
}

public class CentralMidfielder : PlayerBase
{
    public override Position Position => Position.CentralMidfielder;
}

public class AttackingMidfielder : PlayerBase
{
    public override Position Position => Position.AttackingMidfielder;
}

public class RightMidfielder : PlayerBase
{
    public override Position Position => Position.RightMidfielder;
}

public class LeftMidfielder : PlayerBase
{
    public override Position Position => Position.LeftMidfielder;
}
