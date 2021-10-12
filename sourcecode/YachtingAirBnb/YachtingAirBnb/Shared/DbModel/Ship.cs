using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YachtingAirBnb.Shared.DbModel
{
    public class Ship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Lenght { get; set; }
        public int ProductionYear { get; set; }
        public string HomePort { get; set; }
        public double Weight { get; set; }
        public int PersonsMax { get; set; }
        public string ShipType { get; set; }

        //merülés
        public double Drought { get; set; }

        public double Width { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public decimal PriceAtWeekDays { get; set; }
        public decimal PriceAtWeekEnds { get; set; }
        public decimal Caution { get; set; }
        public int PersonId { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsDeleted { get; set; }
    }
}
