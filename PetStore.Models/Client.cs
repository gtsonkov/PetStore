using PetStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class Client
    {
        public Client()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Pets = new HashSet<Pet>();
            this.ClientProducts = new HashSet<ClientProducts>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.UserNameMinLenght)]
        [MaxLength(GlobalConstants.UserNameMaxLenght)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(GlobalConstants.FirstNameMaxLenght)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.LastNameMaxLenght)]
        public string LastName { get; set; }

        [Required]
        [MinLength(GlobalConstants.EmailMinLenght)]
        [MaxLength(GlobalConstants.EmailMaxLenght)]
        public string Email { get; set; }

        public string Telefon { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }

        public virtual ICollection<ClientProducts> ClientProducts { get; set; }
    }
}