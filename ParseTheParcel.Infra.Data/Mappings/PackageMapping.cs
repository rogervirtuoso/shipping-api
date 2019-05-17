using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Roger.ParseTheParcel.Domain.Models;
using Roger.Framework.EntityFramework.Configuration;
using Roger.ParseTheParcel.Domain.Models.Package;
using Roger.ParseTheParcel.Domain.Models.PackageCost;

namespace Roger.ParseTheParcel.Infra.Data.Mappings
{
    public class PackageMapping : EntityTypeConfiguration<Package>
    {
        public override void Map(EntityTypeBuilder<Package> builder)
        {
            builder.ToTable("Package");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(b => b.Height).IsRequired();
        }
    }
}