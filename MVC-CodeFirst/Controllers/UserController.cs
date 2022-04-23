using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_CodeFirst.Domain;
using MVC_CodeFirst.Models.ViewModels;
using MVC_CodeFirst.Persistence;

namespace MVC_CodeFirst.Controllers;

public class UserController : Controller
{
    private readonly DatabaseContext _context;

    public UserController(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<IActionResult> Index()
    {
        return View(await _context.Users.ToListAsync());
    }
    
    public  IActionResult Create()
    {
        ViewBag.title = "Crear";
        IEnumerable items = new[]
        {
            new { Value = "Single", Text = "Soltero/a"},
            new { Value = "Married", Text = "Casado/a"},
            new { Value = "Divorced", Text = "Divorciado/a"},
            new { Value = "Other", Text = "Otro"}
        };

        ViewData["CivilStatus"] = new SelectList(items, "Value", "Text");
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(UserViewModel model)
    {
        ViewBag.title = "Crear";
        if (ModelState.IsValid)
        {
            var user = new User()
            {
                Address = model.Address,
                Email = model.Email,
                Fullname = model.Fullname,
                CivilStatus = model.CivilStatus,
                PhoneNumber = model.PhoneNumber
            };
            _context.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        IEnumerable items = new[]
        {
            new { Value = "Single", Text = "Soltero/a"},
            new { Value = "Married", Text = "Casado/a"},
            new { Value = "Divorced", Text = "Divorciado/a"},
            new { Value = "Other", Text = "Otro"}
        };

        ViewData["CivilStatus"] = new SelectList(items, "Value", "Text", model.CivilStatus);
        return View();
    }
    
    
    public async Task<IActionResult> Edit(int userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
        if (user == null)
        {
            return NotFound();
        }
        
        IEnumerable items = new[]
        {
            new { Value = "Single", Text = "Soltero/a"},
            new { Value = "Married", Text = "Casado/a"},
            new { Value = "Divorced", Text = "Divorciado/a"},
            new { Value = "Other", Text = "Otro"}
        };
        ViewData["CivilStatus"] = new SelectList(items, "Value", "Text", user.CivilStatus);
        var model = new UserViewModel()
        {
            Address = user.Address,
            Email = user.Email,
            Fullname = user.Fullname,
            CivilStatus = user.CivilStatus,
            PhoneNumber = user.PhoneNumber,
            UserId = user.UserId
        };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UserViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == model.UserId);

            if (user == null)
            {
                return NotFound();
            }
            
            user.Address = model.Address;
            user.Email = model.Email;
            user.Fullname = model.Fullname;
            user.CivilStatus = model.CivilStatus;
            user.PhoneNumber = model.PhoneNumber;
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["Users"] = new SelectList(_context.Users, "UserId", "Fullname", model.UserId);
        return View();
    }
    
    public async Task<ActionResult> Delete(int? userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
        if (user == null)
        {
            return NotFound();
        }
        
        IEnumerable items = new[]
        {
            new { Value = "Single", Text = "Soltero/a"},
            new { Value = "Married", Text = "Casado/a"},
            new { Value = "Divorced", Text = "Divorciado/a"},
            new { Value = "Other", Text = "Otro"}
        };
        ViewData["CivilStatus"] = new SelectList(items, "Value", "Text", user.CivilStatus);
        return View(user);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(int userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);

        if (user == null)
        {
            return NotFound();
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}