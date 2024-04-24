using System.ComponentModel.DataAnnotations;

namespace Adopta_O_Emotie_Virtuala.Models.DomainModels
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }

    }
}
