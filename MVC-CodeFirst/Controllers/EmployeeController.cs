using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_CodeFirst.Domain;
using MVC_CodeFirst.Models.ViewModels;
using MVC_CodeFirst.Persistence;

namespace MVC_CodeFirst.Controllers;

public class EmployeeController : Controller
{
    private readonly DatabaseContext _context;

    public EmployeeController(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Employees.Include(x => x.User).ToListAsync());
    }

    public IActionResult Create()
    {
        ViewData["Users"] = new SelectList(_context.Users, "UserId", "Fullname");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(EmployeeViewModel model)
    {
        if (ModelState.IsValid)
        {
            var employee = new Employee()
            {
                Charge = model.Charge,
                Department = model.Department,
                Salary = model.Salary,
                FinishTime = model.FinishTime,
                StartedAt = model.StartedAt,
                UserId = model.UserId
            };
            _context.Add(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["Users"] = new SelectList(_context.Users, "UserId", "Fullname", model.UserId);
        return View();
    }
    
    
    public async Task<IActionResult> Edit(int employeeId)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
        if (employee == null)
        {
            return NotFound();
        }
        var users = await _context.Users.ToListAsync();
        ViewData["Users"] = new SelectList( users, "UserId", "Fullname", employee.UserId);
        
        var model = new EmployeeViewModel()
        {
            Charge = employee.Charge,
            Department = employee.Department,
            Salary = employee.Salary,
            FinishTime = employee.FinishTime,
            StartedAt = employee.StartedAt,
            UserId = employee.UserId,
            EmployeeId = employee.EmployeeId
        };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EmployeeViewModel model)
    {
        if (ModelState.IsValid)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == model.EmployeeId);

            if (employee == null)
            {
                return NotFound();
            }
            employee.Charge = model.Charge;
            employee.Department = model.Department;
            employee.Salary = model.Salary;
            employee.UserId = model.UserId;
            employee.FinishTime = model.FinishTime;
            employee.StartedAt = model.StartedAt;
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["Users"] = new SelectList(_context.Users, "UserId", "Fullname", model.UserId);
        return View();
    }
    
    public async Task<ActionResult> Delete(int? employeeId)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(x => x.UserId == employeeId);
        if (employee == null)
        {
            return NotFound();
        }
        var model = new EmployeeViewModel()
        {
            Charge = employee.Charge,
            Department = employee.Department,
            Salary = employee.Salary,
            FinishTime = employee.FinishTime,
            StartedAt = employee.StartedAt,
            UserId = employee.UserId,
            EmployeeId = employee.EmployeeId
        };
        var users = await _context.Users.ToListAsync();
        ViewData["Users"] = new SelectList( users, "UserId", "Fullname", employee.UserId);
       
        return View(model);
    }
    
    [HttpPost,ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int employeeId)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);

        if (employee == null)
        {
            return NotFound();
        }
        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}