using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Server.Models
{
    public class Reservation
    {
        public Reservation()
        {
            Ship = new Ship();
            Person = new ApplicationUser();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        [Required]
        public DateTime ToDate { get; set; }

        public Ship Ship { get; set; }

        public ApplicationUser Person { get; set; }
    }
}
