using CampSleepaway.Domain;
using Microsoft.EntityFrameworkCore;

namespace CampSleepaway.Data;

public class CampSleepawayContext : DbContext
{
    public DbSet<Cabin> Cabins { get; set; }
    public DbSet<Camper> Campers { get; set; }
    public DbSet<Counselor> Counselors { get; set; }
    public DbSet<NextOfKin> NextOfKins { get; set; }
    public DbSet<CabinCamper> CabinCamper { get; set; }
    public DbSet<CabinCounselor> CabinCounselor { get; set; }
    public DbSet<CamperNextOfKin> CamperNextOfKin { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //Connection to Pandora:
        optionsBuilder.UseSqlServer("Data Source= Pandora\\SqlExpress; " +
                                    "Initial Catalog=CampSleepaway; " +
                                    "Integrated Security=True; " +
                                    "Trustservercertificate=true; " +
                                    "Trusted_Connection=True");
        base.OnConfiguring(optionsBuilder);

        //Connection to Paul:

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Camper>()
    .HasMany(cam => cam.Cabins)
    .WithMany(cam => cam.Campers)
    .UsingEntity<CabinCamper>
    (cabcam => cabcam.HasOne<Cabin>().WithMany(),
        cab => cab.HasOne<Camper>().WithMany())
    .Property(camnok => camnok.EnterDate)
    .IsRequired();

        modelBuilder.Entity<Cabin>()
            .HasMany(cab => cab.Counselors)
            .WithMany(cou => cou.Cabins)
            .UsingEntity<CabinCounselor>
            (cabcou => cabcou.HasOne<Counselor>().WithMany(),
                    cou => cou.HasOne<Cabin>().WithMany())
                .Property(cabcou => cabcou.EnterDate)
            .IsRequired();

        modelBuilder.Entity<Camper>()
            .HasMany(cam => cam.NextOfKins)
            .WithMany(nok => nok.Campers)
            .UsingEntity<CamperNextOfKin>
            (camnok => camnok.HasOne<NextOfKin>().WithMany(),
                cou => cou.HasOne<Camper>().WithMany())
            .Property(camnok => camnok.EnterDate)
            .IsRequired();

        modelBuilder.Entity<Camper>().HasData(

            new Camper { CamperId = 1, FirstName = "Jane", Surname = "Doe", Allergies = "null" },
            new Camper { CamperId = 2, FirstName = "John", Surname = "Doe", Allergies = "Peanuts" },
            new Camper { CamperId = 3, FirstName = "Denys", Surname = "Demetr", Allergies = "null" },
            new Camper { CamperId = 4, FirstName = "Queenie", Surname = "Penuzzi", Allergies = "null" },
            new Camper { CamperId = 5, FirstName = "Grove", Surname = "Smith", Allergies = "Dogs" },
            new Camper { CamperId = 6, FirstName = "Emye", Surname = "Overall", Allergies = "Cats" },
            new Camper { CamperId = 7, FirstName = "Wilton", Surname = "Florence", Allergies = "null" },
            new Camper { CamperId = 8, FirstName = "Pamela", Surname = "Samples", Allergies = "Carrots" },
            new Camper { CamperId = 9, FirstName = "Percy", Surname = "Smallcomb", Allergies = "null" },
            new Camper { CamperId = 10, FirstName = "Essy", Surname = "Piddocke", Allergies = "Sunlight" },
            new Camper { CamperId = 11, FirstName = "Hannah", Surname = "Burnyate", Allergies = "Gluten" },
            new Camper { CamperId = 12, FirstName = "Alia", Surname = "Wait", Allergies = "null" },
            new Camper { CamperId = 13, FirstName = "Eartha", Surname = "Florence", Allergies = "null" },
            new Camper { CamperId = 14, FirstName = "Tybi", Surname = "Banbridge", Allergies = "Electricity" },
            new Camper { CamperId = 15, FirstName = "Cecily", Surname = "Wavell", Allergies = "null" },
            new Camper { CamperId = 16, FirstName = "Welch", Surname = "Godspede", Allergies = "null" },
            new Camper { CamperId = 17, FirstName = "Arlene", Surname = "Wavell", Allergies = "null" },
            new Camper { CamperId = 18, FirstName = "Obediah", Surname = "Fitzpatrick", Allergies = "null" });

        modelBuilder.Entity<Cabin>().HasData(
         new Cabin { CabinId = 1, Name = "Sunny Woods cabin", CounselorId = 1 },
         new Cabin { CabinId = 2, Name = "Happy Raccoon cabin", CounselorId = 2 },
         new Cabin { CabinId = 3, Name = "Aqua Wilderness cabin", CounselorId = 3 },
         new Cabin { CabinId = 4, Name = "Green Country cabin", CounselorId = 4 },
         new Cabin { CabinId = 5, Name = "Grey Meadows cabin", CounselorId = 5 },
         new Cabin { CabinId = 6, Name = "Blue Outback cabin", });

        modelBuilder.Entity<Counselor>().HasData(
        new Counselor { CounselorId = 1, FirstName = "Kym", Surname = "MacIlurick", YearsActive = "4" },
        new Counselor { CounselorId = 2, FirstName = "Felice", Surname = "Balharry" },
        new Counselor { CounselorId = 3, FirstName = "Morgan", Surname = "Rex" },
        new Counselor { CounselorId = 4, FirstName = "Marion", Surname = "Currum" },
        new Counselor { CounselorId = 5, FirstName = "Cletus", Surname = "Cholomin" });

        modelBuilder.Entity<CabinCamper>().HasData(
        new CabinCamper { CabinId = 1, CamperId = 1, EnterDate = new DateTime(2021, 05, 01), ExitDate = new DateTime(2021, 05, 05) },
        new CabinCamper { CabinId = 2, CamperId = 2, EnterDate = new DateTime(2021, 05, 01), ExitDate = new DateTime(2021, 05, 05) },
        new CabinCamper { CabinId = 3, CamperId = 3, EnterDate = new DateTime(2021, 05, 01), ExitDate = new DateTime(2021, 05, 05) },
        new CabinCamper { CabinId = 4, CamperId = 4, EnterDate = new DateTime(2021, 05, 01), ExitDate = new DateTime(2021, 05, 05) },
        new CabinCamper { CabinId = 5, CamperId = 5, EnterDate = new DateTime(2021, 05, 01), ExitDate = new DateTime(2021, 05, 05) },
        new CabinCamper { CabinId = 1, CamperId = 6, EnterDate = new DateTime(2021, 05, 01), ExitDate = new DateTime(2021, 05, 05) },
        new CabinCamper { CabinId = 2, CamperId = 7, EnterDate = new DateTime(2021, 05, 01), ExitDate = new DateTime(2021, 05, 05) });

        modelBuilder.Entity<CabinCounselor>().HasData(
        new CabinCounselor { CabinId = 1, CounselorId = 1, EnterDate = new DateTime(2021, 05, 01), ExitDate = new DateTime(2021, 05, 05) },
        new CabinCounselor { CabinId = 2, CounselorId = 2, EnterDate = new DateTime(2021, 05, 01), ExitDate = new DateTime(2021, 05, 05) },
        new CabinCounselor { CabinId = 3, CounselorId = 3, EnterDate = new DateTime(2021, 05, 01), ExitDate = new DateTime(2021, 05, 05) },
        new CabinCounselor { CabinId = 4, CounselorId = 4, EnterDate = new DateTime(2021, 05, 01), ExitDate = new DateTime(2021, 05, 05) },
        new CabinCounselor { CabinId = 5, CounselorId = 5, EnterDate = new DateTime(2021, 05, 01), ExitDate = new DateTime(2021, 05, 05) });

        modelBuilder.Entity<CamperNextOfKin>().HasData(
        new CamperNextOfKin { CamperId = 1, NextOfKinId = 1, EnterDate = new DateTime(2021, 05, 02), ExitDate = new DateTime(2021, 05, 02) },
        new CamperNextOfKin { CamperId = 2, NextOfKinId = 2, EnterDate = new DateTime(2021, 05, 02), ExitDate = new DateTime(2021, 05, 02) },
        new CamperNextOfKin { CamperId = 3, NextOfKinId = 3, EnterDate = new DateTime(2021, 05, 02), ExitDate = new DateTime(2021, 05, 02) },
        new CamperNextOfKin { CamperId = 4, NextOfKinId = 4, EnterDate = new DateTime(2021, 05, 02), ExitDate = new DateTime(2021, 05, 02) });

        modelBuilder.Entity<NextOfKin>().HasData(
        new NextOfKin { NextOfKinId = 1, FirstName = "Andy", Surname = "Belmont", },
        new NextOfKin { NextOfKinId = 2, FirstName = "Jaqueline", Surname = "Doe", },
        new NextOfKin { NextOfKinId = 3, FirstName = "Jack", Surname = "Doe", },
        new NextOfKin { NextOfKinId = 4, FirstName = "Genia", Surname = "Andresser", },
        new NextOfKin { NextOfKinId = 5, FirstName = "Minny", Surname = "Roderigo", });
    }
}