using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skilladd.Domain.Hiring.Classes;
using Skilladd.Domain.Hiring.Enum.EnumJobPost;
using Skilladd.Domain.Hiring.VO;

namespace Skilladd.Infrastructure.Configurations;

public class JobPostConfiguration : IEntityTypeConfiguration<JobPost>
{
    public void Configure(EntityTypeBuilder<JobPost> builder)
    {
        builder.ToTable("jobposts");
        
        builder.HasKey(j => j.Id);
        
        builder.Property(j => j.Id)
            .HasConversion(
                j => j.Value,
                value => JobPostId.Create(value));

        builder.HasOne(c => c.Company)
            .WithMany(j => j.JobPosts)
            .HasForeignKey(j => j.CompanyId);

        builder.Property(j => j.Title)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(j => j.Description)
            .HasMaxLength(500)
            .IsRequired();
        
        builder.Property(j => j.Requirements)
            .HasMaxLength(250)
            .IsRequired();

        builder.OwnsOne(j => j.Offer, o =>
        {
            o.Property(j => j.SalaryFrom).HasColumnName("salary_from");
            o.Property(j => j.SalaryTo).HasColumnName("salary_to");
            o.Property(j => j.Currency).HasColumnName("currency");
        });

        builder.Property(j => j.Employment)
            .IsRequired();

        builder.Property(j => j.Format)
            .IsRequired();

        builder.Property(j => j.Skills)
            .HasColumnType("jsonb");
        
        builder.Property(j => j.Status)
            .HasDefaultValue(EnumStatus.Draft)
            .IsRequired();

        builder.Property(j => j.ExpiresAt)
            .HasColumnType("timestamp without time zone");

        builder.Property(j => j.CreatedAt)
            .HasDefaultValueSql("NOW()"); 
    }
}