using maui_test.ViewModels;

namespace maui_test.Pages;

public partial class TrendingPage : ContentPage
{
	private TrendingVM viewModel;

	public TrendingPage(TrendingVM viewModel)
	{
		InitializeComponent();
		this.BindingContext = this.viewModel = viewModel;
	}
}