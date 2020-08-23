using PetStore.Common;
using PetStore.Models.Enumerations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class Pet
    {
        public Pet()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; } //GUID ID must be generated in Constructor

        [Required]
        [MaxLength(GlobalConstants.PetNameMaxLenght)]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [Range(GlobalConstants.PetMinAge,GlobalConstants.PetMaxAge)]
        public int Age { get; set; }

        public bool IsSold { get; set; }

        public decimal Price { get; set; }

        [Required]
        public string BreedId { get; set; }

        public virtual Breed Breed { get; set; }

        public string ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}