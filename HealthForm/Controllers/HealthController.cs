using HealthForm.Data;
using HealthForm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthForm.Controllers
{
    public class HealthController : Controller
    {
        private readonly HealthDbContext _context;

        public HealthController(HealthDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var health = await _context.Health.ToListAsync();
            return View(health);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddHealthViewModel addHealthViewModel)
        {
            if (ModelState.IsValid)
            {
                var health = new Health()
                {
                    Id = Guid.NewGuid(),
                    Name = addHealthViewModel.Name,
                    BusinessEmail = addHealthViewModel.BusinessEmail,
                    CompanyName = addHealthViewModel.CompanyName,
                    Designation = addHealthViewModel.Designation,
                    BusinessNumber = addHealthViewModel.BusinessNumber,
                    LicensePlate = addHealthViewModel.LicensePlate,
                    NricFinNumber = addHealthViewModel.NricFinNumber,
                    Quarantine = addHealthViewModel.Quarantine,
                    Contact = addHealthViewModel.Contact,
                    FeverFluSymptoms = addHealthViewModel.FeverFluSymptoms,
                    OnlineForm = addHealthViewModel.OnlineForm,
                };
                await _context.Health.AddAsync(health);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var health = await _context.Health.FirstOrDefaultAsync(x => x.Id == id);   
            
            if(health != null)
            {
                var viewModel = new UpdateHealthViewModel()
                {
                    Id = health.Id,
                    Name = health.Name,
                    BusinessEmail= health.BusinessEmail,
                    CompanyName = health.CompanyName,
                    Designation = health.Designation,
                    BusinessNumber= health.BusinessNumber,
                    LicensePlate = health.LicensePlate,
                    NricFinNumber= health.NricFinNumber,
                    Quarantine= health.Quarantine,
                    Contact = health.Contact,
                    FeverFluSymptoms = health.FeverFluSymptoms,
                    OnlineForm = health.OnlineForm,
                };
                return await Task.Run (() =>View("View",viewModel));
            }
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateHealthViewModel model)
        {
            var health = await _context.Health.FindAsync(model.Id);
            if(health != null)
            {
                health.Name= model.Name;
                health.BusinessEmail= model.BusinessEmail;
                health.CompanyName= model.CompanyName;
                health.Designation= model.Designation;
                health.BusinessNumber= model.BusinessNumber;
                health.LicensePlate= model.LicensePlate;
                health.NricFinNumber= model.NricFinNumber;
                health.Quarantine   = model.Quarantine;
                health.Contact = model.Contact;
                health.FeverFluSymptoms = model.FeverFluSymptoms;
                health.OnlineForm = model.OnlineForm;

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateHealthViewModel model)
        {
            var health = await _context.Health.FindAsync(model.Id);
            if(health != null)
            {
                _context.Health.Remove(health);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
