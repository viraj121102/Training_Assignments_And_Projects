using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace HRISApp.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly DepartmentService _Service;
        private readonly IServiceClass<Department> _context;
        public DepartmentsController(DepartmentService service, IServiceClass<Department> context)
        {
            _Service = service;
            _context = context;
        }
        // GET: DepartmentsController
        public ActionResult Index()
        {
            //List<Department> deptLsit = _Service.GetDepartments();
            // using generic service class
            List<Department> deptLsit2 = _context.GetList().ToList();
            return View(deptLsit2);
        }

        // GET: DepartmentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department dept)
        {
            try
            {
                
                    TempData["message"] = _Service.AddDepartment(dept);
                    return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartmentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartmentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
