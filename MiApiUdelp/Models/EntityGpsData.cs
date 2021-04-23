using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiApiUdelp.Models
{
    public class EntityGpsData
    {
        public int id { get; set; }
        public string androidId { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public int battery { get; set; }
        public string dateSystem { get; set; }
    }
}