using ASPInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPInventory.Controllers
{
    public class FrontendController : Controller
    {
        // GET: Frontend
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Webdev()
        {
            return View();
        }

        public ActionResult Mobiledev()
        {
            return View();
        }

        public ActionResult Graphic()
        {
            return View();
        }

        // เรียกแสดงแบบฟอร์มลงทะเบียน
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // Submit แบบฟอร์มลงทะเบียน POST Action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            string message = "";

            // ตรวจสอบว่า Validation ผ่านแล้ว
            if (ModelState.IsValid)
            {

                // บันทึกลงตารางในฐานข้อมูล
                using (ASPInventoryDBEntities db = new ASPInventoryDBEntities())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    ModelState.Clear(); // Reset และ Clear ข้อมูลในฟอร์ใ
                    message = "<div class=\"alert alert-success\">ลงทะเบียนเรียบร้อยแล้ว</div>";
                    // Redirect ไปหน้า Login
                    return RedirectToAction("Login", "Frontend");
                }

            }
            else
            {
                message = "<div class=\"alert alert-danger\">ป้อนข้อมูลให้ครบก่อน</div>";
            }

            ViewBag.Message = message;
            return View();

        }

        public ActionResult Registeruser()
        {
            return View();
        }

        // เรียกแสดงแบบฟอร์มลงเข้าสุ่ระบบ
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // Submit แบบฟอร์มเข้าสุ่ระบบ POST Action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            string message = "";

            // ตรวจสอบว่า Validation ผ่านแล้ว
            if (user.EmailID != null && user.Password != null)
            {
                using (ASPInventoryDBEntities db = new ASPInventoryDBEntities())
                {
                    var query = db.Users.Where(u => u.EmailID == user.EmailID).FirstOrDefault();
                    if (query != null)
                    {
                        if (string.Compare(user.Password, query.Password) == 0)
                        {
                            // เก็บข้อมูลลง session ไว้ตรวจใน Controller Backend
                            Session["Email"] = query.EmailID;
                            Session["Firstname"] = query.FirstName;
                            Session["LastName"] = query.LastName;

                            return RedirectToAction("Dashboard", "Backend");
                        }
                        else
                        {
                            message = "<div class=\"alert alert-danger\">ป้อนรหัสผ่านไม่ถูกต้อง</div>";
                        }
                    }
                    else
                    {
                        message = "<div class=\"alert alert-danger\">ไม่พบอีเมล์นี้</div>";
                    }
                }
            }
            else
            {
                message = "<div class=\"alert alert-danger\">ป้อนข้อมูลให้ครบก่อน</div>";
            }

            ViewBag.Message = message;
            return View();

        }
    }
}