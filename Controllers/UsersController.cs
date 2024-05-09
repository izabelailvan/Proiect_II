using Adopta_O_Emotie_Virtuala.Data;
using Adopta_O_Emotie_Virtuala.Models;
using Adopta_O_Emotie_Virtuala.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    }
}
