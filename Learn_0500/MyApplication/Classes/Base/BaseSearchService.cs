using Application.Persistence;

namespace MyApplication.Classes.Base;

public abstract class BaseSearchService : object
{
	public BaseSearchService(ApplicationDbContext applicationDbContext) : base()
	{
		ApplicationDbContext = applicationDbContext;
	}

	public ApplicationDbContext ApplicationDbContext { get; init; }
}
