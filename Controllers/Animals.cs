using Adopta_O_Emotie_Virtuala.Data;
using Adopta_O_Emotie_Virtuala.Models;
using Adopta_O_Emotie_Virtuala.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Adopta_O_Emotie_Virtuala.Controllers
{
    public class Animals : Controller
    {
        private readonly MVCDbContext mVCDbContext;
        public Animals(MVCDbContext mVCDbContext)
        {
            this.mVCDbContext= mVCDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           var animals=await mVCDbContext.Animals.ToListAsync();
            return View(animals);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAnimalViewModel addAnimalRequest)
        {
            var animal = new Animal()
            {
                ID_Animal = Guid.NewGuid(),
                Name = addAnimalRequest.Name,
                Species = addAnimalRequest.Species,
                Race = addAnimalRequest.Race,
                Size = addAnimalRequest.Size,
                Sex = addAnimalRequest.Sex,
                Age = addAnimalRequest.Age,
                Description = addAnimalRequest.Description,
                Disponibiity = addAnimalRequest.Disponibiity
            };

            await mVCDbContext.Animals.AddAsync(animal);
            await mVCDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var animal = await mVCDbContext.Animals.FirstOrDefaultAsync(x => x.ID_Animal == id);

            if (animal != null)
            {
                var viewModel = new UpdateAnimalViewModel()
                {
                    ID_Animal = animal.ID_Animal,
                    Name = animal.Name,
                    Species = animal.Species,
                    Race = animal.Race,
                    Size = animal.Size,
                    Sex = animal.Sex,
                    Age = animal.Age,
                    Description = animal.Description,
                    Disponibiity = animal.Disponibiity

                };
                return await Task.Run(()=> View("View",viewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateAnimalViewModel model)
        {
            var animal = await mVCDbContext.Animals.FindAsync(model.ID_Animal);
            if (animal != null)
            {
                animal.Name= model.Name;
                animal.Species= model.Species;
                animal.Race= model.Race;
                animal.Size= model.Size;
                animal.Sex= model.Sex;
                animal.Age= model.Age;
                animal.Description= model.Description;
                animal.Disponibiity= model.Disponibiity;

                await mVCDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateAnimalViewModel model)
        {
            var animal= await mVCDbContext.Animals.FindAsync(model.ID_Animal);
            if (animal != null)
            {
                mVCDbContext.Animals.Remove(animal);
                await mVCDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
