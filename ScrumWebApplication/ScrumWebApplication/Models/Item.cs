using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScrumWebApplication.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public bool TakenOver { get; set; }
    }
}