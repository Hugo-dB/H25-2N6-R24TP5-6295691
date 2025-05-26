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

        /// <summary>
        /// Tester la méthode Ajouter qui retourne une consultation avec une chanson null
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AjouterAvcRetourAvcValeurInvalideTest()
        {
            Historique objHistorique = new Historique();

            objHistorique.Ajouter(null, DateTime.Now);
        }

        /// <summary>
        /// Tester la méthpde ConsultationAt qui retourne la consultation située à l'index donné
        /// </summary>
        [TestMethod]
        public void ConsultationAtTest()
        {
            DateTime objDateTime = DateTime.Now;
            ChansonAAC objChanson = new ChansonAAC("Chansons", "Test", "Test", 2000);
            Consultation objConsultation = new Consultation(objDateTime, objChanson);
            Historique objHistorique = new Historique();

            objHistorique.Ajouter(objConsultation);

            Assert.AreEqual(objConsultation, objHistorique.ConsultationAt(0));
        }

        /// <summary>
        /// Tester la méthode ConsultationAt avec un index situé hors des limites
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConsultationAtAvcValeurInvalideTest()
        {
            DateTime objDateTime = DateTime.Now;
            ChansonAAC objChanson = new ChansonAAC("Chansons", "Test", "Test", 2000);
            Consultation objConsultation = new Consultation(objDateTime, objChanson);
            Historique objHistorique = new Historique();

            objHistorique.Ajouter(objConsultation);

            objHistorique.ConsultationAt(1);
        }

        /// <summary>
        /// Tester la méthode Vider qui enlève toutes le consultations de l'historique
        /// </summary>
        [TestMethod]
        public void ViderTest()
        {
            DateTime objDateTime = DateTime.Now;
            ChansonAAC objChanson = new ChansonAAC("Chansons", "Test", "Test", 2000);
            Consultation objConsultation = new Consultation(objDateTime, objChanson);
            Historique objHistorique = new Historique();
            objHistorique.Ajouter(objConsultation);

            objHistorique.Vider();

            Assert.AreEqual(0, objHistorique.ColConsultations.Count);
        }

        /// <summary>
        /// Tester la méthode NbConsultationsPourUneChanson qui retourne le nombre de consultation pour la chanson donnée
        /// </summary>
        [TestMethod]
        public void NbConsultationsPourUneChansonTest()
        {
            DateTime objDateTime = DateTime.Now;
            ChansonAAC objChanson = new ChansonAAC("Chansons", "Test", "Test", 2000);
            Consultation objConsultation = new Consultation(objDateTime, objChanson);
            Historique objHistorique = new Historique();
            objHistorique.Ajouter(objConsultation);

            Assert.AreEqual(1, objHistorique.NbConsultationsPourUneChanson(objChanson));
        }

        /// <summary>
        /// Tester la méthode NbConsultationPourUneChanson avec une chanson qui est null
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NbConsultationsPourUneChansonAvcValeurInvalideTest()
        {
            DateTime objDateTime = DateTime.Now;
            ChansonAAC objChanson = new ChansonAAC("Chansons", "Test", "Test", 2000);
            Consultation objConsultation = new Consultation(objDateTime, objChanson);
            Historique objHistorique = new Historique();
            objHistorique.Ajouter(objConsultation);

            objHistorique.NbConsultationsPourUneChanson(null);
        }

        /// <summary>
        /// Tester la méthode HistoriqueEntreDeuxDates qui retourne une liste de consultations qui se sont passées entre les 2 dates données
        /// </summary>
        [TestMethod]
        public void HistoriqueEntreDeuxDatesTest()
        {
            DateTime objDateTime1 = new DateTime(2010, 04, 23);
            DateTime objDateTime2 = new DateTime(2011, 04, 23);
            DateTime objDateTime3 = new DateTime(2012, 04, 23);
            ChansonAAC objChanson = new ChansonAAC("Chansons", "Test", "Test", 2000);
            Consultation objConsultation1 = new Consultation(objDateTime1, objChanson);
            Consultation objConsultation2 = new Consultation(objDateTime2, objChanson);
            Consultation objConsultation3 = new Consultation(objDateTime3, objChanson);
            List<Consultation> objListe = new List<Consultation>();
            objListe.Add(objConsultation1);
            objListe.Add(objConsultation2);
            objListe.Add(objConsultation3);
            Historique objHistorique = new Historique(objListe);

            Assert.AreEqual(2, objHistorique.HistoriqueEntreDeuxDates(objDateTime2, objDateTime3).Count);
        }

        /// <summary>
        /// Tester la méthode NbConsultationsDepuisXSecondes qui retourne le nombre de consultations qui se sont passées depuis le nombre de secondes donné
        /// </summary>
        [TestMethod]
        public void NbConsultationsDepuisXSecondesTest()
        {
            DateTime objDateTime1 = new DateTime(2010, 04, 23);
            DateTime objDateTime2 = DateTime.Now;
            DateTime objDateTime3 = DateTime.Now;
            ChansonAAC objChanson = new ChansonAAC("Chansons", "Test", "Test", 2000);
            Consultation objConsultation1 = new Consultation(objDateTime1, objChanson);
            Consultation objConsultation2 = new Consultation(objDateTime2, objChanson);
            Consultation objConsultation3 = new Consultation(objDateTime3, objChanson);
            List<Consultation> objListe = new List<Consultation>();
            objListe.Add(objConsultation1);
            objListe.Add(objConsultation2);
            objListe.Add(objConsultation3);
            Historique objHistorique = new Historique(objListe);

            Assert.AreEqual(2, objHistorique.NbConsultationsDepuisXSecondes(10));
        }

        /// <summary>
        /// Tester la méthode NbConsultationsDepuisXSecondes avec un nombre de secondes négatif
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void NbConsultationsDepuisXSecondesAvcValeurInvalideTest()
        {
            Historique objHistorique = new Historique();

            objHistorique.NbConsultationsDepuisXSecondes(-10);
        }
        #endregion
    }
}
