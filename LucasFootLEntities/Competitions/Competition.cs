using LucasFoot.Entities.Match;
using LucasFoot.Entities.TeamModels.Team;

namespace LucasFoot.Entities.Competitions;

public abstract class Competition
{
    public int Id { get; set; }
    public int Year { get; private set; }
    public int NumberOfTeams { get; private set; }
    public string Name { get; private set; }
    public bool IsFinished { get; private set; }
    public CompetitionLevel Level { get; private set; }
    public Region Region { get; private set; }
    public abstract CompetitionFormat CompetitionFormat { get; }
    public abstract LeagueDivision Division { get; }
    public abstract RelegationRule RelegationRule { get; }
    public abstract BrazilState State { get; }
    public abstract string Discriminator { get; }
    public ICollection<CompetitionTeam>? Teams { get; set; }
    public ICollection<CompetitionMatch>? Matches { get; set; }

    private CompetitionRound _round;
    protected CompetitionRound ActualRound
    {
        get { return _round; }
        set { _round = value; }
    }

    public Competition(string name, int numberOfTeams, int year, Region region, CompetitionLevel level)
    {
        Name = name;
        NumberOfTeams = numberOfTeams;
        Year = year;
        Region = region;
        Level = level;
    }

    public bool TryFinishCompetition()
    {
        if (!IsFinished && AllMatchesFinished())
        {
            IsFinished = true;
        }

        return IsFinished;
    }

    private bool AllMatchesFinished()
    {
        throw new NotImplementedException();
    }
}

public class LeagueCompetition : Competition
{
    public int MainClassifiedDirectly { get; private set; }
    public int MainClassifiedByPlayoff { get; private set; }
    public int SecondaryClassified { get; private set; }
    public int Promoted { get; private set; }
    public int Relegated { get; private set; }
    public LeagueFormat LeagueFormat { get; private set; }
    public override LeagueDivision Division { get; }
    public override RelegationRule RelegationRule { get; }
    public override BrazilState State { get; }
    public override CompetitionFormat CompetitionFormat => CompetitionFormat.League;
    public override string Discriminator => nameof(LeagueCompetition);

    public LeagueCompetition(string name, int numberOfTeams, int promoted, int relegated, int year,
                             Region region, CompetitionLevel level, LeagueDivision division, LeagueFormat format,
                             RelegationRule relegationRule, BrazilState? state = null)
        : base(name, numberOfTeams, year, region, level)
    {
        Promoted = promoted;
        Relegated = relegated;
        Division = division;
        LeagueFormat = format;
        RelegationRule = relegationRule;
        State = state ?? BrazilState.None;
        ActualRound = CompetitionRound.LeagueStage;

        if (IsMainCompetition() && IsNationalCompetition())
        {
            MainClassifiedDirectly = 4;
            MainClassifiedByPlayoff = 2;
            SecondaryClassified = 6;
        }
    }

    public bool IsMainCompetition()
    {
        return Division == LeagueDivision.First;
    }

    public bool IsNationalCompetition()
    {
        return Level == CompetitionLevel.National;
    }

    public CompetitionRound GetActualRound()
    {
        return ActualRound;
    }
}

public class KnockoutCompetition : Competition
{
    public KnockoutFormat KnockoutFormat { get; private set; }
    public override BrazilState State { get; }
    public override CompetitionFormat CompetitionFormat => CompetitionFormat.Knockout;
    public override LeagueDivision Division => LeagueDivision.None;
    public override RelegationRule RelegationRule => RelegationRule.None;
    public override string Discriminator => nameof(KnockoutCompetition);

    public KnockoutCompetition(string name, int numberOfTeams, int year, Region region, CompetitionLevel level,
                               KnockoutFormat knockoutFormat, BrazilState? state = null)
        : base(name, numberOfTeams, year, region, level)
    {
        ValidateNumberOfTeams(numberOfTeams);
        KnockoutFormat = knockoutFormat;
        ActualRound = GetKnockoutRoundByNumberOfTeams(numberOfTeams);
        State = state ?? BrazilState.None;
    }

    private static CompetitionRound GetKnockoutRoundByNumberOfTeams(int teams)
    {
        return teams switch
        {
            64 => CompetitionRound.RoundOf64,
            32 => CompetitionRound.RoundOf32,
            16 => CompetitionRound.RoundOf16,
            8 => CompetitionRound.Quarterfinal,
            4 => CompetitionRound.Semifinal,
            2 => CompetitionRound.Final,
            _ => throw new ArgumentException(
                "Number of teams must be less than or equal to 64 and greather than 1.", nameof(NumberOfTeams))
        };
    }

    public CompetitionRound GetActualRound()
    {
        return ActualRound;
    }

    public void UpdateActualRound() // check if all matches are finished
    {
        ActualRound = ActualRound switch
        {
            CompetitionRound.RoundOf64 => CompetitionRound.RoundOf32,
            CompetitionRound.RoundOf32 => CompetitionRound.RoundOf16,
            CompetitionRound.RoundOf16 => CompetitionRound.Quarterfinal,
            CompetitionRound.Quarterfinal => CompetitionRound.Semifinal,
            CompetitionRound.Semifinal => CompetitionRound.Final,
            _ => ActualRound
        };
    }

    private void ValidateNumberOfTeams(int teams)
    {
        var isValidated = (Math.Log2(teams) % 1 == 0) && teams > 1;
        if (!isValidated)
        {
            throw new ArgumentException("Number of teams must be a power of 2.", nameof(NumberOfTeams));
        }
    }
}

public class LeagueAndKnockoutCompetition : Competition
{
    public int ClassifiedByGroup { get; private set; }
    public int NumberOfGroups { get; private set; }
    public int TeamsPerGroup => NumberOfTeams / NumberOfGroups;
    public KnockoutFormat KnockoutFormat { get; private set; }
    public GroupFormat GroupFormat { get; private set; }
    public override LeagueDivision Division { get; }
    public override RelegationRule RelegationRule { get; }
    public override BrazilState State { get; }
    public override CompetitionFormat CompetitionFormat => CompetitionFormat.LeagueAndKnockout;
    public override string Discriminator => nameof(LeagueAndKnockoutCompetition);

    public LeagueAndKnockoutCompetition(string name, int numberOfTeams, int classifiedByGroup, int numberOfGroups, int year,
                                        Region region, CompetitionLevel level, KnockoutFormat knockoutFormat, GroupFormat groupFormat,
                                        LeagueDivision division, RelegationRule? relegationRule = null, BrazilState? state = null)
        : base(name, numberOfTeams, year, region, level)
    {
        ClassifiedByGroup = classifiedByGroup;
        NumberOfGroups = numberOfGroups;

        if (TeamsPerGroup <= 2)
            throw new ArgumentException("Teams per group must be greater then 2.", nameof(TeamsPerGroup));

        KnockoutFormat = knockoutFormat;
        GroupFormat = groupFormat;
        Division = division;
        ActualRound = CompetitionRound.GroupStage;
        RelegationRule = relegationRule ?? RelegationRule.None;
        State = state ?? BrazilState.None;
    }

    public CompetitionRound GetActualRound()
    {
        return ActualRound;
    }

    public void UpdateActualRound()  // check if all matches are finished
    {
        if (ActualRound == CompetitionRound.GroupStage)
        {
            var allClassified = ClassifiedByGroup * NumberOfGroups;
            ActualRound = GetKnockoutRoundByNumberOfTeams(allClassified);
            return;
        }

        ActualRound = ActualRound switch
        {
            CompetitionRound.RoundOf64 => CompetitionRound.RoundOf32,
            CompetitionRound.RoundOf32 => CompetitionRound.RoundOf16,
            CompetitionRound.RoundOf16 => CompetitionRound.Quarterfinal,
            CompetitionRound.Quarterfinal => CompetitionRound.Semifinal,
            CompetitionRound.Semifinal => CompetitionRound.Final,
            _ => ActualRound
        };
    }

    private CompetitionRound GetKnockoutRoundByNumberOfTeams(int teams)
    {
        return teams switch
        {
            64 => CompetitionRound.RoundOf64,
            32 => CompetitionRound.RoundOf32,
            16 => CompetitionRound.RoundOf16,
            8 => CompetitionRound.Quarterfinal,
            4 => CompetitionRound.Semifinal,
            2 => CompetitionRound.Final,
            _ => throw new ArgumentException(
                "Number of teams must be less than or equal to 64 and greather than 1.", nameof(NumberOfTeams))
        };
    }
}
