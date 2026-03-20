using HouseRental.API.Database;
using HouseRental.Shared;
using Microsoft.AspNetCore.Mvc;

namespace HouseRental.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EndpointsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public EndpointsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost("featureCardInformationUpload")]
        public async Task<IActionResult> UploadImage([FromForm] FeatureCardInformationUploadDTO featureInformationUploadDto)
        {
            if (featureInformationUploadDto.CardImage == null || featureInformationUploadDto.CardImage.Length == 0)
            {
                return BadRequest();
            }

            using var memoryStream = new MemoryStream();
            await featureInformationUploadDto.CardImage.CopyToAsync(memoryStream);

            var featureCard = new FeatureCard
            {
                CardTitle = featureInformationUploadDto.CardTitle,
                CardDescription = featureInformationUploadDto.CardDescription,
                CardImage = memoryStream.ToArray()
            };

            _dataContext.FeatureCards.Add(featureCard);
            await _dataContext.SaveChangesAsync();

            return Ok();
        }
    }
}
