using Domain;
using Application.Persistence;
using MyApplication.Classes.Base;
using Microsoft.EntityFrameworkCore;

namespace MyApplication.Classes.Countries;

public class CountriesSearchService : BaseSearchService
{
	public CountriesSearchService(ApplicationDbContext applicationDbContext) : base(applicationDbContext: applicationDbContext)
	{
	}

	public async Task<BaseSearchResponse<Country>> SearchAsync(CountriesSearchRequest request)
	{
		var query =
			ApplicationDbContext.Countries
			.AsQueryable()
			;

		if (string.IsNullOrWhiteSpace(value: request.Name) == false)
		{
			var name = request.Name.ToLower();

			query = query.Where(current => current.Name.ToLower().Contains(name));
		}

		if (string.IsNullOrWhiteSpace(value: request.CodeFrom) == false)
		{
			var codeFrom = Convert.ToInt32(value: request.CodeFrom);

			query = query.Where(current => current.Code >= codeFrom);
		}

		if (string.IsNullOrWhiteSpace(value: request.CodeTo) == false)
		{
			var codeTo = Convert.ToInt32(value: request.CodeTo);

			query = query.Where(current => current.Code <= codeTo);
		}

		var recourdCount = query.Count();

		query = query.OrderBy(current => current.Name);

		query = query
			.Skip(count: request.PageIndex * request.PageSize)
			.Take(count: request.PageSize)
			;

		var list =
			await
			query.ToListAsync()
			;

		var pageCount =
			recourdCount / request.PageSize;

		var response =
			new BaseSearchResponse<Country>
			{
				List = list,
				PageCount = pageCount,
				RecordCount = recourdCount,
				PageIndex = request.PageIndex,
			};

		return response;
	}
}
