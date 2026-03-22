using Microsoft.AspNetCore.Http;
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
        public string CardTitle { get; set; } = string.Empty;
        public string CardDescription { get; set; } = string.Empty;
        public byte[] CardImage { get; set; } = [];
    }

    public class FeatureCardDTO
    {
        public string CardTitle { get; set; } = string.Empty;
        public string CardDescription { get; set; } = string.Empty;
        public required IFormFile CardImage { get; set; }
    }
}
