using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bayi.Models.Mapping
{
    public class StokMap : EntityTypeConfiguration<Stok>
    {
        public StokMap()
        {
            // Primary Key
            this.HasKey(t => t.stok_ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Stok");
            this.Property(t => t.stok_ID).HasColumnName("stok_ID");
            this.Property(t => t.kucuk).HasColumnName("kucuk");
            this.Property(t => t.orta).HasColumnName("orta");
            this.Property(t => t.buyuk).HasColumnName("buyuk");
            this.Property(t => t.enbuyuk).HasColumnName("enbuyuk");
        }
    }
}
