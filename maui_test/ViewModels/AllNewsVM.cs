using maui_test.Models;
using maui_test.Services;
using System.Collections.ObjectModel;

namespace maui_test.ViewModels
{
    public class AllNewsVM : NotifyPropertyChanged
    {
        private readonly HackerNewsAPI api = new();

        #region Variables & Properties
        private List<long> storyIds { get; set; } = new();

        private ObservableCollection<HackerNewsStory> stories = new();
        public ObservableCollection<HackerNewsStory> Stories
        {
            get { return this.stories; }
            private set
            {
                this.stories = value;
                OnPropertyChanged(nameof(this.Stories));
            }
        }
        #endregion

        public AllNewsVM()
        {
            _ = LoadStoryIds();
        }

        private async Task LoadStoryIds()
        {
            this.storyIds = await api.GetStoryIds();
            _ = LoadStorySummeries();
        }

        public async Task LoadStorySummeries()
        {
            if (this.storyIds.Any())
            {
                List<long> loadBatch = this.storyIds.Skip(this.Stories.Count).Take(30).ToList();

                foreach (long id in loadBatch)
                {
                    HackerNewsStory story = await this.api.GetStorySummery(id);
                    this.Stories.Add(story);
                }
            }
        }
    }
}
