using Adopta_O_Emotie_Virtuala.Data;
using Adopta_O_Emotie_Virtuala.Models.DomainModels;
using Adopta_O_Emotie_Virtuala.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Adopta_O_Emotie_Virtuala.Controllers
{
    public class ParentsController : Controller
    {
        private readonly MVCDbContext mVCDbContext;
        public ParentsController(MVCDbContext mVCDbContext)
        {
            this.mVCDbContext = mVCDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var parents = await mVCDbContext.Foster_Parents.ToListAsync();
            return View(parents);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

       [HttpPost]
        public async Task<IActionResult> Add(AddParentViewModel addParentRequest)
        {
           
            var parent = new Foster_parents()
            {
                ID_Parent = Guid.NewGuid(),
                ID_User = addParentRequest.ID_User,
                ExperienceWithAnimals = addParentRequest.ExperienceWithAnimals,
                Prefrences = addParentRequest.Prefrences
            };
            await mVCDbContext.Foster_Parents.AddAsync(parent);
            await mVCDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var parent = await mVCDbContext.Foster_Parents.FirstOrDefaultAsync(x => x.ID_Parent == id);

            if (parent != null)
            {
                var viewModel = new UpdateParentsViewModel()
                {
                    ID_Parent = parent.ID_Parent,
                    ID_User = parent.ID_User,
                    ExperienceWithAnimals = parent.ExperienceWithAnimals,
                    Prefrences = parent.Prefrences
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateParentsViewModel model)
        {
            var parent = await mVCDbContext.Foster_Parents.FindAsync(model.ID_Parent);
            if (parent != null)
            {
                parent.ID_Parent = model.ID_Parent;
                parent.ID_User = model.ID_User;
                parent.ExperienceWithAnimals = model.ExperienceWithAnimals;
                parent.Prefrences = model.Prefrences;


                await mVCDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateParentsViewModel model)
        {
            var parent = await mVCDbContext.Foster_Parents.FindAsync(model.ID_Parent);
            if (parent != null)
            {
                mVCDbContext.Foster_Parents.Remove(parent);
                await mVCDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
