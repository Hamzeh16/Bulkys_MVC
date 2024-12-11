using BulkyBookDataAccess.Data;
using BulkyBookDataAccess.Repositray.IRepositray;
using BulkyBookModels.Model;
using BulkyBookModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBookDataAccess.Repositray
{
   public class BookingPage: Repository<BookingPagecs>, IBookingPage
    {
        private AppDbContext _db;
        public BookingPage(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(BookingPagecs obj)
        {
            _db.BookingPages.Update(obj);
        }
    }
}