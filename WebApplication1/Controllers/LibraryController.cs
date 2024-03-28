using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LibraryController : Controller
    {
        // GET: Library
        LibraryRepository MyLibraryrepository = new LibraryRepository();

        // GET: Resume
        public ActionResult Index()
        {
            var data = MyLibraryrepository.GetList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            LibraryMangementSystem book = new LibraryMangementSystem();

            book.BookInformation.Add(new BookInfo());
            book.BookInformation.Add(new BookInfo());
            book.BookInformation.Add(new BookInfo());
            book.BookInformation.Add(new BookInfo());
            book.BookInformation.Add(new BookInfo());

            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LibraryMangementSystem library)
        {

            if (ModelState.IsValid)
            {
                MyLibraryrepository.AddingInformation(library);




               return RedirectToActionPermanent("Index");
              
            }



            return View(library);
        }


        [HttpGet]
        public ActionResult Edit(Guid id)
        {

            var applicant = MyLibraryrepository.Get(id);



            return View(applicant);
        }
        [HttpPost]
        public ActionResult Edit(LibraryMangementSystem student)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    MyLibraryrepository.UpdateInformation(student);
                    TempData["Message"] = $"Student Name: {student.StudentName} updated successfully";
                    return RedirectToActionPermanent("Index");
                }

            }
            catch (Exception)
            {


            }


            return View(student);
        }
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var dltInfo = MyLibraryrepository.GetStudentInfobyId(id);
            return View(dltInfo);
        }
        [HttpPost]
        public ActionResult Delete(LibraryMangementSystem deleteInfo)
        {
            MyLibraryrepository.DeleteStudent(deleteInfo);
            TempData["Message"] = $"Student Name {deleteInfo.StudentName} Delete successfully";
            return RedirectToActionPermanent("Index");
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var student = MyLibraryrepository.Get(id);



            return View(student);




        }
    }
}