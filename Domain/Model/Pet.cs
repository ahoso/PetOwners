
using System.ComponentModel.DataAnnotations;

namespace PetOwners.Core.Domain
{
    /// <summary>
    /// Pet Class
    /// </summary>
    public class Pet
    {
        /// <summary>
        /// Name of Pet
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Type of Pet
        /// </summary>
        [Required]
        public string Type { get; set; }
    }
}

