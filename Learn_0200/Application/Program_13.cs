//using Dtat;
//using System;
//using Microsoft.EntityFrameworkCore;
//using System.Text.RegularExpressions;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//{
//	try
//	{
//		using var applicationDbContext = new ApplicationDbContext();
//	}
//	catch (Exception ex)
//	{
//		Console.WriteLine(value: ex.Message);
//	}
//}

//// **************************************************
//// *** Category 01 **********************************
//// **************************************************
//public class Category01 : object
//{
//	public Category01() : base()
//	{
//	}

//	/// <summary>
//	/// Best Practice
//	/// </summary>
//	public int Id { get; set; }
//	public string? Name { get; set; }
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 02 **********************************
//// **************************************************
//public class Category02 : object
//{
//	public Category02() : base()
//	{
//	}

//	public int ID { get; set; }
//	public string? Name { get; set; }
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 03 **********************************
//// **************************************************
//public class Category03 : object
//{
//	public Category03() : base()
//	{
//	}

//	public int Category03Id { get; set; }
//	public string? Name { get; set; }
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 04 **********************************
//// **************************************************
//public class Category04 : object
//{
//	public Category04() : base()
//	{
//	}

//	public int Category04ID { get; set; }
//	public string? Name { get; set; }
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 05 **********************************
//// **************************************************
//public class Category05 : object
//{
//	public Category05() : base()
//	{
//	}

//	/// <summary>
//	/// خطا می‌دهد
//	/// </summary>
//	public int Code { get; set; }
//	public string? Name { get; set; }
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 06 **********************************
//// **************************************************
//public class Category06 : object
//{
//	public Category06() : base()
//	{
//	}

//	/// <summary>
//	/// این ویژگی فقط مربوط به بانک‌اطلاعاتی می‌باشد
//	/// 
//	/// داریم Key چون در اسکیوال‌سرور، کلمه
//	/// می‌شود [Key] نام این فیلد، تبدیل به
//	/// </summary>
//	//[Key]
//	//public int Key { get; set; }
//	[Key]
//	public int Code { get; set; }
//	public string? Name { get; set; }
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 07 **********************************
//// **************************************************
//public class Category07 : object
//{
//	public Category07() : base()
//	{
//	}

//	[Key]
//	public int Id { get; set; }

//	/// <summary>
//	/// این ویژگی هم مربوط به برنامه
//	/// می‌شود و هم مربوط به بانک اطلاعاتی می‌شود
//	/// </summary>
//	//[MaxLength(length: 100)]
//	[MaxLength(length: Constant.MaxLength.Name)]
//	public string? Name { get; set; }
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 08 **********************************
//// **************************************************
//public class Category08 : object
//{
//	public Category08() : base()
//	{
//	}

//	[Key]
//	public int Id { get; set; }

//	/// <summary>
//	/// این ویژگی فقط مربوط به برنامه می‌شود
//	/// </summary>
//	[MinLength(length: 3)]

//	/// <summary>
//	/// این ویژگی هم مربوط به برنامه
//	/// می‌شود و هم مربوط به بانک اطلاعاتی می‌شود
//	/// </summary>
//	[MaxLength(length: 100)]
//	public string? Name { get; set; }
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 09 **********************************
//// **************************************************
//public class Category09 : object
//{
//	public Category09() : base()
//	{
//	}

//	[Key]
//	public int Id { get; set; }

//	/// <summary>
//	/// این ویژگی هم مربوط به برنامه
//	/// می‌شود و هم مربوط به بانک اطلاعاتی می‌شود
//	/// </summary>
//	[StringLength(maximumLength: 100)]
//	public string? Name { get; set; }
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 10 **********************************
//// **************************************************
//public class Category10 : object
//{
//	public Category10() : base()
//	{
//	}

//	[Key]
//	public int Id { get; set; }

//	/// <summary>
//	/// بخشی از این ویژگی، هم مربوط به برنامه
//	/// می‌شود و هم مربوط به بانک اطلاعاتی می‌شود
//	/// 
//	/// ولی بخشی از این ویژگی، صرفا مربوط به برنامه می‌شود
//	/// </summary>
//	[StringLength(maximumLength: 100, MinimumLength = 3)]
//	public string? Name { get; set; }
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 11 **********************************
//// **************************************************
//public class Category11 : object
//{
//	public Category11() : base()
//	{
//	}

//	[Key]
//	public int Id { get; set; }

//	/// <summary>
//	/// این ویژگی هم مربوط به برنامه
//	/// می‌شود و هم مربوط به بانک اطلاعاتی می‌شود
//	/// </summary>
//	[Required]
//	[StringLength(maximumLength: 100, MinimumLength = 3)]
//	public string? Name { get; set; }
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 12 **********************************
//// **************************************************
//public class Category12 : object
//{
//	public Category12() : base()
//	{
//	}

//	[Key]
//	public int Id { get; set; }

//	/// <summary>
//	/// بخشی از این ویژگی، هم مربوط به برنامه
//	/// می‌شود و هم مربوط به بانک اطلاعاتی می‌شود
//	/// 
//	/// ولی بخشی از این ویژگی، صرفا مربوط به برنامه می‌شود
//	/// </summary>
//	[Required(AllowEmptyStrings = false)]
//	[StringLength(maximumLength: 100, MinimumLength = 3)]
//	public string? Name { get; set; }
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 13 **********************************
//// **************************************************
//// طراحی هوشمندانه که در نسخه قبل امکان‌پذیر نبود
//// **************************************************
//public class Category13 : object
//{
//	/// <summary>
//	/// را می‌نوشتیم Default Constructor در نسخه قدیم باید حتما
//	/// </summary>
//	//public Category13() : base()
//	//{
//	//}

//	public Category13(string name) : base()
//	{
//		Name = name;
//	}

//	/// <summary>
//	/// Note: private set;
//	/// </summary>
//	[Key]
//	public int Id { get; init; }

//	/// <summary>
//	/// Note: string? -> string
//	/// </summary>
//	[Required(AllowEmptyStrings = false)]
//	[StringLength(maximumLength: 100, MinimumLength = 3)]
//	public string Name { get; set; }
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 14 **********************************
//// **************************************************
//// طراحی هوشمندانه که در نسخه قبل امکان‌پذیر نبود
//// Primary Constructor
//// **************************************************
//public class Category14(string name) : object
//{
//	//public Category14(string name) : base()
//	//{
//	//	Name = name;
//	//}

//	[Key]
//	public int Id { get; init; }

//	[Required(AllowEmptyStrings = false)]
//	[StringLength(maximumLength: 100, MinimumLength = 3)]
//	public string Name { get; set; } = name;
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 15 **********************************
//// **************************************************
//public class Category15(string name) : object
//{
//	[Key]
//	public int Id { get; init; }

//	[Required(AllowEmptyStrings = false)]
//	[StringLength(maximumLength: 100, MinimumLength = 3)]
//	public string Name { get; set; } = name;

//	/// <summary>
//	/// این ویژگی، فقط مربوط به برنامه می‌شود
//	/// 
//	/// ها به شرطی عمل می‌کنند Validator
//	/// نباشد null که فیلد مربوط به آن‌ها
//	/// </summary>
//	[Range(minimum: 1, maximum: 100_000)]
//	//[Range(minimum: 1, maximum: 100000)]
//	public int Ordering { get; set; } = 10_000;
//	//public int Ordering { get; set; } = 10000;
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 16 **********************************
//// **************************************************
//public class Category16(string name) : object
//{
//	[Key]
//	public int Id { get; init; }

//	[Required(AllowEmptyStrings = false)]
//	[StringLength(maximumLength: 100, MinimumLength = 3)]
//	public string Name { get; set; } = name;

//	[MaxLength(length: 10)]

//	/// <summary>
//	/// این ویژگی فقط مربوط به برنامه می‌شود
//	/// </summary>
//	//[RegularExpression(pattern: "^\\d$")]
//	//[RegularExpression(pattern: "^\\d{10}$")]
//	//[RegularExpression(pattern: "^\\d{10,12}$")]
//	[RegularExpression(pattern: Constant.RegularExpression.PostalCode)]
//	public string? PostalCode { get; set; }

//	public bool ValidatePostalCode()
//	{
//		if (string.IsNullOrWhiteSpace(value: PostalCode))
//		{
//			return true;
//		}

//		//var result =
//		//	Regex.IsMatch
//		//	(input: PostalCode, pattern: "^\\d{10}$");

//		var result =
//			Regex.IsMatch
//			(input: PostalCode, pattern: Constant.RegularExpression.PostalCode);

//		return result;
//	}
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 17 **********************************
//// **************************************************
//// In Classic EF: Automatically: Country -> Countries Based on Model Name
//// In EF Core: Automatically: Country -> Countries Based on DbSet Property Name
//// **************************************************
//// System.ComponentModel.DataAnnotations.Schema.Table
//// System.ComponentModel.DataAnnotations.Schema.Column
//// **************************************************
//[Table(name: "CategoriesTable")]
//public class Category17(string name) : object
//{
//	[Key]
//	[Column(name: "CategoryId")]
//	public int Id { get; init; }

//	[Column(name: "CategoryName")]
//	[Required(AllowEmptyStrings = false)]
//	[StringLength(maximumLength: 100, MinimumLength = 3)]
//	public string Name { get; set; } = name;
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 18 **********************************
//// **************************************************
//[Table(name: "TABLE_001")]
//public class Category18(string name) : object
//{
//	[Key]
//	[Column(name: "FIELD_001")]
//	public int Id { get; init; }

//	[Column(name: "FIELD_002")]
//	[Required(AllowEmptyStrings = false)]
//	[StringLength(maximumLength: 100, MinimumLength = 3)]
//	public string Name { get; set; } = name;
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 19 **********************************
//// **************************************************
//// Multiple Schema does not work in Sqlite!
//// Schema does not work in SQL Server Compact Edition at all!
//// **************************************************
//[Table(name: "Categories", Schema = "Cms")]
////[Table(name: "Categories", Schema = "CMS")]
//public class Category19(string name) : object
//{
//	[Key]
//	public int Id { get; init; }

//	[Required(AllowEmptyStrings = false)]
//	[StringLength(maximumLength: 100, MinimumLength = 3)]
//	public string Name { get; set; } = name;
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 20 **********************************
//// **************************************************
//// متاسفانه هیچ‌یک از سه دستور ذیل کار نمی‌کند
//// **************************************************
////[Table(Schema = "Cms")]
////[Table(name: "", Schema = "Cms")]
////[Table(name: null, Schema = "Cms")]
////[Table(name: "Categories", Schema = "Cms")]
//[Table(name: nameof(ApplicationDbContext.Categories_20), Schema = "Cms")]
////[Table(name: nameof(ApplicationDbContext.Categories_20), Schema = Constant.Schema.Cms)]
//public class Category20(string name) : object
//{
//	[Key]
//	public int Id { get; init; }

//	[Required(AllowEmptyStrings = false)]
//	[StringLength(maximumLength: 100, MinimumLength = 3)]
//	public string Name { get; set; } = name;
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 21 **********************************
//// **************************************************
//// Id:
//// 
////		In C#		In SQL Server Database
//// 
////		int			int
////		long		bigint
////		Guid		uniqueidentifier
//// **************************************************
//public class Category21(string name) : object
//{
//	[Key]
//	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
//	//[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
//	public int Id { get; init; }
//	//public int Id { get; set; }

//	[Required(AllowEmptyStrings = false)]
//	[StringLength(maximumLength: 100, MinimumLength = 3)]
//	public string Name { get; set; } = name;
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 22 **********************************
//// **************************************************
//public class Category22(string name) : object
//{
//	// **********
//	/// <summary>
//	/// بانک اطلاعاتی مقدار آن را
//	/// تولید می‌کند و به سمت برنامه ارسال می‌کند
//	/// </summary>
//	[Key]
//	public Guid Id { get; init; }

//	[Required(AllowEmptyStrings = false)]
//	[StringLength(maximumLength: 100, MinimumLength = 3)]
//	public string Name { get; set; } = name;
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 23 **********************************
//// **************************************************
//public class Category23(string name) : object
//{
//	[Key]
//	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
//	//public Guid Id { get; init; } = new Guid(); // این دستور غلط است
//	public Guid Id { get; init; } = Guid.NewGuid();

//	[Required(AllowEmptyStrings = false)]
//	[StringLength(maximumLength: 100, MinimumLength = 3)]
//	public string Name { get; set; } = name;
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 24 **********************************
//// **************************************************
//public class Category24(string name) : object
//{
//	[Key]
//	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
//	public Guid Id { get; init; } = Guid.NewGuid();

//	/// <summary>
//	/// Note: init;
//	/// </summary>
//	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
//	public int Code { get; init; }
//	//public long Code { get; init; }

//	[Required(AllowEmptyStrings = false)]
//	[StringLength(maximumLength: 100, MinimumLength = 3)]
//	public string Name { get; set; } = name;
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 25 **********************************
//// **************************************************
//public class Category25(string name) : object
//{
//	[Key]
//	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
//	public Guid Id { get; init; } = Guid.NewGuid();

//	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
//	public int Code1 { get; init; }

//	/// <summary>
//	/// Error!
//	/// only one column per table can be configured as 'Identity'.
//	///
//	/// تعریف نمایید Sequence بعدا یاد خواهید گرفت که چیزی به نام
//	/// </summary>
//	//[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
//	//public int Code2 { get; init; }

//	[Required(AllowEmptyStrings = false)]
//	[StringLength(maximumLength: 100, MinimumLength = 3)]
//	public string Name { get; set; } = name;
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 26 **********************************
//// **************************************************
//public class Category26(string name) : object
//{
//	[Key]
//	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
//	public Guid Id { get; init; }

//	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
//	public int Code { get; init; }

//	/// <summary>
//	/// New: required
//	/// </summary>
//	[Required(AllowEmptyStrings = false)]
//	[StringLength(maximumLength: 100, MinimumLength = 3)]
//	public string Name { get; set; } = name;

//	public string DisplayName
//	{
//		get
//		{
//			var result =
//				$"{Code} - {Name}";

//			return result;
//		}
//	}

//	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
//	//public DateTime InsertDateTime { get; init; }
//	//public DateTimeOffset InsertDateTime { get; init; } = DateTimeOffset.Now;
//	public DateTimeOffset InsertDateTime { get; init; } = Dtat.DateTime.Now;

//	/// <summary>
//	/// Set ای که Property
//	/// نداشته باشد تبدیل به فیلد در بانک اطلاعاتی نمی‌شود
//	/// </summary>
//	public PersianDate InsertPersianDate
//	{
//		get
//		{
//			var result =
//				InsertDateTime.ToPersianDate();

//			return result;
//		}
//	}

//	public PersianDateTime InsertPersianDateTime
//	{
//		get
//		{
//			var result =
//				InsertDateTime.ToPersianDateTime();

//			return result;
//		}
//	}
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 27 **********************************
//// **************************************************
//public class Category27(string name) : object
//{
//	[Key]
//	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
//	public Guid Id { get; init; } = Guid.NewGuid();

//	[Required(AllowEmptyStrings = false)]
//	[StringLength(maximumLength: 100)]
//	public string Name { get; set; } = name;

//	/// <summary>
//	/// تبدیل به فیلد بانک اطلاعاتی می‌شود
//	/// </summary>
//	public int MyProperty10 { get; init; }

//	/// <summary>
//	/// تبدیل به فیلد بانک اطلاعاتی می‌شود
//	/// </summary>
//	public int MyProperty11 { get; set; }

//	/// <summary>
//	/// تبدیل به فیلد بانک اطلاعاتی می‌شود
//	/// </summary>
//	public int MyProperty12 { get; private set; }

//	/// <summary>
//	/// تبدیل به فیلد بانک اطلاعاتی می‌شود
//	/// </summary>
//	public int MyProperty13 { get; protected set; }

//	/// <summary>
//	/// تبدیل به فیلد بانک اطلاعاتی می‌شود
//	/// </summary>
//	public int MyProperty14 { get; internal set; }

//	/// <summary>
//	/// تبدیل به فیلد بانک اطلاعاتی می‌شود
//	/// </summary>
//	public int MyProperty15 { get; private protected set; }

//	/// <summary>
//	/// تبدیل به فیلد بانک اطلاعاتی می‌شود
//	/// </summary>
//	public int MyProperty16 { get; protected internal set; }



//	/// <summary>
//	/// !تبدیل به فیلد بانک اطلاعاتی نمی‌شود
//	/// </summary>
//	public int MyProperty21 { get; }



//	/// <summary>
//	/// !تبدیل به فیلد بانک اطلاعاتی نمی‌شود
//	/// </summary>
//	[NotMapped]
//	public int MyProperty22 { get; set; }



//	/// <summary>
//	/// !تبدیل به فیلد بانک اطلاعاتی نمی‌شود
//	/// </summary>
//	private int MyProperty23 { get; set; }

//	/// <summary>
//	/// !تبدیل به فیلد بانک اطلاعاتی نمی‌شود
//	/// </summary>
//	protected int MyProperty24 { get; set; }

//	/// <summary>
//	/// !تبدیل به فیلد بانک اطلاعاتی نمی‌شود
//	/// </summary>
//	internal int MyProperty25 { get; set; }

//	/// <summary>
//	/// !تبدیل به فیلد بانک اطلاعاتی نمی‌شود
//	/// </summary>
//	private protected int MyProperty26 { get; set; }

//	/// <summary>
//	/// !تبدیل به فیلد بانک اطلاعاتی نمی‌شود
//	/// </summary>
//	protected internal int MyProperty27 { get; set; }
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** Category 28 **********************************
//// **************************************************
//public class Category28(string name) : object
//{
//	[Key]
//	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
//	public Guid Id { get; init; } = Guid.NewGuid();

//	[StringLength(maximumLength: 100)]
//	[Required(AllowEmptyStrings = false)]
//	public string Name { get; set; } = name;

//	[StringLength(maximumLength: 100)]

//	/// <summary>
//	/// Order is Zero based!
//	/// Note: Using TypeName is not recommended!
//	/// 
//	/// Example: nVarChar(Max) -> nVarChar(100) -> Char(100)
//	/// </summary>
//	[Column(Order = 0, TypeName = "Char")]
//	public string? Description { get; set; }
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** UserInGroup 01 *******************************
//// **************************************************
//// ضمن آن‌که تفکر ذیل را اصلا
//// توصیه نمی‌کنم، باید دقت داشته باشیم که
//// کار نمی‌کند EF Core کار می‌کند، ولی در EF روش ذیل، در
//// 
//// Error:
//// The entity type 'UserInGroup01' has multiple properties with the [Key] attribute.
//// Composite primary keys can only be set using 'HasKey' in 'OnModelCreating'.
//// **************************************************
//public class UserInGroup01(Guid userId, Guid groupId) : object
//{
//	[Key]
//	[Column(Order = 0)]
//	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
//	public Guid UserId { get; init; } = userId;

//	[Key]
//	[Column(Order = 1)]
//	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
//	public Guid GroupId { get; init; } = groupId;

//	public bool IsActive { get; set; }
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** UserInGroup 02 *******************************
//// **************************************************
//public class UserInGroup02(Guid userId, Guid groupId) : object
//{
//	[Key]
//	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
//	public Guid Id { get; init; } = Guid.NewGuid();

//	/// <summary>
//	/// Foreign Key
//	/// 
//	/// دستور ذیل، ناقص است! انشاءالله در قسمت روابط
//	/// یک به چند و چند به چند به این موضوع به طور کامل می‌پردازیم
//	/// </summary>
//	public Guid UserId { get; init; } = userId;

//	/// <summary>
//	/// Foreign Key
//	/// 
//	/// دستور ذیل، ناقص است! انشاءالله در قسمت روابط
//	/// یک به چند و چند به چند به این موضوع به طور کامل می‌پردازیم
//	/// </summary>
//	public Guid GroupId { get; init; } = groupId;
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** User 01 **************************************
//// **************************************************
//public class User01(string username) : object
//{
//	[Key]
//	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
//	public Guid Id { get; init; } = Guid.NewGuid();

//	[MaxLength(length: 20)]
//	[Required(AllowEmptyStrings = false)]

//	// کار نمی‌کند EF Core کار می‌کند و در EF دستور ذیل فقط در
//	//[Index(IsUnique = true)]
//	public string Username { get; set; } = username;
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** User 02 **************************************
//// **************************************************
///// نکته بسیار مهم
///// 
///// تعریف کرد Index نمی‌توان برای فیلدهایی از جنس ذیل
///// 
///// Text
///// nText
///// VarChar(Max)
///// nVarChar(Max)
//// **************************************************
////[Index("Username", IsUnique = true)]
////[Index("Uesrnme", IsUnique = true)] -> اگر سوتی بدهیم

//// Index Name: IX_Users02_Username
//[Index(nameof(Username), IsUnique = true)]

//// Index Name: Googooli
////[Index(nameof(Username), IsUnique = true, Name = "Googooli")]

//// Note: Obsolete
////[Index(propertyNames: nameof(Username), IsUnique = true, Name = "Googooli")]

//// مدل نوشتن ذیل خطا می‌دهد
////[Index(propertyNames: nameof(FirstName), nameof(LastName), IsUnique = false)]

//[Index(nameof(FirstName), nameof(LastName), IsUnique = false)]

//// خطا می‌دهد EF دستور ذیل در
//// اتفاق جالبی رخ می‌دهد EF Core ولی در
//// nvarchar(450)
//[Index(nameof(Description))]
//public class User02(string username) : object
//{
//	[Key]
//	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
//	public Guid Id { get; init; } = Guid.NewGuid();

//	[MaxLength(length: 20)]
//	[Required(AllowEmptyStrings = false)]
//	public string Username { get; set; } = username;

//	[MaxLength(length: 30)]
//	public string? LastName { get; set; }

//	[MaxLength(length: 20)]
//	public string? FirstName { get; set; }

//	public string? Description { get; set; }
//}
//// **************************************************
//// **************************************************
//// **************************************************

//// **************************************************
//// *** User 03 **************************************
//// **************************************************
//[Index(nameof(Username), IsUnique = true)]
//[Index(nameof(FirstName), nameof(LastName), IsUnique = false)]
//public class User03(string username) : object
//{
//	[Key]
//	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
//	public Guid Id { get; init; } = Guid.NewGuid();

//	[Range(minimum: 1, maximum: 100_000)]
//	public int Ordering { get; set; } = 10_000;

//	[MaxLength(length: 20)]
//	[Required(AllowEmptyStrings = false)]
//	public string Username { get; set; } = username;

//	[MaxLength(length: 30)]
//	public string? LastName { get; set; }

//	[MaxLength(length: 20)]
//	public string? FirstName { get; set; }
//}
//// **************************************************
//// **************************************************
//// **************************************************

//public class ApplicationDbContext : DbContext
//{
//	public ApplicationDbContext() : base()
//	{
//		Database.EnsureCreated();
//	}

//	public DbSet<Category01> Categories_01 { get; set; }
//	public DbSet<Category02> Categories_02 { get; set; }
//	public DbSet<Category03> Categories_03 { get; set; }
//	public DbSet<Category04> Categories_04 { get; set; }

//	// Error!
//	//public DbSet<Category05> Categories_05 { get; set; }

//	public DbSet<Category06> Categories_06 { get; set; }
//	public DbSet<Category07> Categories_07 { get; set; }
//	public DbSet<Category08> Categories_08 { get; set; }
//	public DbSet<Category09> Categories_09 { get; set; }
//	public DbSet<Category10> Categories_10 { get; set; }
//	public DbSet<Category11> Categories_11 { get; set; }
//	public DbSet<Category12> Categories_12 { get; set; }
//	public DbSet<Category13> Categories_13 { get; set; }
//	public DbSet<Category14> Categories_14 { get; set; }
//	public DbSet<Category15> Categories_15 { get; set; }
//	public DbSet<Category16> Categories_16 { get; set; }
//	public DbSet<Category17> Categories_17 { get; set; }
//	public DbSet<Category18> Categories_18 { get; set; }
//	public DbSet<Category19> Categories_19 { get; set; }
//	public DbSet<Category20> Categories_20 { get; set; }
//	public DbSet<Category21> Categories_21 { get; set; }
//	public DbSet<Category22> Categories_22 { get; set; }
//	public DbSet<Category23> Categories_23 { get; set; }
//	public DbSet<Category24> Categories_24 { get; set; }
//	public DbSet<Category25> Categories_25 { get; set; }
//	public DbSet<Category26> Categories_26 { get; set; }
//	public DbSet<Category27> Categories_27 { get; set; }
//	public DbSet<Category28> Categories_28 { get; set; }

//	// Error!
//	//public DbSet<UserInGroup01> UsersInGroups_01 { get; set; }
//	public DbSet<UserInGroup02> UsersInGroups_02 { get; set; }

//	public DbSet<User01> Users_01 { get; set; }
//	public DbSet<User02> Users_02 { get; set; }
//	public DbSet<User03> Users_03 { get; set; }

//	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//	{
//		var connectionString =
//			"Server=.;User ID=sa;Password=1234512345;Database=LEARNING_EF_CORE_0200;MultipleActiveResultSets=true;TrustServerCertificate=True;";

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
