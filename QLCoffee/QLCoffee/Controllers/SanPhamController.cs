using QLCoffee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLCoffee.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        QuanLyQuanCoffeeEntities database = new QuanLyQuanCoffeeEntities();
        public ActionResult Index()
        {
            return View(database.SANPHAMs.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SANPHAM sanpham)
        {
            database.SANPHAMs.Add(sanpham);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            return View(database.SANPHAMs.Where(s => s.MaSP == id).FirstOrDefault());
        }
        public ActionResult Edit(string id)
        {
            return View(database.SANPHAMs.Where(s => s.MaSP == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(string id, SANPHAM sanpham)
        {
            database.Entry(sanpham).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            return View(database.SANPHAMs.Where(s => s.MaSP == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(string id, SANPHAM sanpham)
        {
            sanpham = database.SANPHAMs.Where(s => s.MaSP == id).FirstOrDefault();
            database.SANPHAMs.Remove(sanpham);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}