using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project.Web.Date;
using Project.Web.Models;
using Project.Web.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Project.Web.Controllers
{
    public class PersonsController : Controller

    {
        private readonly ApplicationDbContext dbContext;
        public PersonsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPersonViewModel viewModel)
        {
            var person = new Person
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribed = viewModel.Subscribed,
            };
            await dbContext.Persons.AddAsync(person);
            await dbContext.SaveChangesAsync();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var persons = await dbContext.Persons.ToListAsync();

            return View(persons);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var person = await dbContext.Persons.FindAsync(id);

            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Person viewmodel)
        {
            var person = await dbContext.Persons.FindAsync(viewmodel.Id);

            if (person is not null)
            {
                person.Name = viewmodel.Name;
                person.Email = viewmodel.Email;
                person.Phone = viewmodel.Phone;
                person.Subscribed = viewmodel.Subscribed;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Persons");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Person viewModel)
        {
            var person = await dbContext.Persons
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if(person is not null)
            {
                dbContext.Persons.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Persons");
        }
    }
}
