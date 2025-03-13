using maui_test.ViewModels;

namespace maui_test.Pages;

public partial class SettingsPage : ContentPage
{
	private SettingVM viewModel;

    public SettingsPage()
	{
		InitializeComponent();

		this.viewModel = new();
		this.BindingContext = this.viewModel;
	}

	private void AddFilterBtn_Clicked(object sender, EventArgs e)
	{
        _ = viewModel.AddFilterToList();
		this.ExcludeProperty_Entry.Focus();
    }

    private async void SaveBtn_Clicked(object sender, EventArgs e)
    {
		await viewModel.SaveProfile();
		this.NameProperty_Entry.Focus();
    }
}