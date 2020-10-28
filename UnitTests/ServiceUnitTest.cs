using Microsoft.Extensions.Logging;
using System;
using TestLibrary.Services;
using Xunit;
using Moq;
using System.Collections.Generic;
using TestLibrary.Models;
using TestLibrary;
using System.Reflection.Metadata;
using NuGet.Frameworks;
using System.Linq;

namespace UnitTests
{
    public class ServiceUnitTest
    {
        private readonly IPeopleService _peopleService;

        public ServiceUnitTest()
        {
            var logger = new Mock<ILogger<IPeopleService>>();
            _peopleService = new PeopleService(logger.Object);
        }

        /// <summary>
        /// Test PeopleService.GetCatsByOwnerGender method 
        /// </summary>
        [Fact]
        public void GivenPetOwnersData_WhenFiltered_ShouldReturnCatsByOwnerGender()
        {
            // Arrange
            var data = GetPetOwners();
            data.First().Pets = new List<Pet> 
            { 
                new Pet { Name = "Bob", Type = "Cat" },
                new Pet { Name = "Nemo", Type = "Fish" }
            };
            data.Last().Pets = new List<Pet> 
            { 
                new Pet { Name = "Mary", Type = "Cat" },
                new Pet { Name = "Fido", Type = "Dog" }
            };

            // Act
            var result = _peopleService.GetCatsByOwnerGender(data);

            // Assert
            Assert.True(result.Any());
            Assert.True(result.First(x => x.OwnerGender == Constants.Male).CatNames.Any());
            Assert.True(result.First(x => x.OwnerGender == Constants.Female).CatNames.Any());
        }

        /// <summary>
        /// Test PeopleService.GetCatsByOwnerGender method with no pet people data
        /// </summary>
        [Fact]
        public void GivenNoPetPeople_WhenFiltered_ShouldReturnEmptyCatNameList()
        {
            // Arrange
            var data = GetPetOwners();

            // Act
            var result = _peopleService.GetCatsByOwnerGender(data);

            // Assert
            Assert.True(result.Any());
            
            Assert.True(result.First().OwnerGender.ToLower() == Constants.Male.ToLower());
            Assert.False(result.First().CatNames.Any());

            Assert.True(result.Last().OwnerGender.ToLower() == Constants.Female.ToLower());
            Assert.False(result.Last().CatNames.Any());
        }

        /// <summary>
        /// Helper to generate test data
        /// </summary>
        /// <returns></returns>
        private IList<PetOwner> GetPetOwners()
        {
            return new List<PetOwner>
            { 
                new PetOwner { Gender = Constants.Male },
                new PetOwner { Gender = Constants.Female },
                new PetOwner { Gender = Constants.Male },
                new PetOwner { Gender = Constants.Female },
                new PetOwner { Gender = Constants.Male },
                new PetOwner { Gender = Constants.Female },
                new PetOwner { Gender = Constants.Male },
                new PetOwner { Gender = Constants.Female },
                new PetOwner { Gender = Constants.Male },
                new PetOwner { Gender = Constants.Female }
            };
        }
    }
}
