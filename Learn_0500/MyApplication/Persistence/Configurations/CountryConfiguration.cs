using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Persistence.Configurations;

internal sealed class CountryConfiguration : object, IEntityTypeConfiguration<Country>
{
	public void Configure(EntityTypeBuilder<Country> builder)
	{
		// **************************************************
		builder
			.Property(current => current.Name)
			.IsUnicode(unicode: false)
			;

		builder
			.HasIndex(current => new { current.Name })
			.IsUnique(unique: true)
			;
		// **************************************************

		// **************************************************
		// Seed Data
		// **************************************************
		for (var index = 1; index <= 1_000; index++)
		{
			var data =
				new Country(name: $"Country {index}")
				{
					// Id is Identity!
					Id = index,
					Code = index,
				};

			builder.HasData(data: data);
		}
		// **************************************************
	}
}
