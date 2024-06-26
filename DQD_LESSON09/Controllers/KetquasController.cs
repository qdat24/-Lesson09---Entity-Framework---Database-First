using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DQD_LESSON09.Models;

namespace DQD_LESSON09.Controllers
{
    public class KetquasController : Controller
    {
        private UniversityEntities db = new UniversityEntities();

        // GET: Ketquas
        public ActionResult DQDIndex()
        {
            var ketquas = db.Ketquas.Include(k => k.MonHoc).Include(k => k.SinhVien);
            return View(ketquas.ToList());
        }

        // GET: Ketquas/Details/5
        public ActionResult DQDDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ketqua ketqua = db.Ketquas.Find(id);
            if (ketqua == null)
            {
                return HttpNotFound();
            }
            return View(ketqua);
        }

        // GET: Ketquas/Create
        public ActionResult DQDCreate()
        {
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH");
            ViewBag.MaSV = new SelectList(db.SinhViens, "MaSV", "HoSV");
            return View();
        }

        // POST: Ketquas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DQDCreate([Bind(Include = "MaSV,MaMH,Diem")] Ketqua ketqua)
        {
            if (ModelState.IsValid)
            {
                db.Ketquas.Add(ketqua);
                db.SaveChanges();
                return RedirectToAction("DQDIndex");
            }

            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH", ketqua.MaMH);
            ViewBag.MaSV = new SelectList(db.SinhViens, "MaSV", "HoSV", ketqua.MaSV);
            return View(ketqua);
        }

        // GET: Ketquas/Edit/5
        public ActionResult DQDEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ketqua ketqua = db.Ketquas.Find(id);
            if (ketqua == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH", ketqua.MaMH);
            ViewBag.MaSV = new SelectList(db.SinhViens, "MaSV", "HoSV", ketqua.MaSV);
            return View(ketqua);
        }

        // POST: Ketquas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DQDEdit([Bind(Include = "MaSV,MaMH,Diem")] Ketqua ketqua)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ketqua).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DQDIndex");
            }
            ViewBag.MaMH = new SelectList(db.MonHocs, "MaMH", "TenMH", ketqua.MaMH);
            ViewBag.MaSV = new SelectList(db.SinhViens, "MaSV", "HoSV", ketqua.MaSV);
            return View(ketqua);
        }

        // GET: Ketquas/Delete/5
        public ActionResult DQDDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ketqua ketqua = db.Ketquas.Find(id);
            if (ketqua == null)
            {
                return HttpNotFound();
            }
            return View(ketqua);
        }

        // POST: Ketquas/Delete/5
        [HttpPost, ActionName("DQDDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DQDDeleteConfirmed(int id)
        {
            Ketqua ketqua = db.Ketquas.Find(id);
            db.Ketquas.Remove(ketqua);
            db.SaveChanges();
            return RedirectToAction("DQDIndex");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
