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

        public Task<bool> DeleteFeatureCardInformation(int entryID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditFeatureCardInformation(FeatureCard featureCard)
        {
            throw new NotImplementedException();
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

        #endregion

    }
}
