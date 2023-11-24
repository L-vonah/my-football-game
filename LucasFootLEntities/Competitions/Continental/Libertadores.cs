﻿namespace LucasFoot.Entities.Competitions.Continental;

public class Libertadores : ContinentalCompetition
{
    public override int TeamsPerGroup => NumberOfTeams / NumberOfGroups;
    public override string Name => "Copa Libertadores";
    public override int ClassifiedByGroup => 2;
    public override int NumberOfGroups => 8;
    public override int NumberOfTeams => 32;
    public override CompetitionType Type => CompetitionType.Continental;
    public override CompetitionFormat Format => CompetitionFormat.GroupAndKnockout;
}
