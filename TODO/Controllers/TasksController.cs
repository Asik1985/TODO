
using TODO.Web.Data;
using TODO.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace TODO.Web.Controllers;

public class TasksController : Controller
{
    private readonly TODOContext _db;

    public TasksController(TODOContext db)
    {
        _db = db;
    }

    // GET: /Tasks/Index
    public ActionResult Index()
    {
        IEnumerable<Task> tasks = _db.Tasks.ToList();
        return View(tasks);
    }


    // GET: Tasks/Details/5
    public ActionResult Details(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }
        var task = _db.Tasks.FirstOrDefault(m => m.Id == id);
        if (task is null)
        {
            return NotFound();
        }

        return View(task);
    }



    // GET: Tasks/Create
    public IActionResult Create()
    {
        ViewBag.Tasks = new SelectList(_db.Tasks.Where(x => x.ParentId == 0), "Id", "Name");
        return View();
    }

    // POST: Tasks/Create
    [HttpPost]
    public IActionResult Create(Task task)
    {
        if (ModelState.IsValid)
        {
            _db.Add(task);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(task);
    }



    // GET: Tasks/Edit/5
    public ActionResult Edit(int id)
    {
        var task = _db.Tasks.Find(id);
        if (task == null)
        {
            return NotFound();
        }
        return View(task);
    }

    // POST: Tasks/Edit/5
    [HttpPost]
    public IActionResult Edit(int id, Task task)
    {
        if (id != task.Id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            _db.Update(task);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(task);
    }


    // GET: Tasks/Delete/5
    public IActionResult Delete(int id)
    {
        var task = _db.Tasks.FirstOrDefault(m => m.Id == id);
        if (task == null)
        {
            return NotFound();
        }

        return View(task);
    }

    // POST: Tasks/DeleteConfirmed/5
    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        var task = _db.Tasks.Find(id);
        if (task != null)
        {
            _db.Tasks.Remove(task);
            _db.SaveChanges();
        }
        return RedirectToAction("Index");
    }




}
