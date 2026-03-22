using HouseRental.Shared;
using Microsoft.Extensions.Options;
using System.Net.Http;
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

        public Task<IEnumerable<FeatureCard>?> GetAllFeatureCardInformation()
        {
            throw new NotImplementedException();
        }
    }
}
