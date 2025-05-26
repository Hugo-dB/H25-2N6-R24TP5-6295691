//using BaladeurMultiFormats;
using BaladeurMultiFormats;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.Contracts;

namespace BaladeurMultiFormats_Tests
{
    
    [TestClass]
    public class Consultation_Tests
    {
        #region CONSTRUCTEURS

        /// <summary>
        /// Tester le constructeur 
        /// </summary>
        [TestMethod]
        public void ConstrConsultation()
        {
            // Instancier la classe Consultation avec un DateTime.Now et la chanson objChanson
            DateTime objDateTime = DateTime.Now;
            ChansonAAC objChanson = new ChansonAAC("Chansons", "Test", "Test", 2000);
            Consultation objConsultation = new Consultation(objDateTime, objChanson);
            // Vérifier la valeur des propriétés Date et LaChanson
            Assert.AreEqual(objDateTime, objConsultation.Date);
            Assert.AreEqual(objChanson, objConsultation.LaChanson);
        }

        /// <summary>
        /// Tester le constructeur avec un DateTime invalide
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstrAvcDateInvalide()
        {
            DateTime objDateTime = new DateTime();
            ChansonAAC objChanson = new ChansonAAC("Chansons", "Test", "Test", 2000);
        
            Consultation objConsultation = new Consultation(objDateTime, objChanson);            
        }

        #endregion

        #region PROPRIÉTÉS

        [TestMethod()]
        public void DélaiTest()
        {
            ChansonAAC objChanson = new ChansonAAC("Chansons", "Test", "Test", 2000);
            Consultation objConsultation = new Consultation(DateTime.Now, objChanson);

            Assert.AreEqual((int)((DateTime.Now - objConsultation.Date).TotalSeconds), objConsultation.Délai);
        }

        #endregion
    }

}
