using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.DatabseContext;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class StudentController : Controller
{
    private readonly ApplicationsDbContext context;

    public StudentController(ApplicationsDbContext context)
    {
        this.context = context;
    }
    [HttpGet]
    public async Task<IActionResult>  Index()
    {
        var data=await context.Set<Student>().AsNoTracking().ToListAsync();   
        return View(data);
    }
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(int id)
    {
        if (id==0)
        {
            return View(new Student());
        }
        else
        {
            var data = await context.Set<Student>().FindAsync(id);
            return View(data);
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(int id,Student student)
    {
        if (id==0)
        {
            if (ModelState.IsValid)
            {
                await context.Set<Student>().AddAsync(student);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
        else
        {
            context.Set<Student>().Update(student);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(new Student());
    }
    public async Task<IActionResult> Delete(int id)
    {
        if (id!=0)
        {
            var data=await context.Set<Student>().FindAsync(id);
            if (data is not null)
            {
                context.Set<Student>().Remove(data);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }      
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Details(int id)
    {
        var data = await context.Set<Student>().FindAsync(id);
        return View(data);
    }
}
