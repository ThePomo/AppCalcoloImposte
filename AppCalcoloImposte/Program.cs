using System;
using System.Globalization;
using System.Text;


class Program
    
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("=== CALCOLO IMPOSTA SUL REDDITO ===");

        string nome;
        do
        {
            Console.Write("Inserisci il nome: ");
            nome = Console.ReadLine();
            if (string.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Il nome è obbligatorio. Riprova.");
            }
        } while (string.IsNullOrEmpty(nome));

        string cognome;
        do
        {
            Console.Write("Inserisci il cognome: ");
            cognome = Console.ReadLine();
            if (string.IsNullOrEmpty(cognome))
            {
                Console.WriteLine("Il cognome è obbligatorio. Riprova.");
            }
        } while (string.IsNullOrEmpty(cognome));


        Console.Write("Inserisci la data di nascita (Giorno/Mese/Anno): ");
        DateTime dataNascita;
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataNascita))
        {
            Console.Write("Formato non valido. Riprova (Giorno/Mese/Anno): ");
        }



        string codiceFiscale;
        do
        {
            Console.Write("Inserisci il codice fiscale: ");
            codiceFiscale = Console.ReadLine();

            if (string.IsNullOrEmpty(codiceFiscale))
            {
                Console.WriteLine("Il Codice Fiscale è obbligatorio. Riprova");
            }
        } while (string.IsNullOrEmpty(codiceFiscale));


        Console.Write("Inserisci il sesso (M/F): ");
        char sesso;
        while (!char.TryParse(Console.ReadLine().ToUpper(), out sesso) || (sesso != 'M' && sesso != 'F'))
        {
            Console.Write("Valore non valido. Inserisci M o F: ");
        }

        string comuneResidenza;
        do
        {
            Console.Write("Inserisci il comune di residenza: ");
            comuneResidenza = Console.ReadLine();

            if (string.IsNullOrEmpty(comuneResidenza))
            {
                Console.WriteLine("Il comune di residenza è obbligatorio. Riprova.");
            }
        } while (string.IsNullOrEmpty(comuneResidenza));

        Console.Write("Inserisci il reddito annuale: ");
        double redditoAnnuale;
        while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out redditoAnnuale) || redditoAnnuale < 0)
        {
            Console.Write("Valore non valido. Inserisci un numero positivo: ");
        }

        
        Contribuente contribuente = new Contribuente(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);

       
        contribuente.StampaRiepilogo();
    }
}