namespace maui_test.Models
{
    public class NewsStory
    {
        public long Id { get; set; }
        public string By { get; set; }
        public long Score { get; set; }
        public long Time { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

        public NewsStory(long id, string by, long score, long time, string title, string url)
        {
            this.Id = id;
            this.By = by;
            this.Score = score;
            this.Time = time;
            this.Title = title;
            this.Url = url;
        }

        public NewsStory() { }
    }
}
