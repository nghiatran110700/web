using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.DTO
{
    public class ProductDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal? pirce { get; set; }
        public int? amount { get; set; }
        public string description { get; set; }
        public string photo { get; set; }
        public int? idcategory { get; set; }
        public string cateName { get; set; }
    }
}