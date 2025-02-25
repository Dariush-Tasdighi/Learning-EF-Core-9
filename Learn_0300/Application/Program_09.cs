//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//try
//{
//	var roleName =
//		$"Administrator";

//	{
//		using var applicationDbContext = new ApplicationDbContext();

//		var hasAnyRole =
//			await
//			applicationDbContext.MenuItems.AnyAsync();

//		if (hasAnyRole == false)
//		{
//			// **************************************************
//			var menuItem =
//				new MenuItem(title: "Settings");

//			applicationDbContext.Add(entity: menuItem);
//			// **************************************************

//			// **************************************************
//			var childMenuItem =
//				new MenuItem("User Settings");

//			menuItem.Children.Add(item: childMenuItem);

//			childMenuItem =
//				new MenuItem("Role Settings");

//			menuItem.Children.Add(item: childMenuItem);

//			childMenuItem =
//				new MenuItem("Country Settings");

//			menuItem.Children.Add(item: childMenuItem);
//			// **************************************************

//			await applicationDbContext.SaveChangesAsync();
//		}
//	}
//}
//catch (Exception ex)
//{
//	Console.WriteLine(value: ex.Message);
//}

//public abstract class Entity : object
//{
//	[Key]
//	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
//	public Guid Id { get; private set; } = Guid.NewGuid();

//	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
//	public DateTimeOffset InsertDateTime { get; private set; } = DateTimeOffset.Now;
//}

//public class MenuItem(string title) : Entity
//{
//	public Guid? ParentId { get; set; }

//	public virtual MenuItem? Parent { get; set; }

//	public int Depth { get; set; }

//	public string Path { get; set; } = "/";

//	[MaxLength(length: 100)]
//	[Required(AllowEmptyStrings = false)]
//	public string Title { get; set; } = title;

//	public virtual IList<MenuItem> Children { get; } = [];
//}

//internal class MenuItemConfiguration : object, IEntityTypeConfiguration<MenuItem>
//{
//	public MenuItemConfiguration() : base()
//	{
//	}

//	public void Configure(EntityTypeBuilder<MenuItem> builder)
//	{
//		builder
//			.HasKey(current => current.Id)
//			.IsClustered(clustered: false)
//			;

//		//builder
//		//	.HasIndex(current => new { current.Title })
//		//	.IsUnique(unique: true)
//		//	;

//		builder
//			.HasIndex(current => new { current.ParentId, current.Title })
//			.IsUnique(unique: true)
//			;

//		builder
//			.HasMany(left => left.Children)
//			.WithOne(right => right.Parent)
//			.IsRequired(required: false)
//			.HasForeignKey(user => user.ParentId)
//			.OnDelete(deleteBehavior: DeleteBehavior.NoAction)
//			;
//	}
//}

//public class ApplicationDbContext : DbContext
//{
//	public ApplicationDbContext() : base()
//	{
//		Database.EnsureCreated();
//	}

//	public DbSet<MenuItem> MenuItems { get; set; }

//	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//	{
//		var connectionString =
//			"Server=.;User ID=sa;Password=1234512345;Database=LEARNING_EF_CORE_0300;MultipleActiveResultSets=true;TrustServerCertificate=True;";

//		optionsBuilder
//			.UseSqlServer(connectionString: connectionString)
//			;
//	}

//	protected override void OnModelCreating(ModelBuilder modelBuilder)
//	{
//		modelBuilder.ApplyConfigurationsFromAssembly
//			(assembly: typeof(ApplicationDbContext).Assembly);
//	}
//}
