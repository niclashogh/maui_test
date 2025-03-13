using maui_test.ViewModels;

namespace maui_test.Pages;

[QueryProperty(nameof(FilterId), "filterId")]
public partial class FilteredNewsPage : ContentPage
{
	public string FilterId { get; set; }
	private FilteredNewsVM viewModel;

	public FilteredNewsPage()
	{
		InitializeComponent();

		this.viewModel = new();
        this.BindingContext = this.viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

		if (!string.IsNullOrWhiteSpace(FilterId))
		{
            this.viewModel.CurrentFilterId = int.Parse(this.FilterId!);
            await this.viewModel.LoadFilteredStorySummeries();
		}
    }

    private async void LoadMoreBtn_Clicked(object sender, EventArgs e) => await this.viewModel.LoadFilteredStorySummeries();
}