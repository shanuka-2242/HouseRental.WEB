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

        #region Manage House Images Functions

        public async Task<bool> AddHouseImage(HouseImage houseImage)
        {
            try
            {
                await _dataContext.HouseImages.AddAsync(houseImage);
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

        public async Task<bool> EditHouseImage(HouseImage houseImage)
        {
            try
            {
                _dataContext.HouseImages.Update(houseImage);
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

        public async Task<bool> DeleteHouseImage(int entryID)
        {
            try
            {
                var houseImage = await _dataContext.HouseImages.FindAsync(entryID);
                if (houseImage != null)
                {
                    _dataContext.HouseImages.Remove(houseImage);
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

        public async Task<IEnumerable<HouseImage>?> GetAllHouseImages()
        {
            try
            {
                var houseImages = await _dataContext.HouseImages.ToListAsync();
                if (houseImages != null && houseImages.Count > 0)
                {
                    return houseImages;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Manage House Information Functions

        public async Task<bool> AddHouseInformation(HouseInformation houseInformation)
        {
            try
            {
                await _dataContext.HouseInformation.AddAsync(houseInformation);
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

        public async Task<bool> EditHouseInformation(HouseInformation houseInformation)
        {
            try
            {
                _dataContext.HouseInformation.Update(houseInformation);
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

        public async Task<HouseInformation?> GetHouseInformation()
        {
            try
            {
                var houseInformation = await _dataContext.HouseInformation.FirstOrDefaultAsync();
                if (houseInformation != null)
                {
                    return houseInformation;
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
