using BudgetPlanner.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlanner.Backend.Database
{
    //DbContext luokka, hoitaa tietokannan luomisen ja sen käyttämisen. Toimii siis tietokannan ja APIn välissä
    //appsettingsissä pitää tehdä tietokanta string, joka on tietokannan nimi


    //Seuraava homma:
    //metodit, jolla tietokantaa käytetään. Interface?

    /// <summary>
    /// Voidaan lisätä kulu
    /// Voidaan poistaa kulu
    /// Kulun muokkaus
    /// Haetaan kaikki kulut käyttäjä id perusteella
    /// Haetaan maksamattomat kulut
    /// Haetaan kaikki maksetut
    /// Haetaan kaikki maksamattomat
    /// Haetaan toistuvat kulut
    /// Haetaan ei toistuvat
    /// </summary>

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        //Create tables for in db
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<LastOccurrDate> LastOccurrDates { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data for RecurringTypes table
            modelBuilder.Entity<RecurrType>().HasData(
                new RecurrType(1, "Once"),
                new RecurrType(2, "Monthly"),
                new RecurrType(3, "Yearly")
                );

            //Seed data for Categories table
            modelBuilder.Entity<Category>().HasData(
                new Category(1, "Category1"),
                new Category(2, "Category2"),
                new Category(3, "Category3"),
                new Category(4, "Category4")

            );
        }
    }
}
