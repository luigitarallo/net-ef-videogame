using System.Diagnostics.Metrics;

namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using VideogameContext db = new VideogameContext();

            // La condizione mi serve per evitare che crei righe duplicate ad ogni lancio del program
            if (!db.SoftwareHouse.Any())
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
                Console.WriteLine("6. Chiudere il programma");
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
                        
                        Console.Write("Qual'è l'ID della Software House?");

                        int softwareHouseId;

                        while(!int.TryParse(Console.ReadLine(), out softwareHouseId) || softwareHouseId < 1 || softwareHouseId > 6)
                        {
                            Console.WriteLine("Scelta non valida. Riprova");
                            Console.Write("Qual è l'ID della Software House? ");
                        }
                        Videogame videogame = new Videogame(name, overview, releaseDate, softwareHouseId);
                        if (VideogameManager.InsertVideogame(videogame))
                            Console.WriteLine("Videogame inserito con successo nel Database!");
                        break;
                    case 2:
                        Console.Write("Inserisci l'ID del videogioco da cercare: ");
                        if (!int.TryParse(Console.ReadLine(), out int id))
                        {
                            Console.WriteLine("ID deve essere un numero. Riprova.");
                            continue;
                        }
                        
                        break;
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        Console.WriteLine("Programma chiuso.");
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. Riprova");
                        break;
                }
            } while (scelta != 6);
        }


    
    }
}
