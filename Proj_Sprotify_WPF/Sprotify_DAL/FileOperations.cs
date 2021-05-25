using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprotify_Models;
using System.IO;

namespace Sprotify_DAL
{
    public class FileOperations
    {
        public static List<Artiest> BestandInlezen(string bestand)
        {
            List<Artiest> lijst = new List<Artiest>();
            List<string> gegevens = null;
            Artiest a = null;
            try
            {
                using (StreamReader reader = new StreamReader(bestand))
                {


                    while (!reader.EndOfStream)
                    {
                        gegevens = reader.ReadLine().Split(';').ToList();
                        try
                        {
                            switch (gegevens[0])
                            {
                                case "Artiest":
                                    a = new Artiest(gegevens[1], gegevens[2]);
                                    break;
                                case "Playlist":
                                    a = new Playlist(gegevens[1]);
                                    break;
                                case "Nummer":
                                    a = new Nummer(gegevens[1], int.Parse(gegevens[2]), (gegevens[3]);
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            //fouten opvangen van double.parse
                            FoutLoggen(ex);
                        }
                        lijst.Add(a);
                    }
                }
            }
            catch (Exception ex)
            {
                //fouten opvangen van niet bestaand bestand
                FoutLoggen(ex);
            }

            return lijst;

        }

        public static void AddArtiest(string bestand, Artiest artiest)
        {
            using (StreamWriter writer = new StreamWriter("Artiesten.txt", true))
            {
                writer.Write(artiest.GetType().Name.ToString() + ";" + artiest.Naam + ";" + product.Beschrijving + ";" + product.Prijs + ";");

                if (artiest is Playlist playlist)
                {
                    writer.Write(playlist.Naam);
                }
                else if (artiest is Nummer nummer)
                {
                    writer.Write(nummer.Naam);
                }
                writer.WriteLine();
            }


        }
        public static void AddPlaylist(string bestand, Nummer nummer)
        {
            using (StreamWriter writer = new StreamWriter("Artiesten.txt", true))
            {
                writer.Write(artiest.GetType().Name.ToString() + ";" + artiest.Naam + ";" + product.Beschrijving + ";" + product.Prijs + ";");

                if (artiest is Playlist playlist)
                {
                    writer.Write(playlist.Naam);
                }
                else if (artiest is Nummer nummer)
                {
                    writer.Write(nummer.Naam);
                }
                writer.WriteLine();
            }


        }

        public static void FoutLoggen(Exception fout)
        {
            using (StreamWriter writer = new StreamWriter("foutenbestand.txt", true))
            {

                writer.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
                writer.WriteLine(fout.GetType().Name);
                writer.WriteLine(fout.Message);
                writer.WriteLine(fout.StackTrace);
                writer.WriteLine(new String('-', 80));
                writer.WriteLine();
            }
        }
    }
}
