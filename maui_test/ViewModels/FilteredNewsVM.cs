using maui_test.Models;
using maui_test.Repositories;
using maui_test.Services;
using System.Collections.ObjectModel;

namespace maui_test.ViewModels
{
    public class FilteredNewsVM : NotifyPropertyChanged
    {
        private FilterProfileRepo repository = new();
        private HackerNewsAPI hnApi = new();
        private DRNewsAPI dnApi = new();

        #region Variables & Properties
        public int CurrentFilterId = 0;
        public List<string> CurrentFilters { get; set; } = new();
        private List<long> storyIds { get; set; } = new();

        private ObservableCollection<DRNewsStory> stories = new(); // Either of type HackerNewsStory || DRNewsStory
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

        public FilteredNewsVM()
        {
            //_ = LoadStoryIds();
        }

        public async Task LoadFilteredStorySummeries()
        {
            this.CurrentFilters = await this.repository.LoadFiltersFromId(this.CurrentFilterId);
            ObservableCollection<DRNewsStory> news = await this.dnApi.GetStorySummeries(this.Stories.Count, 200);
            int storyPool = 0;

            foreach (DRNewsStory story in news)
            {
                if (storyPool >= 30) break;

                if (!CurrentFilters.Any(filter => story.Title.Contains(filter, StringComparison.OrdinalIgnoreCase)))
                {
                    this.Stories.Add(story);
                    storyPool++;
                }
            }
        }

        #region HackerNews Controls (Fix)
        //private async Task LoadStoryIds() => this.storyIds = await hnApi.GetStoryIds();

        //public async Task LoadFilteredStorySummeries(int filterId)
        //{
        //    this.CurrentFilters = await this.repository.LoadFiltersFromId(filterId);

        //    if (this.storyIds.Any())
        //    {
        //        List<long> loadBatch = this.storyIds.Skip(this.Stories.Count).ToList();
        //        int storyPool = 0;

        //        foreach (long id in loadBatch)
        //        {
        //            if (storyPool >= 30) break;

        //            HackerNewsStory story = await this.hnApi.GetStorySummery(id);

        //            if (!CurrentFilters.Any(filter => story.Title.Contains(filter, StringComparison.OrdinalIgnoreCase)))
        //            {
        //                this.Stories.Add(story);
        //                storyPool++;
        //            }
        //        }
        //    }
        //}
        #endregion
    }
}
