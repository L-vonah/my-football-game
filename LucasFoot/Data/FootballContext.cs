using LucasFoot.Entities.Competitions;
using LucasFoot.Entities.Manager;
using LucasFoot.Entities.Player;
using LucasFoot.Entities.TeamModels.Team;
using Microsoft.EntityFrameworkCore;

namespace LucasFoot.Data;

public class FootballContext : DbContext
{
    public virtual DbSet<CompetitionPlacement> Placements { get; set; } = null!;
    public virtual DbSet<Competition> Competitions { get; set; } = null!;
    public virtual DbSet<LeagueCompetition> LeagueCompetitions { get; set; } = null!;
    public virtual DbSet<KnockoutCompetition> KnockoutCompetitions { get; set; } = null!;
    public virtual DbSet<LeagueAndKnockoutCompetition> LeagueAndKnockoutCompetitions { get; set; } = null!;
    public virtual DbSet<Manager> Managers { get; set; } = null!;
    public virtual DbSet<TeamManagerRecord> TeamManagerRecords { get; set; } = null!;
    public virtual DbSet<Player> Players { get; set; } = null!;
    public virtual DbSet<TeamPlayerRecord> TeamPlayerRecords { get; set; } = null!;
    public virtual DbSet<Team> Teams { get; set; } = null!;
    public virtual DbSet<CompetitionTeam> CompetitionTeams { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompetitionPlacement>(a =>
        {
            a.HasKey(a => new { a.TeamId, a.ManagerId, a.CompetitionId });
        });
        modelBuilder.Entity<Competition>(c =>
        {
            c.HasKey(c => c.Id);
            c.HasDiscriminator<string>("Discriminator")
                .HasValue<LeagueCompetition>(nameof(LeagueCompetition))
                .HasValue<KnockoutCompetition>(nameof(KnockoutCompetition))
                .HasValue<LeagueAndKnockoutCompetition>(nameof(LeagueAndKnockoutCompetition));
        });
        modelBuilder.Entity<CompetitionTeam>(c =>
        {
            c.HasKey(c => new { c.TeamId, c.CompetitionId });
        });
        modelBuilder.Entity<Manager>(t =>
        {
            t.HasKey(t => t.Id);
            t.HasMany(t => t.Teams)
                .WithOne(p => p.Manager)
                .HasForeignKey(p => p.ManagerId);
        });
        modelBuilder.Entity<TeamManagerRecord>(t =>
        {
            t.HasKey(t => new { t.ManagerId, t.TeamId, t.StartDate });
            t.HasOne(t => t.Team)
                .WithMany(p => p.Managers)
                .HasForeignKey(p => p.TeamId);
            t.HasOne(t => t.Manager)
                .WithMany(p => p.Teams)
                .HasForeignKey(p => p.ManagerId);
        });
        modelBuilder.Entity<TeamPlayerRecord>(t =>
        {
            t.HasKey(t => new { t.PlayerId, t.TeamId, t.StartDate });
            t.HasOne(t => t.Team)
                .WithMany(p => p.Players)
                .HasForeignKey(p => p.TeamId);
            t.HasOne(t => t.Player)
                .WithMany(p => p.Teams)
                .HasForeignKey(p => p.PlayerId);
        });
        modelBuilder.Entity<Player>(p =>
        {
            p.HasKey(p => p.Id);
        });
        modelBuilder.Entity<Team>(t =>
        {
            t.HasKey(t => t.Id);
            t.HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId);
            t.HasMany(t => t.Placements)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId);
            t.HasMany(t => t.Managers)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId);
        });
    }
}
