using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Sprotify_DAL;

namespace Sprotify_UnitTests
{
    [TestClass]
    public class SprotifyTests
    {
        [TestMethod]
        public void ArtiestToevoegenKrijgtGeenBool()
        {
            //Nieuwe artiest aanmaken, verified is geen bool
            Artiest a = new Artiest
            {
                naam = "Test",
                maandelijkseLuisteraars = 1,
                verified = bool.TryParse("geen bool", out bool boolFout)
            };

            //Testen of dit klopt met IsTrue()
            Assert.IsTrue(a.verified != true || a.verified != false);
        }

        [TestMethod]
        public void MagRegioNullZijn()
        {
            //Nieuw nummer aanmaken, regio niet invullen
            Nummer n = new Nummer
            {
                titel = "",
                aantalKeerGespeeld = 0,
                like = true,
                lengte = 1,
                genre = "",
                platenMaatschappij = ""
            };

            //Testen of dit klopt met AreEqual()
            Assert.AreEqual(n.regio, null);
        }
    }
}
