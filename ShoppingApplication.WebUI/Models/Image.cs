using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingApplication.WebUI.Models
{
    public class Image
    {
        public int Id { get; set; }
        public String URL { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
    }
}