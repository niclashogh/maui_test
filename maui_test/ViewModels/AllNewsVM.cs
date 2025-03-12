using maui_test.Models;
using maui_test.Services;
using System.Collections.ObjectModel;

namespace maui_test.ViewModels
{
    public class AllNewsVM : NotifyPropertyChanged
    {
        public readonly HackerNewsAPI Api;

        #region Variables & Properties
        private List<long> storyIds { get; set; } = new();

        private ObservableCollection<NewsStory> stories = new();
        public ObservableCollection<NewsStory> Stories
        {
            get { return this.stories; }
            private set
            {
                this.stories = value;
                OnPropertyChanged(nameof(this.Stories));
            }
        }
        #endregion

        public AllNewsVM(HackerNewsAPI api)
        {
            this.Api = api;
            _ = LoadStoryIds();
        }

        private async Task LoadStoryIds()
        {
            this.storyIds = await Api.GetStoryIds();
            _ = LoadStorySummeries();
        }

        public async Task LoadStorySummeries()
        {
            if (this.storyIds.Any())
            {
                List<long> loadBatch = this.storyIds.Skip(this.Stories.Count).Take(30).ToList();

                foreach (long id in loadBatch)
                {
                    NewsStory story = await this.Api.GetStorySummery(id);
                    this.Stories.Add(story);
                }
            }
        }
    }
}
