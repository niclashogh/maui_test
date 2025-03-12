using System.Collections.ObjectModel;

namespace maui_test.Models
{
    public class FilterProfileDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Filters { get; set; } = new();

        public FilterProfileDTO() { }
    }
}
