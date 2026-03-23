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
    }
}
