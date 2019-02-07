using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Erp.Models.Mapping
{
    public class IstekMap : EntityTypeConfiguration<Istek>
    {
        public IstekMap()
        {
            // Primary Key
            this.HasKey(t => t.istek_ID);

            // Properties
            this.Property(t => t.bayi_adi)
                .HasMaxLength(15);

            this.Property(t => t.Durum)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Istek");
            this.Property(t => t.istek_ID).HasColumnName("istek_ID");
            this.Property(t => t.bayi_adi).HasColumnName("bayi_adi");
            this.Property(t => t.kucuk).HasColumnName("kucuk");
            this.Property(t => t.orta).HasColumnName("orta");
            this.Property(t => t.buyuk).HasColumnName("buyuk");
            this.Property(t => t.enbuyuk).HasColumnName("enbuyuk");
            this.Property(t => t.istektarihi).HasColumnName("istektarihi");
            this.Property(t => t.Durum).HasColumnName("Durum");
        }
    }
}
