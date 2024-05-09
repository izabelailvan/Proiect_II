using System.ComponentModel.DataAnnotations.Schema;

namespace Adopta_O_Emotie_Virtuala.Models
{
    public class AddAdoptionViewModel
    {
        public String ID_Animal { get; set; }
        public String ID_Parent { get; set; }
        public DateTime DateOfAdoption { get; set; }
        public String Status { get; set; }
    }
}
