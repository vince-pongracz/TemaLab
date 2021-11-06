using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Shared
{
    public class ApplicationUserDTO
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string FacebookLink { get; set; }

        public string InstagramLink { get; set; }

        public virtual ICollection<RankingDTO> Rankings { get; set; }

        public virtual ICollection<ReservationGetDTO> Reservations { get; set; }

        public virtual ICollection<ShipDTO> OwnedShips { get; set; }
    }
}
