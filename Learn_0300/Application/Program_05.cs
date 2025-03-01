//using System;
//using System.Linq;
//using System.Diagnostics;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//try
//{
//	var groupName = "Managers";
//	var username = "DariushTasdighi";

//	{
//		using var applicationDbContext = new ApplicationDbContext();

//		var hasAnyUser =
//			await
//			applicationDbContext.Users.AnyAsync();

//		if (hasAnyUser == false)
//		{
//			var newUser = new User(username: username);

//			applicationDbContext.Add(entity: newUser);

//			await applicationDbContext.SaveChangesAsync();
//		}

//		var hasAnyGroup =
//			await
//			applicationDbContext.Groups.AnyAsync();

//		if (hasAnyGroup == false)
//		{
//			var newGroup = new Group(name: groupName);

//			applicationDbContext.Add(entity: newGroup);

//			await applicationDbContext.SaveChangesAsync();
//		}
//	}

//	{
//		using var applicationDbContext = new ApplicationDbContext();

//		var theUser =
//			await
//			applicationDbContext.Users
//			.Where(current => current.Username.ToLower() == username.ToLower())
//			.FirstOrDefaultAsync();

//		if (theUser is null)
//		{
//			Console.WriteLine(value: $"There is not the {username} user!");
//			return;
//		}

//		var theGroup =
//			await
//			applicationDbContext.Groups
//			.Where(current => current.Name.ToLower() == groupName.ToLower())
//			.FirstOrDefaultAsync();

//		if (theGroup is null)
//		{
//			Console.WriteLine(value: $"There is not the {groupName} group!");
//			return;
//		}

//		theGroup.Users.Add(item: theUser);
//		// [OR]
//		theUser.Groups.Add(item: theGroup);

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

//	public virtual IList<Group> Groups { get; } = [];
//}

//public class Group(string name) : Entity
//{
//	[MaxLength(length: 50)]
//	[Required(AllowEmptyStrings = false)]
//	public string Name { get; set; } = name;

//	public virtual IList<User> Users { get; } = [];
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

//		//[User]	[UsersInGroups]		[Group]

//		builder
//			.HasMany(current => current.Groups)
//			.WithMany(other => other.Users)
//			.UsingEntity
//			(
//				joinEntityName: "UsersInGroups",
//				// ترتیب نوشتن دو دستور ذیل، بینهایت اهمیت دارد
//				// نزدیک در نزدیک - دور در دور
//				configureRight: right => right.HasOne(typeof(Group)).WithMany().HasForeignKey("GroupId").HasPrincipalKey(nameof(Group.Id)),
//				configureLeft: left => left.HasOne(typeof(User)).WithMany().HasForeignKey("UserId").HasPrincipalKey(nameof(User.Id)),
//				configureJoinEntityType: join => join.HasKey("UserId", "GroupId")
//			);

//		// نکته: دو دستور ذیل با هم فرق می‌کنند
//		//join => join.HasKey("GroupId", "UserId")
//		//join => join.HasKey("UserId", "GroupId")

//		// با فرض این‌که، همه جداول، یک فیلد به نام دقیقا
//		// Id
//		// دارد، می‌توانیم به جای دستور فوق، از دستور ذیل استفاده نماییم
//		//builder
//		//	.HasMany(current => current.Groups)
//		//	.WithMany(other => other.Users)
//		//	.UsingEntity
//		//	(
//		//		joinEntityName: "UsersInGroups",
//		//		// ترتیب نوشتن دو دستور ذیل، بینهایت اهمیت دارد
//		//		// نزدیک در نزدیک - دور در دور
//		//		configureRight: right => right.HasOne(typeof(Group)).WithMany().HasForeignKey("GroupId"),
//		//		configureLeft: left => left.HasOne(typeof(User)).WithMany().HasForeignKey("UserId"),
//		//		configureJoinEntityType: join => join.HasKey("UserId", "GroupId")
//		//	);
//	}
//}

//internal class GroupConfiguration : object, IEntityTypeConfiguration<Group>
//{
//	public GroupConfiguration() : base()
//	{
//	}

//	public void Configure(EntityTypeBuilder<Group> builder)
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

//public class ApplicationDbContext : DbContext
//{
//	public ApplicationDbContext() : base()
//	{
//		Database.EnsureCreated();
//	}

//	public DbSet<User> Users { get; set; }
//	public DbSet<Group> Groups { get; set; }

//	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//	{
//		var connectionString =
//			"Server=.;User ID=sa;Password=1234512345;Database=LEARNING_EF_CORE_0300;MultipleActiveResultSets=true;TrustServerCertificate=True;";

//		// **************************************************
//		//optionsBuilder
//		//	.UseSqlServer(connectionString: connectionString)
//		//	;
//		// **************************************************

//		// **************************************************
//		// New!
//		//optionsBuilder
//		//	.LogTo(e => Debug.WriteLine(e))
//		//	;

//		// [OR]

//		// New!
//		//optionsBuilder
//		//	.LogTo(e => Console.WriteLine(e))
//		//	;

//		// [OR]

//		// New!
//		//optionsBuilder
//		//	.LogTo(action: Console.WriteLine)
//		//	;

//		// New!
//		optionsBuilder
//			.LogTo(action: Console.WriteLine)
//			.UseSqlServer(connectionString: connectionString)
//			;
//	}

//	protected override void OnModelCreating(ModelBuilder modelBuilder)
//	{
//		modelBuilder.ApplyConfigurationsFromAssembly
//			(assembly: typeof(ApplicationDbContext).Assembly);
//	}
//}
