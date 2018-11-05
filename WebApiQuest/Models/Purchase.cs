using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApiQuest.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }

       
        public int ProductId { get; set; }

        
        public int SizeTableId { get; set; }
        
        public string Name { get; set; }

        public DateTime LastDateOrder { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [ForeignKey("SizeTableId")]
        public SizeTable SizeTable { get; set; }
    }
}