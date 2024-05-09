using Adopta_O_Emotie_Virtuala.Data;
using Adopta_O_Emotie_Virtuala.Models;
using Adopta_O_Emotie_Virtuala.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Numerics;

namespace Adopta_O_Emotie_Virtuala.Controllers
{
    public class UsersController : Controller
    {
        private readonly MVCDbContext mVCDbContext;
        public UsersController(MVCDbContext mVCDbContext) { 
        this.mVCDbContext = mVCDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           var users = await mVCDbContext.Users.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUserViewModel addUserRequest)
        { 
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = addUserRequest.Name,
                Email= addUserRequest.Email,
                Phone= addUserRequest.Phone,
                Address= addUserRequest.Address,
                DateOfBirth= addUserRequest.DateOfBirth,
                Password= addUserRequest.Password
            };
            await mVCDbContext.Users.AddAsync(user);
            await mVCDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var user = await mVCDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                var viewModel = new UpdateUsersViewModel()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.Phone,
                    Address = user.Address,
                    DateOfBirth = user.DateOfBirth,
                    Password = user.Password

                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateUsersViewModel model)
        {
            var user = await mVCDbContext.Users.FindAsync(model.Id);
            if (user != null)
            {
                user.Name = model.Name;
                user.Email = model.Email;
                user.Phone = model.Phone;
                user.Address = model.Address;
                user.DateOfBirth = model.DateOfBirth;
                user.Password = model.Password;

                await mVCDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateUsersViewModel model)
        {
            var user = await mVCDbContext.Users.FindAsync(model.Id);
            if (user != null)
            {
                mVCDbContext.Users.Remove(user);
                await mVCDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
