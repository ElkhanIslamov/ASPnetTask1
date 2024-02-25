using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contexts;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;
        public EmployeeController(AppDbContext context)
        {
           _context = context;
        }
        public IActionResult Index()
        {
            List<Employee> employees = _context.Employees.ToList();
            return View(employees);
        }
        public IActionResult Detail(int id)
        {
            //ViewBag.Id = id;
            Employee employee = _context.Employees.FirstOrDefault( x => x.Id == id);
            if (employee == null) 
            return NotFound();

            return View(employee);
        }

        
    }
}
