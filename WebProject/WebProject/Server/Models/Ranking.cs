using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Server.Models
{
    public class Ranking
    {
        public int Id { get; set; }

        public int Stars { get; set; }

        public DateTime Date { get; set; }

        public string Comment { get; set; }

        public ApplicationUser Person { get; set; }

        public Ship Ship { get; set; }
    }
}
