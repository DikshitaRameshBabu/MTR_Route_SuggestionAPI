using System.ComponentModel.DataAnnotations;

namespace MTR_RouteSuggestionAPI.Models
{
    public class Station
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        
    }
}
