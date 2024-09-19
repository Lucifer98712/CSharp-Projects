using EFCoreEg.Repositories;
using Microsoft.AspNetCore.Mvc;
using EFCoreEg.Models;
using Microsoft.Data.SqlClient;

namespace EFCoreEg.Controllers
{
    public class ProductController : Controller
    {
       IRepository<Product> _repo = null;

        public ProductController(IRepository<Product> repo)
        {
            _repo = repo;
        }

        //GET: ProductController

        public ActionResult Index()
        {
            return View(_repo.GetAllRecords());
        }

        // GET: ProductController/Details/S

        public ActionResult Details(int id) 
        {
            return View(_repo.GetSingleRecord(id));
        }

        // GET: ProductController/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        public ActionResult Create(Product prod) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.AddRecord(prod);
                    return Content("Record has been inserted !");
                }
                else
                {
                    return View(prod);
                }
            }
            catch (SqlException ex) 
            {
                return Content("Something wrong" + ex.Message);
            }
        }

        // GET: ProductController/Edit/S

        public ActionResult Edit(int id) 
        {
            return View();
        }

        // POST: ProductController/Edit/S

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product prod)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.UpdateRecord(prod);
                    return Content("Record has been edited !");
                }
                else
                {
                    return View(prod);
                }
            }
            catch (SqlException ex)
            {
                return Content("Something wrong " + ex.Message);
            }

        }

        // GET: ProductController/Delete/S

        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/S

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product prod)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.DeleteRecord(prod);
                    return Content("Record has been deleted !");
                }
                else
                {
                    return View(prod);
                }
            }
            catch (SqlException ex)
            {
                return Content("Something wrong " + ex.Message);
            }

        }
    }
}
