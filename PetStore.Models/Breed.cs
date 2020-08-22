using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class Breed
    {
        public Breed()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Pets = new HashSet<Pet>();
        }

        [Key]
        public string Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}