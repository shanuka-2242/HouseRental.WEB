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

        #region Manage feature card information API endpoints

        //POST: api/v1/ContentManagement/addFeatureCardInformation
        [HttpPost("addFeatureCardInformation")]
        public async Task<ActionResult> InsertFeatureCardInformation([FromForm] FeatureCardDTO featureCardDTO)
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
                featureCard.CardTitle = featureCardDTO.CardTitle;
                featureCard.CardDescription = featureCardDTO.CardDescription;
                featureCard.CardImage = memoryStream.ToArray();

                var result = await _contentManagementService.AddFeatureCardInformation(featureCard);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Inserting information into the database failed.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Deleting information from the database failed due to database error or provided entryID wasn't able to found.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        //PUT: api/v1/ContentManagement/editFeatureCardInformation
        [HttpPut("editFeatureCardInformation")]
        public async Task<ActionResult> EditFeatureCardInformation(FeatureCard featureCard)
        {
            try
            {
                var result = await _contentManagementService.EditFeatureCardInformation(featureCard);
                if (result)
                {
                    return Ok();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Editing information from the database failed due to database error.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
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
                    return NotFound("Couldn't find any items related to this requested type from the database.");
                }
                return Ok(featureCards);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        #endregion
    }
}
