using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using school_manegment_system.datacontext;
using school_manegment_system.Models;
using Microsoft.AspNetCore.Http; // Add this namespace
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

public class parentController : Controller
{
    private readonly database _context;
    int i; 

    public parentController(database context)
    {
        _context = context;
    }

    // GET: parent/Login
    public IActionResult Login()
    {
        return View();
    }

    // POST: parent/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(school model)
    {
        var data = await _context.school.FirstOrDefaultAsync(s => s.Name == model.Name && s.studentpasskey == model.studentpasskey);
        if (data == null)
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt. Please try again.");
            return View(model);
        }

        HttpContext.Session.SetString("user_id", data.Id.ToString());
        i = data.Id;
        return RedirectToAction("Details", new { id = i });
    }

    // GET: parent/About


    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.school == null)
        {
            return NotFound();
        }

        var school = await _context.school
            .FirstOrDefaultAsync(m => m.Id == id);
        if (school == null)
        {
            return NotFound();
        }

        return View(school);








    }




    public IActionResult Logout()
    {
        // Sign the user out here (e.g., clear authentication cookies, session data, etc.)
        HttpContext.SignOutAsync(); // This is a common method for signing the user out

        return RedirectToAction("Login"); // Redirect to the login page or any other desired page after logout
    }

    // ... Other controller actions
}
