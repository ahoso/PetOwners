using System.ComponentModel.DataAnnotations;
namespace PetOwners.Core.Domain
{
    /// <summary>
    /// Owner Class
    /// </summary>
    public class Owner
    {
        /// <summary>
        /// Owner Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gender of Owner
        /// </summary>
        [Required]
        public string Gender { get; set; }

        /// <summary>
        /// Age of Owner
        /// </summary>
        [Required]
        public int Age { get; set; }

        /// <summary>
        /// Pets owner owns
        /// </summary>
        public Pet[] Pets { get; set; }
    }
}