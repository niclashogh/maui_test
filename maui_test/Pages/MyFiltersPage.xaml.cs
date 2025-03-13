using maui_test.ViewModels;

namespace maui_test.Pages;

public partial class MyFiltersPage : ContentPage
{
	private MyFiltersVM viewModel;

	public MyFiltersPage()
	{
		InitializeComponent();
		
		this.viewModel = new();
		this.BindingContext = this.viewModel;
	}

    private async void NewFilterBtn_Clicked(object sender, EventArgs e) => await Shell.Current.GoToAsync(nameof(SettingsPage));

    private async void Profile_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (this.viewModel.Profiles.Any() && this.viewModel.Profiles.Contains(this.viewModel.SelectedProfile))
		{
            await Shell.Current.GoToAsync($"{nameof(FilteredNewsPage)}?filterId={this.viewModel.SelectedProfile.Id}");
        }
	}
}