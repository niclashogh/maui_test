using maui_test.Repositories;
using maui_test.Services;
using System.Collections.ObjectModel;

namespace maui_test.ViewModels
{
    public class SettingVM : NotifyPropertyChanged
    {
        private FilterProfileRepo Repository = new();

        #region Variables & Properties
        public string FilterName { get; set; }

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

        internal async Task SaveProfile() => Repository.Add(this.FilterName, this.ExcludeFilters);
    }
}
