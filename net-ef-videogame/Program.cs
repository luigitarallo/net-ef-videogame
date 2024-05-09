using System.Diagnostics.Metrics;

namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using VideogameContext db = new VideogameContext();

            // La condizione mi serve per evitare che crei righe duplicate ad ogni lancio del program
            if (!db.SoftwareHouses.Any())
            {
                List<SoftwareHouse> softwareHouses = new List<SoftwareHouse>
                {
                    new SoftwareHouse("Nintendo", "Kyoto", "Japan"),
                    new SoftwareHouse("Rockstar Games", "New York City", "United States"),
                    new SoftwareHouse("Valve Corporation", "Bellevue", "United States"),
                    new SoftwareHouse("Electronic Arts", "Redwood City", "United States"),
                    new SoftwareHouse("Ubisoft", "Montreuil", "France"),
                    new SoftwareHouse("Konami", "Kyoto", "Japan")
                };
                foreach (var softwareHouse in softwareHouses)
                {
                    db.Add(softwareHouse);
                }
                db.SaveChanges();
            }
            int scelta;
            do
            {
                Console.WriteLine("Seleziona un'opzione");
                Console.WriteLine("1. Inserire un nuovo videogioco");
                Console.WriteLine("2. Ricercare un videogioco per ID");
                Console.WriteLine("3. Ricercare tutti i videogiochi aventi il nome contenente una determinata stringa");
                Console.WriteLine("4. Cancellare un videogioco");
                Console.WriteLine("5. Inserire una nuova Software House");
                Console.WriteLine("6. Mostra tutti i videogame prodotti da una Software House tramite ID");
                Console.WriteLine("7. Chiudere il programma");
                Console.Write("Seleziona un numero per scegliere cosa fare: ");

                if (!int.TryParse(Console.ReadLine(), out scelta))
                {
                    Console.WriteLine("Scelta non valida. Riprova");
                    continue;
                }

                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("Inserimento di un nuovo videogioco");

                        string name = "";
                        while (string.IsNullOrWhiteSpace(name))
                        {
                            Console.Write("Nome del videogioco: ");
                            name = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(name))
                            {
                                Console.WriteLine("Il nome inserito non è valido. Inserisci un nome valido.");
                            }
                        }
                       
                        string overview = "";
                        while (string.IsNullOrWhiteSpace(overview))
                        {
                            Console.WriteLine("Descrizione: ");
                            overview = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(overview))
                            {
                                Console.WriteLine("La descrizione del gioco non è valida. Inserisci una descrizione valida.");
                            }
                        }

                        DateOnly releaseDate;
                        Console.WriteLine("Data di rilascio (formato aaaa-mm-gg): ");
                        while (!DateOnly.TryParse(Console.ReadLine(), out releaseDate))
                        {
                            Console.WriteLine("Formato data non valido. Riprova.");
                            Console.WriteLine("Data di rilascio (formato aaaa-mm-gg): ");
                        }

                        Console.WriteLine("Seleziona la Software House:");
                        List<SoftwareHouse> softwareHouses = SoftwareHouseManager.GetAllSoftwareHouses();
                        foreach (var sh in softwareHouses)
                        {
                            Console.WriteLine($"{sh.SoftwareHouseId}. {sh.Name}");
                        }
                        int softwareHouseId;
                        while (true)
                        {
                            Console.Write("Inserisci l'ID della Software House: ");
                            if (!int.TryParse(Console.ReadLine(), out softwareHouseId) || !softwareHouses.Any(sh => sh.SoftwareHouseId == softwareHouseId))
                            {
                                Console.WriteLine("ID della Software House non valido. Riprova.");
                            }
                            else
                            {
                                break;
                            }
                        }

                        Videogame videogame = new Videogame(name, overview, releaseDate, softwareHouseId);
                        if (VideogameManager.InsertVideogame(videogame))
                        {
                            Console.WriteLine("Videogame inserito con successo nel Database!");
                        }
                        else
                        {
                            Console.WriteLine("Si è verificato un errore durante l'inserimento del videogame.");
                        }
                        break;                     
                    case 2:
                        Console.Write("Inserisci l'ID del videogioco da cercare: ");
                        if (!int.TryParse(Console.ReadLine(), out int id))
                        {
                            Console.WriteLine("ID deve essere un numero. Riprova.");
                            continue;
                        }
                        Videogame videogameSearched = VideogameManager.GetVideogameById(id);
                        if (videogameSearched != null)
                        {
                            Console.WriteLine(videogameSearched.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Nessun videogame trovato");
                        }
                        break;
                    case 3:
                        Console.Write("Inserisci il nome del videogame da cercare: ");
                        string searchString = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(searchString))
                        {
                            List<Videogame> foundGames = VideogameManager.GetVideogameByString(searchString);
                            if (foundGames.Count > 0)
                            {
                                Console.WriteLine("Videogiochi trovati:");
                                foreach (Videogame game in foundGames)
                                {
                                    Console.WriteLine($"Nome: {game.Name}, Descrizione: {game.Overview}\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nessun videogame trovato con il nome specificato.\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Il nome inserito non è valido.");
                        }
                        break;
                    case 4:
                        Console.Write("Inserisci l'ID del videogioco da cancellare: ");
                        if (!int.TryParse(Console.ReadLine(), out int idToDelete))
                        {
                            Console.WriteLine("ID non valido. Riprova.");
                            break;
                        }
                        bool isDeleted = VideogameManager.DeleteVideogameById(idToDelete);
                        if (isDeleted)
                        {
                            Console.WriteLine("Videogioco eliminato con successo.");
                        }
                        else
                        {
                            Console.WriteLine("Impossibile trovare il videogioco specificato.");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Inserimento di una nuova Software House");
                        string nameSoftwareHouse = "";
                        while (string.IsNullOrWhiteSpace(nameSoftwareHouse))
                        {
                            Console.Write("Nome della Software House: ");
                            nameSoftwareHouse = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(nameSoftwareHouse))
                            {
                                Console.WriteLine("Il nome inserito non è valido. Inserisci un nome valido.");
                            }
                        }

                        string city = "";
                        while (string.IsNullOrWhiteSpace(city))
                        {
                            Console.WriteLine("Inserisci la città della Software House: ");
                            city = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(city))
                            {
                                Console.WriteLine("La città della Software House non è valida. Inserisci una Software House valida.");
                            }
                        }
                        string country = "";
                        while (string.IsNullOrWhiteSpace(country))
                        {
                            Console.WriteLine("Inserisci il paese della Software House: ");
                            country = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(country))
                            {
                                Console.WriteLine("Il paese della Software House non è valido. Inserisci un paese valido.");
                            }
                        }
                        SoftwareHouse softwareHouse = new SoftwareHouse(nameSoftwareHouse, city, country);
                        if (SoftwareHouseManager.InsertSoftwareHouse(softwareHouse))
                        {
                            Console.WriteLine("SoftwareHouse inserita con successo nel Database!");
                        }
                        else
                        {
                            Console.WriteLine("Si è verificato un errore durante l'inserimento della SoftwareHouse.");
                        }
                        break;
                    case 6:
                        Console.WriteLine("Inserisci l'ID della Software House di cui vuoi visualizzare i videogame: ");
                        softwareHouses = SoftwareHouseManager.GetAllSoftwareHouses();
                        foreach (SoftwareHouse sofwareHouse in softwareHouses)
                        {
                            Console.WriteLine($"{sofwareHouse.SoftwareHouseId}. {sofwareHouse.Name}");
                        }
                        if (!int.TryParse(Console.ReadLine(), out int softwareHouseIdToSearch))
                        {
                            Console.WriteLine("ID non valido. Riprova.");
                            break;
                        }
                        List<Videogame> videogames = VideogameManager.GetVideogamesBySoftwareHouseId(softwareHouseIdToSearch);
                        if (videogames.Count > 0)
                        {
                            Console.WriteLine($"Videogiochi prodotti dalla Software House con ID '{softwareHouseIdToSearch}':");
                            foreach (Videogame game in videogames)
                            {
                                Console.WriteLine(game.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Nessun videogame trovato per la Software House con ID '{softwareHouseIdToSearch}'.");
                        }
                        break;
                    case 7:
                        Console.WriteLine("Programma chiuso.");
                        break;
                        
                    default:
                        Console.WriteLine("Scelta non valida. Riprova");
                        break;
                }
            } while (scelta != 7);
        }


    
    }
}
