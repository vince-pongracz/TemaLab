using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YachtingAirBnb.Shared.DbModel
{
    public class Ranking
    {
        public int Id { get; set; }

        public int PersonID { get; set; }

        public int Stars { get; set; }
        public int ShipId { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}
