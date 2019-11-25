using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NationalParks.Models
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
    [NotMapped]
   public class VisitorModel
    {
        public string total { get; set; }
        public List<Visitor> data { get; set; }
        public string limit { get; set; }
        public string start { get; set; }
    }
}