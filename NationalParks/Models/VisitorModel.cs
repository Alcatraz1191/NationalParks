using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class VisitorModel
    {
        public class Visitor
        {
            public string latLong { get; set; }
            public string description { get; set; }
            public string parkCode { get; set; }
            public string id { get; set; }
            public string directionsInfo { get; set; }
            public string directionsUrl { get; set; }
            public string url { get; set; }
            public string name { get; set; }
        }


        public class Visitors
        {
            public string total { get; set; }
            public List<VisitorModel> data { get; set; }
            public string limit { get; set; }
            public string start { get; set; }
        }
    }
}
