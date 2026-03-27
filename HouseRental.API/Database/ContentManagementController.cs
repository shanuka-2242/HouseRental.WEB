using HouseRental.API.Services;
using HouseRental.Shared;
using Microsoft.AspNetCore.Mvc;

namespace HouseRental.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContentManagementController : ControllerBase
    {
        private readonly IContentManagementService _contentManagementService;

        public ContentManagementController(IContentManagementService contentManagementService)
        {
            _contentManagementService = contentManagementService;
        }

        #region Manage Feature Card Information API Endpoints

        //POST: api/v1/ContentManagement/addFeatureCardInformation
        [HttpPost("addFeatureCardInformation")]
        public async Task<ActionResult> AddFeatureCardInformation([FromForm] FeatureCardDTO featureCardDTO)
        {
            try
            {
                if (featureCardDTO.CardImage == null || featureCardDTO.CardImage.Length == 0)
                {
                    return BadRequest("Feature card image cannot be null.");
                }

                using var memoryStream = new MemoryStream();
                await featureCardDTO.CardImage.CopyToAsync(memoryStream);

                FeatureCard featureCard = new FeatureCard();
                featureCard.CardTitle = featureCardDTO.CardTitle;
                featureCard.CardDescription = featureCardDTO.CardDescription;
                featureCard.CardImage = memoryStream.ToArray();
                featureCard.ImageContentType = featureCardDTO.CardImage.ContentType;
                featureCard.ImageFileName = featureCardDTO.CardImage.FileName;

                var result = await _contentManagementService.AddFeatureCardInformation(featureCard);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Adding feature card information into the database got failed.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Exception occurred: {ex.ToString()}");
            }
        }

        //DELETE: api/v1/ContentManagement/deleteFeatureCardInformation/entryID
        [HttpDelete("deleteFeatureCardInformation/{entryID}")]
        public async Task<ActionResult> DeleteFeatureCardInformation(int entryID)
        {
            try
            {
                var result = await _contentManagementService.DeleteFeatureCardInformation(entryID);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Deleting feature card information from the database failed due to database error or provided EntryID was not able to found.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Exception occurred: {ex.ToString()}");
            }
        }

        //PUT: api/v1/ContentManagement/editFeatureCardInformation
        [HttpPut("editFeatureCardInformation")]
        public async Task<ActionResult> EditFeatureCardInformation([FromForm] FeatureCardDTO featureCardDTO)
        {
            try
            {
                if (featureCardDTO.CardImage == null || featureCardDTO.CardImage.Length == 0)
                {
                    return BadRequest("CardImage cannot be empty.");
                }

                using var memoryStream = new MemoryStream();
                await featureCardDTO.CardImage.CopyToAsync(memoryStream);

                FeatureCard featureCard = new FeatureCard();
                featureCard.EntryID = featureCardDTO.EntryID;
                featureCard.CardTitle = featureCardDTO.CardTitle;
                featureCard.CardDescription = featureCardDTO.CardDescription;
                featureCard.CardImage = memoryStream.ToArray();
                featureCard.ImageContentType = featureCardDTO.CardImage.ContentType;
                featureCard.ImageFileName = featureCardDTO.CardImage.FileName;

                var result = await _contentManagementService.EditFeatureCardInformation(featureCard);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Editing feature card information into the database got failed.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Exception occurred: {ex.ToString()}");
            }
        }

        //GET: api/v1/ContentManagement/getAllFeatureCardInformation
        [HttpGet("getAllFeatureCardInformation")]
        public async Task<ActionResult> GetAllFeatureCardInformation()
        {
            try
            {
                var featureCards = await _contentManagementService.GetAllFeatureCardInformation();
                if (featureCards == null)
                {
                    return NotFound("Could not found any feature card information from the database.");
                }
                return Ok(featureCards);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Exception occurred: {ex.ToString()}");
            }
        }

        #endregion

        #region Manage Destination Card Information API Endpoints

        //POST: api/v1/ContentManagement/addDestinationCardInformation
        [HttpPost("addDestinationCardInformation")]
        public async Task<ActionResult> AddDestinationCardInformation([FromForm] DestinationCardDTO destinationCardDTO)
        {
            try
            {
                if (destinationCardDTO.CardImage == null || destinationCardDTO.CardImage.Length == 0)
                {
                    return BadRequest("Destination card image cannot be null.");
                }

                using var memoryStream = new MemoryStream();
                await destinationCardDTO.CardImage.CopyToAsync(memoryStream);

                DestinationCard destinationCard = new DestinationCard();
                destinationCard.CardTitle = destinationCardDTO.CardTitle;
                destinationCard.CardDescription = destinationCardDTO.CardDescription;
                destinationCard.Distance = destinationCardDTO.Distance;
                destinationCard.CardImage = memoryStream.ToArray();
                destinationCard.ImageContentType = destinationCardDTO.CardImage.ContentType;
                destinationCard.ImageFileName = destinationCardDTO.CardImage.FileName;

                var result = await _contentManagementService.AddDestinationCardInformation(destinationCard);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Adding destination card information into the database got failed.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Exception occurred: {ex.ToString()}");
            }
        }

        //DELETE: api/v1/ContentManagement/deleteDestinationCardInformation/entryID
        [HttpDelete("deleteDestinationCardInformation/{entryID}")]
        public async Task<ActionResult> DeleteDestinationCardInformation(int entryID)
        {
            try
            {
                var result = await _contentManagementService.DeleteDestinationCardInformation(entryID);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Deleting destination card information from the database failed due to database error or provided EntryID was not able to found.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Exception occurred: {ex.ToString()}");
            }
        }

        //PUT: api/v1/ContentManagement/editDestinationCardInformation
        [HttpPut("editDestinationCardInformation")]
        public async Task<ActionResult> EditDestinationCardInformation([FromForm] DestinationCardDTO destinationCardDTO)
        {
            try
            {
                if (destinationCardDTO.CardImage == null || destinationCardDTO.CardImage.Length == 0)
                {
                    return BadRequest("CardImage cannot be empty.");
                }

                using var memoryStream = new MemoryStream();
                await destinationCardDTO.CardImage.CopyToAsync(memoryStream);

                DestinationCard destinationCard = new DestinationCard();
                destinationCard.EntryID = destinationCardDTO.EntryID;
                destinationCard.CardTitle = destinationCardDTO.CardTitle;
                destinationCard.CardDescription = destinationCardDTO.CardDescription;
                destinationCard.Distance = destinationCardDTO.Distance;
                destinationCard.CardImage = memoryStream.ToArray();
                destinationCard.ImageContentType = destinationCardDTO.CardImage.ContentType;
                destinationCard.ImageFileName = destinationCardDTO.CardImage.FileName;

                var result = await _contentManagementService.EditDestinationCardInformation(destinationCard);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Editing destination card information into the database got failed.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Exception occurred: {ex.ToString()}");
            }
        }

        //GET: api/v1/ContentManagement/getAllDestinationCardInformation
        [HttpGet("getAllDestinationCardInformation")]
        public async Task<ActionResult> GetAllDestinationCardInformation()
        {
            try
            {
                var destinationCards = await _contentManagementService.GetAllDestinationCardInformation();
                if (destinationCards == null)
                {
                    return NotFound("Could not found any destination card information from the database.");
                }
                return Ok(destinationCards);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Exception occurred: {ex.ToString()}");
            }
        }

        #endregion

        #region Manage House Images API Endpoints

        //POST: api/v1/ContentManagement/addHouseImage
        [HttpPost("addHouseImage")]
        public async Task<ActionResult> AddHouseImage([FromForm] HouseImageDTO houseImageDTO)
        {
            try
            {
                if (houseImageDTO.Image == null || houseImageDTO.Image.Length == 0)
                {
                    return BadRequest("House image cannot be null.");
                }

                using var memoryStream = new MemoryStream();
                await houseImageDTO.Image.CopyToAsync(memoryStream);

                HouseImage houseImage = new HouseImage();
                houseImage.Image = memoryStream.ToArray();
                houseImage.ImageContentType = houseImageDTO.Image.ContentType;
                houseImage.ImageFileName = houseImageDTO.Image.FileName;

                var result = await _contentManagementService.AddHouseImage(houseImage);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Adding house image into the database got failed.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Exception occurred: {ex.ToString()}");
            }
        }

        //DELETE: api/v1/ContentManagement/deleteHouseImage/entryID
        [HttpDelete("deleteHouseImage/{entryID}")]
        public async Task<ActionResult> DeleteHouseImage(int entryID)
        {
            try
            {
                var result = await _contentManagementService.DeleteHouseImage(entryID);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Deleting house image from the database failed due to database error or provided EntryID was not able to found.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Exception occurred: {ex.ToString()}");
            }
        }

        //PUT: api/v1/ContentManagement/editHouseImage
        [HttpPut("editHouseImage")]
        public async Task<ActionResult> EditHouseImage([FromForm] HouseImageDTO houseImageDTO)
        {
            try
            {
                if (houseImageDTO.Image == null || houseImageDTO.Image.Length == 0)
                {
                    return BadRequest("HouseImage cannot be empty.");
                }

                using var memoryStream = new MemoryStream();
                await houseImageDTO.Image.CopyToAsync(memoryStream);

                HouseImage houseImage = new HouseImage();
                houseImage.EntryID = houseImageDTO.EntryID;
                houseImage.Image = memoryStream.ToArray();
                houseImage.ImageContentType = houseImageDTO.Image.ContentType;
                houseImage.ImageFileName = houseImageDTO.Image.FileName;

                var result = await _contentManagementService.EditHouseImage(houseImage);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Editing house image into the database got failed.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Exception occurred: {ex.ToString()}");
            }
        }

        //GET: api/v1/ContentManagement/getAllHouseImages
        [HttpGet("getAllHouseImages")]
        public async Task<ActionResult> GetAllHouseImages()
        {
            try
            {
                var houseImages = await _contentManagementService.GetAllHouseImages();
                if (houseImages == null)
                {
                    return NotFound("Could not found any house images from the database.");
                }
                return Ok(houseImages);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Exception occurred: {ex.ToString()}");
            }
        }

        #endregion

        #region Manage House Information API Endpoints

        //PUT: api/v1/ContentManagement/editHouseInformation
        [HttpPut("editHouseInformation")]
        public async Task<ActionResult> EditHouseInformation(HouseInformation houseInformation)
        {
            try
            {
                if (houseInformation == null)
                {
                    return BadRequest("HouseInformation cannot be null.");
                }
                
                var result = await _contentManagementService.EditHouseInformation(houseInformation);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Editing house information into the database got failed.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Exception occurred: {ex.ToString()}");
            }
        }

        //GET: api/v1/ContentManagement/getHouseInformation
        [HttpGet("getHouseInformation")]
        public async Task<ActionResult> GetHouseInformation()
        {
            try
            {
                var houseInformation = await _contentManagementService.GetHouseInformation();
                if (houseInformation == null)
                {
                    return NotFound("Could not found any house information from the database.");
                }
                return Ok(houseInformation);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Exception occurred: {ex.ToString()}");
            }
        }

        //POST: api/v1/ContentManagement/addHouseInformation
        [HttpPost("addHouseInformation")]
        public async Task<ActionResult> AddHouseInformation(HouseInformation houseInformation)
        {
            try
            {
                if (houseInformation == null)
                {
                    return BadRequest("House information cannot be null.");
                }

                var result = await _contentManagementService.AddHouseInformation(houseInformation);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Adding house information into the database got failed.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Exception occurred: {ex.ToString()}");
            }
        }

        #endregion
    }
}
