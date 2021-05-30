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
        //Toevoegen
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
                return 0;
            }

        }

        //Verwijderen
        public static int VerwijderenNummer(Nummer nummer)
        {
            try
            {
                using (SprotifyEntities entities = new SprotifyEntities())
                {
                    entities.Entry(nummer).State = EntityState.Deleted;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }
        public static int VerwijderenArtiest(Artiest artiest)
        {
            try
            {
                using (SprotifyEntities entities = new SprotifyEntities())
                {
                    entities.Entry(artiest).State = EntityState.Deleted;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        //Aanpassen
        public static int AanpassenNummer(Nummer nummer)
        {
            using (SprotifyEntities entities = new SprotifyEntities())
            {
                entities.Entry(nummer).State = EntityState.Modified;
                return entities.SaveChanges();
            }
        }

        public static int AanpassenArtiest(Artiest artiest)
        {
            using (SprotifyEntities entities = new SprotifyEntities())
            {
                entities.Entry(artiest).State = EntityState.Modified;
                return entities.SaveChanges();
            }
        }

        //Ophalen

        //Artiest.xaml
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

        //Nummer.xaml
        public static List<ArtiestNummer> OphalenArtiestNummerViaContains(string letters)
        {
            using (SprotifyEntities entities = new SprotifyEntities())
            {
                var query = entities.ArtiestNummer
                    .Include(x => x.Artiest)
                    .Include(x=> x.Nummer)
                    .Where(x => x.Artiest.naam.Contains(letters) || x.Nummer.titel.Contains(letters)
                    && x.artiestId == x.Artiest.id && x.nummerId == x.Nummer.id)
                    .OrderBy(x => x.artiestId)
                    .ThenBy(x => x.nummerId);
                return query.ToList();
            }
        }
        //Nummer.xaml
        public static List<ArtiestNummer> OphalenArtiestNummer()
        {
            using (SprotifyEntities entities = new SprotifyEntities())
            {
                var query = entities.ArtiestNummer
                    .Include(x => x.Artiest)
                    .Include(x => x.Nummer)
                    .Where(x => x.artiestId == x.Artiest.id && x.nummerId == x.Nummer.id)
                    .OrderBy(x => x.Nummer.titel)
                    .ThenBy(x => x.Artiest.naam);
                return query.ToList();
            }
        }

    }
}
