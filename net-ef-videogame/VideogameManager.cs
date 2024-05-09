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
        public static Videogame? GetVideogameById(int id)
        {
            using VideogameContext db = new VideogameContext();
            try
            {
                Videogame? videoGameSearched = db.Videogames.Where(videogame=> videogame.VideogameId == id).FirstOrDefault();
                if (videoGameSearched == null)
                {
                    return null;
                }
                return videoGameSearched;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Si è verificato un errore durante la ricerca del videogioco: {ex.Message}");
                return null;
            }
        }

        public static List<Videogame> GetVideogameByString(string searchString)
        {
            using VideogameContext db = new VideogameContext();
            try
            {
                List<Videogame> videogames = db.Videogames.Where(videogame => videogame.Name.Contains(searchString)).ToList();
                return videogames;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Si è verificato un errore durante la ricerca dei videogiochi: {ex.Message}");
                return new List<Videogame>();
            }
        }

        // DELETE 
        public static bool DeleteVideogameById(int id)
        {
            using (VideogameContext db = new VideogameContext())
            {
                try
                {
                    Videogame videogameToDelete = db.Videogames.FirstOrDefault(v => v.VideogameId == id);

                    if (videogameToDelete != null)
                    {
                        db.Videogames.Remove(videogameToDelete);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        // READ VIDEOGAMES LIST BY SOFTWARE HOUSE ID
        public static List<Videogame> GetVideogamesBySoftwareHouseId(int softwareHouseId)
        {
            using (VideogameContext db = new VideogameContext())
            {
                try
                {
                    return db.Videogames.Where(vg => vg.SoftwareHouseId == softwareHouseId).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Si è verificato un errore durante il recupero dei videogiochi della Software House: {ex.Message}");
                    return new List<Videogame>();
                }
            }
        }
    }
}
