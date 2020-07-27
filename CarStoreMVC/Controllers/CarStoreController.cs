using CarStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarStoreMVC.Controllers
{
    public class CarStoreController : Controller
    {
        CarStoreEntities carData = new CarStoreEntities();


        // GET: CarStore
        public ActionResult CarList()
        {
            return View(carData.CarRecords.ToList());
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
        public ActionResult Create(CarRecord carRecord)
        {
            if (!ModelState.IsValid)
                return View();
            carData.CarRecords.Add(carRecord);
            carData.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("CarList");
        }

        // GET: CarStore/Edit/5
        public ActionResult Edit(int id)
        {

            var IdToEdit = (from m in carData.CarRecords where m.Id == id select m).First();
            return View(IdToEdit);
        }

        // POST: CarStore/Edit/5
        [HttpPost]
        public ActionResult Edit(CarRecord carRecord)
        {

            var orignalRecord = (from m in carData.CarRecords where m.Id == carRecord.Id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            carData.Entry(orignalRecord).CurrentValues.SetValues(carRecord);

            carData.SaveChanges();
            return RedirectToAction("CarList");
        }

        // GET: CarStore/Delete/5
        public ActionResult Delete(CarRecord carRecord)
        {
            var d = carData.CarRecords.Where(x => x.Id == carRecord.Id).FirstOrDefault();
            carData.CarRecords.Remove(d);
            carData.SaveChanges();
            return RedirectToAction("CarList");
        }

        // POST: CarStore/Delete/5
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
