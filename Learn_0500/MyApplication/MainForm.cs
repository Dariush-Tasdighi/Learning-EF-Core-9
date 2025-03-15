using Application.Persistence;
using MyApplication.Classes.Countries;

namespace MyApplication;

public partial class MainForm : Form
{
	public MainForm()
	{
		InitializeComponent();
	}

	private int PageCount { get; set; }
	private int PageIndex { get; set; }

	private void MainForm_Load(object sender, EventArgs e)
	{
		pageSizeComboBox.SelectedIndex = 0;

		PageIndex = 0;
		Search();
	}

	private void PageSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		PageIndex = 0;
		Search();
	}

	private void SearchButton_Click(object sender, EventArgs e)
	{
		PageIndex = 0;
		Search();
	}

	public async void Search()
	{
		var pageSize =			Convert.ToInt32(pageSizeComboBox.SelectedItem);

		var request =
			new CountriesSearchRequest
			{
				PageSize = pageSize,
				PageIndex = PageIndex,
				Name = nameTextBox.Text,
				CodeTo = codeToTextBox.Text,
				CodeFrom = codeFromTextBox.Text,
			};

		using var applicationDbContext = new ApplicationDbContext();

		var searchService =
			new CountriesSearchService(applicationDbContext: applicationDbContext);

		var response = await searchService.SearchAsync(request: request);

		PageCount = response.PageCount;

		myDataGridView.DataSource = response.List;

		pageCountLabel.Text = response.PageCount.ToString();
		recordCountLabel.Text = response.RecordCount.ToString();
		pageIndexLabel.Text = (response.PageIndex + 1).ToString();
	}

	private void GoToFirstPageButton_Click(object sender, EventArgs e)
	{
		PageIndex = 0;
		Search();
	}

	private void GoToPreviousPageButton_Click(object sender, EventArgs e)
	{
		if (PageIndex > 0)
		{
			PageIndex--;
		}

		Search();
	}

	private void GoToNextPageButton_Click(object sender, EventArgs e)
	{
		if (PageIndex <= PageCount - 2)
		{
			PageIndex++;
		}

		Search();
	}

	private void GoToLastPageButton_Click(object sender, EventArgs e)
	{
		PageIndex = PageCount - 1;
		Search();
	}
}
