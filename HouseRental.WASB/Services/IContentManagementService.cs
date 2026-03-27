using HouseRental.Shared;

namespace HouseRental.WASB.Services
{
    public interface IContentManagementService
    {
        #region Manage Feature Card Information Functions

        Task<bool> AddFeatureCardInformation(FeatureCard featureCard);
        Task<bool> EditFeatureCardInformation(FeatureCard featureCard);
        Task<bool> DeleteFeatureCardInformation(int entryID);
        Task<List<FeatureCard>?> GetAllFeatureCardInformation();

        #endregion

        #region Manage Destination Card Information Functions

        Task<bool> AddDestinationCardInformation(DestinationCard destinationCard);
        Task<bool> EditDestinationCardInformation(DestinationCard destinationCard);
        Task<bool> DeleteDestinationCardInformation(int entryID);
        Task<List<DestinationCard>?> GetAllDestinationCardInformation();

        #endregion

        #region Manage House Images Functions

        Task<bool> AddHouseImage(HouseImage houseImage);
        Task<bool> EditHouseImage(HouseImage houseImage);
        Task<bool> DeleteHouseImage(int entryID);
        Task<List<HouseImage>?> GetAllHouseImages();

        #endregion

        #region Manage House Information Functions

        Task<bool> AddHouseInformation(HouseInformation houseInformation);
        Task<bool> EditHouseInformation(HouseInformation houseInformation);
        Task<HouseInformation?> GetHouseInformation();

        #endregion
    }
}
