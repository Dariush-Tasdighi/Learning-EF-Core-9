using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Persistence;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext() : base()
	{
		Database.EnsureCreated();
	}

	public DbSet<Country> Countries { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		var connectionString =
			"Server=.;User ID=sa;Password=1234512345;Database=LEARNING_EF_CORE_0500;MultipleActiveResultSets=true;TrustServerCertificate=True;";

		optionsBuilder
			.UseLazyLoadingProxies()
			.UseSqlServer(connectionString: connectionString)
			;
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly
			(assembly: typeof(ApplicationDbContext).Assembly);
	}
}
