using Microsoft.EntityFrameworkCore;

var applicationDbContext = new ApplicationDbContext();

var category =
	new Category
	{
		Name = "My Category",
	};

applicationDbContext.Categories.Add(entity: category);

applicationDbContext.SaveChanges();

applicationDbContext.Dispose();
//applicationDbContext = null; // !دیگر نیازی نیست

/// <summary>
/// In Separate File and Folder!
/// </summary>
public class Category : object
{
	public Category() : base()
	{
	}

	public int Id { get; set; }

	public string? Name { get; set; }
}

/// <summary>
/// In Separate File and Folder!
///
/// DatabaseContext -> استاندارد قبلی من
/// ApplicationDbContext -> استاندارد جدید من
/// </summary>
public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext() : base()
	{
	}

	/// <summary>
	/// Table Name -> Categories
	/// </summary>
	public DbSet<Category> Categories { get; set; }
}
