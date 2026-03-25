using HouseRental.Shared;

namespace HouseRental.API.Services
{
    public interface IContentManagementService
    {
        #region Manage Feature Card Information Functions

        Task<bool> AddFeatureCardInformation(FeatureCard featureCard);
        Task<bool> EditFeatureCardInformation(FeatureCard featureCard);
        Task<bool> DeleteFeatureCardInformation(int entryID);
        Task<IEnumerable<FeatureCard>?> GetAllFeatureCardInformation();

        #endregion

        #region Manage Destination Card Information Functions

        Task<bool> AddDestinationCardInformation(DestinationCard destinationCard);
        Task<bool> EditDestinationCardInformation(DestinationCard destinationCard);
        Task<bool> DeleteDestinationCardInformation(int entryID);
        Task<IEnumerable<DestinationCard>?> GetAllDestinationCardInformation();

        #endregion
    }
}
