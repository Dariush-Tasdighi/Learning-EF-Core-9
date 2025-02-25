//using System;
//using System.Linq;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;
//using Microsoft.EntityFrameworkCore.ChangeTracking;
//using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//try
//{
//	var roleName = $"Administrator";

//	{
//		using var applicationDbContext = new ApplicationDbContext();

//		var hasAnyRole =
//			await
//			applicationDbContext.Roles.AnyAsync();

//		if (hasAnyRole == false)
//		{
//			var newRole = new Role(name: roleName);

//			applicationDbContext.Add(entity: newRole);

//			await applicationDbContext.SaveChangesAsync();
//		}
//	}

//	{
//		using var applicationDbContext = new ApplicationDbContext();

//		var foundRole =
//			await
//			applicationDbContext.Roles
//			.Where(current => current.Name.ToLower() == roleName.ToLower())
//			.FirstOrDefaultAsync();

//		if (foundRole is null)
//		{
//			var errorMessage = $"{roleName} role not found!";
//			Console.WriteLine(value: errorMessage);
//			return;
//		}

//		var hasAnyUser =
//			await
//			applicationDbContext.Users.AnyAsync();

//		if (hasAnyUser)
//		{
//			Console.WriteLine(value: $"The users has been already created!");
//			return;
//		}

//		// **************************************************
//		// ایجاد کاربر، به سه حالت مختلف
//		// **************************************************
//		User newUser;
//		EntityEntry entityEntry;

//		// Solution (1)
//		newUser =
//			new User(username: "User1")
//			{
//				RoleId = foundRole.Id,
//			};

//		entityEntry = applicationDbContext.Add(entity: newUser);
//		// /Solution (1)

//		// Solution (2)
//		newUser =
//			new User(username: "User2")
//			{
//				Role = foundRole,
//			};

//		entityEntry = applicationDbContext.Add(entity: newUser);
//		// /Solution (2)

//		// Solution (3)
//		newUser =
//			new User(username: "User3");

//		foundRole.Users.Add(item: newUser);
//		// /Solution (3)

//		var affectedRows =
//			await
//			applicationDbContext.SaveChangesAsync();

//		Console.WriteLine(value: $"{nameof(affectedRows)}: {affectedRows}");
//		// **************************************************
//	}
//}
//catch (Exception ex)
//{
//	Console.WriteLine(value: ex.Message);
//}

//public abstract class Entity : object
//{
//	protected Entity() : base()
//	{
//	}

//	[Key]
//	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
//	public Guid Id { get; init; } = Guid.NewGuid();

//	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
//	public DateTimeOffset InsertDateTime { get; init; } = DateTimeOffset.Now;
//}

//public class Role(string name) : Entity
//{
//	[MaxLength(length: 50)]
//	[Required(AllowEmptyStrings = false)]
//	public string Name { get; set; } = name;

//	//public virtual IList<User>? Users { get; set; } // Bad Practice!
//	//public virtual IList<User>? Users { get; }
//	//public virtual IList<User> Users { get; } = new List<User>();
//	public virtual IList<User> Users { get; } = [];
//}

//public class User(string username) : Entity
//{
//	[Required]
//	public Guid RoleId { get; set; }

//	public virtual Role? Role { get; set; }

//	[MaxLength(length: 20)]
//	[Required(AllowEmptyStrings = false)]
//	public string Username { get; set; } = username;
//}

////public class User(Role role, string username) : Entity
////{
////	[Required]
////	public Guid RoleId { get; set; }

////	public virtual Role Role { get; set; } = role;

////	[MaxLength(length: 20)]
////	[Required(AllowEmptyStrings = false)]
////	public string Username { get; set; } = username;
////}

//internal class RoleConfiguration : object, IEntityTypeConfiguration<Role>
//{
//	public RoleConfiguration() : base()
//	{
//	}

//	public void Configure(EntityTypeBuilder<Role> builder)
//	{
//		builder
//			.HasKey(current => current.Id)
//			.IsClustered(clustered: false)
//			;

//		builder
//			.HasIndex(current => new { current.Name })
//			.IsUnique(unique: true)
//			;
//	}
//}

//internal class UserConfiguration : object, IEntityTypeConfiguration<User>
//{
//	public UserConfiguration() : base()
//	{
//	}

//	public void Configure(EntityTypeBuilder<User> builder)
//	{
//		builder
//			.HasKey(current => current.Id)
//			.IsClustered(clustered: false)
//			;

//		builder
//			.Property(current => current.Username)
//			.IsUnicode(unicode: false)
//			;

//		builder
//			.HasIndex(current => new { current.Username })
//			.IsUnique(unique: true)
//			;
//	}
//}

//public class ApplicationDbContext : DbContext
//{
//	public ApplicationDbContext() : base()
//	{
//		Database.EnsureCreated();
//	}

//	public DbSet<Role> Roles { get; set; }
//	public DbSet<User> Users { get; set; }

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
