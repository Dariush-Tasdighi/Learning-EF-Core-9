//using System;
//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//try
//{
//	var username = "Dariush Tasdighi";

//	{
//		using var applicationDbContext = new ApplicationDbContext();

//		var hasAnyUser =
//			await
//			applicationDbContext.Users.AnyAsync();

//		if (hasAnyUser)
//		{
//			Console.WriteLine(value: $"Please Delete Database First!");
//			return;
//		}

//		var newUser = new User(username: username);

//		applicationDbContext.Add(entity: newUser);

//		var affectedRows =
//			await
//			applicationDbContext.SaveChangesAsync();

//		Console.WriteLine(value: $"{nameof(affectedRows)}: {affectedRows}");
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

//public class User(string username) : Entity
//{
//	[MaxLength(length: 20)]
//	[Required(AllowEmptyStrings = false)]
//	public string Username { get; set; } = username;

//	public string? String1 { get; set; }
//	public string? String2 { get; set; }
//	public string? String3 { get; set; }
//	public string? String4 { get; set; }
//	public string? String5 { get; set; }
//	public string? String6 { get; set; }
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

//		// Char(10)
//		builder
//			.Property(current => current.String1)
//			.IsUnicode(unicode: false)
//			.HasMaxLength(maxLength: 10)
//			.IsFixedLength(fixedLength: true)
//			;

//		// NChar(10)
//		builder
//			.Property(current => current.String2)
//			.IsUnicode(unicode: true)
//			.HasMaxLength(maxLength: 10)
//			.IsFixedLength(fixedLength: true)
//			;

//		// Varchar(10)
//		builder
//			.Property(current => current.String3)
//			.IsUnicode(unicode: false)
//			.HasMaxLength(maxLength: 10)
//			.IsFixedLength(fixedLength: false)
//			;

//		// NVarchar(10) - OK
//		builder
//			.Property(current => current.String4)
//			.IsUnicode(unicode: true)
//			.HasMaxLength(maxLength: 10)
//			.IsFixedLength(fixedLength: false)
//			;

//		// Varchar(Max)
//		builder
//			.Property(current => current.String5)
//			.IsUnicode(unicode: false)
//			//.HasMaxLength(maxLength: 10)
//			.IsFixedLength(fixedLength: false)
//			;

//		// NVarchar(Max) - OK
//		builder
//			.Property(current => current.String6)
//			.IsUnicode(unicode: true)
//			//.HasMaxLength(maxLength: 10)
//			.IsFixedLength(fixedLength: false)
//			;
//	}
//}

//public class ApplicationDbContext : DbContext
//{
//	public ApplicationDbContext() : base()
//	{
//		Database.EnsureCreated();
//	}

//	public DbSet<User> Users { get; set; }

//	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//	{
//		var connectionString =
//			"Server=.;User ID=sa;Password=1234512345;Database=LEARNING_EF_CORE_0300;MultipleActiveResultSets=true;TrustServerCertificate=True;";

//		//optionsBuilder
//		//	.LogTo(action: Console.WriteLine)
//		//	;

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
