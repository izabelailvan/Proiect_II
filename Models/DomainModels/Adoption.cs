using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adopta_O_Emotie_Virtuala.Models.DomainModels
{
    public class Adoption
    {
        [Key]
        public Guid ID_Adoption { get; set; }
        [ForeignKey("Animal")]
        public String ID_Animal { get; set; }
        [ForeignKey("Foster_parents")]
        public String ID_Parent { get; set; }
        public DateTime DateOfAdoption { get; set; }
        public String Status { get; set; }
    }
}
