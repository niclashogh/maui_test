namespace maui_test.Models
{
    public class FilterDTO
    {
        public string Filter {  get; set; }

        public FilterDTO(string filter)
        {
            this.Filter = filter;
        }

        public FilterDTO() { }
    }
}
