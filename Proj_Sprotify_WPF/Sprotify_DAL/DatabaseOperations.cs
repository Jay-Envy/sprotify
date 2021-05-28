using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Sprotify_DAL
{
    public static class DatabaseOperations
    {
        //Artiest en Playlist toevoegen
        public static int ToevoegenArtiest(Artiest artiest)
        {
            try
            {
                using (SprotifyEntities sprotifyEntities = new SprotifyEntities())
                {
                    sprotifyEntities.Artiest.Add(artiest);
                    return sprotifyEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }

        }

        public static int ToevoegenNummer(Nummer nummer)
        {
            try
            {
                using (SprotifyEntities sprotifyEntities = new SprotifyEntities())
                {
                    sprotifyEntities.Nummer.Add(nummer);
                    return sprotifyEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                throw;
            }

        }

        //Ophalen
        public static List<Artiest> OphalenArtiesten()
        {
            using (SprotifyEntities entities = new SprotifyEntities())
            {
                var query = entities.Artiest
                    .OrderBy(x => x.id)
                    .ThenBy(x => x.naam);
                return query.ToList();
            }
        }
        public static List<Nummer> OphalenNummers()
        {
            using (SprotifyEntities entities = new SprotifyEntities())
            {
                var query = entities.Nummer
                    .Include(x => x.ArtiestNummers.Select(sub => sub.Artiest))
                    .OrderBy(x => x.titel);
                return query.ToList();
            }
        }
        public static List<Artiest> OphalenArtiestViaZoek(int cijfer)
        {
            using (SprotifyEntities entities = new SprotifyEntities())
            {
                var query = entities.Artiest
                    .Where(x => x.naam.Contains(cijfer.ToString()))
                    .OrderBy(x => x.maandelijkseLuisteraars)
                    .ThenBy(x => x.id);
                return query.ToList();
            }
        }

        public static List<ArtiestNummer> OphalenArtiestNummer(string letters)
        {
            using (SprotifyEntities entities = new SprotifyEntities())
            {
                var query = entities.ArtiestNummer
                    .Include(x => x.Artiest)
                    .Include(x=> x.Nummer)
                    .Where(x => x.Artiest.naam.Contains(letters) || x.Nummer.titel.Contains(letters))
                    .OrderBy(x => x.artiestId)
                    .ThenBy(x => x.nummerId);
                return query.ToList();
            }
        }
        public static List<Nummer> OphalenNummerLengte(string letters)
        {
            using (SprotifyEntities entities = new SprotifyEntities())
            {
                var query = entities.Nummer
                    .Where(x => x.titel.Contains(letters))
                    .OrderBy(x => x.titel);
                return query.ToList();
            }
        }

        public static List<Nummer> ZoekViaNummer(string letters)
        {
            using (SprotifyEntities entities = new SprotifyEntities())
            {
                var query = entities.Nummer
                    .Include(x => x.ArtiestNummers.Select(sub => sub.Artiest))
                    .Where(x => x.titel.Contains(letters))
                    .OrderBy(x => x.titel);
                return query.ToList();
            }
        }
    }
}
