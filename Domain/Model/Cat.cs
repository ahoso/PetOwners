using System.ComponentModel.DataAnnotations;
namespace PetOwners.Core.Domain
{
    /// <summary>
    /// Cat Calss derived from Pet
    /// </summary>
    public class Cat:Pet
    {
        /// <summary>
        /// Gender of Owner
        /// </summary>
        public string OwnerGender { get; set; }

    }
}
