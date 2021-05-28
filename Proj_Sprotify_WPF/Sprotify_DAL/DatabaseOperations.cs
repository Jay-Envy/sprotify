using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprotify_DAL
{
    public static class DatabaseOperations
    {
        //public static List<Nummer> OphalenNummers()
        //{
        //    using (SprotifyEntities entities = new SprotifyEntities())
        //    {
        //        var query = entities.Nummer;
        //        return query.ToList();
        //    }
        //}
        public static int ToevoegenArtiest(Artiest artiest)
        {
            using (SprotifyEntities sprotifyEntities = new SprotifyEntities())
            {
                sprotifyEntities.Artiest.Add(artiest);
                return sprotifyEntities.SaveChanges();
            }
        }
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
                    .OrderBy(x => x.id)
                    .ThenBy(x => x.titel);
                return query.ToList();
            }
        }
        public static List<Playlist> OphalenPlaylists()
        {
            using (SprotifyEntities entities = new SprotifyEntities())
            {
                var query = entities.Playlist
                    .OrderBy(x => x.id)
                    .ThenBy(x => x.naam);
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
                    .Include("Nummer")
                    .Include("Artiest")
                    .Where(x => x.Artiest.naam.Contains(letters) || x.Nummer.titel.Contains(letters))
                    .OrderBy(x => x.artiestId)
                    .ThenBy(x => x.nummerId);
                return query.ToList();
            }
        }
    }
}
