namespace Dtat;

public static class Constant : object
//public static class Constants : object
{
	public static class MaxLength : object
	{
		public const int Name = 100;
		//public const int NAME = 100;

		//public int Name = 100; // کار نمی‌کند
		//public static int Name = 100; // کار نمی‌کند

		public const int Username = 20;
		public const int LastName = 30;
		public const int FullName = 50;
		public const int FirstName = 20;
	}

	public static class Range : object
	{
		public const int OrderingMinimum = 1;
		public const int OrderingMaximum = 100_000;
	}

	public static class RegularExpression : object
	{
		public const string PostalCode = "^\\d{10}$";
	}
}
