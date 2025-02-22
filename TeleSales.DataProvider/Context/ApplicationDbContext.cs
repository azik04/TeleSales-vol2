using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;
using TeleSales.DataProvider.Configurations.List;
using TeleSales.DataProvider.Configurations.Main;
using TeleSales.DataProvider.Configurations.Rel;
using TeleSales.DataProvider.Entities.List;
using TeleSales.DataProvider.Entities.Main;
using TeleSales.DataProvider.Entities.Rel;

namespace TeleSales.DataProvider.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CityConfiguration());
        modelBuilder.ApplyConfiguration(new ApplicationTypeConfiguration());
        modelBuilder.ApplyConfiguration(new RegionConfiguration());
        modelBuilder.ApplyConfiguration(new ResultConfiguration());
        modelBuilder.ApplyConfiguration(new StatusConfiguration());
        modelBuilder.ApplyConfiguration(new SubResultConfiguration());


        modelBuilder.ApplyConfiguration(new CallCenterConfiguration());
        modelBuilder.ApplyConfiguration(new ChannelConfiguration());
        modelBuilder.ApplyConfiguration(new DebitorConfiguration());
        modelBuilder.ApplyConfiguration(new UserChannelConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UzadilmaConfiguration());

        modelBuilder.ApplyConfiguration(new AdministrationConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        modelBuilder.ApplyConfiguration(new EmployerConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Regions> Regions { get; set; }
    public DbSet<ApplicationTypes> ApplicationTypes { get; set; }
    public DbSet<Results> Results { get; set; }
    public DbSet<Statuses> Status { get; set; }
    public DbSet<Cities> Cities { get; set; }

    public DbSet<SubResults> SubResults { get; set; }


    public DbSet<CallCenters> CallCenters { get; set; }
    public DbSet<Channels> Сhannels { get; set; }
    public DbSet<Debitors> Debitors { get; set; }
    public DbSet<UserChannels> UserChannels { get; set; }
    public DbSet<Users> Users { get; set; }
    public DbSet<Uzadilmas> Uzadilmas { get; set; }


    public DbSet<Administrations> Administrations { get; set; }
    public DbSet<Departments> Departments { get; set; }
    public DbSet<Employers> Employers { get; set; }
}
