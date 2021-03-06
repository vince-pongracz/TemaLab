using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebProject.Shared
{
    public class ShipDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Length { get; set; }

        public int ProductionYear { get; set; }

        public string HomePort { get; set; }

        public double Weight { get; set; }

        public int MaxPeople { get; set; }

        public string ShipType { get; set; }

        public double Draught { get; set; } //merülés

        public double Width { get; set; }

        public string Description { get; set; }

        public string Manufacturer { get; set; }

        public decimal PriceAtWeekDays { get; set; }

        public decimal PriceAtWeekEnds { get; set; }

        public decimal Caution { get; set; }

        public bool IsAvailable { get; set; }

        public string OwnerId { get; set; }

        [JsonIgnore]
        public virtual ApplicationUserDTO Owner { get; set; }

        [JsonIgnore]
        public virtual ICollection<ReservationGetDTO> Reservations { get; set; }
        [JsonIgnore]
        public virtual ICollection<RankingDTO> Rankings { get; set; }
        
        public string RouteToPic { get; set; }
    }
}
