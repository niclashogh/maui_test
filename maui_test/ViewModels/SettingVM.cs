using maui_test.Repositories;
using maui_test.Services;
using System.Collections.ObjectModel;

namespace maui_test.ViewModels
{
    public class SettingVM : NotifyPropertyChanged
    {
        private FilterProfileRepo repository = new();

        #region Variables & Properties
        private string filterName = string.Empty;
        public string FilterName
        {
            get { return this.filterName; }
            set
            {
                this.filterName = value;
                OnPropertyChanged(nameof(this.FilterName));
            }
        }

        private ObservableCollection<string> excludeFilters = new();
        public ObservableCollection<string> ExcludeFilters
        {
            get { return this.excludeFilters; }
            set
            {
                this.excludeFilters = value;
                OnPropertyChanged(nameof(this.ExcludeFilters));
            }
        }

        private string excludeProperty = string.Empty;
        public string ExcludeProperty
        {
            get { return this.excludeProperty; }
            set
            {
                this.excludeProperty = value;
                OnPropertyChanged(nameof(this.ExcludeProperty));
            }
        }
        #endregion

        public SettingVM()
        {
            
        }

        internal async Task AddFilterToList()
        {
            if (!string.IsNullOrEmpty(this.ExcludeProperty))
            {
                this.ExcludeFilters.Add(this.ExcludeProperty);
                this.ExcludeProperty = string.Empty;
            }
        }

        internal async Task SaveProfile()
        {
            if (!string.IsNullOrEmpty(this.FilterName))
            {
                if (this.ExcludeFilters.Any())
                {
                    repository.Add(this.FilterName, this.ExcludeFilters);
                    this.ExcludeFilters = new();
                    this.FilterName = string.Empty;
                }
            }
        }
    }
}
