using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Shared
{
    class ShipImageDTO
    {
        public int Id { get; set; }

        public int ShipId { get; set; }

        public string RouteToPic { get; set; }

        public string ImageTitle { get; set; }

        public string ImageDescription { get; set; }
    }
}
