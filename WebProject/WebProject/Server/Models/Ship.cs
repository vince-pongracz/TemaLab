using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Server.Models
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
        [Column(TypeName = "decimal(18,2)")]
        public decimal PriceAtWeekDays { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PriceAtWeekEnds { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Caution { get; set; }
        public int PersonId { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsDeleted { get; set; }
    }
}
