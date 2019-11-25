using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NationalParks.Models
{
    public class Park
    {
        //public string CampgroundsID { get; set; }
        public string VisitorsID { get; set; }
        public string states { get; set; }
        public string latLong { get; set; }
        public string description { get; set; }
        public string designation { get; set; }
        public string parkCode { get; set; }
        public string id { get; set; }
        public string directionsInfo { get; set; }
        public string directionsUrl { get; set; }
        public string fullName { get; set; }
        public string url { get; set; }
        public string weatherInfo { get; set; }
        public string name { get; set; }
        public virtual Visitor Visitors { get; set; }

    }
    [NotMapped]
    public class ParksModel
    {
        public string total { get; set; }
        public List<Park> data { get; set; }
        public string limit { get; set; }
        public string start { get; set; }
    }

}