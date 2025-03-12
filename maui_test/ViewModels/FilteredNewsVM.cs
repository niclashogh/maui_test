using maui_test.Models;
using maui_test.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maui_test.ViewModels
{
    public class FilteredNewsVM : NotifyPropertyChanged
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

        public FilteredNewsVM(HackerNewsAPI api)
        {
            this.Api = api;
            _ = LoadStoryIds();
        }

        private async Task LoadStoryIds()
        {
            this.storyIds = await Api.GetStoryIds();
            _ = LoadFilteredStorySummeries(1);
        }

        public async Task LoadFilteredStorySummeries(int filteredId)
        {
            if (this.storyIds.Any())
            {
                // Hardcoded Solution
                if (filteredId == 1)
                {
                    List<long> loadBatch = this.storyIds.Skip(this.Stories.Count).ToList();
                    int storyPool = 0;
                    List<string> dummyFilters = new List<string>()
                    {
                        new("Mark"),
                        new("Gemini"),
                        new("Zinc")
                    };

                    foreach (long id in loadBatch)
                    {
                        if (storyPool >= 30) break;

                        NewsStory story = await this.Api.GetStorySummery(id);

                        if (!dummyFilters.Any(filter => story.Title.Contains(filter, StringComparison.OrdinalIgnoreCase)))
                        {
                            this.Stories.Add(story);
                            storyPool++;
                        }
                    }
                }
            }
        }
    }
}
