using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    internal static class VideogameManager
    {
        // CREATE
        public static bool InsertVideogame(Videogame videogame)
        {
            using VideogameContext db = new VideogameContext();
            try
            {
                db.Videogames.Add(videogame);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        // READ


    }
}
