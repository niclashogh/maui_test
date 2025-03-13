namespace maui_test.Models
{
    public class DRNewsStory
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string ImageUrl { get; set; }
        public string PubDate { get; set; }

        public DRNewsStory(string title, string desc, string link, string img, string pubDate)
        {
            this.Title = title;
            this.Description = desc;
            this.Link = link;
            this.ImageUrl = img;
            this.PubDate = pubDate;
        }

        public DRNewsStory() { }
    }
}
