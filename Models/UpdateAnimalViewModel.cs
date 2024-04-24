using System.ComponentModel.DataAnnotations;

namespace Adopta_O_Emotie_Virtuala.Models
{
    public class UpdateAnimalViewModel
    {
        [Key]
        public Guid ID_Animal { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Race { get; set; }
        public string Size { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public string Disponibiity { get; set; }

    }
}
