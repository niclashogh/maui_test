using maui_test.Models;
using maui_test.Repositories;
using maui_test.Services;
using System.Collections.ObjectModel;

namespace maui_test.ViewModels
{
    public class MyFiltersVM : NotifyPropertyChanged
    {
        private FilterProfileRepo repository = new();

        #region Variables & Properties
        private ObservableCollection<FilterProfileDTO> profiles = new();
        public ObservableCollection<FilterProfileDTO> Profiles
        {
            get { return this.profiles; }
            set
            {
                this.profiles = value;
                OnPropertyChanged(nameof(this.Profiles));
            }
        }

        private FilterProfileDTO selectedProfile = new();
        public FilterProfileDTO SelectedProfile
        {
            get { return this.selectedProfile; }
            set
            {
                this.selectedProfile = value;
                OnPropertyChanged(nameof(this.SelectedProfile));
            }
        }
        #endregion

        public MyFiltersVM()
        {
            _ = Load();
        }

        private async Task Load() => this.Profiles = await repository.Load();
    }
}
