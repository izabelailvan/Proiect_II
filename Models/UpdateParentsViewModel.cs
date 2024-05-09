using System.ComponentModel.DataAnnotations.Schema;

namespace Adopta_O_Emotie_Virtuala.Models
{
    public class UpdateParentsViewModel
    {
        public Guid ID_Parent { get; set; }
        public String ID_User { get; set; }
        public String ExperienceWithAnimals { get; set; }
        public String Prefrences { get; set; }
    }
}
