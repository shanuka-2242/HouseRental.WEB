using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HouseRental.Shared
{
    public class AppSettings
    {
        public string APIBaseURL { get; set; } = string.Empty;
    }

    #region FeatureCard Card Class & DTO

    public class FeatureCard
    {
        [Key]
        public int EntryID { get; set; }
        public string CardTitle { get; set; } = string.Empty;
        public string CardDescription { get; set; } = string.Empty;
        public byte[] CardImage { get; set; } = [];
        public string ImageContentType { get; set; } = string.Empty;
        public string ImageFileName { get; set; } = string.Empty;
    }

    public class FeatureCardDTO
    {
        public int EntryID { get; set; }
        public string CardTitle { get; set; } = string.Empty;
        public string CardDescription { get; set; } = string.Empty;
        public required IFormFile CardImage { get; set; }
    }

    #endregion

    #region Destination Card Class & DTO

    public class DestinationCard
    {
        [Key]
        public int EntryID { get; set; }
        public string CardTitle { get; set; } = string.Empty;
        public string CardDescription { get; set; } = string.Empty;
        public string Distance { get; set; } = string.Empty;
        public byte[] CardImage { get; set; } = [];
        public string ImageContentType { get; set; } = string.Empty;
        public string ImageFileName { get; set; } = string.Empty;
    }

    public class DestinationCardDTO
    {
        public int EntryID { get; set; }
        public string CardTitle { get; set; } = string.Empty;
        public string CardDescription { get; set; } = string.Empty;
        public string Distance { get; set; } = string.Empty;
        public required IFormFile CardImage { get; set; }
    }

    #endregion
}
