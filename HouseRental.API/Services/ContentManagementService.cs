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
                var featureCards = await _dataContext.FeatureCards.ToListAsync();
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

        #region Manage Destination Card Information Functions

        public async Task<IEnumerable<DestinationCard>?> GetAllDestinationCardInformation()
        {
            try
            {
                var destinationCards = await _dataContext.DestinationCards.ToListAsync();
                if (destinationCards != null && destinationCards.Count > 0)
                {
                    return destinationCards;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> EditDestinationCardInformation(DestinationCard destinationCard)
        {
            try
            {
                _dataContext.DestinationCards.Update(destinationCard);
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

        public async Task<bool> DeleteDestinationCardInformation(int entryID)
        {
            try
            {
                var destinationCard = await _dataContext.DestinationCards.FindAsync(entryID);
                if (destinationCard != null)
                {
                    _dataContext.DestinationCards.Remove(destinationCard);
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

        public async Task<bool> AddDestinationCardInformation(DestinationCard destinationCard)
        {
            try
            {
                await _dataContext.DestinationCards.AddAsync(destinationCard);
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

        #endregion
    }
}
