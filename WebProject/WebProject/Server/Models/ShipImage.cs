using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebProject.Server.Models
{
    public class ShipImage
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int ShipId { get; set; }

        [Required]
        public string RouteToPic { get; set; }

        [MaxLength(30, ErrorMessage ="Title too long, max 30 characters")]
        public string ImageTitle { get; set; }

        [MaxLength(200, ErrorMessage = "Title too long, max 200 characters")]
        public string ImageDescription { get; set; }

    }
}
