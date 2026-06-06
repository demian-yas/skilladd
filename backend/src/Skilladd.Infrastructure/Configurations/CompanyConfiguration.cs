using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skilladd.Domain.Hiring.Classes;
using Skilladd.Domain.Hiring.VO;

namespace Skilladd.Infrastructure.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("companies");
        
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Id)
            .HasConversion(
                id => id.Value,
                value => CompanyId.Create(value));
 
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Slug)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(c => c.Description)
            .HasMaxLength(500);

        builder.Property(c => c.LogoUrl);
        
        builder.Property(c => c.Website)
            .HasMaxLength(250);

        builder.Property(c => c.Industry)
            .HasMaxLength(100);

        builder.Property(c => c.Size);
        
        builder.OwnsOne(c => c.Address, a =>
            {
                a.Property(c => c.Country).HasColumnName("country");
                a.Property(c => c.City).HasColumnName("city");
                a.Property(c => c.Street).HasColumnName("street");
            }
        );

        builder.Property(c => c.Location)
            .HasColumnType("jsonb");
        
        builder.Property(c => c.IsVerified)
            .HasDefaultValue(false);

        builder.Property(c => c.CreatedAt)
            .HasDefaultValueSql("NOW()");
    }
}