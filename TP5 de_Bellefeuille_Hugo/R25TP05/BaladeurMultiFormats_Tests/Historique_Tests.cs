using BaladeurMultiFormats;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BaladeurMultiFormats_Tests
{
    [TestClass]
    public class Historique_Tests
    {
        #region CONSTRUCTEURS

        /// <summary>
        /// Tester le constructeur sans paramètre
        /// </summary>
        [TestMethod]
        public void ConstrSansParamTest()
        {
            Historique objHistorique = new Historique();

            Assert.IsNotNull(objHistorique);
        }

        /// <summary>
        /// Tester le constructeur avec paramètres
        /// </summary>
        [TestMethod]
        public void ConstrAvcParamTest()
        {
            DateTime objDateTime = DateTime.Now;
            ChansonAAC objChanson = new ChansonAAC("Chansons", "Test", "Test", 2000);
            Consultation objConsultation = new Consultation(objDateTime, objChanson);
            List<Consultation> objListe = new List<Consultation>();
            objListe.Add(objConsultation);

            Historique objHistorique = new Historique(objListe);

            Assert.AreEqual(objListe, objHistorique.ColConsultations);
        }

        /// <summary>
        /// Tester le constructeur avec paramètres avec une liste de consulations null
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstrParamAvcListeInvalideTest()
        {
            Historique objHistorique = new Historique(null);
        }
        #endregion

        #region MÉTHODES

        /// <summary>
        /// Tester la méthode Ajouter
        /// </summary>
        [TestMethod]
        public void AjouterTest()
        {
            DateTime objDateTime = DateTime.Now;
            ChansonAAC objChanson = new ChansonAAC("Chansons", "Test", "Test", 2000);
            Consultation objConsultation = new Consultation(objDateTime, objChanson);
            List<Consultation> objListe = new List<Consultation>();
            objListe.Add(objConsultation);
            Historique objHistorique = new Historique();

            objHistorique.Ajouter(objConsultation);

            Assert.AreEqual(objListe[0], objHistorique.ColConsultations[0]);
        }

        /// <summary>
        /// Tester la méthode Ajouter avec une consultation invalide 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AjouterAvecValeurInvalideTest()
        {
            Historique objHistorique = new Historique();

            objHistorique.Ajouter(null);
        }

        /// <summary>
        /// Tester la méthode Ajouter qui retourne une consultation
        /// </summary>
        [TestMethod]
        public void AjouterAvcRetourTest()
        {
            DateTime objDateTime = DateTime.Now;
            ChansonAAC objChanson = new ChansonAAC("Chansons", "Test", "Test", 2000);
            Consultation objConsultation = new Consultation(objDateTime, objChanson);
            Historique objHistorique = new Historique();
            List<Consultation> objListe = new List<Consultation>();
            objListe.Add(objConsultation);

            objHistorique.Ajouter(objChanson, objDateTime);

            Assert.AreEqual(objListe.Count, objHistorique.ColConsultations.Count);
        }

        #endregion
    }
}
