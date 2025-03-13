using maui_test.Models;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace maui_test.Services
{
    public class DRNewsAPI
    {
        private HttpClient client = new();

        public DRNewsAPI() { }

        public async Task<ObservableCollection<DRNewsStory>> GetStorySummeries(int skip, int take)
        {
            ObservableCollection<DRNewsStory> news = new();

            string xmlResponse = await client.GetStringAsync("https://www.dr.dk/nyheder/service/feeds/allenyheder");
            XDocument xmlDoc = XDocument.Parse(xmlResponse);

            IEnumerable<XElement> items = xmlDoc.Descendants("item");
            string defaultImage = @"https://is1-ssl.mzstatic.com/image/thumb/Purple124/v4/29/55/2e/29552ea2-5952-af7a-f398-89d177968258/AppIcon-0-0-1x_U007emarketing-0-0-0-7-0-0-85-220.png/600x600wa.png";

            foreach (XElement item in items.Skip(skip).Take(take))
            {
                
                string title = item.Element("title")?.Value ?? "No Title";
                string desc = item.Element("description")?.Value ?? "No Description";
                string link = item.Element("link")?.Value ?? "#";
                string pubDate = item.Element("pubDate")?.Value ?? "Unknown Date";

                news.Add(new(title, desc, link, defaultImage, pubDate));
            }

            return news;
        }
    }
}
