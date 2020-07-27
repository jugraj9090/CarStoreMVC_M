using CarStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarStoreMVC.Controllers
{
    public class StaffController : Controller
    {
        CarStoreEntities carData = new CarStoreEntities();


        // GET: CarStore
        public ActionResult StaffList()
        {
            return View(carData.StaffRecords.ToList());
        }

        // GET: CarStore/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarStore/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarStore/Create
        [HttpPost]
        public ActionResult Create(StaffRecord staffRecord)
        {
            if (!ModelState.IsValid)
                return View();
            carData.StaffRecords.Add(staffRecord);
            carData.SaveChanges();
            
            return RedirectToAction("StaffList");
        }

        // GET: CarStore/Edit/5
        public ActionResult Edit(int id)
        {

            var IdToEdit = (from m in carData.StaffRecords where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: CarStore/Edit/5
        [HttpPost]
        public ActionResult Edit(StaffRecord staffRecord)
        {

            var orignalRecord = (from m in carData.StaffRecords where m.id == staffRecord.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            carData.Entry(orignalRecord).CurrentValues.SetValues(staffRecord);

            carData.SaveChanges();
            return RedirectToAction("StaffList");
        }

        // GET: CarStore/Delete/5
        public ActionResult Delete(CarRecord staffRecord)
        {
            var d = carData.StaffRecords.Where(x => x.id == staffRecord.Id).FirstOrDefault();
            carData.StaffRecords.Remove(d);
            carData.SaveChanges();
            return RedirectToAction("StaffList");
        }



        // POST: Staff/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
