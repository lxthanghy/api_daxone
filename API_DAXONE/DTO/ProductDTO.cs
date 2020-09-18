using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_DAXONE.DTO
{
    public class ProductDTO
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public string Frame { get; set; }
        public string Rims { get; set; }
        public string Tires { get; set; }
        public string Weight { get; set; }
        public string WeightLimit { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}