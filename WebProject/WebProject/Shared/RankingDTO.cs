using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Shared
{
    public class RankingDTO
    {
        public int Id { get; set; }

        public int Stars { get; set; }

        public DateTime Date { get; set; }

        public string Comment { get; set; }

        public ApplicationUserDTO Person { get; set; }

        public ShipDTO Ship { get; set; }
    }
}
