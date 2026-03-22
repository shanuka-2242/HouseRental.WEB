using HouseRental.API.Database;
using HouseRental.Shared;
using Microsoft.EntityFrameworkCore;

namespace HouseRental.API.Services
{
    public class ContentManagementService : IContentManagementService
    {
        private readonly DataContext _dataContext;

        public ContentManagementService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region Manage Feature Card Information Functions

        public async Task<bool> AddFeatureCardInformation(FeatureCard featureCard)
        {
            try
            {
                await _dataContext.FeatureCards.AddAsync(featureCard);
                var result = await _dataContext.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteFeatureCardInformation(int entryID)
        {
            try
            {
                var featureCard = await _dataContext.FeatureCards.FindAsync(entryID);
                if (featureCard != null)
                {
                    _dataContext.FeatureCards.Remove(featureCard);
                    var result = await _dataContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> EditFeatureCardInformation(FeatureCard featureCard)
        {
            try
            {
                _dataContext.FeatureCards.Update(featureCard);
                var result = await _dataContext.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<IEnumerable<FeatureCard>?> GetAllFeatureCardInformation()
        {
            try
            {
                var featureCards =  await _dataContext.FeatureCards.ToListAsync();
                if (featureCards != null && featureCards.Count > 0)
                {
                    return featureCards;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

    }
}
