using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenShiftHRapp.Models;
using System.Threading.Tasks;





namespace OpenShiftHRapp.Controllers
{
    public class EmpController : Controller
    {
        private readonly EmpContext _context;

        public EmpController(EmpContext context)
        {
            _context = context;
        }

        // GET: Emp
        public async Task<IActionResult> Index()
        {
            return View(await _context.Emps.ToListAsync());
        }


        // GET: Emp/Create
        public IActionResult AddOrEdit(int EmpId = 0)
        {
            if (EmpId == 0)
                return View(new Emp());
            else
                return View(_context.Emps.Find(EmpId));
        }

        // POST: Emp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("EmpId,Name,EmailId,Department,Location")] Emp emp)
        {
            if (ModelState.IsValid)
            {
                if (emp.EmpId == 0)
                    _context.Add(emp);
                else
                    _context.Update(emp);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emp);
        }

        // GET: Emp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var emp = await _context.Emps.FindAsync(id);
            _context.Emps.Remove(emp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
