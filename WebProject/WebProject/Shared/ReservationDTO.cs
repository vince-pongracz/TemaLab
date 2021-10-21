using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Shared
{
    public class ReservationDTO
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public ShipDTO Ship { get; set; }

        public ApplicationUserDTO Person { get; set; }
    }
}
