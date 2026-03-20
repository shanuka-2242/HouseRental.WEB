using System.ComponentModel.DataAnnotations;

namespace HouseRental.Shared
{
    public class AppSettings
    {
        public string APIBaseURL { get; set; } = string.Empty;
    }

    public class FeatureCard
    {
        [Key]
        public int EntryId { get; set; }
        public string FeatureCardTitle { get; set; } = string.Empty;
        public string FeatureCardDescription { get; set; } = string.Empty;
        public string FeatureCardImage { get; set; } = string.Empty;
    }
}
