using maui_test.ViewModels;
using System.Threading.Tasks;

namespace maui_test.Pages;

public partial class AllNewsPage : ContentPage
{
    private AllNewsVM viewModel;

    public AllNewsPage()
	{
        InitializeComponent();

        this.viewModel = new();
        this.BindingContext = this.viewModel;
    }

    private async void LoadMoreBtn_Clicked(object sender, EventArgs e) => await this.viewModel.LoadStorySummeries();
}