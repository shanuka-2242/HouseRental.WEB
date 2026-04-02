using HouseRental.Shared;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace HouseRental.WASB.Services
{
    public class ContentManagementService : IContentManagementService
    {
        private HttpClient _httpClient { get; }

        public ContentManagementService(HttpClient httpClient, IOptions<AppSettings> AppSettings)
        {
            httpClient.BaseAddress = new Uri(AppSettings.Value.APIBaseURL);
            _httpClient = httpClient;
        }

        #region Manage Feature Card Information Services

        public async Task<bool> AddFeatureCardInformation(FeatureCard featureCard)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("addFeatureCardInformation", featureCard);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteFeatureCardInformation(int entryID)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"deleteFeatureCardInformation/{entryID}");
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> EditFeatureCardInformation(FeatureCard featureCard)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("editFeatureCardInformation", featureCard);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<FeatureCard>?> GetAllFeatureCardInformation()
        {
            try
            {
                var response = await _httpClient.GetAsync("getAllFeatureCardInformation");
                if (response.IsSuccessStatusCode)
                {
                    var featureCards = await response.Content.ReadFromJsonAsync<List<FeatureCard>>();
                    if (featureCards != null && featureCards.Count > 0)
                    {
                        return featureCards;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine($"Response code result received from ContentManagementService.GetAllFeatureCardInformation(): {response.StatusCode.ToString()}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred at ContentManagementService.GetAllFeatureCardInformation():{ex.ToString()}");
                return null;
            }
        }

        #endregion

        #region Manage Destination Card Information Services

        public async Task<bool> AddDestinationCardInformation(DestinationCard destinationCard)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditDestinationCardInformation(DestinationCard destinationCard)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteDestinationCardInformation(int entryID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DestinationCard>?> GetAllDestinationCardInformation()
        {
            try
            {
                var response = await _httpClient.GetAsync("getAllDestinationCardInformation");
                if (response.IsSuccessStatusCode)
                {
                    var destinationCards = await response.Content.ReadFromJsonAsync<List<DestinationCard>>();
                    if (destinationCards != null && destinationCards.Count > 0)
                    {
                        return destinationCards;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine($"Response code result received from ContentManagementService.GetAllDestinationCardInformation(): {response.StatusCode.ToString()}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred at ContentManagementService.GetAllDestinationCardInformation():{ex.ToString()}");
                return null;
            }
        }

        public async Task<bool> AddHouseImage(HouseImage houseImage)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditHouseImage(HouseImage houseImage)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteHouseImage(int entryID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<HouseImage>?> GetAllHouseImages()
        {
            try
            {
                var response = await _httpClient.GetAsync("getAllHouseImages");
                if (response.IsSuccessStatusCode)
                {
                    var houseImages = await response.Content.ReadFromJsonAsync<List<HouseImage>>();
                    if (houseImages != null && houseImages.Count > 0)
                    {
                        return houseImages;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine($"Response code result received from ContentManagementService.GetAllHouseImages(): {response.StatusCode.ToString()}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred at ContentManagementService.GetAllHouseImages():{ex.ToString()}");
                return null;
            }
        }

        #endregion

        #region Manage House Information Services

        public async Task<bool> AddHouseInformation(HouseInformation houseInformation)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditHouseInformation(HouseInformation houseInformation)
        {
            throw new NotImplementedException();
        }

        public async Task<HouseInformation?> GetHouseInformation()
        {
            try
            {
                var response = await _httpClient.GetAsync("getHouseInformation");
                if (response.IsSuccessStatusCode)
                {
                    var houseInformation = await response.Content.ReadFromJsonAsync<HouseInformation>();
                    if (houseInformation != null)
                    {
                        return houseInformation;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine($"Response code result received from ContentManagementService.GetHouseInformation(): {response.StatusCode.ToString()}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred at ContentManagementService.GetHouseInformation():{ex.ToString()}");
                return null;
            }
        }

        #endregion
    }
}
