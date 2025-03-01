using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

try
{
	var roleName = $"Administrator";

	{
		using var applicationDbContext = new ApplicationDbContext();

		var hasAnyMenuItem =
			await
			applicationDbContext.MenuItems.AnyAsync();

		if (hasAnyMenuItem == false)
		{
			// **************************************************
			var menuItem = new MenuItem(title: "Settings");
			applicationDbContext.Add(entity: menuItem);
			// **************************************************

			// **************************************************
			MenuItem childMenuItem;

			childMenuItem = new MenuItem(title: "Role Settings");
			menuItem.Children.Add(item: childMenuItem);

			childMenuItem = new MenuItem(title: "User Settings");
			menuItem.Children.Add(item: childMenuItem);

			childMenuItem = new MenuItem(title: "Country Settings");
			menuItem.Children.Add(item: childMenuItem);
			// **************************************************

			await applicationDbContext.SaveChangesAsync();
		}
	}
}
catch (Exception ex)
{
	Console.WriteLine(value: ex.Message);
}

public abstract class Entity : object
{
	protected Entity() : base()
	{
	}

	[Key]
	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
	public Guid Id { get; init; } = Guid.NewGuid();

	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
	public DateTimeOffset InsertDateTime { get; init; } = DateTimeOffset.Now;
}

public class MenuItem(string title) : Entity
{
	public Guid? ParentId { get; set; }
	//public Guid? MenuItemId { get; set; }

	public virtual MenuItem? Parent { get; set; }
	//public virtual MenuItem? MenuItem { get; set; }

	public int Depth { get; set; }

	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
	public int Code { get; set; }

	[MaxLength(length: 250)]
	public string Path { get; set; } = "/";

	[MaxLength(length: 100)]
	[Required(AllowEmptyStrings = false)]
	public string Title { get; set; } = title;

	public virtual IList<MenuItem> Children { get; } = [];
	//public virtual IList<MenuItem> MenuItems { get; } = [];
}

internal class MenuItemConfiguration : object, IEntityTypeConfiguration<MenuItem>
{
	public MenuItemConfiguration() : base()
	{
	}

	public void Configure(EntityTypeBuilder<MenuItem> builder)
	{
		builder
			.HasKey(current => current.Id)
			.IsClustered(clustered: false)
			;

		//builder
		//	.HasIndex(current => new { current.Title })
		//	.IsUnique(unique: true)
		//	;

		builder
			.HasIndex(current => new { current.ParentId, current.Title })
			.IsUnique(unique: true)
			;

		builder
			.HasMany(current => current.Children)
			.WithOne(other => other.Parent)
			.IsRequired(required: false)
			.HasForeignKey(other => other.ParentId)
			.OnDelete(deleteBehavior: DeleteBehavior.NoAction)
			;
	}
}

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext() : base()
	{
		Database.EnsureCreated();
	}

	public DbSet<MenuItem> MenuItems { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		var connectionString =
			"Server=.;User ID=sa;Password=1234512345;Database=LEARNING_EF_CORE_0300;MultipleActiveResultSets=true;TrustServerCertificate=True;";

		optionsBuilder
			.UseSqlServer(connectionString: connectionString)
			;
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly
			(assembly: typeof(ApplicationDbContext).Assembly);
	}
}
