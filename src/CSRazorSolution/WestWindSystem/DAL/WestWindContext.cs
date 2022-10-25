#nullable disable
#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.DAL
{
    //  This class cannot be access from outside of the class library project.
    //  Any reference within the class library project to this class will be honoured.
    //  This is a level of security
    internal class WestWindContext : DbContext
    {
        public WestWindContext(DbContextOptions<WestWindContext> options) : base(options)
        {

        }
        public DbSet<BuildVersion> BuildVersions { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Territory> Territories { get; set; }

    }
}
