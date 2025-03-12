using maui_test.ViewModels;
using System.Threading.Tasks;

namespace maui_test.Pages;

//[QueryProperty(nameof(filterId), "filterId")]
public partial class FilteredNewsPage : ContentPage
{
	//private string filterId { get; set; }

	private FilteredNewsVM viewModel;

	public FilteredNewsPage(FilteredNewsVM viewModel)
	{
		InitializeComponent();
		this.BindingContext = this.viewModel = viewModel;
	}

  //  protected override async void OnAppearing()
  //  {
  //      base.OnAppearing();

		//if (!string.IsNullOrEmpty(this.filterId))
		//{
		//	await this.viewModel.LoadFilteredStorySummeries(int.Parse(this.filterId));
  //      }
		//else await this.viewModel.LoadFilteredStorySummeries(1);
  //  }
}