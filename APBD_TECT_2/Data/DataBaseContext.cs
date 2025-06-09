using APBD_TECT_2.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_TECT_2.Data;

public class DatabaseContext : DbContext{

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Race> Races { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<TrackRace> TrackRacers { get; set; }
    public DbSet<RaceParticipation> RaceParticipations { get; set; }
    public DbSet<Racer> Racers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<RaceParticipation>()
            .HasKey(rp => new {rp.TrackRaceId,rp.RacerId });
        
        modelBuilder.Entity<Race>().HasData(
            new Race()
            {
                RaceId = 1,
                Date = DateTime.Now.AddDays(-1),
                location = "Misnk",
                Name = "Bulbozavr"
            },
            new Race()
            {
                RaceId = 2,
                Date = DateTime.Now.AddDays(-10),
                location = "Gomel",
                Name = "Pikachi",
            }
        );
        
        modelBuilder.Entity<RaceParticipation>().HasData(
            new RaceParticipation()
            {
                TrackRaceId = 1,
                RacerId = 1,
                FinishTimeInSeconds = 10,
                Position = 1
            },
            new RaceParticipation()
            {
                TrackRaceId = 2,
                RacerId= 2,
                FinishTimeInSeconds = 20,
                Position = 2
            });

        modelBuilder.Entity<Racer>().HasData(
            new Racer()
            {
                FirstName = "Dmitry",
                LastName = "Barmuta",
                RacerId = 1
            },
            new Racer()
            {
                FirstName = "Michal",
                LastName = "Pazio",
                RacerId = 2
            },
            new Racer()
            {
                FirstName = "Danyil",
                LastName = "Danilian",
                RacerId = 3
            },
            new Racer()
            {
                FirstName = "Oleksandr",
                LastName = "Biktimirov",
                RacerId = 4
            });

        modelBuilder.Entity<Track>().HasData(
            new Track()
            {
                TrackId = 1,
                LengthinKm = 100,
                Name = "Despacito"
            },
            new Track()
            {
                TrackId = 2,
                LengthinKm = 100,
                Name = "Despacito"
            });
        modelBuilder.Entity<TrackRace>().HasData(
            new TrackRace()
            {
                TrackId = 1,
                TrackRaceId = 1,
                BestTimeInSeconds = 1,
                Laps = 1,
                RaceId = 1,
            },
            new TrackRace()
            {
                TrackId = 2,
                TrackRaceId = 2,
                BestTimeInSeconds = 10,
                Laps = 2,
                RaceId = 2,
            });
    }
}
