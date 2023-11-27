using LucasFoot.Entities.Competitions;
using LucasFoot.Entities.Manager;
using LucasFoot.Entities.Player;
using LucasFoot.Entities.TeamModels.Team;
using Microsoft.EntityFrameworkCore;

namespace LucasFoot.Data;

public class FootballContext : DbContext
{
    public virtual DbSet<Achievement> Achievements { get; set; } = null!;
    public virtual DbSet<Competition> Competitions { get; set; } = null!;
    public virtual DbSet<NationalCompetition> NationalCompetitions { get; set; } = null!;
    public virtual DbSet<MainNationalCompetition> MainNationalCompetitions { get; set; } = null!;
    public virtual DbSet<KnockoutCompetition> CupCompetitions { get; set; } = null!;
    public virtual DbSet<ContinentalCompetition> ContinentalCompetitions { get; set; } = null!;
    public virtual DbSet<TeamManager> Managers { get; set; } = null!;
    public virtual DbSet<TeamManagerRecord> TeamManagerRecords { get; set; } = null!;
    public virtual DbSet<PlayerBase> Players { get; set; } = null!;
    public virtual DbSet<Team> Teams { get; set; } = null!;
    public virtual DbSet<CompetitionTeam> CompetitionTeams { get; set; } = null!;
    public virtual DbSet<GroupOrLeagueTeam> GroupOrLeagueTeams { get; set; } = null!;
    public virtual DbSet<KnockoutTeam> CupTeams { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(a =>
        {
            a.HasKey(a => new { a.TeamId, a.ManagerId, a.CompetitionId, a.Year });
        });
        modelBuilder.Entity<Competition>(c =>
        {
            c.HasKey(c => c.Id);
            c.HasDiscriminator<string>("Discriminator")
                .HasValue<NationalCompetition>(nameof(NationalCompetition))
                .HasValue<MainNationalCompetition>(nameof(MainNationalCompetition))
                .HasValue<KnockoutCompetition>(nameof(KnockoutCompetition))
                .HasValue<ContinentalCompetition>(nameof(ContinentalCompetition));
        });
        modelBuilder.Entity<CompetitionTeam>(c =>
        {
            c.HasKey(c => new { c.TeamId, c.CompetitionId });
            c.HasDiscriminator<string>("Discriminator")
                .HasValue<GroupOrLeagueTeam>(nameof(GroupOrLeagueTeam))
                .HasValue<KnockoutTeam>(nameof(KnockoutTeam));
        });
        modelBuilder.Entity<TeamManager>(t =>
        {
            t.HasKey(t => t.Id);
            t.HasMany(t => t.Teams)
                .WithOne(p => p.Manager)
                .HasForeignKey(p => p.ManagerId);
            t.HasMany(t => t.Achievements)
                .WithOne(p => p.Manager)
                .HasForeignKey(p => p.ManagerId);
        });
        modelBuilder.Entity<TeamManagerRecord>(t =>
        {
            t.HasKey(t => t.Id);
            t.HasOne(t => t.Team)
                .WithMany(p => p.Managers)
                .HasForeignKey(p => p.TeamId);
            t.HasOne(t => t.Manager)
                .WithMany(p => p.Teams)
                .HasForeignKey(p => p.ManagerId);
        });
        modelBuilder.Entity<TeamPlayerRecord>(t =>
        {
            t.HasKey(t => t.Id);
            t.HasOne(t => t.Team)
                .WithMany(p => p.Players)
                .HasForeignKey(p => p.TeamId);
            t.HasOne(t => t.Player)
                .WithMany(p => p.Teams)
                .HasForeignKey(p => p.PlayerId);
        });
        modelBuilder.Entity<PlayerBase>(p =>
        {
            p.HasKey(p => p.Id);
        });
        modelBuilder.Entity<Team>(t =>
        {
            t.HasKey(t => t.Id);
            t.HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId);
            t.HasMany(t => t.Achievements)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId);
            t.HasMany(t => t.Managers)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId);
        });
    }
}
