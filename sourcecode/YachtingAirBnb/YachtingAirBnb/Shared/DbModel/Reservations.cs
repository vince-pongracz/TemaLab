using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YachtingAirBnb.Shared.DbModel
{
    public class Reservations
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int ShipId { get; set; }
        public int PersonId { get; set; }
    }
}
