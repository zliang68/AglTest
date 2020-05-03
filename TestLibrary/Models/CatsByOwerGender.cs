using System.Collections;
using System.Collections.Generic;

namespace TestLibrary.Models
{
    /// <summary>
    /// Cat names based on gender of owners
    /// </summary>
    public class CatsByOwnerGender
    {
        public string OwnerGender { get; set; }
        public IList<string> CatNames { get; set; }
    }
}