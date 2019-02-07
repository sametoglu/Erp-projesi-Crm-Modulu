using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Erp.Models.Mapping;

namespace Erp.Models
{
    public partial class ERPContext : DbContext
    {
        static ERPContext()
        {
            Database.SetInitializer<ERPContext>(null);
        }

        public ERPContext()
            : base("Name=ERPContext")
        {
        }

        public DbSet<Deger> Degers { get; set; }
        public DbSet<Istek> Isteks { get; set; }
        public DbSet<NakliyeSirketleri> NakliyeSirketleris { get; set; }
        public DbSet<Sati> Satis { get; set; }
        public DbSet<Stok> Stoks { get; set; }
        public DbSet<Teslimat> Teslimats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DegerMap());
            modelBuilder.Configurations.Add(new IstekMap());
            modelBuilder.Configurations.Add(new NakliyeSirketleriMap());
            modelBuilder.Configurations.Add(new SatiMap());
            modelBuilder.Configurations.Add(new StokMap());
            modelBuilder.Configurations.Add(new TeslimatMap());
        }
    }
}
