using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Erp.Models.Mapping
{
    public class SatiMap : EntityTypeConfiguration<Sati>
    {
        public SatiMap()
        {
            // Primary Key
            this.HasKey(t => t.satis_ID);

            // Properties
            this.Property(t => t.bayi_adi)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Satis");
            this.Property(t => t.satis_ID).HasColumnName("satis_ID");
            this.Property(t => t.bayi_adi).HasColumnName("bayi_adi");
            this.Property(t => t.kucuk).HasColumnName("kucuk");
            this.Property(t => t.orta).HasColumnName("orta");
            this.Property(t => t.buyuk).HasColumnName("buyuk");
            this.Property(t => t.enbuyuk).HasColumnName("enbuyuk");
            this.Property(t => t.toplamsatis).HasColumnName("toplamsatis");
            this.Property(t => t.tarih).HasColumnName("tarih");
        }
    }
}
