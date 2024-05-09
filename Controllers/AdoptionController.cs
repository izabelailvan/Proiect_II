using Adopta_O_Emotie_Virtuala.Data;
using Adopta_O_Emotie_Virtuala.Models.DomainModels;
using Adopta_O_Emotie_Virtuala.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Adopta_O_Emotie_Virtuala.Controllers
{
    public class AdoptionController : Controller
    {
        private readonly MVCDbContext mVCDbContext;
        public AdoptionController(MVCDbContext mVCDbContext)
        {
            this.mVCDbContext = mVCDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var adoptions = await mVCDbContext.Adoptions.ToListAsync();
            return View(adoptions);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAdoptionViewModel addAdoptionRequest)
        {
            var adoption = new Adoption()
            {
                ID_Adoption = Guid.NewGuid(),
                ID_Animal = addAdoptionRequest.ID_Animal,
                ID_Parent = addAdoptionRequest.ID_Parent,
                DateOfAdoption = addAdoptionRequest.DateOfAdoption,
                Status=addAdoptionRequest.Status
            };
            await mVCDbContext.Adoptions.AddAsync(adoption);
            await mVCDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
