using Backend.Domain.Contract.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Globalization;

namespace Backend.Persistence.Database.Configuration
{
    public abstract class BaseEntityConfiguration<T, U> : IEntityTypeConfiguration<T> where T : Entity<U> where U : Identity, new()
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            var inflector = new Inflector.Inflector(new CultureInfo("en"));
            builder.ToTable(inflector.Pluralize(typeof(T).Name));
            builder.Property(x => x.Id).HasConversion(new StronglyTypedIdValueConverter<U>());
            AddConfig(builder);
        }

        protected abstract void AddConfig(EntityTypeBuilder<T> builder);
    }
}