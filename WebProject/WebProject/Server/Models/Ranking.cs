using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebProject.Shared;

namespace WebProject.Server.Models
{
    public class Ranking
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5 stars")]
        public int Stars { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [StringLength(500, ErrorMessage = "Comment length has to be between 0 and 500 characters")]
        public string Comment { get; set; }

        public string UserId { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }

        public int ShipId { get; set; }

        [JsonIgnore]
        public virtual Ship Ship { get; set; }
    }
}
