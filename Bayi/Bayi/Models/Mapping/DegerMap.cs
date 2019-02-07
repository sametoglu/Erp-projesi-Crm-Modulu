using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bayi.Models.Mapping
{
    public class DegerMap : EntityTypeConfiguration<Deger>
    {
        public DegerMap()
        {
            // Primary Key
            this.HasKey(t => t.deger_ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Deger");
            this.Property(t => t.deger_ID).HasColumnName("deger_ID");
            this.Property(t => t.sirket_ID).HasColumnName("sirket_ID");
            this.Property(t => t.puan).HasColumnName("puan");

            // Relationships
            this.HasOptional(t => t.NakliyeSirketleri)
                .WithMany(t => t.Degers)
                .HasForeignKey(d => d.sirket_ID);

        }
    }
}
