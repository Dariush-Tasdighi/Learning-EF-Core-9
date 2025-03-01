//using System;
//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//try
//{
//	var username1 = $"Username1";
//	var username2 = $"Username2";
//	var username3 = $"Username3";
//	var username4 = $"Username4";

//	{
//		using var applicationDbContext = new ApplicationDbContext();

//		var hasAnyUser =
//			await
//			applicationDbContext.Users.AnyAsync();

//		if (hasAnyUser)
//		{
//			Console.WriteLine(value: "Please Delete Database First!");
//			return;
//		}

//		User newUser;
//		UserProfile newUserProfile;

//		// **************************************************
//		newUser = new User(username: username1);

//		applicationDbContext.Add(entity: newUser);
//		// **************************************************

//		// **************************************************
//		// In DDD: Bad Practice!
//		// **************************************************
//		newUser = new User(username: username2);

//		newUserProfile =
//			new UserProfile(fullName: "Full Name (2)")
//			{
//				UserId = newUser.Id,
//			};

//		applicationDbContext.Add(entity: newUser);
//		applicationDbContext.Add(entity: newUserProfile);

//		// ?????
//		//applicationDbContext.AddRange(newUser, newUserProfile);
//		// **************************************************

//		// **************************************************
//		// In DDD: Bad Practice!
//		// **************************************************
//		newUser = new User(username: username3);

//		newUserProfile =
//			new UserProfile(fullName: "Full Name (3)")
//			{
//				User = newUser,
//			};

//		applicationDbContext.Add(entity: newUser);
//		applicationDbContext.Add(entity: newUserProfile);
//		// **************************************************

//		// **************************************************
//		newUser = new User(username: username4);
//		newUserProfile = new UserProfile(fullName: "Full Name (4)");

//		newUser.Profile = newUserProfile;

//		applicationDbContext.Add(entity: newUser);
//		// **************************************************

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
//	/// <summary>
//	/// نکته مهم - دستور ذیل را نباید بنویسیم
//	/// </summary>
//	//public Guid? ProfileId { get; set; }

//	public virtual UserProfile? Profile { get; set; }

//	[MaxLength(length: 20)]
//	[Required(AllowEmptyStrings = false)]
//	public string Username { get; set; } = username;
//}

//public class UserProfile(string fullName) : Entity
//{
//	[Required]
//	public Guid UserId { get; set; }

//	public virtual User? User { get; set; }
//	//public virtual User User { get; set; } = null!;

//	[MaxLength(length: 50)]
//	[Required(AllowEmptyStrings = false)]
//	public string FullName { get; set; } = fullName;
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

//		builder
//			.HasOne(current => current.Profile)
//			.WithOne(other => other.User)
//			.HasForeignKey<UserProfile>(other => other.UserId)
//			.IsRequired(required: true)
//			;
//	}
//}

//internal class UserProfileConfiguration : object, IEntityTypeConfiguration<UserProfile>
//{
//	public UserProfileConfiguration() : base()
//	{
//	}

//	public void Configure(EntityTypeBuilder<UserProfile> builder)
//	{
//		builder
//			.HasKey(current => current.Id)
//			.IsClustered(clustered: false)
//			;

//		builder
//			.HasIndex(current => new { current.FullName })
//			.IsUnique(unique: false)
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

//	/// <summary>
//	/// عرف نیست
//	/// </summary>
//	//public DbSet<UserProfile> UserProfiles { get; set; }

//	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//	{
//		var connectionString =
//			"Server=.;User ID=sa;Password=1234512345;Database=LEARNING_EF_CORE_0300;MultipleActiveResultSets=true;TrustServerCertificate=True;";

//		optionsBuilder
//			//.LogTo(action: Console.WriteLine)
//			.UseSqlServer(connectionString: connectionString)
//			;
//	}

//	protected override void OnModelCreating(ModelBuilder modelBuilder)
//	{
//		modelBuilder.ApplyConfigurationsFromAssembly
//			(assembly: typeof(ApplicationDbContext).Assembly);
//	}
//}
