using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeakerShop.Models
{
    public class PageList
    {
        public IEnumerable<Speaker> Speakers { get; set; }
        public PageInfo pageInfo { get; set; }
        public string Currentcategory { get; set; }
        public string SortCat { get; set; }
    }
}