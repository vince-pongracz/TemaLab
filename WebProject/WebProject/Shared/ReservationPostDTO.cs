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

        public int ShipId { get; set; }

        public virtual ShipDTO Ship { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUserDTO Person { get; set; }
    }
}
