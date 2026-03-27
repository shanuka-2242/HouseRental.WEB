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

    #region House Image Class & DTO

    public class HouseImage
    {
        [Key]
        public int EntryID { get; set; }
        public byte[] Image { get; set; } = [];
        public string ImageContentType { get; set; } = string.Empty;
        public string ImageFileName { get; set; } = string.Empty;
    }

    public class HouseImageDTO
    {
        public int EntryID { get; set; }
        public required IFormFile Image { get; set; }
    }

    #endregion

    #region House Information Card Class

    public class HouseInformation
    {
        [Key]
        public int EntryID { get; set; }
        public string VillaName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public string OwnerEmail { get; set; } = string.Empty;
    }

    #endregion
}
