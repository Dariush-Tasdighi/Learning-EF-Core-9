//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;
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
//			var newRole =
//				new Role(name: roleName);

//			applicationDbContext.Add(entity: newRole);

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

//		// New
//		//builder
//		//	.HasMany(role => role.Users)
//		//	.WithOne(user => user.Role)
//		//	.IsRequired(required: true)
//		//	.HasForeignKey(user => user.RoleId)
//		//	.OnDelete(deleteBehavior: DeleteBehavior.NoAction)
//		//	;

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
