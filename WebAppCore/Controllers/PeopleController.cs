using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TestLibrary;
using TestLibrary.Models;
using TestLibrary.Services;

namespace WebAppCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IPeopleService _peopleService;

        public PeopleController(ILogger<PeopleController> logger, IConfiguration configuration, IPeopleService peopleService)
        {
            _logger = logger;
            _configuration = configuration;
            _peopleService = peopleService;            
        }

        /// <summary>
        /// Get list of cat names grouped by owner's gender
        /// </summary>
        /// <returns></returns>
        [HttpGet("cats")]
        [ProducesResponseType(typeof(IEnumerable<CatsByOwnerGender>), 200)]
        public async Task<ActionResult> GetCats()
        {
            try
            {
                var data = await _peopleService.GetPetOwners(_configuration[Constants.PeopleServiceUrl]);
                return Ok(_peopleService.GetCatsByOwnerGender(data));
            }
            catch (Exception ex)
            {
                _logger.LogError($"FAILED: GetCats - {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to get data.");
            }
        }
    }
}
