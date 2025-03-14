using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Persistence;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext() : base()
	{
		//Database.Migrate();
		Database.EnsureCreated();
	}

	public ApplicationDbContext(DbContextOptions options) : base(options: options)
	{
		//Database.Migrate();
		Database.EnsureCreated();
	}

	public DbSet<Country> Countries { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (optionsBuilder.IsConfigured == false)
		{
			var connectionString =
				"Server=.;User ID=sa;Password=1234512345;Database=LEARNING_EF_CORE_0600;MultipleActiveResultSets=true;TrustServerCertificate=True;";

			optionsBuilder
				.UseLazyLoadingProxies()
				.UseSqlServer(connectionString: connectionString)
				;
		}
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly
			(assembly: typeof(ApplicationDbContext).Assembly);
	}
}
