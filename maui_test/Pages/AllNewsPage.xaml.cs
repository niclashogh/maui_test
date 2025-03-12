using maui_test.ViewModels;
using System.Threading.Tasks;

namespace maui_test.Pages;

public partial class AllNewsPage : ContentPage
{
    private AllNewsVM viewModel;

    public AllNewsPage(AllNewsVM viewModel)
	{
        InitializeComponent();
        this.BindingContext = this.viewModel = viewModel;
    }

    private async void NewFilterBtn_Clicked(object sender, EventArgs e) => await Shell.Current.GoToAsync(nameof(SettingsPage));

    private async void LoadMoreBtn_Clicked(object sender, EventArgs e) => await this.viewModel.LoadStorySummeries();
}