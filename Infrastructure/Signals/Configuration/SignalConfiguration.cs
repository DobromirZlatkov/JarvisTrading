namespace JarvisTrading.Infrastructure.Signals.Configuration
{
    using JarvisTrading.Domain.Signals.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SignalConfiguration : IEntityTypeConfiguration<Signal>
    {
        public void Configure(EntityTypeBuilder<Signal> builder)
        {
            builder
                .HasOne(x => x.SourceType)
                .WithMany()
                .HasForeignKey("Ref_Source")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
