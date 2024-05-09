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
    }
}
