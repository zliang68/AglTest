using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TestLibrary.Models;

namespace TestLibrary.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly ILogger<IPeopleService> _logger;

        public PeopleService(ILogger<IPeopleService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get data from passed in Url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<IList<PetOwner>> GetPetOwners(string url)
        {
            _logger.LogInformation($"Start getting data from {url}");

            try
            {
                var httpClient = new HttpClient();

                var httpResponse = await httpClient.GetAsync(url);
                httpResponse.EnsureSuccessStatusCode();

                var result = await httpResponse.Content.ReadAsAsync<IList<PetOwner>>();

                _logger.LogInformation($"Finished getting data from {url}");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception when accessing {url}");
                throw;
            }
        }

        /// <summary>
        /// Retrieve a list of records identified by gender
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public IList<CatsByOwnerGender> GetCatsByOwnerGender(IList<PetOwner> data)
        {
            var result = new List<CatsByOwnerGender>
            { 
               new CatsByOwnerGender 
               { 
                   OwnerGender = Constants.Male, 
                   CatNames = GetCatNames(data, Constants.Male, Constants.Cat) 
               },
               new CatsByOwnerGender 
               { 
                   OwnerGender = Constants.Female, 
                   CatNames = GetCatNames(data, Constants.Female, Constants.Cat) 
               }
            } ;
            
            return result;
        }

        /// <summary>
        /// Retrieve cat names filtered by owner's gender and pet's type
        /// </summary>
        /// <param name="data"></param>
        /// <param name="gender"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private IList<string> GetCatNames(IList<PetOwner> data, string gender, string type)
        {
            var catNames = data.Where(x => x.Gender == gender && x.Pets != null)
                                .SelectMany(y => y.Pets.Where(z => z.Type == type)
                                    .Select(a => a.Name))
                                    .OrderBy(b => b)
                                    .ToList();
            return catNames;
        }
    }
}
