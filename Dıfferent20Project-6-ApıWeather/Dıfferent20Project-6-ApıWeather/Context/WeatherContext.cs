using Dıfferent20Project_6_ApıWeather.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dıfferent20Project_6_ApıWeather.Context
{
    public class WeatherContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=MULUSOY\\SQLEXPRESS01;Initial Catalog=Different20Project-6-DB;Integrated Security=True;TrustServerCertificate=True;");

        }
        public DbSet<City> Cities { get; set; }
    }
}
