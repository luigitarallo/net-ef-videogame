using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    internal static class SoftwareHouseManager
    {
        // CREATE
        public static bool InsertSoftwareHouse(SoftwareHouse sofwareHouse)
        {
            using VideogameContext db = new VideogameContext();
            try
            {
                db.SoftwareHouses.Add(sofwareHouse);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        // READ
        public static List<SoftwareHouse> GetAllSoftwareHouses()
        {
            using (VideogameContext db = new VideogameContext())
            {
                try
                {
                    return db.SoftwareHouses.ToList();
                }
                catch (Exception)
                {
                    return new List<SoftwareHouse>();
                }
            }
        }
    }
}
