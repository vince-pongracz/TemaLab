using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebProject.Server.Models
{
    public class Ship
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Name must be at least 2 Characters and maximum 15 characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Range(1, 100, ErrorMessage = " Length must be between 1 and 100 meters")]
        public double Length { get; set; }

        [Range(1900, 2050, ErrorMessage = " Year must be between 1900 and 2050")]
        public int ProductionYear { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Port name must be at least 2 Characters and maximum 20 characters", MinimumLength = 2)]
        public string HomePort { get; set; }

        [Range(50, 20000, ErrorMessage = " Weight must be between 50 and 20000 kgs")]
        public double Weight { get; set; }

        [Required]
        [Range(1, 50, ErrorMessage = " Number of max people must be between 1 and 50 kgs")]
        public int MaxPeople { get; set; }

        [MaxLength(20, ErrorMessage = "Maximum 20 characters are allowed")]
        public string ShipType { get; set; }

        [Range(0, 15, ErrorMessage = " Draught must be between 0 and 15 meters")]
        public double Draught { get; set; }//merülés

        [Range(1, 50, ErrorMessage = " Width must be between 1 and 50 meters")]
        public double Width { get; set; }

        [MaxLength(1000, ErrorMessage = "Maximum 1000 characters are allowed")]
        public string Description { get; set; }

        [MaxLength(20, ErrorMessage = "Maximum 20 characters are allowed")]
        public string Manufacturer { get; set; }

        [Required]
        [Range(5000, 500000, ErrorMessage = "Price must be between 5000 and 500000")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PriceAtWeekDays { get; set; }

        [Required]
        [Range(5000, 500000, ErrorMessage = "Price must be between 5000 and 500000")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PriceAtWeekEnds { get; set; }

        [Required]
        [Range(10000, 1000000, ErrorMessage = "Price must be between 10000 and 1000000")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Caution { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [JsonIgnore]
        public virtual ICollection<Reservation> Reservations { get; set; }

        public string OwnerId { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser Owner { get; set; }

        [JsonIgnore]
        public virtual ICollection<Ranking> Rankings { get; set; }

        public int ImageId { get; set; }

    }
}
