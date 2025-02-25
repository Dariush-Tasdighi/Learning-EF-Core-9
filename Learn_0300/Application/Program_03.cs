using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

try
{
	var username = $"DariushTasdighi";

	{
		using var applicationDbContext = new ApplicationDbContext();

		var hasAnyUser =
			await
			applicationDbContext.Users.AnyAsync();

		if (hasAnyUser == false)
		{
			var newUser =
				new User(username: username);

			applicationDbContext.Add(entity: newUser);

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

public class User(string username) : Entity
{
	[MaxLength(length: 20)]
	[Required(AllowEmptyStrings = false)]
	public string Username { get; set; } = username;

	public virtual IList<Post> WrittenPosts { get; } = [];
	public virtual IList<Post> VerifiedPosts { get; } = [];
}

public class Post(string title) : Entity
{
	[Required]
	public Guid WriterUserId { get; set; }

	public virtual User? WriterUser { get; set; }

	public Guid? VerifierUserId { get; set; }

	public virtual User? VerifierUser { get; set; }

	[MaxLength(length: 20)]
	[Required(AllowEmptyStrings = false)]
	public string Title { get; set; } = title;
}

internal class UserConfiguration : object, IEntityTypeConfiguration<User>
{
	public UserConfiguration() : base()
	{
	}

	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder
			.HasKey(current => current.Id)
			.IsClustered(clustered: false)
			;

		builder
			.Property(current => current.Username)
			.IsUnicode(unicode: false)
			;

		builder
			.HasIndex(current => new { current.Username })
			.IsUnique(unique: true)
			;

		builder
			.HasMany(current => current.WrittenPosts)
			.WithOne(other => other.WriterUser)
			.IsRequired(required: true)
			.HasForeignKey(other => other.WriterUserId)
			.OnDelete(deleteBehavior: DeleteBehavior.NoAction)
			;

		builder
			.HasMany(current => current.VerifiedPosts)
			.WithOne(other => other.VerifierUser)
			.IsRequired(required: false)
			.HasForeignKey(other => other.VerifierUserId)
			.OnDelete(deleteBehavior: DeleteBehavior.NoAction)
			;
	}
}

internal class PostConfiguration : object, IEntityTypeConfiguration<Post>
{
	public PostConfiguration() : base()
	{
	}

	public void Configure(EntityTypeBuilder<Post> builder)
	{
		builder
			.HasKey(current => current.Id)
			.IsClustered(clustered: false)
			;
	}
}

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext() : base()
	{
		Database.EnsureCreated();
	}

	public DbSet<User> Users { get; set; }
	public DbSet<Post> Posts { get; set; }

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
