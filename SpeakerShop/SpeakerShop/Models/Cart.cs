using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeakerShop.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string CartBrand { get; set; }
        public string CartModel { get; set; }
        public string CartImg { get; set; }
        public string CartColor { get; set; }
        public int CartPrice { get; set; }
    }
}