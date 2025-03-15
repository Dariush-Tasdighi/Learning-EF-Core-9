using Domain;
using System;
using ViewModels;
using Application;
using System.Data;
using System.Linq;
using Application.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

try
{
	using var applicationDbContext = new ApplicationDbContext();

	// **************************************************
	// سه دستور ذيل، کاملا با هم معادل می‌باشند
	// **************************************************
	{
		var countries =
			applicationDbContext.Countries
			.ToList()
			;
	}

	{
		var countries =
			await
			applicationDbContext.Countries
			.ToListAsync()
			;
	}

	// Below Command: Using just in WPF / Silverlight (منسوخ)
	//	-> Architecture: MVVM

	{
		// Load() -> using Microsoft.EntityFrameworkCore;
		applicationDbContext.Countries
			.Load();

		// استفاده می کنيم Local از

		// Observable Collection based on Observable Pattern (Design Patterns)
		var countries =
			applicationDbContext.Countries.Local;
	}
	// **************************************************
	// "SELECT * FROM Countries"
	// **************************************************

	// **************************************************
	{
		var countries =
			await
			applicationDbContext.Countries
			.Where(current => current.Code >= 10)
			.ToListAsync()
			;
	}
	// **************************************************
	// "SELECT * FROM Countries WHERE Code >= 10"
	// **************************************************

	// **************************************************
	// دو دستور ذيل، کاملا با هم معادل می‌باشند
	// **************************************************
	{
		var countries =
			await
			applicationDbContext.Countries
			.Where(current => current.Code >= 10 && current.Code <= 20)
			.ToListAsync()
			;
	}

	{
		var countries =
			await
			applicationDbContext.Countries
			.Where(current => current.Code >= 10)
			.Where(current => current.Code <= 20)
			.ToListAsync()
			;
	}
	// **************************************************
	// "SELECT * FROM Countries WHERE Code >= 10 AND Code <= 20"
	// **************************************************

	// **************************************************
	{
		var countries =
			await
			applicationDbContext.Countries
			.Where(current => current.Code < 10 || current.Code > 20)
			.ToListAsync()
			;
	}
	// **************************************************
	// "SELECT * FROM Countries WHERE Code < 10 OR Code > 20"
	// **************************************************

	// **************************************************
	{
		var countries =
			await
			applicationDbContext.Countries
			.Where(current => current.Name == "Iran")
			.ToListAsync()
			;
	}
	// **************************************************
	// "SELECT * FROM Countries WHERE Name = 'Iran'"
	// **************************************************

	// **************************************************
	// دو دستور ذيل، کاملا با هم معادل می‌باشند
	// **************************************************
	{
		var countries =
			await
			applicationDbContext.Countries
			.Where(current => current.Name.ToLower() == "Iran".ToLower())
			.ToListAsync()
			;
	}

	{
		var countries =
			await
			applicationDbContext.Countries
			.Where(current => current.Name.ToLower() == "iran")
			.ToListAsync()
			;
	}

	{
		var countries =
			await
			applicationDbContext.Countries
			.Where(current => current.Name.ToUpper() == "Iran".ToUpper())
			.ToListAsync()
			;
	}

	{
		var countries =
			await
			applicationDbContext.Countries
			.Where(current => current.Name.ToUpper() == "IRAN")
			.ToListAsync()
			;
	}
	// **************************************************
	// "SELECT * FROM Countries WHERE Name = 'Iran'"
	// **************************************************

	// **************************************************
	{
		var countries =
			await
			applicationDbContext.Countries
			.Where(current => current.Name.ToLower().StartsWith("Ir".ToLower()))
			.ToListAsync()
			;
	}
	// **************************************************
	// "SELECT * FROM Countries WHERE Name LIKE 'Ir%'"
	// **************************************************

	// **************************************************
	{
		var countries =
			await
			applicationDbContext.Countries
			.Where(current => current.Name.ToLower().EndsWith("an".ToLower()))
			.ToListAsync()
			;
	}
	// **************************************************
	// "SELECT * FROM Countries WHERE Name LIKE '%an'"
	// **************************************************

	// **************************************************
	{
		var countries =
			await
			applicationDbContext.Countries
			.Where(current => current.Name.ToLower().Contains("ra".ToLower()))
			.ToListAsync()
			;
	}
	// **************************************************
	// "SELECT * FROM Countries WHERE Name LIKE '%ra%'"
	// **************************************************

	// **************************************************
	// Note: دقت کنيد که دستور ذيل کار نمی کند
	// **************************************************
	{
		var search = "علی علوی";

		// "SELECT * FROM Countries WHERE Name LIKE '%علی علوی%'"

		// "علی%علوی"
		search = search.Replace(oldValue: " ", newValue: "%");

		// "SELECT * FROM Countries WHERE Name LIKE '%علی%علوی%'"
	}
	// **************************************************

	// **************************************************
	// چرا کار نمی‌کند؟
	//
	// یکی دیگر از شاهکارها و زیبایی‌های
	// EF / EF Core
	// آن است که
	// SQL Injection Free!
	// می‌باشد
	// **************************************************

	// **************************************************
	// Dynamic Search: Introduction
	// **************************************************
	{
		var search = "علی علوی";

		// "علی%علوی"
		// خوشبختانه! کار نمی‌کند
		//search = search.Replace(oldValue: " ", newValue: "%");

		var countries =
			await
			applicationDbContext.Countries
			.Where(current => current.Name.ToLower().Contains(search.ToLower()))
			.ToListAsync()
			;
	}

	{
		//var countries =
		//	await
		//	applicationDbContext.Countries
		//	.Where(current => current.Name.ToLower().Contains("علی".ToLower()))
		//	.Where(current => current.Name.ToLower().Contains("علوی".ToLower()))
		//	.ToListAsync()
		//	;

		var search = "علی علوی";

		var keywords =
			search.Split(separator: ' ');

		var countries =
			await
			applicationDbContext.Countries
			.Where(current => current.Name.ToLower().Contains(keywords[0].ToLower()))
			.Where(current => current.Name.ToLower().Contains(keywords[1].ToLower()))
			.ToListAsync()
			;
	}

	{
		var search = "علی علوی";

		var keywords =
			search.Split(separator: ' ');

		var countries =
			await
			applicationDbContext.Countries
			.Where(current =>
				current.Name.ToLower().Contains(keywords[0].ToLower())
				||
				current.Name.ToLower().Contains(keywords[1].ToLower()))
			.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	{
		var countries =
			await
			applicationDbContext.Countries
			.OrderBy(current => current.Code)
			.ToListAsync()
			;
	}
	// **************************************************
	// "SELECT * FROM Countries ORDER BY Code"
	// "SELECT * FROM Countries ORDER BY Code ASC"
	// **************************************************

	// **************************************************
	{
		var countries =
			await
			applicationDbContext.Countries
			.OrderByDescending(current => current.Code)
			.ToListAsync()
			;
	}
	// **************************************************
	// "SELECT * FROM Countries ORDER BY Code DESC"
	// **************************************************

	// **************************************************
	// Note: Bad Practice
	// کار نمی‌کرد EF (OLD) فکر می‌کنم که دستور ذیل، در نسخه قدیم
	// **************************************************
	{
		var countries =
			await
			applicationDbContext.Countries
			.OrderBy(current => current.Name)
			.Where(current => current.Code >= 10)
			.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	// Note: Best Practice
	// **************************************************
	{
		var countries =
			await
			applicationDbContext.Countries
			.Where(current => current.Code >= 10)
			.OrderBy(current => current.Name)
			.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	// Note: Wrong Usage!
	// **************************************************
	{
		var countries =
			await
			applicationDbContext.Countries
			.OrderBy(current => current.Code)
			.OrderBy(current => current.Name)
			.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	{
		var countries =
			await
			applicationDbContext.Countries
			// فقط اولی
			.OrderBy(current => current.Code)
			// دومی به بعد
			.ThenBy(current => current.Name)
			.ToListAsync()
			;
	}

	{
		var countries =
			await
			applicationDbContext.Countries
			// فقط اولی
			.OrderBy(current => current.Code)
			// دومی به بعد
			.ThenByDescending(current => current.Name)
			.ToListAsync()
			;
	}

	{
		var countries =
			await
			applicationDbContext.Countries
			// فقط اولی
			.OrderByDescending(current => current.Code)
			// دومی به بعد
			.ThenBy(current => current.Name)
			.ToListAsync()
			;
	}

	{
		var countries =
			await
			applicationDbContext.Countries
			// فقط اولی
			.OrderByDescending(current => current.Code)
			// دومی به بعد
			.ThenByDescending(current => current.Name)
			.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	// Optimization!
	// **************************************************
	// Loading Related Data:
	//
	// a) Not Loading!
	// b) Lazy Loading!
	// c) Eager Loading!
	//
	// هدف: می‌خواهیم، تعداد استان‌های کشوری که کد آن یک است را بدست آوریم
	// فرض می‌کنیم که تعداد استان‌های کشوری با کد یک، ده میلیون استان باشد
	// **************************************************
	{
		var country =
			await
			applicationDbContext.Countries
			.Where(current => current.Code == 1)
			.FirstOrDefaultAsync();

		if (country is not null)
		{
			// In Lazy Mode:
			// If we use
			// 1. virtual keyword for the states property
			// 2. UseLazyLoadingProxies() method in ApplicationDbContext
			// The states will be loaded in lazy mode.

			// In Normal Mode:
			// stateCount is zero!
			var stateCount =
				country.States.Count;
		}
	}
	// **************************************************

	// **************************************************
	{
		//var states =
		//	await
		//	applicationDbContext.States
		//	.Where(current => current.Country.Code == 1)
		//	.ToListAsync()
		//	;

		//var states =
		//	await
		//	applicationDbContext.States
		//	.Where(current => current.Country is not null && current.Country.Code == 1)
		//	.ToListAsync()
		//	;

		//var states =
		//	await
		//	applicationDbContext.States
		//	.Where(current => current.Country != null && current.Country.Code == 1)
		//	.ToListAsync()
		//	;

		var states =
			await
			applicationDbContext.States
			.Where(current => current.Country!.Code == 1)
			.ToListAsync()
			;

		var stateCountOfSomeCountry = states.Count;
	}
	// **************************************************

	// **************************************************
	{
		var stateCountOfSomeCountry =
			await
			applicationDbContext.States
			.Where(current => current.Country!.Code == 1)
			.CountAsync();
	}
	// **************************************************
	// "SELECT COUNT(*) FROM States ...                 "
	// **************************************************

	// **************************************************
	// Undocumented!
	// **************************************************
	{
		var country =
			await
			applicationDbContext.Countries
			.Where(current => current.Code == 1)
			.FirstOrDefaultAsync();

		if (country is not null)
		{
			var stateCountOfSomeCountry =
				await
				applicationDbContext.Entry(country)
					.Collection(current => current.States)
					.Query()
					.CountAsync();
		}
	}
	// **************************************************

	// **************************************************
	// فاجعه
	//
	// فرض کنید که هر کشور
	// به طور متوسط ده میلیون استان دارد
	// **************************************************
	{
		var country =
			await
			applicationDbContext.Countries
			.Where(current => current.Code == 1)
			.FirstOrDefaultAsync();

		if (country is not null)
		{
			var states =
				country.States
				.Where(current => current.Code <= 10)
				.ToList()
				;
		}
	}
	// **************************************************

	// **************************************************
	{
		var states =
			await
			applicationDbContext.States
			.Where(current => current.Code <= 10)
			.Where(current => current.Country!.Code == 1)
			.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	// Undocumented!
	// **************************************************
	{
		var country =
			await
			applicationDbContext.Countries
			.Where(current => current.Code == 1)
			.FirstOrDefaultAsync();

		if (country is not null)
		{
			var statesOfSomeCountry =
				await
				applicationDbContext.Entry(country)
				.Collection(current => current.States)
				.Query()
				.Where(state => state.Code <= 10)
				.ToListAsync()
				;
		}
	}
	// **************************************************

	// **************************************************
	{
		var country =
			await
			applicationDbContext.Countries
			.Where(current => current.Code == 1)
			.FirstOrDefaultAsync()
			;

		if (country is not null)
		{
			var stateCount =
				country.States.Count;
		}
	}

	{
		// Learning Eager Loading!

		// اگر بخواهیم، زمانی که کشوری از بانک اطلاعاتی دریافت
		// کردیم، همه استان‌های آن نیز، در همان درخواست، منتقل شود
		// از دستور ذیل استفاده می‌کنیم
		var country =
			await
			applicationDbContext.Countries
			.Include("States")
			.Where(current => current.Code == 1)
			.FirstOrDefaultAsync();

		// در این حالت امکان بی‌دقتی وجود دارد
		//var country =
		//	await
		//	applicationDbContext.Countries
		//	.Include("Stats")
		//	.Where(current => current.Code >= 1)
		//	.FirstOrDefaultAsync();

		if (country is not null)
		{
			var stateCount =
				country.States.Count;
		}
	}
	// **************************************************

	// **************************************************
	// Note: Include -> Strongly Typed
	//
	// در این حالت امکان بی‌دقتی وجود ندارد
	// **************************************************
	{
		var country =
			await
			applicationDbContext.Countries
			.Include(current => current.States)
			.Where(current => current.Code == 1)
			.FirstOrDefaultAsync();

		//var country =
		//	await
		//	applicationDbContext.Countries
		//	.Include(current => current.Stats)
		//	.Where(current => current.Code == 1)
		//	.FirstOrDefaultAsync();

		if (country is not null)
		{
			var stateCount =
				country.States.Count;
		}
	}
	// **************************************************

	// **************************************************
	{
		var country =
			await
			applicationDbContext.Countries
			.Include("States")
			.Include("States.Cities")
			.Where(current => current.Code == 1)
			.FirstOrDefaultAsync();

		// در این حالت نیز امکان بی‌دقتی وجود دارد

		if (country is not null)
		{
			var stateCount =
				country.States.Count;
		}
	}
	// **************************************************

	// **************************************************
	// Undocumented!
	// Note: Strongly Typed
	// **************************************************
	{
		var country =
			await
			applicationDbContext.Countries

			// In EF and EF Core
			//.Include(current => current.States)
			//.Include(current => current.States.Select(state => state.Cities))

			// In EF Core
			.Include(current => current.States)
				.ThenInclude(state => state.Cities)

			.Where(current => current.Code == 1)
			.FirstOrDefaultAsync();

		if (country is not null)
		{
			var stateCount =
				country.States.Count;
		}
	}
	// **************************************************

	// **************************************************
	{
		var country =
			await
			applicationDbContext.Countries

			// In EF and EF Core
			//.Include(current => current.States)
			//.Include(current => current.States.Select(state => state.Cities))
			//.Include(current => current.States.Select(state => state.Cities.Select(city => city.Sections))

			// In EF Core
			.Include(current => current.States)
				.ThenInclude(state => state.Cities)
					.ThenInclude(city => city.Sections)

			.Where(current => current.Code == 1)
			.FirstOrDefaultAsync();

		if (country is not null)
		{
			var stateCount =
				country.States.Count;
		}
	}
	// **************************************************

	// **************************************************
	// Workshop Project
	// **************************************************
	//var theUser =
	//	await
	//	applicationDbContext.Users

	//	.Include(current => current.Companies)
	//		.ThenInclude(company => company.Applications)
	//			.ThenInclude(application => application.UserValidIPs)

	//	.Include(current => current.Companies)
	//		.ThenInclude(company => company.Applications)
	//			.ThenInclude(application => application.ApplicationValidIPs)

	//	.Where(current => current.Username == username)
	//	.FirstOrDefaultAsync();
	// **************************************************

	// **************************************************
	{
		var city =
			await
			applicationDbContext.Cities
			.Where(current => current.Code == 10)
			.FirstOrDefaultAsync();

		if (city is not null)
		{
			// کد قدیمی
			//string? stateName = null;
			//if (city.State is not null)
			//{
			//	stateName = city.State.Name;
			//}

			// کد جدید / مدرن
			var stateName = city.State?.Name;
		}
	}
	// **************************************************

	// **************************************************
	{
		var city =
			await
			applicationDbContext.Cities
			.Include("State")
			.Where(current => current.Code == 10)
			.FirstOrDefaultAsync();

		if (city is not null)
		{
			var stateName = city.State?.Name;
			var countryName = city.State?.Country?.Name;
		}
	}
	// **************************************************

	// **************************************************
	{
		var city =
			await
			applicationDbContext.Cities
			.Include("State")
			.Include("State.Country")
			.Where(current => current.Code == 10)
			.FirstOrDefaultAsync();

		if (city is not null)
		{
			var stateName = city.State?.Name;
			var countryName = city.State?.Country?.Name;
		}
	}
	// **************************************************

	// **************************************************
	// Note: Include -> Strongly Typed
	// **************************************************
	{
		var city =
			await
			applicationDbContext.Cities
			.Include(current => current.State)
			.Where(current => current.Code == 10)
			.FirstOrDefaultAsync();

		if (city is not null)
		{
			var stateName = city.State?.Name;
			var countryName = city.State?.Country?.Name;
		}
	}
	// **************************************************

	// **************************************************
	{
		var city =
			await
			applicationDbContext.Cities

			// In EF or EF Core
			//.Include(current => current.State)
			//.Include(current => current.State!.Country)

			// In EF Core
			.Include(current => current.State)
				.ThenInclude(state => state!.Country)

			.Where(current => current.Code == 10)
			.FirstOrDefaultAsync();

		if (city is not null)
		{
			var stateName = city.State?.Name;
			var countryName = city.State?.Country?.Name;
		}
	}
	// **************************************************

	// **************************************************
	// Partial Eater Loading!
	//
	// EF Core یک شاهکار دیگر در
	// **************************************************
	{
		var country =
			await
			applicationDbContext.Countries

			// Just In EF Core not in EF
			.Include(current => current.States.Where(state => state.IsActive))
				.ThenInclude(state => state.Cities.Where(city => city.IsActive))
					.ThenInclude(city => city.Sections.Where(section => section.IsActive))

			.Where(current => current.Code == 10)
			.FirstOrDefaultAsync();

		if (country is not null)
		{
			var stateCount = country.States.Count;
		}
	}
	// **************************************************

	// **************************************************
	// صورت مساله
	//
	// من همه کشورهايی را می‌خواهم که
	// لااقل در نام يکی از استان‌های آن، حرف {بی} وجود داشته باشد
	// لااقل = Any
	// **************************************************
	{
		// Solution (1)
		var countries =
			await
			applicationDbContext.Countries
			// دقت کنيد که صرف شرط ذيل، نيازی به دستور
			// Include
			// نيست
			//.Include(current => current.States)
			.Where(current => current.States.Any(state => state.Name.ToLower().Contains("B".ToLower())))
			.ToListAsync()
			;
	}

	{
		// Solution (2)
		// Note: Wrong Answer
		var countries =
			await
			applicationDbContext.States
			.Where(current => current.Name.ToLower().Contains("B".ToLower()))
			.Select(current => current.Country)
			.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	// غلط است Solution (2) چرا
	// **************************************************
	// C1		A1
	// C1		B1
	// C2		A2
	// C2		B2
	//
	// Result for Solution (1) and Solution (2):
	// [C1, C2] => OK
	//
	// BUT
	// C1		A1
	// C1		B1
	// C1		B2
	// C2		A2
	// C2		B3
	// C2		B4
	//
	// Result for Solution (1):
	// [C1, C2] = > OK
	//
	// Result for Solution (2):
	// [C1, C1, C2, C2] => NOT OK!
	// **************************************************

	// **************************************************
	// صورت مساله
	//
	// من همه کشورهايی را می‌خواهم که
	// در لااقل نام يکی از شهرهای آن، حرف {بی} وجود داشته باشد
	// **************************************************
	{
		var countries =
			await
			applicationDbContext.Countries
			// دقت کنيد که صرف شرط ذيل، نيازی به دستور
			// Include
			// نيست
			//.Include(current => current.States)
			//.Include(current => current.States.Select(state => state.Cities))
			.Where(current => current.States.Any
				(state => state.Cities.Any
				(city => city.Name.ToLower().Contains("B".ToLower()))))
			.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	// صورت مساله
	//
	// من همه شهرهایی را می‌خواهم که
	// جمعیت کشورشان بیش از ده میلیون نفر باشد
	// **************************************************
	{
		var cities =
			await
			applicationDbContext.Cities
			// دقت کنيد که صرف شرط ذيل، نيازی به دستور
			// Include
			// نيست
			//.Include(current => current.State)
			//.Include(current => current.State.Country)
			//.Where(current => current.State.Country.Population >= 10000000)
			//.Where(current => current.State!.Country!.Population >= 10000000)
			.Where(current => current.State!.Country!.Population >= 10_000_000)
			.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	// Country -> State -> City -> Section -> Hotel
	// **************************************************
	{
		var hotels =
			await
			applicationDbContext.Hotels
			.ToListAsync()
			;
	}

	{
		var hotels =
			await
			applicationDbContext.Hotels
			.Where(current => current.SectionId == 100)
			//.Where(current => current.Section!.Id == 100)
			.ToListAsync()
			;
	}

	{
		var hotels =
			await
			applicationDbContext.Hotels
			.Where(current => current.Section!.CityId == 101)
			//.Where(current => current.Section!.City!.Id == 101)
			.ToListAsync()
			;
	}

	{
		var hotels =
			await
			applicationDbContext.Hotels
			.Where(current => current.Section!.City!.StateId == 102)
			//.Where(current => current.Section!.City!.State!.Id == 102)
			.ToListAsync()
			;
	}

	{
		var hotels =
			await
			applicationDbContext.Hotels
			.Where(current => current.Section!.City!.State!.CountryId == 103)
			//.Where(current => current.Section!.City!.State!.Country!.Id == 103)
			.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	// خاطره‌ای از یک نابغه
	// **************************************************
	{
		//var countries =
		//	await
		//	applicationDbContext.Countries
		//	.Where(current => current.Code => 5)
		//	.Where(current => current.Code =< 45)
		//	.ToListAsync()
		//	;
	}
	// **************************************************

	// **************************************************
	{
		applicationDbContext.Countries
			.Where(current => current.Code >= 5)
			.Where(current => current.Code <= 45)
			.Load();

		var countryCount =
			applicationDbContext.Countries.Local.Count;

		applicationDbContext.Countries
			.Where(current => current.Code >= 10)
			.Where(current => current.Code <= 50)
			.Load();

		countryCount =
			applicationDbContext.Countries.Local.Count;
	}
	// **************************************************

	// **************************************************
	// Dynamic Search
	//
	//
	//	State(1)
	//
	//Name: _____
	//
	//[Search]-> 2 States
	//
	//State(2)
	//
	//Name: _____
	//Code: _____
	//
	//[Search]-> 4 States
	//
	//State(3)
	//
	//Name: __________
	//Code From: _____
	//Code To: _____
	//
	//[Search]-> 8 States
	//
	//State(N)->N = 10
	//
	//			10
	//[Search]-> 2   States
	// **************************************************
	{
		// **************************************************
		//string? countryName = null;
		//string? countryCodeTo = null;
		//string? countryCodeFrom = null;
		// OR
		//string? countryName = "Iran";
		//string? countryCodeTo = null;
		//string? countryCodeFrom = null;
		// OR
		//string? countryName = null;
		//string? countryCodeTo = "10";
		//string? countryCodeFrom = null;
		// OR
		string? countryName = "Iran";
		string? countryCodeTo = "10";
		string? countryCodeFrom = null;
		// OR
		// ...    3
		// Up to 2  = 8 States!
		// **************************************************

		// **************************************************
		// ما با دستور ذیل مشکل داریم
		//var data =
		//	applicationDbContext.Countries
		//	;

		//var data =
		//	applicationDbContext.Countries
		//	.Where(current => current.IsActive)
		//	;

		//var data =
		//	applicationDbContext.Countries
		//	.Where(current => 1 == 1)
		//	;

		var data =
			applicationDbContext.Countries
			.AsQueryable()
			;

		if (string.IsNullOrWhiteSpace(value: countryName) == false)
		{
			data = data.Where(current => current.Name.ToLower().Contains(countryName.ToLower()));
		}

		if (string.IsNullOrWhiteSpace(value: countryCodeFrom) == false)
		{
			// Note: Wrong Usage!
			//data = data.Where(current => current.Code >= Convert.ToInt32(countryCodeFrom));

			var countryCodeFromInt =
				Convert.ToInt32(value: countryCodeFrom);

			data = data.Where(current => current.Code >= countryCodeFromInt);
		}

		if (string.IsNullOrWhiteSpace(value: countryCodeTo) == false)
		{
			var countryCodeToInt =
				Convert.ToInt32(value: countryCodeTo);

			data = data.Where(current => current.Code <= countryCodeToInt);
		}

		data = data.OrderBy(current => current.Id);

		//data.Load();

		// يا

		// Note: Wrong Usage!
		//data = data.ToList();

		//var result = data.ToList();

		var result =
			await
			data.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	{
		//var search =
		//	"   Ali       Reza  Iran Carpet   Ali         ";

		// یه جوری
		//string[] keywords =
		//	{ "Ali", "Reza", "Iran", "Carpet" };

		// دستور ذیل کار نمی‌کند
		//var keywords =
		//	{ "Ali", "Reza", "Iran", "Carpet" };

		var keywords =
			new string[] { "Ali", "Reza", "Iran", "Carpet" };

		var data =
			applicationDbContext.Countries
			.AsQueryable();

		foreach (var keyword in keywords)
		{
			data = data.Where(current => current.Name.ToLower().Contains(keyword.ToLower()));
		}

		data = data.OrderBy(current => current.Code);

		var result =
			await
			data.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	{
		var search =
			"   Ali       Reza  Iran Carpet   Ali         ";

		search = search.Trim();
		//search = "Ali       Reza  Iran Carpet   Ali";

		while (search.Contains(value: "  "))
		{
			search = search.Replace
				(oldValue: "  ", newValue: " ");
		}
		//search = "Ali Reza Iran Carpet Ali";

		//var keywords =
		//	search.Split(separator: ' ');
		// keywords: {"Ali", "Reza", "Iran", "Carpet", "Ali"}

		var keywords =
			search.Split(separator: ' ').Distinct();
		// keywords: {"Ali", "Reza", "Iran", "Carpet"}

		var data =
			applicationDbContext.Countries
			.AsQueryable();

		foreach (var keyword in keywords)
		{
			data = data.Where(current => current.Name.ToLower().Contains(keyword.ToLower()));
		}

		data = data.OrderBy(current => current.Code);

		var result =
			await
			data.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	{
		var search =
			"   Ali       Reza  Iran Carpet   Ali         ";

		search = search.Trim();

		while (search.Contains(value: "  "))
		{
			search = search.Replace(oldValue: "  ", newValue: " ");
		}

		var keywords = search.Split(separator: ' ').Distinct();

		var data =
			applicationDbContext.Countries
			.AsQueryable();

		// Mr. Farshad Rabiei
		// دستور ذیل باید چک شود
		data = data.Where(current => keywords.Contains(current.Name));

		data = data.OrderBy(current => current.Code);

		var result =
			await
			data.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	// Learning Traditional LINQ
	// **************************************************
	// دستورات ذيل کاملا با هم معادل هستند
	// **************************************************
	{
		applicationDbContext.Countries
			.Load();

		// applicationDbContext.Countries.Local
	}

	{
		var data =
			applicationDbContext.Countries
			.ToList()
			;
	}

	{
		var data =
			await
			applicationDbContext.Countries
			.ToListAsync()
			;
	}

	{
		var data =
			from Country in applicationDbContext.Countries
			select Country
			;
	}
	// **************************************************
	// SELECT * FROM Countries
	// **************************************************

	// **************************************************
	// ها Country آرایه‌ای از
	// Select * From Countries WHERE ... ORDER BY ...
	// **************************************************
	{
		var data =
			from Country in applicationDbContext.Countries
			where Country.Name.ToLower().Contains("Iran".ToLower())
			orderby Country.Name
			select Country
			;

		foreach (var currentCountry in data)
		{
			Console.WriteLine(value: currentCountry.Name);
		}
	}
	// **************************************************

	// **************************************************
	// مدرن
	// **************************************************
	{
		var data =
			await
			applicationDbContext.Countries
			.Where(current => current.Name.ToLower().Contains("Iran".ToLower()))
			.OrderBy(current => current.Name)
			.ToListAsync()
			;

		foreach (var currentCountry in data)
		{
			Console.WriteLine(value: currentCountry.Name);
		}
	}
	// **************************************************

	// **************************************************
	// ها string آرایه‌ای از
	// Select Name From Countries WHERE ... ORDER BY ...
	// **************************************************
	{
		var data =
			from Country in applicationDbContext.Countries
			where Country.Name.ToLower().Contains("Iran".ToLower())
			orderby Country.Name
			select Country.Name
			;

		foreach (var currentCountryName in data)
		{
			Console.WriteLine(value: currentCountryName);
		}
	}
	// **************************************************

	// **************************************************
	// مدرن
	// **************************************************
	{
		var data =
			await
			applicationDbContext.Countries
			.Where(current => current.Name.ToLower().Contains("Iran".ToLower()))
			.OrderBy(current => current.Name)
			.Select(current => current.Name)
			.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	// Note: See Learning Anonymous Object File!
	// 
	// See: LearningAnonymousObject.cs
	// **************************************************

	// **************************************************
	{
		//var data =
		//	from Country in applicationDbContext.Countries
		//	select Country.Name
		//	;

		// دو دستور فوق و ذیل، بی‌نهایت با هم تفاوت دارند

		var data =
			from Country in applicationDbContext.Countries
			select new { Name = Country.Name }
			;

		foreach (var currentPartialCountry in data)
		{
			Console.WriteLine(value: currentPartialCountry.Name);
		}
	}
	// **************************************************

	// **************************************************
	{
		var data =
			from Country in applicationDbContext.Countries
			select new { Country.Name }
			;
	}
	// **************************************************

	// **************************************************
	// مدرن
	// **************************************************
	{
		var data =
			await
			applicationDbContext.Countries
			.Select(current => new { Name = current.Name })
			.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	// مدرن
	// **************************************************
	{
		var data =
			await
			applicationDbContext.Countries
			.Select(current => new { current.Name })
			.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	{
		var data =
			from Country in applicationDbContext.Countries
			select new { Googooli = Country.Name }
			;

		foreach (var currentPartialCountry in data)
		{
			Console.WriteLine(value: currentPartialCountry.Googooli);
		}
	}
	// **************************************************

	// **************************************************
	// مدرن
	// **************************************************
	{
		var data =
			await
			applicationDbContext.Countries
			.Select(current => new { Googooli = current.Name })
			.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	{
		var data =
			from Country in applicationDbContext.Countries
			select new { Size = Country.Population, Country.Name }
			;

		foreach (var currentPartialCountry in data)
		{
			Console.WriteLine(value: currentPartialCountry.Name);
		}
	}
	// **************************************************

	// **************************************************
	// مدرن
	// **************************************************
	{
		var data =
			await
			applicationDbContext.Countries
			.Select(current => new { Size = current.Population, current.Name })
			.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	{
		//var data =
		//	from Country in applicationDbContext.Countries
		//	select (new CountryViewModel1() { NewName = Country.Name })
		//	;

		var data =
			from Country in applicationDbContext.Countries
			select (new CountryViewModel1 { NewName = Country.Name })
			;

		foreach (var currentCountryViewModel in data)
		{
			currentCountryViewModel.NewName += "!";

			Console.WriteLine(value: currentCountryViewModel.NewName);
		}
	}
	// **************************************************

	// **************************************************
	// مدرن
	// **************************************************
	{
		//var data =
		//	await
		//	applicationDbContext.Countries
		//	.Select(current => new CountryViewModel1() { NewName = current.Name })
		//	.ToListAsync()
		//	;

		var data =
			await
			applicationDbContext.Countries
			.Select(current => new CountryViewModel1 { NewName = current.Name })
			.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	{
		var data =
			from Country in applicationDbContext.Countries
			select (new CountryViewModel2 { Name = Country.Name })
			;

		foreach (var currentCountryViewModel in data)
		{
			currentCountryViewModel.Name += "!";

			Console.WriteLine(value: currentCountryViewModel.Name);
		}
	}
	// **************************************************

	// **************************************************
	// مدرن
	// **************************************************
	{
		var data =
			await
			applicationDbContext.Countries
			.Select(current => (new CountryViewModel2 { Name = current.Name }))
			.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	// Note: Wrong Usage!
	// **************************************************
	//{
	//	var data =
	//		from Country in applicationDbContext.Countries
	//		select (new CountryViewModel2 { Country.Name })
	//		;
	//}
	// **************************************************

	// **************************************************
	// مدرن
	// Note: Wrong Usage!
	// **************************************************
	//{
	//	var data =
	//		await
	//		applicationDbContext.Countries
	//		.Select(current => (new CountryViewModel2 { current.Name }))
	//		.ToListAsync()
	//		;
	//}
	// **************************************************

	// **************************************************
	// Note: متاسفانه دستور ذیل کار نمی کند
	// **************************************************
	{
		var data =
			from Country in applicationDbContext.Countries
			where Country.Name.Contains("Iran")
			orderby Country.Name
			select new Country(Country.Name)
			;

		foreach (var currentCountry in data)
		{
			Console.WriteLine(value: currentCountry.Name);
		}
	}
	// **************************************************

	// **************************************************
	// مدرن
	// Note: Wrong Usage!
	// **************************************************
	{
		var data =
			await
			applicationDbContext.Countries
			.Select(current => (new Country(current.Name)))
			.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	// مدرن
	// **************************************************
	{
		var data1 =
			applicationDbContext.Countries
			.Select(current => new { current.Name })
			.ToList()
			.Select(current => new Country(current.Name))
			.ToList()
			;

		// OR

		var data2 =
			(await
			applicationDbContext.Countries
			.Select(current => new { current.Name })
			.ToListAsync())
			.Select(current => new Country(current.Name))
			.ToList()
			;

		// OR

		var data3 =
			await
			applicationDbContext.Countries
			.Select(current => new { current.Name })
			.ToListAsync()
			;

		var data4 =
			data3
			.Select(current => new Country(current.Name))
			.ToList()
			;
	}
	// **************************************************

	// **************************************************
	// مدرن
	// **************************************************
	{
		var data1 =
			applicationDbContext.Countries
			.Select(current => new { current.Id, current.Name })
			.ToList()
			.Select(current => new Country(name: current.Name)
			{
				Id = current.Id,
			})
			.ToList()
			;

		// OR

		var data2 =
			(await
			applicationDbContext.Countries
			.Select(current => new { current.Id, current.Name })
			.ToListAsync())
			.Select(current => new Country(name: current.Name)
			{
				Id = current.Id,
			})
			.ToList()
			;

		// OR

		var data3 =
			await
			applicationDbContext.Countries
			.Select(current => new { current.Id, current.Name })
			.ToListAsync()
			;

		var data4 =
			data3
			.Select(current => new Country(name: current.Name)
			{
				Id = current.Id,
			})
			.ToList()
			;
	}
	// **************************************************

	// **************************************************
	{
		var data =
			await
			applicationDbContext.Countries
			.Select(current => new
			{
				Id = current.Id,
				Name = current.Name,
				StateCount = current.States.Count,
			})
			.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	{
		var data =
			await
			applicationDbContext.Countries
			.Select(current => new
			{
				current.Id,
				current.Name,
				StateCount = current.States.Count,
			})
			.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	// در دو دستور ذیل، در صورتی که تحت شرایطی
	// تعداد استان‌ها، برای یک کشور صفر باشد، خطا ایجاد می‌شود
	// **************************************************
	{
		//var data =
		//	await
		//	applicationDbContext.Countries
		//	.Select(current => new
		//	{
		//		current.Id,
		//		current.Name,
		//		StateCount = current.States.Count,
		//		CityCount = current.States.Sum(state => state.Cities.Count),
		//	})
		//	.ToListAsync()
		//	;
	}

	{
		//var data =
		//	await
		//	applicationDbContext.Countries
		//	.Select(current => new
		//	{
		//		current.Id,
		//		current.Name,
		//		StateCount = current.States.Count,
		//		CityCount = current.States.Select(state => state.Cities.Count).Sum(),
		//	})
		//	.ToListAsync()
		//	;
	}

	{
		// Inline Condition یادآوری
		var number1 = 10;
		var number2 = 20;
		var max = (number1 > number2) ? number1 : number2;
		var min = (number1 < number2) ? number1 : number2;

		var data =
			await
			applicationDbContext.Countries
			.Select(current => new
			{
				current.Id,
				current.Name,

				StateCount = current.States.Count,

				//CityCount = current.States.Count == 0 ? 0 :
				//	current.States.Select(state => new { XCount = state.Cities.Count }).Sum(x => x.XCount)

				//CityCount = current.States.Count == 0 ? 0 :
				//	current.States.Select(state => state.Cities.Count).Sum()

				//CityCount = current.States == null || current.States.Count == 0 ? 0 :
				//	current.States.Select(state => new { XCount = state.Cities == null ? 0 : state.Cities.Count }).Sum(x => x.XCount)

				//CityCount = current.States == null || current.States.Count == 0 ? 0 :
				//	current.States.Select(state => new { XCount = state.Cities == null || state.Cities.Count == 0 ? 0 : state.Cities.Count }).Sum(x => x.XCount)

				//CityCount = current.States == null || current.States.Count == 0 ? 0 :
				//	current.States.Select(state => new { cityCount = state.Cities == null ? 0 : state.Cities.Count }).Sum(x => x.cityCount)
			})
			.ToListAsync()
			;
	}

	{
		//var data =
		//	await
		//	applicationDbContext.Countries
		//	.Select(current => new
		//	{
		//		current.Id,
		//		current.Name,

		//		StateCount =
		//			current.States.Count,

		//		CityCount = current.States.Select
		//			(state => state.Cities.Count).DefaultIfEmpty(0).Sum(),
		//	})
		//	.ToListAsync()
		//	;
	}

	{
		// **************************************************
		// AI Prompt:
		//
		// Suppose that in EF Core, we have three entities.
		// Countries and States and Cities and the relationship
		// between them are one to many. I want a linq query that
		// get all countries and for each country get country name
		// and state count and city count
		// **************************************************
		var data =
			await
			applicationDbContext.Countries
			.Select(current => new
			{
				current.Id,
				current.Name,

				StateCount = current.States.Count,
				CityCount = current.States.SelectMany(state => state.Cities).Count()
			})
			.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	// Learning Group By:
	//
	//	Id		Name		StateCount
	//
	//	1		Country 1	10
	//	2		Country 2	12
	//	3		Country 3	27
	//	4		Country 4	36
	//	...
	// بی‌معنی است Group By در مثال فوق
	//
	//	Id		Course		FullName		Grade
	//
	//	1		Math.		Full Name 1		15
	//	2		Math.		Full Name 2		16
	//	3		Phys.		Full Name 3		19
	//	4		Math.		Full Name 4		17
	//	5		Phys.		Full Name 5		11
	//	...
	//	تعداد نمرات ریاضی چند است؟
	//	بالاترین نمره ریاضی چند است؟
	//	کمترین نمره فیزیک چند است؟
	//	میانگین نمرات ریاضی چند است؟
	//
	//	Id		Year		Course		FullName		Grade
	//
	//	1		1402		Math.		Full Name 1		15
	//	2		1402		Math.		Full Name 2		16
	//	3		1402		Phys.		Full Name 3		19
	//	4		1402		Math.		Full Name 4		17
	//	5		1402		Phys.		Full Name 5		11
	//	6		1403		Math.		Full Name 1		13
	//	7		1403		Math.		Full Name 2		14
	//	8		1403		Phys.		Full Name 3		12
	//	9		1403		Math.		Full Name 4		19
	//	10		1403		Phys.		Full Name 5		16
	//	...
	//	تعداد نمرات ریاضی در سال ۱۴۰۳ چند است؟
	//	بالاترین نمره ریاضی در سال ۱۴۰۲ چند است؟
	//	کمترین نمره فیزیک در سال ۱۴۰۳ چند است؟
	//	میانگین نمرات ریاضی در سال ۱۴۰۳ چند است؟
	// **************************************************

	// **************************************************
	// در مثال ذیل، فرض بر آن است که عدد جمعیت، یک عدد
	// دقیق نبوده و به صورت حدودی تعریف شده است، مثلا
	// حدود ۱۰ میلیون، حدود ۲۰ میلیون و غیره
	// **************************************************
	{
		var data =
			await
			applicationDbContext.Countries
			.GroupBy(current => current.Population)
			.Select(other => new
			{
				Population = other.Key,

				Count = other.Count(),
			})
			.ToListAsync()
			;
	}

	{
		var data =
			await
			applicationDbContext.Countries
			.Where(current => current.Population >= 120_000_000) // Best Practice!
			.GroupBy(current => current.Population)
			.Select(other => new
			{
				Population = other.Key,

				Count = other.Count(),
			})
			.ToListAsync()
			;
	}

	// نکته: بهتر است که ابتدا محدود کنیم و بعد گروه‌بندی کنیم

	{
		var data =
			await
			applicationDbContext.Countries
			.GroupBy(current => current.Population)
			.Where(current => current.Key >= 120_000_000) // Bad Practice!
			.Select(other => new
			{
				Population = other.Key,

				Count = other.Count(),
			})
			.ToListAsync()
			;
	}

	{
		var data =
			await
			applicationDbContext.Countries
			.GroupBy(current => current.Population)
			.Select(other => new
			{
				Population = other.Key,

				Count = other.Count(),
			})
			.Where(other => other.Population >= 120_000_000) // Bad Practice!
			.ToListAsync()
			;
	}

	{
		var data =
			await
			applicationDbContext.Countries
			.Where(current => current.Name.Contains('I'))
			.GroupBy(current => current.Population)
			.Select(other => new
			{
				Population = other.Key,

				Count = other.Count(),
			})
			.ToListAsync()
			;
	}

	//{
	//	// Note: Wrong Usage!
	//	var data =
	//		await
	//		applicationDbContext.Countries
	//		.GroupBy(current => current.Population)
	//		.Where(current => current.Name.Contains('ا')) // Error!
	//		.Select(other => new
	//		{
	//			Population = other.Key,

	//			Count = other.Count(),
	//		})
	//		.Where(other => other.Name.Contains('ا')) // Error!
	//		.ToListAsync()
	//		;
	//}

	{
		var data =
			await
			applicationDbContext.Countries
			.GroupBy(current => current.Population)
			.Select(other => new
			{
				Population = other.Key,

				Count = other.Count(),
			})
			.Where(other => other.Count >= 5)
			.ToListAsync()
			;
	}

	{
		var data =
			await
			applicationDbContext.Countries
			.Where(current => current.Name.Contains('I'))
			.Where(current => current.Population >= 120_000_000) // Best Practice!
			.GroupBy(current => new { current.Population }) // Best Practice!
			.Select(other => new
			{
				Population = other.Key,

				Count = other.Count(),
			})
			.Where(other => other.Count >= 5) // Best Practice!
			.ToListAsync()
			;
	}

	{
		var data =
			await
			applicationDbContext.Countries
			.GroupBy(current => new { current.Population, current.HealthyRate })
			.Select(other => new
			{
				Population = other.Key.Population,
				HealthyRate = other.Key.HealthyRate,

				Count = other.Count(),
			})
			.ToListAsync()
			;
	}

	{
		var data =
			await
			applicationDbContext.Countries
			.GroupBy(current => new { current.Population, current.HealthyRate })
			.Select(other => new
			{
				other.Key.Population,
				other.Key.HealthyRate,

				Count = other.Count(),
			})
			.ToListAsync()
			;
	}

	{
		var data =
			await
			applicationDbContext.Countries
			.GroupBy(current => current.Population)
			.Select(other => new
			{
				Population = other.Key,

				Count = other.Count(),
				Max = other.Max(current => current.HealthyRate),
				Min = other.Min(current => current.HealthyRate),
				Sum = other.Sum(current => current.HealthyRate),
				Average = other.Average(current => current.HealthyRate),
			})
			.ToListAsync()
			;
	}
	// **************************************************

	// **************************************************
	// **************************************************
	// **************************************************
	// Not LINQ!
	// **************************************************
	// **************************************************
	// **************************************************

	// **************************************************
	// SQL Injection!
	// **************************************************
	{
		// Login
		var username = "dariush";
		var password = "1234512345";

		var query = $"SELECT * FROM Users WHERE Username = {username} && Password = {password}";
	}

	{
		// Hacker -> Login
		//var username = "dariush";
		//var password = "'Alaki' OR 1 = 1"; // Payload

		var query = $"SELECT * FROM Users WHERE Username = dariush && Password = 'alaki' OR 1 = 1";
	}
	// **************************************************

	// **************************************************
	// روش خطرناک
	// **************************************************
	{
		var countryName = "";

		var query =
			"DELETE FROM Countries WHERE CountryName = '" + countryName + "'";
	}

	{
		var countryName = "';DROP DATABASE;SELECT * FROM COUNTRIES WHERE NAME ='";

		var query =
			"DELETE FROM Countries WHERE CountryName = '" + countryName + "'";

		//"DELETE FROM Countries WHERE CountryName = '';DROP DATABASE;SELECT * FROM COUNTRIES WHERE NAME =''";
	}
	// **************************************************

	// **************************************************
	{
		var query = string.Empty;

		var affectedRows =
			applicationDbContext.Database.ExecuteSqlRaw(sql: query);
	}

	{
		var query = string.Empty;

		var affectedRows =
			await
			applicationDbContext.Database.ExecuteSqlRawAsync(sql: query);
	}
	// **************************************************

	// **************************************************
	{
		var query = string.Empty;
		var countryName = string.Empty;

		//Note: Sql Injection!!!
		query = $"DELETE FROM Countries WHERE CountryName = '{countryName}'";

		//Note: Sql Injection Free
		query = "DELETE FROM Countries WHERE CountryName = @CName";

		var sqlParameter = new SqlParameter(parameterName: "CName", value: countryName);

		var affectedRows =
			await
			applicationDbContext.Database.ExecuteSqlRawAsync(sql: query, sqlParameter);
	}
	// **************************************************

	// **************************************************
	{
		var countryName = string.Empty;
		var toCountryCode = string.Empty;
		var fromCountryCode = string.Empty;

		var query = "DELETE FROM Countries WHERE Id >= @FromCode AND Id <= @ToCode AND CountryName LIKE '%@CName%'";

		var dataParameter1 = ProviderFactory.GetDataParameter(parameterName: "CName", value: countryName);
		var dataParameter2 = ProviderFactory.GetDataParameter(parameterName: "ToCode", value: toCountryCode);
		var dataParameter3 = ProviderFactory.GetDataParameter(parameterName: "FromCode", value: fromCountryCode);

		// در دستور ذیل، ترتیب نوشتن پارامترها اهمیتی ندارد
		var affectedRows =
			await
			applicationDbContext.Database.ExecuteSqlRawAsync(sql: query,
			dataParameter1, dataParameter2, dataParameter3);
	}
	// **************************************************

	// **************************************************
	{
		var countryName = string.Empty;
		var toCountryCode = string.Empty;
		var fromCountryCode = string.Empty;

		var query = "DELETE FROM Countries WHERE Id >= @FromCode AND Id <= @ToCode AND CountryName LIKE '%@CName%'";

		var sqlParameter1 = new SqlParameter(parameterName: "CName", value: countryName);
		var sqlParameter2 = new SqlParameter(parameterName: "ToCode", value: toCountryCode);
		var sqlParameter3 = new SqlParameter(parameterName: "FromCode", value: fromCountryCode);

		var sqlParameter4 =
			new SqlParameter
			{
				ParameterName = "Output1",
				Direction = ParameterDirection.Output,
			};

		var sqlParameter5 =
			new SqlParameter
			{
				Value = "Some Value!",
				ParameterName = "InputOutput1",
				Direction = ParameterDirection.InputOutput,
			};

		// در دستور ذیل، ترتیب نوشتن پارامترها اهمیتی ندارد
		var affectedRows =
			await
			applicationDbContext.Database.ExecuteSqlRawAsync(sql: query,
			sqlParameter3, sqlParameter1, sqlParameter2, sqlParameter4, sqlParameter5);
	}
	// **************************************************

	// **************************************************
	// Migration فلسفه
	// **************************************************
}
catch (Exception ex)
{
	Console.WriteLine(value: ex.Message);
}
