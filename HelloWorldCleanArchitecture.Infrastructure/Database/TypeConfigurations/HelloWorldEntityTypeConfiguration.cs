using Project.Core.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.Infrastructure.Database.TypeConfigurations;

public class HelloWorldEntityTypeConfiguration : IEntityTypeConfiguration<HelloWorld>
{
    public void Configure(EntityTypeBuilder<HelloWorld> builder)
    {
        builder.Property(x => x.HelloWorldMessage).HasMaxLength(100);
    }
}