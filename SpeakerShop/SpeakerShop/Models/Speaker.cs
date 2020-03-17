using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeakerShop.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        public string SpeakerCategory { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public string AcousticsFormat { get; set; }
        public string Img { get; set; }
        public string FrequencyRange { get; set; }
        public string Protection { get; set; }
        public int BatteryCapaсity { get; set; }
        public int Power { get; set; }
        public int Avaliable { get; set; }
        public string Color { get; set; }
        public string Dimensions { get; set; }
        public int Weight { get; set; }
        public string Kit { get; set; }
        public int Guarantee { get; set; }
    }
}