using maui_test.ViewModels;

namespace maui_test.Pages;

public partial class SettingsPage : ContentPage
{
	private SettingVM viewModel;

	public SettingsPage(SettingVM viewModel)
	{
		InitializeComponent();
		BindingContext = this.viewModel = viewModel;
	}

	private void AddFilterBtn_Clicked(object sender, EventArgs e)
	{
        _ = viewModel.AddFilterToList();
		this.ExcludeProperty_Entry.Focus();
    }

    private async void SaveBtn_Clicked(object sender, EventArgs e)
    {
		//await viewModel.SaveProfile();

		// Hardcoded Solution
		string filterId = "1";
		Shell.Current.Items.Add(new ShellContent
		{
			Title = "Sample Filter",
			ContentTemplate = new DataTemplate(typeof(FilteredNewsPage)),
			Route = $"FilteredNews?filterId={filterId}"
		});

		await Shell.Current.GoToAsync($"FilteredNews?filterId={filterId}");
    }
}