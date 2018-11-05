using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiQuest.Models;

namespace WebApiQuest.Controllers
{
    public class ValuesController : ApiController
    {
        AppDbContext db = new AppDbContext();
        // GET api/values
        public IEnumerable<Purchase> Get()
        {
            return db.Purchases;
        }

        public Purchase GetPurchase(int id)
        {
            Purchase purchase = db.Purchases.Find(id);
            return purchase;

        }
        [HttpPost]
        public void CreatePurchese([FromBody] Purchase purchase)
        {
            purchase.LastDateOrder = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
        }
        [HttpPut]
        public void EditPurchase(int id, [FromBody] Purchase purchase)
        {
            if (id == purchase.PurchaseId)
            {
                db.Entry(purchase).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        public void DeletePurchse(int id)
        {
            Purchase purchase = db.Purchases.Find(id);
            if (purchase != null)
            {
                db.Purchases.Remove(purchase);
                db.Entry(purchase).State = EntityState.Deleted;
                db.SaveChanges();
            }

        }
    }
}
