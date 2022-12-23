using System.ComponentModel.DataAnnotations;

namespace MTR_RouteSuggestionAPI.Models
{
    public class SearchHistory
    {
        [Key]
        public int Id { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
    }
}
