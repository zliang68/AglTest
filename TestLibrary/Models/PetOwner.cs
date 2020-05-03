using System;
using System.Collections.Generic;
using System.Text;

namespace TestLibrary.Models
{
    /// <summary>
    /// Model of owner with pets for data source
    /// </summary>
    public class PetOwner
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
