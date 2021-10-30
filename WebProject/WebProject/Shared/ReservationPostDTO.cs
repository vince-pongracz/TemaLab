using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Shared
{
    public class ReservationPostDTO
    {
        public int Id { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public ShipDTO Ship { get; set; }

        public ApplicationUserDTO Person { get; set; }
    }
}
