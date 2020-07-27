using CarStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarStoreMVC.Controllers
{
    public class HomeController : Controller
    {
        CarStoreEntities carData = new CarStoreEntities();

        public ActionResult QueryList()
        {
            return View(carData.ContactRecords.ToList());
        }


        // GET: Purchase/Delete/5
        public ActionResult Delete(ContactRecord IdtoDel)
        {
            var d = carData.ContactRecords.Where(x => x.ID == IdtoDel.ID).FirstOrDefault();
            carData.ContactRecords.Remove(d);
            carData.SaveChanges();
            return RedirectToAction("QueryList");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Admin_Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Admin_Dashboard()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Invalid_Details()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        public ActionResult Verification(Login data)
        {


            // String query = "select * from AdminDetails where AdminName='" + data.txt_Name + "' ";
            String query = "select * from LoginRecord where UserName='" + data.txt_Name + "' And UserPassword='" + data.txt_Password + "'";
            DataTable tbl = new DataTable();
            tbl = data.SrchLogin(query);

            if (tbl.Rows.Count > 0)
            {
                return View("Admin_Dashboard");
            }
            else
            {
                return View("Invalid_Details");
            }

        }


        [HttpPost]
        public ActionResult Message(contact data)
        {

            //get the value from the user to pass in the database 

            Login obj = new Login();

            String query = "insert into ContactRecord(Name,Email,Contact,Message) values('" + data.txt_Name + "','" + data.txt_Email + "','" + data.txt_Contact + "','" + data.txt_Msg + "')";

            obj.sendfeedback(query);

            return View("QueryFeedBack");


        }



        public ActionResult QueryFeedBack()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}