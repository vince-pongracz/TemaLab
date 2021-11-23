using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebProject.Shared
{
    public class RankingDTO
    {
        public RankingDTO() { }

        public int Id { get; set; }

        public int Stars { get; set; }

        public DateTime Date { get; set; }

        public string Comment { get; set; }

        public string UserId { get; set; }
        [JsonIgnore]
        public virtual ApplicationUserDTO User { get; set; }

        public int ShipId { get; set; }
        [JsonIgnore]
        public virtual ShipDTO Ship { get; set; }
    }
}
