using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebProject.Shared
{
    public class ReservationGetDTO
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int ShipId { get; set; }
        [JsonIgnore]
        public virtual ShipDTO Ship { get; set; }

        public string ApplicationUserId { get; set; }
        [JsonIgnore]
        public virtual ApplicationUserDTO Person { get; set; }

        public bool ReservationApproved { get; set; } = false;
    }
}
