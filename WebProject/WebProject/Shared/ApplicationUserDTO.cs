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

        public List<RankingDTO> Rankings { get; set; }

        public List<ReservationGetDTO> Reservations { get; set; }

        public List<ShipDTO> OwnedShips { get; set; }
    }
}
