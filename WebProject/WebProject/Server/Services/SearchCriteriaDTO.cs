using Microsoft.AspNetCore.Mvc;
using System;
using System.Runtime.Serialization;

namespace WebProject.Server.Services
{
    public class SearchCriteriaDTO
    {
        [FromQuery(Name = "from")]
        public DateTime? From { get; set; }

        [FromQuery(Name = "until")]
        public DateTime? Until { get; set; }
        [FromQuery(Name = "maxPersons")]
        public int? MaxPersons { get; set; }
        [FromQuery(Name = "where")]
        public string Port { get; set; }
    }
}
