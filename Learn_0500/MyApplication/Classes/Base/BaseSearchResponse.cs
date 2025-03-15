namespace MyApplication.Classes.Base;

public class BaseSearchResponse<T> : object
{
	public BaseSearchResponse() : base()
	{
	}

	public int PageIndex { get; set; }
	public int PageCount { get; set; }
	public int RecordCount { get; set; }
	public IList<T> List { get; set; } = [];
}
