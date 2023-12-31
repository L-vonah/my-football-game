﻿using LucasFoot.Entities.Competitions;
using LucasFoot.Entities.Manager;
using LucasFoot.Entities.Match;
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
    public virtual DbSet<CompetitionMatch> CompetitionMatches { get; set; } = null!;
    public virtual DbSet<MatchEvent> MatchEvents { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
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
        modelBuilder.Entity<CompetitionMatch>(cm =>
        {
            cm.HasKey(cm => cm.MatchId);
            cm.HasOne(cm => cm.Competition).WithMany(c => c.Matches).HasForeignKey(cm => cm.CompetitionId);
            cm.HasOne(cm => cm.HomeTeam).WithMany().HasForeignKey(cm => cm.HomeTeamId);
            cm.HasOne(cm => cm.AwayTeam).WithMany().HasForeignKey(cm => cm.AwayTeamId);
            cm.HasMany(cm => cm.Events).WithOne(e => e.Match).HasForeignKey(e => e.MatchId);
        });
        modelBuilder.Entity<MatchEvent>(me =>
        {
            me.HasKey(me => new { me.MatchId, me.Minute });
            me.HasOne(me => me.Match).WithMany(m => m.Events).HasForeignKey(me => me.MatchId);
            me.HasOne(me => me.PrimaryPlayer).WithMany().HasForeignKey(me => me.PrimaryPlayerId);
            me.HasOne(me => me.SecondaryPlayer).WithMany().HasForeignKey(me => me.SecondaryPlayerId);
        });
    }
}
