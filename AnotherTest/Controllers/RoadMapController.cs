using AnotherTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherTest.Controllers
{
    class RoadMapController
    {
        public static bool DeletefromRM(string bookname)
        {
            using (var _context = new DBReadingProgramEntities())
            {
                var rm = (from u in _context.RoadMaps
                            where u.bookname == bookname
                          select u).FirstOrDefault();
                _context.RoadMaps.Remove(rm);
                _context.SaveChanges();
                return true;
            }
        }
        //public static bool checkExistRoadmap(string bookname)
        //{
        //    using (var _context = new DBReadingProgramEntities())
        //    {
        //        var BookName = from u in _context.RoadMaps
        //                   where u.bookname == bookname
        //                   select u;
        //        if (BookName.Count() == 1)
        //        {
        //            return true;
        //        }
        //        else return false;

        //    }
        //}
        public static List<RoadMap> GetRoadMap()
        {
            using (var _context = new DBReadingProgramEntities())
            {
                var rm = (from u in _context.RoadMaps.AsEnumerable()
                            select new
                            {
                                rmid = u.rmid,
                                username = u.username,
                               link=u.link,
                               bookname=u.bookname,
                               photolink = u.photolink,
                               photo = u.photo,
                               type = u.type
                            }).Select(x => new RoadMap 
                            {
                                rmid = x.rmid,
                                username = x.username,
                                link = x.link,
                               bookname = x.bookname,
                               photolink = x.photolink,
                               photo = x.photo,
                               type = x.type
                            });
                return rm.ToList();
            }
        }
    }
}
