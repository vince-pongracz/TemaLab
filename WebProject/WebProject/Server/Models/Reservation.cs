using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Server.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public Ship Ship { get; set; }

        public ApplicationUser Person { get; set; }
    }
}
