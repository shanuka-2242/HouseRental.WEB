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
    }
}
