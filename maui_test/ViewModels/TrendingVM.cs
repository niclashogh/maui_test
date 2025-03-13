using maui_test.Models;
using maui_test.Services;
using System.Collections.ObjectModel;

namespace maui_test.ViewModels
{
    public class TrendingVM : NotifyPropertyChanged
    {
        private DRNewsAPI api = new();

        #region Variables & Properties
        private ObservableCollection<DRNewsStory> stories = new();
        public ObservableCollection<DRNewsStory> Stories
        {
            get { return this.stories; }
            private set
            {
                this.stories = value;
                OnPropertyChanged(nameof(this.Stories));
            }
        }
        #endregion

        public TrendingVM()
        {
            _ = LoadStorySummeries();
        }

        internal async Task LoadStorySummeries()
        {
            ObservableCollection<DRNewsStory> loaded = await api.GetStorySummeries(this.Stories.Count, 30);

            foreach (DRNewsStory story in loaded)
            {
                this.Stories.Add(story);
            }
        }
    }
}
