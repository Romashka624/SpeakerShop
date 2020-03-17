using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SpeakerShop.Models
{
    public class SpeakerContext : DbContext
    {
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}