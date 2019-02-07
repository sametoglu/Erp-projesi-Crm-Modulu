using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Erp.Models.Mapping
{
    public class NakliyeSirketleriMap : EntityTypeConfiguration<NakliyeSirketleri>
    {
        public NakliyeSirketleriMap()
        {
            // Primary Key
            this.HasKey(t => t.sirket_ID);

            // Properties
            this.Property(t => t.sirket_adi)
                .HasMaxLength(15);

            this.Property(t => t.teslimat_hizi)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("NakliyeSirketleri");
            this.Property(t => t.sirket_ID).HasColumnName("sirket_ID");
            this.Property(t => t.sirket_adi).HasColumnName("sirket_adi");
            this.Property(t => t.km_fiyat).HasColumnName("km_fiyat");
            this.Property(t => t.litre_fiyat).HasColumnName("litre_fiyat");
            this.Property(t => t.teslimat_hizi).HasColumnName("teslimat_hizi");
        }
    }
}
