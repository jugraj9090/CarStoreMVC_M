using CarStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarStoreMVC.Controllers
{
    public class SaleController : Controller
    {
        CarStoreEntities carData = new CarStoreEntities();


        // GET: CarStore
        public ActionResult SaleList()
        {
            return View(carData.SaleRecords.ToList());
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
        public ActionResult Create(SaleRecord saleRecord)
        {
            if (!ModelState.IsValid)
                return View();
            carData.SaleRecords.Add(saleRecord);
            carData.SaveChanges();

            return RedirectToAction("SaleList");
        }

        // GET: CarStore/Edit/5
        public ActionResult Edit(int id)
        {

            var IdToEdit = (from m in carData.SaleRecords where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: CarStore/Edit/5
        [HttpPost]
        public ActionResult Edit(SaleRecord saleRecord)
        {

            var orignalRecord = (from m in carData.SaleRecords where m.id == saleRecord.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            carData.Entry(orignalRecord).CurrentValues.SetValues(saleRecord);

            carData.SaveChanges();
            return RedirectToAction("SaleList");
        }

        // GET: CarStore/Delete/5
        public ActionResult Delete(SaleRecord saleRecord)
        {
            var d = carData.SaleRecords.Where(x => x.id == saleRecord.id).FirstOrDefault();
            carData.SaleRecords.Remove(d);
            carData.SaveChanges();
            return RedirectToAction("StaffList");
        }




        // POST: Sale/Delete/5
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
