using QuanLyNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanSu.Controllers
{
    public class NhanSuController : Controller
    {
        // GET: NhanSu
        public ActionResult Index()
        {
            ListNhanSu dsnhanvien = new ListNhanSu();
            List<NhanSu> obj = dsnhanvien.getdsns(string.Empty).OrderBy(x => x.HOTEN).ToList();
            return View(obj);
        }
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(NhanSu ns)
        {
            if(ModelState.IsValid)
            {
                ListNhanSu dsnhanvien = new ListNhanSu();
                dsnhanvien.InsertNS(ns);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(string id="")
        {
            ListNhanSu dsnhanvien = new ListNhanSu();
            List<NhanSu> obj = dsnhanvien.getdsns(id);
            return View(obj.FirstOrDefault());
        }
        public ActionResult Edit(string id="")
        {
            ListNhanSu dsnhanvien = new ListNhanSu();
            List<NhanSu> obj = dsnhanvien.getdsns(id);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(NhanSu ns)
        {
            if(ModelState.IsValid)
            {
                ListNhanSu dsnhanvien = new ListNhanSu();
                dsnhanvien.EditNS(ns);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(string id="")
        {
            ListNhanSu dsnhanvien = new ListNhanSu();
            List<NhanSu> obj = dsnhanvien.getdsns(id);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(NhanSu ns)
        {
            if (ModelState.IsValid)
            {
                ListNhanSu dsnhanvien = new ListNhanSu();
                dsnhanvien.DeleteNS(ns);
                return RedirectToAction("Index");
            }
            return View();
        }
        
    }
}