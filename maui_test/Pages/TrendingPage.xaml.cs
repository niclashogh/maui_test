using maui_test.ViewModels;

namespace maui_test.Pages;

public partial class TrendingPage : ContentPage
{
	private TrendingVM viewModel;

	public TrendingPage()
	{
		InitializeComponent();

		this.viewModel = new();
		this.BindingContext = this.viewModel;
	}

    private async void LoadMoreBtn_Clicked(object sender, EventArgs e) => _ = this.viewModel.LoadStorySummeries();
}