using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    [Table("videogame")]
    [Index(nameof(Name), IsUnique = false)]
    public class Videogame
    {
        [Key] 
        public int VideogameId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Overview { get; set; }
        [Column("release_date", TypeName = "Date")]
        public DateOnly ReleaseDate { get; set; }
        public int SoftwareHouseId { get; set; }

        public SoftwareHouse SoftwareHouse { get; set; }

        public Videogame(string name, string overview, DateOnly releaseDate, int softwareHouseId)
        {

            Name = name;
            Overview = overview;
            ReleaseDate = releaseDate;
            SoftwareHouseId = softwareHouseId;
        }

        public Videogame(int id, string name, string overview, DateOnly releaseDate, int softwareHouseId)
        {
            VideogameId = id;
            Name = name;
            Overview = overview;
            ReleaseDate = releaseDate;
            SoftwareHouseId = softwareHouseId;
        }
        public override string ToString()
        {
            return $"Nome: {Name}{Environment.NewLine}Descrizione: {Overview}{Environment.NewLine}Data di rilascio: {ReleaseDate}{Environment.NewLine}ID Software House: {SoftwareHouseId}";
        }

    }
}
