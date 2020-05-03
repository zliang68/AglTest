using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestLibrary.Models;

namespace TestLibrary.Services
{
    public interface IPeopleService
    {
        /// <summary>
        /// Interface to retrieve data from data source 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
       Task<IList<PetOwner>> GetPetOwners(string url);
        
        /// <summary>
        /// Interface to transform data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        IList<CatsByOwnerGender> GetCatsByOwnerGender(IList<PetOwner> data);
    }
}
