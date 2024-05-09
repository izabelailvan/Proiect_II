using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Adopta_O_Emotie_Virtuala.Models.DomainModels
{
    public class Foster_parents
    {
        [Key]
        public Guid ID_Parent { get; set; }

        [ForeignKey("User")]
        public String ID_User { get; set; }
        public String ExperienceWithAnimals { get; set; }
        public String Prefrences { get; set; }
    }
}
