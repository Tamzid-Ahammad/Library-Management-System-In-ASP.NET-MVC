using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class LibraryRepository
    {
        static List<LibraryMangementSystem> MyLibrary = new List<LibraryMangementSystem>();
        public LibraryRepository()
        {
            if (MyLibrary.Count == 0)
            {
                for (int i = 1; i <= 2; i++) 
                {
                    LibraryMangementSystem m = new LibraryMangementSystem();
                    m.StudentName = "Student "+i.ToString();
                    m.DaysforBookBorrowed = 1 + i;
                    m.BookInformation.Add(new BookInfo()
                    {
                        BookName = "Harry",
                        AuthorName = "hanry",
                        BookExistingArea = "C3",
                        BookBorrowingPrice = 150
                    });
                    m.BookInformation.Add(new BookInfo()
                    {
                        BookName = "MartialPeak",
                        AuthorName = "Yang Kai",
                        BookExistingArea = "D1",
                        BookBorrowingPrice = 350
                    });
                    MyLibrary.Add(m);
                }
              


            }
        }
        public List<LibraryMangementSystem> GetList()
        {

            return MyLibrary;
        }

        internal LibraryMangementSystem Get(Guid id)
        {
            return MyLibrary.Find(m => m.LibraryId == id);
        }

        internal void AddingInformation(LibraryMangementSystem student)
        {
            MyLibrary.Add(student);
        }
        public void UpdateInformation(LibraryMangementSystem s)
        {


            var idx = MyLibrary.FindIndex(_ => _.LibraryId == s.LibraryId);
            if (idx == -1) return;
            MyLibrary[idx] = s;

        }

        public void DeleteStudent(LibraryMangementSystem book)
        {
            var dlt = (MyLibrary.FindIndex(i => i.LibraryId == book.LibraryId));
            if (dlt == -1) return;
            MyLibrary.RemoveAt(dlt);
        }

        public LibraryMangementSystem GetStudentInfobyId(Guid Id)
        {
            return MyLibrary.Find(p => p.LibraryId == Id);
        }
    }
}