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
			.HasIndex(current => new { current.Name })
			.IsUnique(unique: true)
			;

		//builder
		//	.HasIndex(current => new { current.NewName })
		//	.IsUnique(unique: true)
		//	;
		// **************************************************

		// **************************************************
		// Seed Data
		// **************************************************
		for (var index = 1; index <= 5; index++)
		{
			var data =
				new Country(name: $"Country {index}")
				{
					Id = index,
					Code = index,
				};

			//var data =
			//	new Country(newName: $"Country {index}")
			//	{
			//		Id = index,
			//		Code = index,
			//	};

			builder.HasData(data: data);
		}
		// **************************************************
	}
}
