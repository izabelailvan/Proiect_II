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

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var adoption = await mVCDbContext.Adoptions.FirstOrDefaultAsync(x => x.ID_Adoption == id);

            if (adoption != null)
            {
                var viewModel = new UpdateAdoptionViewModel()
                {
                    ID_Adoption = adoption.ID_Adoption, ID_Animal = adoption.ID_Animal, ID_Parent= adoption.ID_Parent, DateOfAdoption= adoption.DateOfAdoption, Status=adoption.Status
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateAdoptionViewModel model)
        {
            var adoption = await mVCDbContext.Adoptions.FindAsync(model.ID_Adoption);
            if (adoption != null)
            {
                adoption.ID_Adoption = model.ID_Adoption;
                adoption.ID_Animal = model.ID_Animal;
                adoption.ID_Parent = model.ID_Parent;
                adoption.DateOfAdoption = model.DateOfAdoption;
                adoption.Status = model.Status;


                await mVCDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateAdoptionViewModel model)
        {
            var adoption = await mVCDbContext.Adoptions.FindAsync(model.ID_Adoption);
            if (adoption != null)
            {
                mVCDbContext.Adoptions.Remove(adoption);
                await mVCDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
