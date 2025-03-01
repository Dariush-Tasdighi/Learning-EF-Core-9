//using System;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//var roleName = $"Administrator";

//try
//{
//	await CreateTheRoleAsync();
//	await CreateTheUsersAsync();

//	using var applicationDbContext = new ApplicationDbContext();

//	// Lazy Loading
//	var foundRole =
//		await
//		applicationDbContext.Roles
//		.Where(current => current.Name.ToLower() == roleName.ToLower())
//		.FirstOrDefaultAsync();

//	// Eager Loading
//	//var foundRole =
//	//	await
//	//	applicationDbContext.Roles
//	//	.Include(current => current.Users)
//	//	.Where(current => current.Name.ToLower() == roleName.ToLower())
//	//	.FirstOrDefaultAsync();

//	if (foundRole is not null)
//	{
//		var userCount = foundRole.Users.Count();

//		Console.WriteLine(value: $"User Count: {userCount}");
//	}
//}
//catch (Exception ex)
//{
//	Console.WriteLine(value: ex.Message);
//}

//async Task CreateTheRoleAsync()
//{
//	using var applicationDbContext = new ApplicationDbContext();

//	var hasAnyRole =
//		await
//		applicationDbContext.Roles.AnyAsync();

//	if (hasAnyRole)
//	{
//		return;
//	}

//	var newRole = new Role(name: roleName);

//	applicationDbContext.Add(entity: newRole);

//	var affectedRows =
//		await
//		applicationDbContext.SaveChangesAsync();

//	Console.WriteLine(value: $"Role - {nameof(affectedRows)}: {affectedRows}");
//}

//async Task CreateTheUsersAsync()
//{
//	using var applicationDbContext = new ApplicationDbContext();

//	var foundRole =
//		await
//		applicationDbContext.Roles
//		.Where(current => current.Name.ToLower() == roleName.ToLower())
//		.FirstOrDefaultAsync();

//	if (foundRole is null)
//	{
//		var errorMessage = $"{roleName} role not found!";
//		Console.WriteLine(value: errorMessage);
//		return;
//	}

//	var hasAnyUser =
//		await
//		applicationDbContext.Users.AnyAsync();

//	if (hasAnyUser)
//	{
//		return;
//	}

//	User newUser;

//	newUser =
//		new User(username: "User1")
//		{
//			RoleId = foundRole.Id,
//		};

//	applicationDbContext.Add(entity: newUser);

//	newUser =
//		new User(username: "User2")
//		{
//			RoleId = foundRole.Id,
//		};

//	applicationDbContext.Add(entity: newUser);

//	newUser =
//		new User(username: "User3")
//		{
//			RoleId = foundRole.Id,
//		};

//	applicationDbContext.Add(entity: newUser);

//	var affectedRows =
//		await
//		applicationDbContext.SaveChangesAsync();

//	Console.WriteLine(value: $"Users - {nameof(affectedRows)}: {affectedRows}");
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

//	public virtual IList<User> Users { get; } = [];
//}

//public class User(string username) : Entity
//{
//	[Required]
//	public Guid RoleId { get; set; }

//	/// <summary>
//	/// Note: Error in Lazy Loading!
//	/// Property 'User.Role' is not virtual
//	/// </summary>
//	//public Role? Role { get; set; }
//	public virtual Role? Role { get; set; }

//	[MaxLength(length: 20)]
//	[Required(AllowEmptyStrings = false)]
//	public string Username { get; set; } = username;
//}

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

//		builder
//			.HasMany(current => current.Users)
//			.WithOne(other => other.Role)
//			.IsRequired(required: true)
//			.HasForeignKey(other => other.RoleId)
//			.OnDelete(deleteBehavior: DeleteBehavior.NoAction)
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

//		//optionsBuilder
//		//	.LogTo(action: Console.WriteLine)
//		//	;

//		//optionsBuilder
//		//	.UseSqlServer(connectionString: connectionString)
//		//	;

//		// Note: Install NuGet:
//		// Microsoft.EntityFrameworkCore.Proxies
//		optionsBuilder
//			.UseLazyLoadingProxies()
//			.UseSqlServer(connectionString: connectionString)
//			;
//	}

//	protected override void OnModelCreating(ModelBuilder modelBuilder)
//	{
//		modelBuilder.ApplyConfigurationsFromAssembly
//			(assembly: typeof(ApplicationDbContext).Assembly);
//	}
//}
