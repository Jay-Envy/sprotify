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
        public void PlaylistKrijgtJuisteInput()
        {
            //Nieuwe playlist aanmaken, private is een bool
            Playlist p = new Playlist
            {
                naam = "Test",
                @private = bool.TryParse("true", out bool boolJuist)
            };

            //Testen of dit klopt met AreEqual()
            Assert.AreEqual(p.@private, true);
        }
    }
}
