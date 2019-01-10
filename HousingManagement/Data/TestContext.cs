using Microsoft.EntityFrameworkCore;

namespace HousingManagement.Data
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public DbSet<HousingManagement.Models.Users> Users { get; set; }
        public DbSet<HousingManagement.Models.Admins> Admins { get; set; }
        public DbSet<HousingManagement.Models.SellAds> SellAds { get; set; }
        public DbSet<HousingManagement.Models.RentAds> RentAds { get; set; }
        public DbSet<HousingManagement.Models.Report> Report { get; set; }
    }
}
