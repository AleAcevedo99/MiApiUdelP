using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiApiUdelp.Models
{
    public class EntityResponse
    {
        public string message { get; set; }
        public EntityGpsData[] values { get; set; }
    }
}