using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bayi.Models.Mapping
{
    public class TeslimatMap : EntityTypeConfiguration<Teslimat>
    {
        public TeslimatMap()
        {
            // Primary Key
            this.HasKey(t => t.teslimat_ID);

            // Properties
            this.Property(t => t.bayi_adi)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Teslimat");
            this.Property(t => t.teslimat_ID).HasColumnName("teslimat_ID");
            this.Property(t => t.bayi_adi).HasColumnName("bayi_adi");
            this.Property(t => t.sirket_ID).HasColumnName("sirket_ID");
            this.Property(t => t.kucuk).HasColumnName("kucuk");
            this.Property(t => t.orta).HasColumnName("orta");
            this.Property(t => t.buyuk).HasColumnName("buyuk");
            this.Property(t => t.enbuyuk).HasColumnName("enbuyuk");
            this.Property(t => t.teslimtarihi).HasColumnName("teslimtarihi");
            this.Property(t => t.istek_ID).HasColumnName("istek_ID");

            // Relationships
            this.HasOptional(t => t.Istek)
                .WithMany(t => t.Teslimats)
                .HasForeignKey(d => d.istek_ID);
            this.HasOptional(t => t.NakliyeSirketleri)
                .WithMany(t => t.Teslimats)
                .HasForeignKey(d => d.sirket_ID);

        }
    }
}
