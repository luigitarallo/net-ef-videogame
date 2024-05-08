using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    [Table("softwarehouse")]
    [Index(nameof(Name), IsUnique = false)]

    public class SoftwareHouse
    {
        [Key] public int SoftwareHouseId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public List<Videogame> Videogames { get; set; }

    }
}
