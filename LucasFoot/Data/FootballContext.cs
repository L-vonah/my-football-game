using LucasFoot.Entities.Competitions;
using LucasFoot.Entities.Manager;
using LucasFoot.Entities.TeamModels.Team;
using Microsoft.EntityFrameworkCore;

namespace LucasFoot.Data;

public class FootballContext : DbContext
{
    public virtual DbSet<Achievement> Achievements { get; set; } = null!;
    public virtual DbSet<Competition> Competitions { get; set; } = null!;
    public virtual DbSet<Team> Teams { get; set; } = null!;
    public virtual DbSet<TeamManager> Managers { get; set; } = null!;


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
                .HasValue<CupCompetition>(nameof(CupCompetition))
                .HasValue<ContinentalCompetition>(nameof(MainNationalCompetition));
        });
        modelBuilder.Entity<Team>(t =>
        {
            t.HasKey(t => t.Id);
            t.HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Cascade);
            t.HasMany(t => t.Achievements)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId);
            t.HasMany(t => t.Managers)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId);
        });
        modelBuilder.Entity<TeamManager>(t =>
        {
            t.HasKey(t => t.Id);
            t.HasMany(t => t.LastTeams)
                .WithOne(p => p.Manager)
                .HasForeignKey(p => p.ManagerId);
            t.HasMany(t => t.Achievements)
                .WithOne(p => p.Manager)
                .HasForeignKey(p => p.ManagerId);
        });
    }
}
