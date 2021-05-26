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
        //public static List<Artiest> BestandInlezen(string bestand)
        //{
        //    List<Playlist> lijst = new List<Playlist>();
        //    List<string> gegevens = null;
        //    Playlist p = null;
        //    try
        //    {
        //        using (StreamReader reader = new StreamReader(bestand))
        //        {


        //            while (!reader.EndOfStream)
        //            {
        //                gegevens = reader.ReadLine().Split(';').ToList();
        //                try
        //                {
        //                    switch (gegevens[0])
        //                    {
        //                        case "Artiest":
        //                            p = new Artiest(gegevens[1], int.Parse(gegevens[2]), gegevens[3]);
        //                            break;
        //                        case "Playlist":
        //                            p = new Playlist(gegevens[1], int.Parse(gegevens[2]), gegevens[3]);
        //                            break;
        //                        case "Nummer":
        //                            p = new Nummer(gegevens[1], int.Parse(gegevens[2]), gegevens[3]);
        //                            break;
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    //fouten opvangen van int.parse
        //                    FoutLoggen(ex);
        //                }
        //                lijst.Add(p);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //fouten opvangen van niet bestaand bestand
        //        FoutLoggen(ex);
        //    }

        //    return lijst;

        //}

        //public static void AddArtiest(string bestand, Playlist playlist)
        //{
        //    using (StreamWriter writer = new StreamWriter("Collecties.txt", true))
        //    {
        //        writer.Write(playlist.GetType().Name.ToString() + ";" + playlist.Naam);

        //        if (playlist is Nummer nummer)
        //        {
        //            writer.Write(nummer.Naam);
        //        }
        //        else if (playlist is Artiest artiest)
        //        {
        //            writer.Write(artiest.Naam);
        //        }
        //        writer.WriteLine();
        //    }


        //}

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
