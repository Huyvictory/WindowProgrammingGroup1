using AnotherTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherTest.Controllers
{
    class BookController
    {
        public static bool addBook(Document book)
        {
            try
            {
                using (var _context = new DBReadingProgramEntities())
                {
                    _context.Documents.Add(book);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static Document getExistBook(string booklink)
        {
            using (var _context = new DBReadingProgramEntities())
            {
                var book = from u in _context.Documents
                           where u.link == booklink
                           select u;
                if (book.Count() == 1)
                {
                    return book.Single();
                }
                else return null;
            }
        }
        public static bool checkExistBook(string booklink)
        {
            using (var _context = new DBReadingProgramEntities())
            {
                var book = from u in _context.Documents
                           where u.link == booklink
                           select u;
                if (book.Count() == 1)
                {
                    return true;
                }
                else return false;
            }
        }
        public static List<Document> GetallBooks()
        {
            using (var _context = new DBReadingProgramEntities())
            {
                var book = (from u in _context.Documents.AsEnumerable()
                            select new
                            {
                                link = u.link,
                                bookname = u.bookname,
                                photolink = u.photolink,
                                photo = u.photo,
                                type = u.type                               
                              
                            }).Select(x => new Document
                            {
                                link = x.link,
                                bookname = x.bookname,
                                photo = x.photo,
                                type = x.type 
                            });
                return book.ToList();
            }
        }
        public static byte[] Converttobinary(string stringtoconvert)
        {
            byte[] data = null;
            FileInfo info = new FileInfo(stringtoconvert);
            long numBytes = info.Length;
            FileStream fstream = new FileStream(stringtoconvert, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            data = br.ReadBytes((int)numBytes);
            return data;
        }
    }
}
